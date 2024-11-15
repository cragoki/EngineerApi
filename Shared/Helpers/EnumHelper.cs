using Shared.Models;
using System.ComponentModel;
using System.Reflection;

namespace Shared.Helpers
{
    public static class EnumHelper
    {

        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }

        public static List<string> GetEnumDescriptions<T>() where T : Enum
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(field => field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? field.Name)
                .ToList();
        }

        public static List<KeyValueModel> GetEnumKeyValues<T>() where T : Enum
        {
            var keyValueList = new List<KeyValueModel>();
            var descriptions = GetEnumDescriptions<T>(); 
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            // loop through the enum values and descriptions 
            for (int i = 0; i < enumValues.Count; i++)
            {
                var intValue = Convert.ToInt32(enumValues[i]); //get int value
                var description = descriptions[i]; // get description

                keyValueList.Add(new KeyValueModel
                {
                    Id = intValue,
                    Value = description
                });
            }

            return keyValueList;
        }
    }
}
