using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Core
{
    public sealed class CommonUtils
    {
        public static DataTable ConvertDoListToDataTable<T>(List<T> objDoList)
        {

            DataTable dtOut = new DataTable();

            if (objDoList != null && objDoList.Count >= 0)
            {
                T objSource = System.Activator.CreateInstance<T>();
                if (objDoList.Count > 0 && objDoList[0] != null)
                {
                    objSource = objDoList[0];
                }
                //Generate DataTable Column
                PropertyInfo[] pSourceInfo = objSource.GetType().GetProperties().Where(d => !d.PropertyType.FullName.Contains("System.Data")).ToArray();
                foreach (PropertyInfo pInfo in pSourceInfo)
                {
                    string strPropertyType = string.Empty;
                    if (pInfo.PropertyType.FullName == objSource.GetType().ToString())
                    {
                        continue;
                    }

                    if (pInfo.PropertyType.IsGenericType && pInfo.PropertyType.Name.Contains("Nullable"))
                    {
                        Type tNullableType = Type.GetType(pInfo.PropertyType.FullName);
                        strPropertyType = tNullableType.GetGenericArguments()[0].FullName;
                    }
                    else if (!pInfo.PropertyType.IsGenericType)
                    {
                        strPropertyType = pInfo.PropertyType.FullName;
                    }
                    else
                    {
                        continue;
                    }
                    DataColumn col = new DataColumn(pInfo.Name, Type.GetType(strPropertyType));
                    dtOut.Columns.Add(col);
                }

                // Transfer Data from Do list to DataTable
                foreach (T obj in objDoList)
                {
                    if (obj != null)
                    {
                        DataRow row = dtOut.NewRow();
                        for (int idx = 0; idx < dtOut.Columns.Count; idx++)
                        {
                            PropertyInfo pDestInfo = obj.GetType().GetProperty(dtOut.Columns[idx].ColumnName);
                            Object objVal = pDestInfo.GetValue(obj, null);
                            row[dtOut.Columns[idx].ColumnName] = objVal == null ? DBNull.Value : objVal;
                        }
                        dtOut.Rows.Add(row);
                        dtOut.AcceptChanges();
                    }
                }
            }
            return dtOut;
        }

        public static string ConvertToJSON<T>(T entity)
        {
            if (entity != null)
                return JsonConvert.SerializeObject(entity);
            else
                return null;
        }

        public static T JSONToObject<T>(string jsonData)
        {
            if (jsonData != null)
                return JsonConvert.DeserializeObject<T>(jsonData);
            else
                return default(T);
        }

        public static string Decrypt(string text)
        {
            return Security.Encode.Decrypt(text);
        }

        public static string Encrypt(string text)
        {
            return Security.Encode.Encrypt(text);
        }

        public static T2 CopyObjectByPropertyName<T1, T2>(T1 source, T2 destination)
        {
            if (source == null)
            {
                return destination;
            }
            PropertyInfo[] pDestinationInfo = destination.GetType().GetProperties();
            foreach (PropertyInfo pInfo in pDestinationInfo)
            {
                PropertyInfo pSourceInfo = source.GetType().GetProperty(pInfo.Name);
                if (pSourceInfo != null)
                {
                    string destType = string.Empty;
                    string scrType = string.Empty;

                    if (pSourceInfo.PropertyType.IsGenericType)
                    {
                        scrType = Type.GetType(pSourceInfo.PropertyType.FullName).GetGenericArguments()[0].FullName;
                    }
                    else
                    {
                        scrType = pSourceInfo.PropertyType.FullName;
                    }

                    if (pInfo.PropertyType.IsGenericType)
                    {
                        destType = Type.GetType(pInfo.PropertyType.FullName).GetGenericArguments()[0].FullName;
                    }
                    else
                    {
                        destType = pInfo.PropertyType.FullName;
                    }

                    if (destType == scrType)
                    {
                        Object objVal = pSourceInfo.GetValue(source, null);
                        pInfo.SetValue(destination, objVal, null);
                    }
                }
            }

            return destination;
        }

        public static object GetObjectValue<T>(T objSource, string fieldName)
        {
            PropertyInfo pSourceInfo = objSource.GetType().GetProperties().Where(d => d.Name == fieldName).FirstOrDefault();
            if (pSourceInfo != null)
            {
                Object objVal = pSourceInfo.GetValue(objSource, null);
                string strPropertyType = string.Empty;
                if (pSourceInfo.PropertyType.IsGenericType && pSourceInfo.PropertyType.Name.Contains("Nullable"))
                {
                    Type tNullableType = Type.GetType(pSourceInfo.PropertyType.FullName);
                    strPropertyType = tNullableType.GetGenericArguments()[0].FullName;
                }
                else if (!pSourceInfo.PropertyType.IsGenericType)
                {
                    strPropertyType = pSourceInfo.PropertyType.FullName;
                }

                if (objVal == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ChangeType(objVal, Type.GetType(strPropertyType));
                }
            }

            return null;
        }

        public static void SetObjectValue<T>(T objSource, string fieldName, object value)
        {
            PropertyInfo pSourceInfo = objSource.GetType().GetProperties().Where(d => d.Name == fieldName).FirstOrDefault();
            if (pSourceInfo != null)
            {
                string strPropertyType = string.Empty;
                if (pSourceInfo.PropertyType.IsGenericType && pSourceInfo.PropertyType.Name.Contains("Nullable"))
                {
                    Type tNullableType = Type.GetType(pSourceInfo.PropertyType.FullName);
                    strPropertyType = tNullableType.GetGenericArguments()[0].FullName;
                }
                else if (!pSourceInfo.PropertyType.IsGenericType)
                {
                    strPropertyType = pSourceInfo.PropertyType.FullName;
                }

                if (value == null)
                {
                    pSourceInfo.SetValue(objSource, value, null);
                }
                else
                {
                    pSourceInfo.SetValue(objSource, Convert.ChangeType(value, Type.GetType(strPropertyType)), null);
                }
            }
        }

        public static T GetXlsxCellValue<T>(ExcelRange cell)
        {
            T returnType = default(T);
            if(typeof(T) != typeof(String))
            {
                returnType = Activator.CreateInstance<T>();
            }

            if(cell == null)
            {
                return returnType;
            }

            Object objValue = null;
            try
            {
                objValue = cell.Value;
            }
            catch
            {
                objValue = null;
            }

            if(objValue == null)
            {
                return returnType;
            }
            else
            {
                if (typeof(T).IsGenericType && typeof(T).FullName.Contains("Nullable"))
                {
                    if(typeof(T) == typeof(Decimal?))
                    {
                        if(objValue == null)
                        {
                            return returnType;
                        }
                        else
                        {
                            objValue = Convert.ToDecimal(objValue);
                        }
                    }
                    else if (typeof(T) == typeof(Int32?))
                    {
                        if (objValue == null)
                        {
                            return returnType;
                        }
                        else
                        {
                            objValue = Convert.ToInt32(objValue);
                        }
                    }
                    else if (typeof(T) == typeof(DateTime?))
                    {
                        if (objValue == null)
                        {
                            return returnType;
                        }
                        else
                        {
                            objValue = Convert.ToDateTime(objValue);
                        }
                    }
                }
                else
                {
                    if (typeof(T) == typeof(String) && objValue != null)
                    {
                        objValue = objValue.ToString();
                    }
                    else if (typeof(T) == typeof(Decimal))
                    {
                        objValue = Convert.ToDecimal(objValue);
                    }
                    else if (typeof(T) == typeof(Int32))
                    {
                        objValue =Convert.ToInt32(objValue);
                    }
                    else if (typeof(T) == typeof(DateTime))
                    {
                        objValue = Convert.ToDateTime(objValue);
                    }


                }

                return (T)objValue;
            }
        }


        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
