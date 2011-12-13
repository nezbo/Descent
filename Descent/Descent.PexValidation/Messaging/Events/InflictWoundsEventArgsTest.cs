// <copyright file="InflictWoundsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(InflictWoundsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class InflictWoundsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]InflictWoundsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method InflictWoundsEventArgsTest.ToString01(InflictWoundsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]InflictWoundsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method InflictWoundsEventArgsTest.PopulateWithArgs(InflictWoundsEventArgs, String[])
        }
        [PexMethod]
        public InflictWoundsEventArgs Constructor01(string[] stringArgs)
        {
            InflictWoundsEventArgs target = new InflictWoundsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method InflictWoundsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public InflictWoundsEventArgs Constructor(
            int x,
            int y,
            int damage,
            int pierce
        )
        {
            InflictWoundsEventArgs target = new InflictWoundsEventArgs(x, y, damage, pierce);
            return target;
            // TODO: add assertions to method InflictWoundsEventArgsTest.Constructor(Int32, Int32, Int32, Int32)
        }
    }
}
