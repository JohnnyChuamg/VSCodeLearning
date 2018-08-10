using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace IoT.Domain.Helpers
{
    public static class EnumHelper<TModel> where TModel : class
    {
        public static IList<TModel> GetValues(Enum value)
        {
            var enumValues = new List<TModel>();
            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((TModel)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }
        public static TModel Parse(string value)
        {
            return (TModel)Enum.Parse(typeof(TModel), value, true);
        }
        public static IList<string> GetNames(Enum value)
        {
            return value.GetType()
                        .GetFields(BindingFlags.Static | BindingFlags.Public)
                        .Select(s => s.Name)
                        .ToList();
        }
        private static string LookupResourse(Type resourceManagerProvider, string resourceKey)
        {
            foreach (var staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (staticProperty.PropertyType == typeof(ResourceManager))
                {
                    ResourceManager resourceManager = (ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }
            return resourceKey; // Fallback with the key name
        }
        public static string GetDisplayValue(TModel value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;

            var firstDescription = descriptionAttributes?.FirstOrDefault();
            if (firstDescription?.ResourceType != null)
                return LookupResourse(firstDescription.ResourceType, firstDescription.Name);

            return descriptionAttributes.Length > 0 ? firstDescription.Name : value.ToString();
        }
        public static IList<string> GetDisplayValue(Enum value)
        {
            return GetNames(value).Select(s => GetDisplayValue(Parse(s))).ToList();
        }
    }
}