// <copyright file="GiveCoinsEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class GiveCoinsEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
public void Constructor01234()
{
    GiveCoinsEventArgs giveCoinsEventArgs;
    string[] ss = new string[2];
    ss[0] = "1";
    ss[1] = "1";
    giveCoinsEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)giveCoinsEventArgs);
    Assert.AreEqual<int>(1, giveCoinsEventArgs.PlayerId);
    Assert.AreEqual<int>(1, giveCoinsEventArgs.NumberOfCoins);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveCoinsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveCoinsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveCoinsEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)giveCoinsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException937()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "0";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException511()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "\u0001";
      ss[1] = "\u0001";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException699()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "\0\0";
      ss[1] = "\0\0";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException609()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[0];
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException163()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      giveCoinsEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
public void Constructor352()
{
    GiveCoinsEventArgs giveCoinsEventArgs;
    giveCoinsEventArgs = this.Constructor(1, 1);
    Assert.IsNotNull((object)giveCoinsEventArgs);
    Assert.AreEqual<int>(1, giveCoinsEventArgs.PlayerId);
    Assert.AreEqual<int>(1, giveCoinsEventArgs.NumberOfCoins);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveCoinsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveCoinsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveCoinsEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)giveCoinsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException663()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      giveCoinsEventArgs = this.Constructor(1, 0);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException710()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      giveCoinsEventArgs = this.Constructor(0, 0);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException197()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException593()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException205()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException225()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-0";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException312()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "0\0";
      ss[1] = "0\0";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException782()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      giveCoinsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveCoinsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException471()
{
    try
    {
      GiveCoinsEventArgs giveCoinsEventArgs;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      giveCoinsEventArgs = this.Constructor01(ss);
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