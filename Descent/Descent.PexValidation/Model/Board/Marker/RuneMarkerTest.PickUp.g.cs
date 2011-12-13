// <copyright file="RuneMarkerTest.PickUp.g.cs">Copyright �  2011</copyright>
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
using Microsoft.Pex.Framework.Explorable;
using Microsoft.Xna.Framework.Graphics;
using Descent.Model.Board;
using Descent.Model.Player.Figure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace Descent.Model.Board.Marker
{
    public partial class RuneMarkerTest
    {
[TestMethod]
[PexGeneratedBy(typeof(RuneMarkerTest))]
public void PickUp636()
{
    RuneMarker runeMarker;
    runeMarker = PexInvariant.CreateInstance<RuneMarker>();
    PexInvariant.SetField<int>((object)runeMarker, "id", 0);
    PexInvariant.SetField<string>((object)runeMarker, "name", (string)null);
    PexInvariant.SetField<Texture2D>((object)runeMarker, "texture", (Texture2D)null);
    PexInvariant.SetField<int>((object)runeMarker, "movementPoints", 0);
    PexInvariant.SetField<RuneKey>((object)runeMarker, "color", RuneKey.Red);
    PexInvariant.CheckInvariant((object)runeMarker);
    this.PickUp(runeMarker, (Hero)null);
    Assert.IsNotNull((object)runeMarker);
    Assert.AreEqual<int>
        (0, ((global::Descent.Model.Board.Marker.Marker)runeMarker).Id);
    Assert.AreEqual<string>
        ((string)null, ((global::Descent.Model.Board.Marker.Marker)runeMarker).Name);
    Assert.IsNull(((global::Descent.Model.Board.Marker.Marker)runeMarker).Texture);
    Assert.AreEqual<int>
        (0, ((global::Descent.Model.Board.Marker.Marker)runeMarker).MovementPoints);
}
    }
}