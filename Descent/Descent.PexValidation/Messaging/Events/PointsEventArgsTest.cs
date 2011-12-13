// <copyright file="PointsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PointsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PointsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PointsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PointsEventArgsTest.ToString01(PointsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]PointsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method PointsEventArgsTest.PopulateWithArgs(PointsEventArgs, String[])
        }
        [PexMethod]
        public PointsEventArgs Constructor01(string[] stringArgs)
        {
            PointsEventArgs target = new PointsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method PointsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public PointsEventArgs Constructor(int points)
        {
            PointsEventArgs target = new PointsEventArgs(points);
            return target;
            // TODO: add assertions to method PointsEventArgsTest.Constructor(Int32)
        }
    }
}
