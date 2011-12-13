// <copyright file="InventoryFieldEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(InventoryFieldEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class InventoryFieldEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]InventoryFieldEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method InventoryFieldEventArgsTest.ToString01(InventoryFieldEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]InventoryFieldEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method InventoryFieldEventArgsTest.PopulateWithArgs(InventoryFieldEventArgs, String[])
        }
        [PexMethod]
        public InventoryFieldEventArgs Constructor01(string[] stringArgs)
        {
            InventoryFieldEventArgs target = new InventoryFieldEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method InventoryFieldEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public InventoryFieldEventArgs Constructor(int inventoryField)
        {
            InventoryFieldEventArgs target = new InventoryFieldEventArgs(inventoryField);
            return target;
            // TODO: add assertions to method InventoryFieldEventArgsTest.Constructor(Int32)
        }
    }
}
