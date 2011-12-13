// <copyright file="RerollDicesEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(RerollDicesEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RerollDicesEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]RerollDicesEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method RerollDicesEventArgsTest.ToString01(RerollDicesEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]RerollDicesEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method RerollDicesEventArgsTest.PopulateWithArgs(RerollDicesEventArgs, String[])
        }
        [PexMethod]
        public RerollDicesEventArgs Constructor01(string[] stringArgs)
        {
            RerollDicesEventArgs target = new RerollDicesEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method RerollDicesEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public RerollDicesEventArgs Constructor(int[] diceIds)
        {
            RerollDicesEventArgs target = new RerollDicesEventArgs(diceIds);
            return target;
            // TODO: add assertions to method RerollDicesEventArgsTest.Constructor(Int32[])
        }
    }
}
