// <copyright file="RolledDicesEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(RolledDicesEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RolledDicesEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]RolledDicesEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method RolledDicesEventArgsTest.ToString01(RolledDicesEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]RolledDicesEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method RolledDicesEventArgsTest.PopulateWithArgs(RolledDicesEventArgs, String[])
        }
        [PexMethod]
        public RolledDicesEventArgs Constructor01(string[] stringArgs)
        {
            RolledDicesEventArgs target = new RolledDicesEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method RolledDicesEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public RolledDicesEventArgs Constructor(int[] rolledSides)
        {
            RolledDicesEventArgs target = new RolledDicesEventArgs(rolledSides);
            return target;
            // TODO: add assertions to method RolledDicesEventArgsTest.Constructor(Int32[])
        }
    }
}
