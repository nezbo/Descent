// <copyright file="DamageTakenEventArgsTest.ToString01.g.cs">Copyright �  2011</copyright>
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
    public partial class DamageTakenEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(DamageTakenEventArgsTest))]
public void ToString01966()
{
    DamageTakenEventArgs damageTakenEventArgs;
    string s;
    damageTakenEventArgs = new DamageTakenEventArgs(8, 0, 0);
    ((GameEventArgs)damageTakenEventArgs).SenderId = 0;
    ((GameEventArgs)damageTakenEventArgs).EventId = (string)null;
    ((GameEventArgs)damageTakenEventArgs).EventType = (EventType)0;
    ((GameEventArgs)damageTakenEventArgs).NeedResponse = false;
    s = this.ToString01(damageTakenEventArgs);
    Assert.AreEqual<string>("8,0,0", s);
    Assert.IsNotNull((object)damageTakenEventArgs);
    Assert.AreEqual<int>(8, damageTakenEventArgs.X);
    Assert.AreEqual<int>(0, damageTakenEventArgs.Y);
    Assert.AreEqual<int>(0, damageTakenEventArgs.Damage);
    Assert.AreEqual<int>(0, ((GameEventArgs)damageTakenEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)damageTakenEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)damageTakenEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)damageTakenEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(DamageTakenEventArgsTest))]
public void ToString01342()
{
    DamageTakenEventArgs damageTakenEventArgs;
    string s;
    damageTakenEventArgs = new DamageTakenEventArgs(0, 0, 0);
    ((GameEventArgs)damageTakenEventArgs).SenderId = 0;
    ((GameEventArgs)damageTakenEventArgs).EventId = (string)null;
    ((GameEventArgs)damageTakenEventArgs).EventType = (EventType)0;
    ((GameEventArgs)damageTakenEventArgs).NeedResponse = false;
    s = this.ToString01(damageTakenEventArgs);
    Assert.AreEqual<string>("0,0,0", s);
    Assert.IsNotNull((object)damageTakenEventArgs);
    Assert.AreEqual<int>(0, damageTakenEventArgs.X);
    Assert.AreEqual<int>(0, damageTakenEventArgs.Y);
    Assert.AreEqual<int>(0, damageTakenEventArgs.Damage);
    Assert.AreEqual<int>(0, ((GameEventArgs)damageTakenEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)damageTakenEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)damageTakenEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)damageTakenEventArgs).NeedResponse);
}
    }
}
