using FluentValidation;
using STM.ATDB.Framework.DataAnnotation;
using STM.ATDB.Framework.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Framework.Validators
{
    public abstract class SECValidator<T> : AbstractValidator<T> where T : class
    {
        protected SECValidator()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }

        /// <summary>
        /// Sets length validation rule(s) to string properties according to appropriate database model
        /// </summary>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="dbContext">Database context</param>
        /// <param name="filterPropertyNames">Properties to skip</param>
        protected virtual void SetStringPropertiesMaxLength<TObject>(params string[] filterPropertyNames)
        {
            var objectType = typeof(TObject);

            var names = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string) && !filterPropertyNames.Contains(p.Name))
                .Select(p => p.Name).ToArray();

            var maxLength = objectType.GetColumnsStringLength(names);
            var expression = maxLength.Keys.ToDictionary(name => name, name => DynamicExpression.ParseLambda<T, string>(name, null));

            foreach (var expr in expression)
            {
                RuleFor(expr.Value).Length(maxLength[expr.Key].MinimumLength, maxLength[expr.Key].MaximumLength);
            }
        }
    }
}
