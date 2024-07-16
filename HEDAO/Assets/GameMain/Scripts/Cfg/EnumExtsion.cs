using System;
using System.Linq;

namespace Cfg
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumNameAttribute : Attribute
    {
        public string Name { get; }

        public EnumNameAttribute(string name)
        {
            Name = name;
        }
    }
    
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);
            var attr = field.GetCustomAttributes(typeof(EnumNameAttribute), false).FirstOrDefault() as EnumNameAttribute;
            return attr?.Name;
        }
    }
}