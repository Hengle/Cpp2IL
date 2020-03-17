using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace Cpp2IL
{
    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string Repeat(this string source, int count)
        {
            var res = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                res.Append(source);
            }

            return res.ToString();
        }
        
        public static void MethodSignatureFullName(this IMethodSignature self, StringBuilder builder)
        {
            builder.Append("(");
            if (self.HasParameters)
            {
                Collection<ParameterDefinition> parameters = self.Parameters;
                for (int index = 0; index < parameters.Count; ++index)
                {
                    ParameterDefinition parameterDefinition = parameters[index];
                    if (index > 0)
                        builder.Append(",");
                    if (parameterDefinition.ParameterType.IsSentinel)
                        builder.Append("...,");
                    builder.Append(parameterDefinition.ParameterType.FullName);
                }
            }
            builder.Append(")");
        }
        
        public static string ToStringEnumerable<T>(this IEnumerable<T> enumerable)
        {
            var builder = new StringBuilder("[");
            builder.Append(string.Join(", ", enumerable));
            builder.Append("]");
            return builder.ToString();
        }
    }
}