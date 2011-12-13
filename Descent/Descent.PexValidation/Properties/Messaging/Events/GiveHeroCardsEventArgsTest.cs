// <copyright file="GiveHeroCardsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(GiveHeroCardsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GiveHeroCardsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]GiveHeroCardsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method GiveHeroCardsEventArgsTest.ToString01(GiveHeroCardsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]GiveHeroCardsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method GiveHeroCardsEventArgsTest.PopulateWithArgs(GiveHeroCardsEventArgs, String[])
        }
        [PexMethod]
        public GiveHeroCardsEventArgs Constructor01(string[] stringArgs)
        {
            GiveHeroCardsEventArgs target = new GiveHeroCardsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method GiveHeroCardsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public GiveHeroCardsEventArgs Constructor(int playerId, int[] heroCardIds)
        {
            GiveHeroCardsEventArgs target = new GiveHeroCardsEventArgs(playerId, heroCardIds);
            return target;
            // TODO: add assertions to method GiveHeroCardsEventArgsTest.Constructor(Int32, Int32[])
        }
    }
}
