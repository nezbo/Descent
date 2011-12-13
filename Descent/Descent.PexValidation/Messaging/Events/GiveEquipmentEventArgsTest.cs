// <copyright file="GiveEquipmentEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(GiveEquipmentEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GiveEquipmentEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]GiveEquipmentEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method GiveEquipmentEventArgsTest.ToString01(GiveEquipmentEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]GiveEquipmentEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method GiveEquipmentEventArgsTest.PopulateWithArgs(GiveEquipmentEventArgs, String[])
        }
        [PexMethod]
        public GiveEquipmentEventArgs Constructor01(string[] stringArgs)
        {
            GiveEquipmentEventArgs target = new GiveEquipmentEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method GiveEquipmentEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public GiveEquipmentEventArgs Constructor(
            int playerId,
            int equipmentId,
            bool free
        )
        {
            GiveEquipmentEventArgs target = new GiveEquipmentEventArgs(playerId, equipmentId, free);
            return target;
            // TODO: add assertions to method GiveEquipmentEventArgsTest.Constructor(Int32, Int32, Boolean)
        }
    }
}
