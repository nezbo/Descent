// <copyright file="GameEventArgsTest.Constructor.g.cs">Copyright �  2011</copyright>
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
using Microsoft.Pex.Engine.Exceptions;

namespace Descent.Messaging.Events
{
    public partial class GameEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(GameEventArgsTest))]
public void Constructor368()
{
    GameEventArgs gameEventArgs;
    gameEventArgs = this.Constructor(1, "", (EventType)0, false);
    Assert.IsNotNull((object)gameEventArgs);
    Assert.AreEqual<int>(1, gameEventArgs.SenderId);
    Assert.AreEqual<string>("", gameEventArgs.EventId);
    Assert.AreEqual<EventType>((EventType)0, gameEventArgs.EventType);
    Assert.AreEqual<bool>(false, gameEventArgs.NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GameEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException36()
{
    try
    {
      GameEventArgs gameEventArgs;
      gameEventArgs = this.Constructor(1, (string)null, (EventType)0, false);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(GameEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException120()
{
    try
    {
      GameEventArgs gameEventArgs;
      gameEventArgs = this.Constructor(0, (string)null, (EventType)0, false);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}