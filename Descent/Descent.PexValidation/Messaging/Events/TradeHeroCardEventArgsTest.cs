// <copyright file="TradeHeroCardEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(TradeHeroCardEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TradeHeroCardEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]TradeHeroCardEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method TradeHeroCardEventArgsTest.ToString01(TradeHeroCardEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]TradeHeroCardEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method TradeHeroCardEventArgsTest.PopulateWithArgs(TradeHeroCardEventArgs, String[])
        }
        [PexMethod]
        public TradeHeroCardEventArgs Constructor01(string[] stringArgs)
        {
            TradeHeroCardEventArgs target = new TradeHeroCardEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method TradeHeroCardEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public TradeHeroCardEventArgs Constructor(int cardId)
        {
            TradeHeroCardEventArgs target = new TradeHeroCardEventArgs(cardId);
            return target;
            // TODO: add assertions to method TradeHeroCardEventArgsTest.Constructor(Int32)
        }
    }
}
