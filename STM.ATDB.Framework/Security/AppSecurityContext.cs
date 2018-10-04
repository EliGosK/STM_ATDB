
using STM.ATDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace STM.ATDB.Framework.Security
{
    public class AppSecurityContext
    {
        private const string rolesKey = "AppSecurityContext_Roles";
        private const string userRolesKey = "AppSecurityContext_UserRoles";
        private const string permissionsKey = "AppSecurityContext_Permissions_{0}";
        private static ObjectCache cache = MemoryCache.Default;

        public IList<PermissionRecord> Permissions(string UserID)
        {
            var data = cache[string.Format(permissionsKey, UserID)] as List<PermissionRecord>;
            return data ?? new List<PermissionRecord>();
            
        }


        public bool IsUserAuthorize(string user, string objectId, string permissioncode)
        {
            if (objectId == "HOME")
            {
                return true;
            }
            else
            {
                return this.Permissions(user).Where(t => String.Compare(t.ObjectId, objectId, true) == 0 && String.Compare(t.PermissionCode, permissioncode, true) == 0).Any();
            }
        }


        public void LoadPermission(string UserID, IEnumerable<PermissionRecord> permissions)
        {

            RemoveDataFromCached(string.Format(permissionsKey, UserID));
            AddDataToCache(string.Format(permissionsKey, UserID), permissions);
        }

        private void AddDataToCache(string key, object value)
        {
            var policy = new CacheItemPolicy()
            {
                AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
            };
            cache.Add(key, value, policy);

        }

        public void RemoveDataFromCached(String key)
        {
            if (cache.Contains(key))
            {
                cache.Remove(key);
            }
        }

        public bool IsExpired(string UserID)
        {
            return cache[string.Format(permissionsKey, UserID)] == null;
            
        }

        public void Clear(string UserID)
        {
            var keys = new string[] { string.Format(permissionsKey, UserID) };
            foreach (var key in keys)
            {
                RemoveDataFromCached(key);
            }
        }




    }
}
