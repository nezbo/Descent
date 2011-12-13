// <copyright file="MarkerTest.IdGet.g.cs">Copyright �  2011</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
using System;
using Descent.Model.Board.Marker.Moles;
using Microsoft.Pex.Framework.Explorable;
using Microsoft.Xna.Framework.Graphics;
using Descent.Model.Player.Figure;
using Microsoft.Moles.Framework;
using Microsoft.Moles.Framework.Behaviors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace Descent.Model.Board.Marker
{
    public partial class MarkerTest
    {
[TestMethod]
[PexGeneratedBy(typeof(MarkerTest))]
public void IdGet493()
{
    SMarker sMarker;
    int i;
    sMarker = PexInvariant.CreateInstance<SMarker>();
    PexInvariant.SetField<int>((object)sMarker, "id", 0);
    PexInvariant.SetField<string>((object)sMarker, "name", (string)null);
    PexInvariant.SetField<Texture2D>((object)sMarker, "texture", (Texture2D)null);
    PexInvariant.SetField<int>((object)sMarker, "movementPoints", 0);
    PexInvariant.SetField<MolesDelegates.Action<Hero>>
        ((object)sMarker, "PickUpHero", (MolesDelegates.Action<Hero>)null);
    PexInvariant.SetField<bool>((object)sMarker, "__callBase", false);
    PexInvariant.SetField<IBehavior>
        ((object)sMarker, "__instanceBehavior", (IBehavior)null);
    PexInvariant.CheckInvariant((object)sMarker);
    i = this.IdGet((global::Descent.Model.Board.Marker.Marker)sMarker);
    Assert.AreEqual<int>(0, i);
}
    }
}
