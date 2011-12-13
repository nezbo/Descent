// <copyright file="AbilityTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Event;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;

namespace Descent.Model.Event
{
    [TestClass]
    [PexClass(typeof(Ability))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class AbilityTest
    {
        [PexMethod]
        public bool TriggeredGet([PexAssumeUnderTest]Ability target)
        {
            bool result = target.Triggered;
            return result;
            // TODO: add assertions to method AbilityTest.TriggeredGet(Ability)
        }
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]Ability target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method AbilityTest.ToString01(Ability)
        }
        [PexMethod]
        public Ability GetAbility(string abilityString)
        {
            Ability result = Ability.GetAbility(abilityString);
            return result;
            // TODO: add assertions to method AbilityTest.GetAbility(String)
        }
        [PexMethod]
        public Ability Constructor()
        {
            Ability target = new Ability();
            return target;
            // TODO: add assertions to method AbilityTest.Constructor()
        }
        [PexMethod]
        public bool AvailableGet([PexAssumeUnderTest]Ability target)
        {
            bool result = target.Available;
            return result;
            // TODO: add assertions to method AbilityTest.AvailableGet(Ability)
        }
        [PexMethod]
        public void Apply([PexAssumeUnderTest]Ability target, global::Descent.Model.Player.Figure.Figure figure)
        {
            target.Apply(figure);
            // TODO: add assertions to method AbilityTest.Apply(Ability, Figure)
        }
    }
}
