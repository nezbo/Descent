// <copyright file="RolledDicesEventArgsTest.ToString01.g.cs">Copyright �  2011</copyright>
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
    public partial class RolledDicesEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(RolledDicesEventArgsTest))]
public void ToString01307()
{
    RolledDicesEventArgs rolledDicesEventArgs;
    string s;
    int[] ints = new int[1];
    ints[0] = 1;
    rolledDicesEventArgs = new RolledDicesEventArgs(ints);
    ((GameEventArgs)rolledDicesEventArgs).SenderId = 0;
    ((GameEventArgs)rolledDicesEventArgs).EventId = (string)null;
    ((GameEventArgs)rolledDicesEventArgs).EventType = (EventType)0;
    ((GameEventArgs)rolledDicesEventArgs).NeedResponse = false;
    s = this.ToString01(rolledDicesEventArgs);
    Assert.AreEqual<string>("1", s);
    Assert.IsNotNull((object)rolledDicesEventArgs);
    Assert.IsNotNull(rolledDicesEventArgs.RolledSides);
    Assert.AreEqual<int>(1, rolledDicesEventArgs.RolledSides.Length);
    Assert.AreEqual<int>(1, rolledDicesEventArgs.RolledSides[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)rolledDicesEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)rolledDicesEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)rolledDicesEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)rolledDicesEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(RolledDicesEventArgsTest))]
public void ToString01561()
{
    RolledDicesEventArgs rolledDicesEventArgs;
    string s;
    int[] ints = new int[1];
    rolledDicesEventArgs = new RolledDicesEventArgs(ints);
    ((GameEventArgs)rolledDicesEventArgs).SenderId = 0;
    ((GameEventArgs)rolledDicesEventArgs).EventId = (string)null;
    ((GameEventArgs)rolledDicesEventArgs).EventType = (EventType)0;
    ((GameEventArgs)rolledDicesEventArgs).NeedResponse = false;
    s = this.ToString01(rolledDicesEventArgs);
    Assert.AreEqual<string>("0", s);
    Assert.IsNotNull((object)rolledDicesEventArgs);
    Assert.IsNotNull(rolledDicesEventArgs.RolledSides);
    Assert.AreEqual<int>(1, rolledDicesEventArgs.RolledSides.Length);
    Assert.AreEqual<int>(0, rolledDicesEventArgs.RolledSides[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)rolledDicesEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)rolledDicesEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)rolledDicesEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)rolledDicesEventArgs).NeedResponse);
}
    }
}
