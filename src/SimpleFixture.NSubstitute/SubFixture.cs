﻿using System;

namespace SimpleFixture.NSubstitute
{
    public class SubFixture : Fixture
    {
        public SubFixture(IFixtureConfiguration configuration = null, bool defaultSingleton = true)
            : base(configuration)
        {
            Add(new SubstituteConvention(defaultSingleton));
        }

        /// <summary>
        /// Substitute for a particular type, by default substitute types are treated as singletons
        /// </summary>
        /// <typeparam name="T">Type to substitute</typeparam>
        /// <param name="substituteAction">arrange</param>
        /// <param name="singleton">singleton</param>
        /// <returns>new substituted type</returns>
        public T Substitute<T>(Action<T> substituteAction = null, bool? singleton = null)
        {
            T returnValue = Generate<T>(constraints: new
                                                     {
                                                         fakeSingleton = singleton
                                                     });

            substituteAction?.Invoke(returnValue);

            return returnValue;
        }
    }
}
