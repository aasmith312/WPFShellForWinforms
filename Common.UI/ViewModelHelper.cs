using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.UI
{
    public static class ViewModelHelper
    {
        static Dictionary<String, Dictionary<String, PropertyInfo>> ObjectToPropertiesCache = new Dictionary<string, Dictionary<string, PropertyInfo>>();
        static Boolean ThrowException = (Boolean.TryParse(ConfigurationManager.AppSettings["ThrowExceptionOnMissingProperty"], out ThrowException)) ? ThrowException : false;

        /// <summary>
        /// Takes an object and inspects it looking for the property name.
        /// To be used with INotifyPropertyChanged objects.
        /// </summary>
        /// <param name="objToValidate"></param>
        /// <param name="stringToValidate"></param>
        /// <returns></returns>
        public static Boolean PropertyExists(INotifyPropertyChanged objToValidate, String stringToValidate)
        {
            Boolean retVal = false;
            ValidateArgs(objToValidate, stringToValidate);

            if(objToValidate != null && !String.IsNullOrEmpty(stringToValidate))
            { 
                Dictionary<String, PropertyInfo> tmp = null;

                if (!ObjectToPropertiesCache.ContainsKey(objToValidate.GetType().Name))
                {
                    PropertyInfo[] props = objToValidate.GetType().GetProperties();
                    tmp = PlaceObjIntoCache(objToValidate, props);
                }
                else
                {
                    tmp = ObjectToPropertiesCache[objToValidate.GetType().Name];
                }

                retVal = ObjectToPropertiesCache[objToValidate.GetType().Name].ContainsKey(stringToValidate);
            }

            if (!retVal && ThrowException)
                throw new ArgumentException(String.Format("Unable to find property {0} in object type {1}", stringToValidate, objToValidate.GetType().Name));

            return retVal;
        }


        /// <summary>
        /// Takes an object, checks if it needs to be in the cache.
        /// </summary>
        /// <param name="objToValidate"></param>
        /// <param name="props"></param>
        private static Dictionary<String, PropertyInfo> PlaceObjIntoCache(INotifyPropertyChanged objToValidate, PropertyInfo[] props)
        {
            String objName = objToValidate.GetType().Name;

            if (!ObjectToPropertiesCache.ContainsKey(objName))
            {
                lock (ObjectToPropertiesCache)
                {
                    if (!ObjectToPropertiesCache.ContainsKey(objName))
                    {
                        ObjectToPropertiesCache.Add(objToValidate.GetType().Name, new Dictionary<string, PropertyInfo>());

                        foreach (var pi in props)
                        {
                            ObjectToPropertiesCache[objName].Add(pi.Name, pi);
                        }
                    }
                }
            }
            return ObjectToPropertiesCache[objName];
        }

        private static void ValidateArgs(object objToValidate, string stringToValidate)
        {
            if (objToValidate == null)
                throw new ArgumentException("Null value passed through.", "objToValidate");

            if(String.IsNullOrEmpty(stringToValidate))
                throw new ArgumentException("Null or empty value passed through.", "stringToValidate");
        }

    }
}
