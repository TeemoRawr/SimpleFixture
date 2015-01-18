﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleFixture.Conventions;

namespace SimpleFixture
{
    /// <summary>
    /// Class used to configure when a return value should be used
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReturnConfiguration<T>
    {
        private readonly FilteredConvention<T> _convention;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="convention">filter convention</param>
        public ReturnConfiguration(FilteredConvention<T> convention)
        {
            _convention = convention;
        }

        /// <summary>
        /// Use return value for specific parent types
        /// </summary>
        /// <typeparam name="TValue">filter type</typeparam>
        /// <returns>return configuration</returns>
        public ReturnConfiguration<T> For<TValue>()
        {
            _convention.AddFilter(r =>
                                  {
                                      if (r.ParentRequest != null &&
                                          typeof(TValue).GetTypeInfo()
                                              .IsAssignableFrom(r.ParentRequest.RequestedType.GetTypeInfo()))
                                      {
                                          return true;
                                      }

                                      return false;
                                  });

            return this;
        }

        /// <summary>
        /// Filter based on name (Parameter name or Property name)
        /// </summary>
        /// <param name="name">name to match exactly</param>
        /// <returns>return configuration</returns>
        public ReturnConfiguration<T> WhenNamed(string name)
        {
            _convention.AddFilter(r => r.RequestName.ToLowerInvariant() == name.ToLowerInvariant());

            return this;
        }

        /// <summary>
        /// Filter based on name function (Parameter name or Property name)
        /// </summary>
        /// <param name="namedFunc">name func used to filter</param>
        /// <returns>return configuration</returns>
        public ReturnConfiguration<T> WhenNamed(Func<string, bool> namedFunc)
        {
            _convention.AddFilter(r => namedFunc(r.RequestName));

            return this;
        }

        /// <summary>
        /// Filter based on data request
        /// </summary>
        /// <param name="matchingFunc">filter method</param>
        /// <returns>return configuration</returns>
        public ReturnConfiguration<T> WhenMatching(Func<DataRequest, bool> matchingFunc)
        {
            _convention.AddFilter(matchingFunc);

            return this;
        }
    }
}
