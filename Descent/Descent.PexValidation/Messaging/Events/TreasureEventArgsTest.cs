// <copyright file="TreasureEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(TreasureEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TreasureEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]TreasureEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method TreasureEventArgsTest.ToString01(TreasureEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]TreasureEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method TreasureEventArgsTest.PopulateWithArgs(TreasureEventArgs, String[])
        }
        [PexMethod]
        public TreasureEventArgs Constructor01(string[] stringArgs)
        {
            TreasureEventArgs target = new TreasureEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method TreasureEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public TreasureEventArgs Constructor(int treasureId)
        {
            TreasureEventArgs target = new TreasureEventArgs(treasureId);
            return target;
            // TODO: add assertions to method TreasureEventArgsTest.Constructor(Int32)
        }
    }
}
