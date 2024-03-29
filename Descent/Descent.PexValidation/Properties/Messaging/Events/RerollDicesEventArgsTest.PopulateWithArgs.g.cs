// <copyright file="RerollDicesEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
    public partial class RerollDicesEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException184()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-\0";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException617()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[4];
      ss[0] = "-00\0";
      ss[1] = "-";
      ss[2] = "-";
      ss[3] = "-";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException210()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-00\0";
      ss[1] = "";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
public void PopulateWithArgs261()
{
    RerollDicesEventArgs rerollDicesEventArgs;
    int[] ints = new int[1];
    rerollDicesEventArgs = new RerollDicesEventArgs(ints);
    ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
    ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
    ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
    ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
    string[] ss = new string[2];
    ss[0] = "0";
    ss[1] = "0";
    this.PopulateWithArgs(rerollDicesEventArgs, ss);
    Assert.IsNotNull((object)rerollDicesEventArgs);
    Assert.IsNotNull(rerollDicesEventArgs.DiceIds);
    Assert.AreEqual<int>(2, rerollDicesEventArgs.DiceIds.Length);
    Assert.AreEqual<int>(0, rerollDicesEventArgs.DiceIds[0]);
    Assert.AreEqual<int>(0, rerollDicesEventArgs.DiceIds[1]);
    Assert.AreEqual<int>(0, ((GameEventArgs)rerollDicesEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)rerollDicesEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)rerollDicesEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)rerollDicesEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException919()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "\0";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException379()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "\0";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException768()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "0:";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException99()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "-";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
public void PopulateWithArgs436()
{
    RerollDicesEventArgs rerollDicesEventArgs;
    int[] ints = new int[1];
    rerollDicesEventArgs = new RerollDicesEventArgs(ints);
    ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
    ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
    ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
    ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
    string[] ss = new string[1];
    ss[0] = "0";
    this.PopulateWithArgs(rerollDicesEventArgs, ss);
    Assert.IsNotNull((object)rerollDicesEventArgs);
    Assert.IsNotNull(rerollDicesEventArgs.DiceIds);
    Assert.AreEqual<int>(1, rerollDicesEventArgs.DiceIds.Length);
    Assert.AreEqual<int>(0, rerollDicesEventArgs.DiceIds[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)rerollDicesEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)rerollDicesEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)rerollDicesEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)rerollDicesEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException630()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-\0";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException638()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException810()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = ":";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException176()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "\0";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException121()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "";
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException400()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      string[] ss = new string[1];
      this.PopulateWithArgs(rerollDicesEventArgs, ss);
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
[PexGeneratedBy(typeof(RerollDicesEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException780()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[1];
      rerollDicesEventArgs = new RerollDicesEventArgs(ints);
      ((GameEventArgs)rerollDicesEventArgs).SenderId = 0;
      ((GameEventArgs)rerollDicesEventArgs).EventId = (string)null;
      ((GameEventArgs)rerollDicesEventArgs).EventType = (EventType)0;
      ((GameEventArgs)rerollDicesEventArgs).NeedResponse = false;
      this.PopulateWithArgs(rerollDicesEventArgs, (string[])null);
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
