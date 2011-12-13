// <copyright file="DiceEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
    public partial class DiceEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException389()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "-9\0";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException95501()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "\0";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException955()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-9";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException392()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
public void PopulateWithArgs161()
{
    DiceEventArgs diceEventArgs;
    diceEventArgs = new DiceEventArgs(0, 0);
    ((GameEventArgs)diceEventArgs).SenderId = 0;
    ((GameEventArgs)diceEventArgs).EventId = (string)null;
    ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
    ((GameEventArgs)diceEventArgs).NeedResponse = false;
    string[] ss = new string[2];
    ss[0] = "0";
    ss[1] = "0";
    this.PopulateWithArgs(diceEventArgs, ss);
    Assert.IsNotNull((object)diceEventArgs);
    Assert.AreEqual<int>(0, diceEventArgs.DiceId);
    Assert.AreEqual<int>(0, diceEventArgs.SideId);
    Assert.AreEqual<int>(0, ((GameEventArgs)diceEventArgs).SenderId);
    Assert.AreEqual<string>((string)null, ((GameEventArgs)diceEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)diceEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)diceEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException158()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException804()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0";
      ss[1] = "\0";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException704()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException902()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException813()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(diceEventArgs, ss);
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
[PexGeneratedBy(typeof(DiceEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException367()
{
    try
    {
      DiceEventArgs diceEventArgs;
      diceEventArgs = new DiceEventArgs(0, 0);
      ((GameEventArgs)diceEventArgs).SenderId = 0;
      ((GameEventArgs)diceEventArgs).EventId = (string)null;
      ((GameEventArgs)diceEventArgs).EventType = (EventType)0;
      ((GameEventArgs)diceEventArgs).NeedResponse = false;
      this.PopulateWithArgs(diceEventArgs, (string[])null);
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