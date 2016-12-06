﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleFixture.xUnit.Impl
{
    public static class ReflectionHelper
    {
        public static T GetAttribute<T>(MethodInfo methodInfo) where T : class
        {
            var returnAttribute = methodInfo.GetCustomAttributes().FirstOrDefault(a => a is T) ??
                                (methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes().FirstOrDefault(a => a is T) ??
                                 methodInfo.DeclaringType.GetTypeInfo().Assembly.GetCustomAttributes().FirstOrDefault(a => a is T));

            return returnAttribute as T;
        }

        public static IEnumerable<T> GetAttributes<T>(MethodInfo methodInfo) where T : class
        {
            var returnList = new List<T>();

            returnList.AddRange(methodInfo.GetCustomAttributes().Where(a => a is T).Select(a => a as T));

            if (returnList.Count == 0)
            {
                returnList.AddRange(methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes().Where(a => a is T).Select(a => a as T));
            }

            if (returnList.Count == 0)
            {
                returnList.AddRange(methodInfo.DeclaringType.GetTypeInfo().Assembly.GetCustomAttributes().Where(a => a is T).Select(a => a as T));
            }

            return returnList;
        }        
    }
}
