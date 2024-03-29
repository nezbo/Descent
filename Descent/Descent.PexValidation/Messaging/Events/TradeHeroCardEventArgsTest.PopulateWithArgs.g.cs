// <copyright file="TradeHeroCardEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
public void PopulateWithArgsThrowsContractException510()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "-00-";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException663()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "-\0";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException41()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = ":";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException854()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "-0-";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException228()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException289()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "--";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException17()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      ss1[0] = "-";
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgs610()
{
    TradeHeroCardEventArgs tradeHeroCardEventArgs;
    string[] ss = new string[1];
    ss[0] = "0";
    tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
    tradeHeroCardEventArgs.CardId = 0;
    ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
    ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
    ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
    ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
    string[] ss1 = new string[1];
    ss1[0] = "0";
    this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException513()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      string[] ss1 = new string[1];
      this.PopulateWithArgs(tradeHeroCardEventArgs, ss1);
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
public void PopulateWithArgsThrowsContractException527()
{
    try
    {
      TradeHeroCardEventArgs tradeHeroCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "0";
      tradeHeroCardEventArgs = new TradeHeroCardEventArgs(ss);
      tradeHeroCardEventArgs.CardId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).SenderId = 0;
      ((GameEventArgs)tradeHeroCardEventArgs).EventId = (string)null;
      ((GameEventArgs)tradeHeroCardEventArgs).EventType = (EventType)0;
      ((GameEventArgs)tradeHeroCardEventArgs).NeedResponse = false;
      this.PopulateWithArgs(tradeHeroCardEventArgs, (string[])null);
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
