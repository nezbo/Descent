// <copyright file="ChooseActionEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(ChooseActionEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChooseActionEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]ChooseActionEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method ChooseActionEventArgsTest.ToString01(ChooseActionEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]ChooseActionEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method ChooseActionEventArgsTest.PopulateWithArgs(ChooseActionEventArgs, String[])
        }
        [PexMethod]
        public ChooseActionEventArgs Constructor01(string[] stringArgs)
        {
            ChooseActionEventArgs target = new ChooseActionEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method ChooseActionEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public ChooseActionEventArgs Constructor(ActionType actionType)
        {
            ChooseActionEventArgs target = new ChooseActionEventArgs(actionType);
            return target;
            // TODO: add assertions to method ChooseActionEventArgsTest.Constructor(ActionType)
        }
    }
}
