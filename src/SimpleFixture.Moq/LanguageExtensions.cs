﻿using Moq;
using System;

namespace SimpleFixture.Moq
{
    /// <summary>
    /// Language extensions
    /// </summary>
    public static class LanguageExtensions
    {
        /// <summary>
        /// Mock a specific object, by default mocks are treated as singletons
        /// </summary>
        /// <typeparam name="T">type to mock</typeparam>
        /// <param name="fixture"></param>
        /// <param name="mockAction">action to apply to the mock</param>
        /// <param name="singleton">should it be a singleton</param>
        /// <returns>new mock</returns>
        public static Mock<T> Mock<T>(this Fixture fixture, Action<Mock<T>> mockAction = null, bool? singleton = null) where T : class
        {
            var returnValue = fixture.Generate<Mock<T>>(constraints: new
            {
                moqSingleton = singleton
            });

            mockAction?.Invoke(returnValue);

            return returnValue;
        }
    }
}
