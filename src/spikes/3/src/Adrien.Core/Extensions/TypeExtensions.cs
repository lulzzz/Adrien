using System;
using System.Linq;
using System.Reflection;

namespace Adrien.Core.Extensions
{
    public static class TypeExtensions
    {
        private const BindingFlags All = BindingFlags.Instance | 
                                         BindingFlags.Static | 
                                         BindingFlags.Public |
                                         BindingFlags.NonPublic;
        /// <summary>
        /// Lookup a method 'Foo{T}' (generic) or 'FooT' (type suffix in the name). 
        /// </summary>
        public static MethodInfo FindMethod(this Type type, string name, Type genericParameter)
        {
            var methods = type.GetMethods(All).Where(m => m.Name == name).ToArray();

            if (methods.Length == 0)
            {
                return type.GetMethods(All).FirstOrDefault(m => m.Name == name + genericParameter.Name);
            }

            return methods.First(m => m.Name == name).MakeGenericMethod(genericParameter);
        }
    }
}
