// <copyright file="ChestTest.CursesGet.g.cs">Copyright �  2011</copyright>
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
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace Descent.Model.Board.Marker
{
    public partial class ChestTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ChestTest))]
public void CursesGet33()
{
    int i;
    Chest s0 = new Chest(0, EquipmentRarity.Common, 0, 0, 0, 0);
    i = this.CursesGet(s0);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)s0);
    Assert.AreEqual<int>(0, s0.Id);
    Assert.AreEqual<EquipmentRarity>(EquipmentRarity.Common, s0.Rarity);
    Assert.AreEqual<int>(0, s0.ConquestTokens);
    Assert.AreEqual<int>(0, s0.Coin);
    Assert.AreEqual<int>(0, s0.Curses);
    Assert.AreEqual<int>(0, s0.Treasures);
}
    }
}
