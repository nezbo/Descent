// <copyright file="PlayerEventArgsTest.ToString01.g.cs">Copyright �  2011</copyright>
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
    public partial class PlayerEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PlayerEventArgsTest))]
public void ToString0155()
{
    PlayerEventArgs playerEventArgs;
    string s;
    playerEventArgs = new PlayerEventArgs(1);
    ((GameEventArgs)playerEventArgs).SenderId = 0;
    ((GameEventArgs)playerEventArgs).EventId = (string)null;
    ((GameEventArgs)playerEventArgs).EventType = (EventType)0;
    ((GameEventArgs)playerEventArgs).NeedResponse = false;
    s = this.ToString01(playerEventArgs);
    Assert.AreEqual<string>("1", s);
    Assert.IsNotNull((object)playerEventArgs);
    Assert.AreEqual<int>(1, playerEventArgs.PlayerId);
    Assert.AreEqual<int>(0, ((GameEventArgs)playerEventArgs).SenderId);
    Assert.AreEqual<string>((string)null, ((GameEventArgs)playerEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)playerEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)playerEventArgs).NeedResponse);
}
    }
}
