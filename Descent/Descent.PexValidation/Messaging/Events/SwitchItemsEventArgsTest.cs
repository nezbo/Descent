// <copyright file="SwitchItemsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(SwitchItemsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SwitchItemsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]SwitchItemsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method SwitchItemsEventArgsTest.ToString01(SwitchItemsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]SwitchItemsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method SwitchItemsEventArgsTest.PopulateWithArgs(SwitchItemsEventArgs, String[])
        }
        [PexMethod]
        public SwitchItemsEventArgs Constructor01(string[] stringArgs)
        {
            SwitchItemsEventArgs target = new SwitchItemsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method SwitchItemsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public SwitchItemsEventArgs Constructor(int field1, int field2)
        {
            SwitchItemsEventArgs target = new SwitchItemsEventArgs(field1, field2);
            return target;
            // TODO: add assertions to method SwitchItemsEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
