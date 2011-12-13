// <copyright file="TradeHeroCardEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class TradeHeroCardEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException365()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "00:";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException957()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-0:";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException148()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-\0";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException223()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = ":";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException597()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
public void Constructor0111()
{
    TradeHeroCardEventArgs tradeHeroCardEventArgs;
    string[] ss = new string[1];
    ss[0] = "0";
    tradeHeroCardEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)tradeHeroCardEventArgs);
    Assert.AreEqual<int>(0, tradeHeroCardEventArgs.CardId);
    Assert.AreEqual<int>(0, ((GameEventArgs)tradeHeroCardEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)tradeHeroCardEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)tradeHeroCardEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException289()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "\u0001";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException461()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "\0";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException539()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "";
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException788()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException120()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[0];
      tradeHeroCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException856()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      tradeHeroCardEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
public void Constructor738()
{
    TradeHeroCardEventArgs tradeHeroCardEventArgs;
    tradeHeroCardEventArgs = this.Constructor(1);
    Assert.IsNotNull((object)tradeHeroCardEventArgs);
    Assert.AreEqual<int>(0, tradeHeroCardEventArgs.CardId);
    Assert.AreEqual<int>(0, ((GameEventArgs)tradeHeroCardEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)tradeHeroCardEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)tradeHeroCardEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(TradeHeroCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException150()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      tradeHeroCardEventArgs = this.Constructor(0);
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