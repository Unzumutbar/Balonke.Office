using System;
using System.ComponentModel;
using System.Linq;

namespace Unzumutbar.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum EnumValue) where TEnum : struct
        {
            var type = typeof(TEnum);
            var name = Enum.GetNames(type).Where(f => f.Equals(EnumValue.ToString())).Select(d => d).FirstOrDefault();
            if (name == null)
            {
                return string.Empty;
            }
            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }
    }
}