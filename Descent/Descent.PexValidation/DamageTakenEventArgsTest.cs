// <copyright file="DamageTakenEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(DamageTakenEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DamageTakenEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]DamageTakenEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method DamageTakenEventArgsTest.ToString01(DamageTakenEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]DamageTakenEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method DamageTakenEventArgsTest.PopulateWithArgs(DamageTakenEventArgs, String[])
        }
        [PexMethod]
        public DamageTakenEventArgs Constructor01(string[] stringArgs)
        {
            DamageTakenEventArgs target = new DamageTakenEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method DamageTakenEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public DamageTakenEventArgs Constructor(
            int x,
            int y,
            int damage
        )
        {
            DamageTakenEventArgs target = new DamageTakenEventArgs(x, y, damage);
            return target;
            // TODO: add assertions to method DamageTakenEventArgsTest.Constructor(Int32, Int32, Int32)
        }
    }
}
