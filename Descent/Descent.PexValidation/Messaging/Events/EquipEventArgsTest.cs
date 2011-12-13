// <copyright file="EquipEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(EquipEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EquipEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]EquipEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method EquipEventArgsTest.ToString01(EquipEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]EquipEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method EquipEventArgsTest.PopulateWithArgs(EquipEventArgs, String[])
        }
        [PexMethod]
        public EquipEventArgs Constructor01(string[] stringArgs)
        {
            EquipEventArgs target = new EquipEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method EquipEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public EquipEventArgs Constructor(int equipmentId, int inventoryField)
        {
            EquipEventArgs target = new EquipEventArgs(equipmentId, inventoryField);
            return target;
            // TODO: add assertions to method EquipEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
