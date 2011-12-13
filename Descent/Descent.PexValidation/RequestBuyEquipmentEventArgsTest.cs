// <copyright file="RequestBuyEquipmentEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(RequestBuyEquipmentEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RequestBuyEquipmentEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]RequestBuyEquipmentEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method RequestBuyEquipmentEventArgsTest.ToString01(RequestBuyEquipmentEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]RequestBuyEquipmentEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method RequestBuyEquipmentEventArgsTest.PopulateWithArgs(RequestBuyEquipmentEventArgs, String[])
        }
        [PexMethod]
        public RequestBuyEquipmentEventArgs Constructor01(string[] stringArgs)
        {
            RequestBuyEquipmentEventArgs target = new RequestBuyEquipmentEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method RequestBuyEquipmentEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public RequestBuyEquipmentEventArgs Constructor(int equipmentId)
        {
            RequestBuyEquipmentEventArgs target = new RequestBuyEquipmentEventArgs(equipmentId);
            return target;
            // TODO: add assertions to method RequestBuyEquipmentEventArgsTest.Constructor(Int32)
        }
    }
}
