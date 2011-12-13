// <copyright file="SpawnMonsterEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(SpawnMonsterEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SpawnMonsterEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]SpawnMonsterEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method SpawnMonsterEventArgsTest.ToString01(SpawnMonsterEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]SpawnMonsterEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method SpawnMonsterEventArgsTest.PopulateWithArgs(SpawnMonsterEventArgs, String[])
        }
        [PexMethod]
        public SpawnMonsterEventArgs Constructor01(string[] stringArgs)
        {
            SpawnMonsterEventArgs target = new SpawnMonsterEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method SpawnMonsterEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public SpawnMonsterEventArgs Constructor(
            int x,
            int y,
            int monsterId
        )
        {
            SpawnMonsterEventArgs target = new SpawnMonsterEventArgs(x, y, monsterId);
            return target;
            // TODO: add assertions to method SpawnMonsterEventArgsTest.Constructor(Int32, Int32, Int32)
        }
    }
}
