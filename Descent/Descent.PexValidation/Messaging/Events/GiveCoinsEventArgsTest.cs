// <copyright file="GiveCoinsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(GiveCoinsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GiveCoinsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]GiveCoinsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method GiveCoinsEventArgsTest.ToString01(GiveCoinsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]GiveCoinsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method GiveCoinsEventArgsTest.PopulateWithArgs(GiveCoinsEventArgs, String[])
        }
        [PexMethod]
        public GiveCoinsEventArgs Constructor01(string[] stringArgs)
        {
            GiveCoinsEventArgs target = new GiveCoinsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method GiveCoinsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public GiveCoinsEventArgs Constructor(int playerId, int numberOfCoins)
        {
            GiveCoinsEventArgs target = new GiveCoinsEventArgs(playerId, numberOfCoins);
            return target;
            // TODO: add assertions to method GiveCoinsEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
