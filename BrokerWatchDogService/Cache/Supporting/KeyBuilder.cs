using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using PostSharp.Aspects;
using System.Collections;

namespace CacheAspect
{
    [Serializable]
    public class KeyBuilder
    {
        public string MethodName { get; set; }
        public CacheSettings Settings { get; set; }
        public string GroupName { get; set; }
        public string ParameterProperty { get; set; }
        private Dictionary<int, string> _parametersNameValueMapper;
        private ParameterInfo[] _methodParameters;
        public ParameterInfo[] MethodParameters
        {
            get { return _methodParameters; }
            set { 
                _methodParameters = value;
                TransformParametersIntoNameValueMapper(_methodParameters);
            }
        }

        private void TransformParametersIntoNameValueMapper(ParameterInfo[] methodParameters)
        {
            _parametersNameValueMapper = new Dictionary<int, string>();
            for (var i = 0; i < methodParameters.Count(); i++)
            {
                _parametersNameValueMapper.Add(i, methodParameters[i].Name);
            }
        }

        public string BuildCacheKey(object instance, Arguments arguments)
        {
            StringBuilder cacheKeyBuilder = new StringBuilder();

            // start building a key based on the method name if a group name not set
            if (string.IsNullOrWhiteSpace(GroupName))
            {
                cacheKeyBuilder.Append(MethodName);
            }
            else
            {
                cacheKeyBuilder.Append(GroupName+";");
            }

            //if (instance != null)
            //{
            //    cacheKeyBuilder.Append(instance);
            //    cacheKeyBuilder.Append(";");
            //}


            int argIndex;
            switch (Settings)
            {
                case CacheSettings.IgnoreParameters:
                    return cacheKeyBuilder.ToString();
                    
                case CacheSettings.UseId:
                    argIndex = GetArgumentIndexByName("Id");
                    cacheKeyBuilder.Append(arguments.GetArgument(argIndex) ?? "Null");
                    break;
                case CacheSettings.UseProperty:
                    if (IsChildProperty())
                    {
                        argIndex = GetArgumentIndexByName(GetParentPropertyName());
                        cacheKeyBuilder.Append(arguments.GetArgument(argIndex, GetChildPropertyName()) ?? "Null");
                    }
                    else
                    {
                        argIndex = GetArgumentIndexByName(ParameterProperty);
                        cacheKeyBuilder.Append(arguments.GetArgument(argIndex) ?? "Null");
                    }
                    break;
                case CacheSettings.Default:
                    for (var i = 0; i < arguments.Count; i++)
                    {
                        BuildDefaultKey(arguments.GetArgument(i), cacheKeyBuilder);
                    }
                    break;
            }

            var key = cacheKeyBuilder.ToString();

            return key;
        }

        private bool IsChildProperty()
        {
            return ParameterProperty.Contains(".") && !string.IsNullOrEmpty(GetChildPropertyName());
        }

        private string GetChildPropertyName()
        {
            return ParameterProperty.Split(new string[] {"."}, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        private string GetParentPropertyName()
        {
            return ParameterProperty.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private static void BuildDefaultKey(object argument, StringBuilder cacheKeyBuilder)
        {
            if (argument != null && typeof(ICollection).IsAssignableFrom(argument.GetType()))
            {
                cacheKeyBuilder.Append("{");
                foreach (object o in (ICollection)argument)
                {
                    cacheKeyBuilder.Append(o ?? "Null");
                }
                cacheKeyBuilder.Append("}");
            }
            else
            {
                cacheKeyBuilder.Append(argument ?? "Null");
            }
        }

        private int GetArgumentIndexByName(string paramName)
        {
            var paramKeyValue = _parametersNameValueMapper.SingleOrDefault( arg => string.Compare(arg.Value, paramName, CultureInfo.InvariantCulture, 
                CompareOptions.IgnoreCase) == 0);

            return paramKeyValue.Key;

        }
    }


    internal static class ArgumentsExtension
    {
        public static object GetArgument(this Arguments arguments, int index, string child)
        {
            object argument = arguments.GetArgument(index);
            var property = argument.GetType().GetProperties().FirstOrDefault(prop => prop.Name.Equals(child, StringComparison.InvariantCultureIgnoreCase));
            if (property == null)
                throw new Exception(
                    "Invalid child property specification! Please take a look at the parameters. Maybe the parameter does not have such a child property that you specified in the Cache attrubute");

            return property.GetValue(argument, null);
        }
    }

    public enum CacheSettings { Default, IgnoreParameters, UseId, UseProperty, IgnoreTTL };
}
