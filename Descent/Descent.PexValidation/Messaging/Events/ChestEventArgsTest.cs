// <copyright file="ChestEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(ChestEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChestEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]ChestEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method ChestEventArgsTest.ToString01(ChestEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]ChestEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method ChestEventArgsTest.PopulateWithArgs(ChestEventArgs, String[])
        }
        [PexMethod]
        public ChestEventArgs Constructor01(string[] stringArgs)
        {
            ChestEventArgs target = new ChestEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method ChestEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public ChestEventArgs Constructor(int chestId)
        {
            ChestEventArgs target = new ChestEventArgs(chestId);
            return target;
            // TODO: add assertions to method ChestEventArgsTest.Constructor(Int32)
        }
    }
}
