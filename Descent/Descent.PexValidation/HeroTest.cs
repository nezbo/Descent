// <copyright file="HeroTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Player.Figure;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Model.Player.Figure
{
    [TestClass]
    [PexClass(typeof(Hero))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class HeroTest
    {
    }
}
