// <copyright file="AssignHeroEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(AssignHeroEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AssignHeroEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]AssignHeroEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method AssignHeroEventArgsTest.ToString01(AssignHeroEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]AssignHeroEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method AssignHeroEventArgsTest.PopulateWithArgs(AssignHeroEventArgs, String[])
        }
        [PexMethod]
        public AssignHeroEventArgs Constructor01(string[] stringArgs)
        {
            AssignHeroEventArgs target = new AssignHeroEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method AssignHeroEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public AssignHeroEventArgs Constructor(int playerId, int heroId)
        {
            AssignHeroEventArgs target = new AssignHeroEventArgs(playerId, heroId);
            return target;
            // TODO: add assertions to method AssignHeroEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
