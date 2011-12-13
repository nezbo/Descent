// <copyright file="DiceEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(DiceEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DiceEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]DiceEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method DiceEventArgsTest.ToString01(DiceEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]DiceEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method DiceEventArgsTest.PopulateWithArgs(DiceEventArgs, String[])
        }
        [PexMethod]
        public DiceEventArgs Constructor01(string[] stringArgs)
        {
            DiceEventArgs target = new DiceEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method DiceEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public DiceEventArgs Constructor(int diceId, int sideId)
        {
            DiceEventArgs target = new DiceEventArgs(diceId, sideId);
            return target;
            // TODO: add assertions to method DiceEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
