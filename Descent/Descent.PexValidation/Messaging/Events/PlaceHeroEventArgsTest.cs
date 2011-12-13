// <copyright file="PlaceHeroEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PlaceHeroEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlaceHeroEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PlaceHeroEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PlaceHeroEventArgsTest.ToString01(PlaceHeroEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]PlaceHeroEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method PlaceHeroEventArgsTest.PopulateWithArgs(PlaceHeroEventArgs, String[])
        }
        [PexMethod]
        public PlaceHeroEventArgs Constructor01(string[] stringArgs)
        {
            PlaceHeroEventArgs target = new PlaceHeroEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method PlaceHeroEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public PlaceHeroEventArgs Constructor(
            int playerId,
            int x,
            int y
        )
        {
            PlaceHeroEventArgs target = new PlaceHeroEventArgs(playerId, x, y);
            return target;
            // TODO: add assertions to method PlaceHeroEventArgsTest.Constructor(Int32, Int32, Int32)
        }
    }
}
