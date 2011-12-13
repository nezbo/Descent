// <copyright file="OverlordCardEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(OverlordCardEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class OverlordCardEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]OverlordCardEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method OverlordCardEventArgsTest.ToString01(OverlordCardEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]OverlordCardEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method OverlordCardEventArgsTest.PopulateWithArgs(OverlordCardEventArgs, String[])
        }
        [PexMethod]
        public OverlordCardEventArgs Constructor01(string[] stringArgs)
        {
            OverlordCardEventArgs target = new OverlordCardEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method OverlordCardEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public OverlordCardEventArgs Constructor(int overlordCardId)
        {
            OverlordCardEventArgs target = new OverlordCardEventArgs(overlordCardId);
            return target;
            // TODO: add assertions to method OverlordCardEventArgsTest.Constructor(Int32)
        }
    }
}
