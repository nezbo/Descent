// <copyright file="GiveOverlordCardsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(GiveOverlordCardsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GiveOverlordCardsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]GiveOverlordCardsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method GiveOverlordCardsEventArgsTest.ToString01(GiveOverlordCardsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]GiveOverlordCardsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method GiveOverlordCardsEventArgsTest.PopulateWithArgs(GiveOverlordCardsEventArgs, String[])
        }
        [PexMethod]
        public GiveOverlordCardsEventArgs Constructor01(string[] stringArgs)
        {
            GiveOverlordCardsEventArgs target = new GiveOverlordCardsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method GiveOverlordCardsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public GiveOverlordCardsEventArgs Constructor(int[] overlordCardIds)
        {
            GiveOverlordCardsEventArgs target = new GiveOverlordCardsEventArgs(overlordCardIds);
            return target;
            // TODO: add assertions to method GiveOverlordCardsEventArgsTest.Constructor(Int32[])
        }
    }
}
