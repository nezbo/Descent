// <copyright file="TokenEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(TokenEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TokenEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]TokenEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method TokenEventArgsTest.ToString01(TokenEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]TokenEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method TokenEventArgsTest.PopulateWithArgs(TokenEventArgs, String[])
        }
        [PexMethod]
        public TokenEventArgs Constructor01(string[] stringArgs)
        {
            TokenEventArgs target = new TokenEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method TokenEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public TokenEventArgs Constructor(int numberOfTokens)
        {
            TokenEventArgs target = new TokenEventArgs(numberOfTokens);
            return target;
            // TODO: add assertions to method TokenEventArgsTest.Constructor(Int32)
        }
    }
}
