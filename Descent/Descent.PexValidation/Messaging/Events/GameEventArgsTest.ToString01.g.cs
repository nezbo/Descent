// <copyright file="GameEventArgsTest.ToString01.g.cs">Copyright �  2011</copyright>
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace Descent.Messaging.Events
{
    public partial class GameEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(GameEventArgsTest))]
public void ToString01754()
{
    string s;
    GameEventArgs s0 = new GameEventArgs();
    s0.SenderId = 0;
    s0.EventId = (string)null;
    s0.EventType = (EventType)0;
    s0.NeedResponse = false;
    s = this.ToString01(s0);
    Assert.AreEqual<string>("", s);
    Assert.IsNotNull((object)s0);
    Assert.AreEqual<int>(0, s0.SenderId);
    Assert.AreEqual<string>((string)null, s0.EventId);
    Assert.AreEqual<EventType>((EventType)0, s0.EventType);
    Assert.AreEqual<bool>(false, s0.NeedResponse);
}
    }
}
