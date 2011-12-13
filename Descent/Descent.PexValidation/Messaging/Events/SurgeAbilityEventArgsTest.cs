// <copyright file="SurgeAbilityEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(SurgeAbilityEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SurgeAbilityEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]SurgeAbilityEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method SurgeAbilityEventArgsTest.ToString01(SurgeAbilityEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]SurgeAbilityEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method SurgeAbilityEventArgsTest.PopulateWithArgs(SurgeAbilityEventArgs, String[])
        }
        [PexMethod]
        public SurgeAbilityEventArgs Constructor01(string[] stringArgs)
        {
            SurgeAbilityEventArgs target = new SurgeAbilityEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method SurgeAbilityEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public SurgeAbilityEventArgs Constructor(int abilityId)
        {
            SurgeAbilityEventArgs target = new SurgeAbilityEventArgs(abilityId);
            return target;
            // TODO: add assertions to method SurgeAbilityEventArgsTest.Constructor(Int32)
        }
    }
}
