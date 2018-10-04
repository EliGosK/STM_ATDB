using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CSI.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetAssemblyVersion(this HtmlHelper helper, Type applicationType, string format = "{0}")
        {
            var version = applicationType.Assembly.GetName().Version;
            TagBuilder builder = new TagBuilder("span");
            builder.InnerHtml = String.Format(format, version);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString GetFileLastWriteTime(this HtmlHelper helper, string file, string format = "{0:yyyy.MM.dd.HHmmss}", string culture = "th-TH")
        {
            TagBuilder builder = new TagBuilder("span");
            if (File.Exists(file))
            {
                builder.InnerHtml = String.Format(CultureInfo.CreateSpecificCulture(culture), format, File.GetLastWriteTime(file));
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));

        }

        public static MvcHtmlString LabelRequiredHintFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string hintText = "*")
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var labelText = metadata.DisplayName ?? metadata.PropertyName;
            if (!String.IsNullOrEmpty(labelText))
            {
                labelText = String.Concat(labelText, " ", hintText);
            }
            return helper.LabelFor<TModel, TProperty>(expression, labelText);
        }

        public static MvcHtmlString LabelRequiredHintFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, string hintText = "*")
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var labelText = metadata.DisplayName ?? metadata.PropertyName;
            if (metadata.IsRequired)
            {
                labelText = String.Concat(labelText, " ", hintText);
            }
            return helper.LabelFor<TModel, TProperty>(expression, labelText, htmlAttributes);
        }
    }
}
