// <copyright file="GiveOverlordCardsEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
    public partial class GiveOverlordCardsEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException620()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[10];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      ss[5] = "1";
      ss[6] = "1";
      ss[7] = "1";
      ss[8] = "1";
      ss[9] = "1";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException387()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[9];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      ss[5] = "1";
      ss[6] = "1";
      ss[7] = "1";
      ss[8] = "1";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException336()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[6];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      ss[5] = "1";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
public void PopulateWithArgs48()
{
    GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
    int[] ints = new int[1];
    giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
    ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
    ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
    ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
    ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
    string[] ss = new string[3];
    ss[0] = "2";
    ss[1] = "1";
    ss[2] = "1";
    this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
    Assert.IsNotNull((object)giveOverlordCardsEventArgs);
    Assert.IsNotNull(giveOverlordCardsEventArgs.OverlordCardIds);
    Assert.AreEqual<int>(2, giveOverlordCardsEventArgs.OverlordCardIds.Length);
    Assert.AreEqual<int>(1, giveOverlordCardsEventArgs.OverlordCardIds[0]);
    Assert.AreEqual<int>(1, giveOverlordCardsEventArgs.OverlordCardIds[1]);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveOverlordCardsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveOverlordCardsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveOverlordCardsEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
public void PopulateWithArgs216()
{
    GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
    int[] ints = new int[1];
    giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
    ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
    ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
    ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
    ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
    string[] ss = new string[2];
    ss[0] = "1";
    ss[1] = "1";
    this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
    Assert.IsNotNull((object)giveOverlordCardsEventArgs);
    Assert.IsNotNull(giveOverlordCardsEventArgs.OverlordCardIds);
    Assert.AreEqual<int>(1, giveOverlordCardsEventArgs.OverlordCardIds.Length);
    Assert.AreEqual<int>(1, giveOverlordCardsEventArgs.OverlordCardIds[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveOverlordCardsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveOverlordCardsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveOverlordCardsEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException561()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-0";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException697()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[3];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException510()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException718()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException716()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0\0";
      ss[1] = "0\0";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException541()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException469()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "0";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException428()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\u0001";
      ss[1] = "\u0001";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException504()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0";
      ss[1] = "\0";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException465()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException999()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException825()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      this.PopulateWithArgs(giveOverlordCardsEventArgs, ss);
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
[PexGeneratedBy(typeof(GiveOverlordCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException354()
{
    try
    {
      GiveOverlordCardsEventArgs giveOverlordCardsEventArgs;
      int[] ints = new int[1];
      giveOverlordCardsEventArgs = new GiveOverlordCardsEventArgs(ints);
      ((GameEventArgs)giveOverlordCardsEventArgs).SenderId = 0;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventId = (string)null;
      ((GameEventArgs)giveOverlordCardsEventArgs).EventType = (EventType)0;
      ((GameEventArgs)giveOverlordCardsEventArgs).NeedResponse = false;
      this.PopulateWithArgs(giveOverlordCardsEventArgs, (string[])null);
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