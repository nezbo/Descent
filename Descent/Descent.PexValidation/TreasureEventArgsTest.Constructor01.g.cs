// <copyright file="TreasureEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class TreasureEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException383()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "00:";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException123()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "-0:";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException215()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "-\0";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException940()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = ":";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException741()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "-";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
public void Constructor01497()
{
    TreasureEventArgs treasureEventArgs;
    string[] ss = new string[1];
    ss[0] = "0";
    treasureEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)treasureEventArgs);
    Assert.AreEqual<int>(0, treasureEventArgs.TreasureId);
    Assert.AreEqual<int>(0, ((GameEventArgs)treasureEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)treasureEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)treasureEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)treasureEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException813()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "\u0001";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException397()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "\0";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException247()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      ss[0] = "";
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException788()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[1];
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException830()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      string[] ss = new string[0];
      treasureEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException136()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      treasureEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
public void Constructor136()
{
    TreasureEventArgs treasureEventArgs;
    treasureEventArgs = this.Constructor(1);
    Assert.IsNotNull((object)treasureEventArgs);
    Assert.AreEqual<int>(1, treasureEventArgs.TreasureId);
    Assert.AreEqual<int>(0, ((GameEventArgs)treasureEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)treasureEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)treasureEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)treasureEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(TreasureEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException408()
{
    try
    {
      TreasureEventArgs treasureEventArgs;
      treasureEventArgs = this.Constructor(0);
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
