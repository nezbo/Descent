// <copyright file="RerollDicesEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
public void Constructor01ThrowsContractException542()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "-0\u0001";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException177()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "\0";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01278()
{
    RerollDicesEventArgs rerollDicesEventArgs;
    string[] ss = new string[2];
    ss[0] = "-0";
    ss[1] = "-0";
    rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException631()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "-0:";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException71501()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[2];
      ss[0] = "0";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01459()
{
    RerollDicesEventArgs rerollDicesEventArgs;
    string[] ss = new string[1];
    ss[0] = "0";
    rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException896()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "-\0";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException715()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "-";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException723()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = ":";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException736()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "\u0001";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException368()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "\0";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException332()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      ss[0] = "";
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException962()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[1];
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException818()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      string[] ss = new string[0];
      rerollDicesEventArgs = this.Constructor01(ss);
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
public void Constructor01ThrowsContractException350()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      rerollDicesEventArgs = this.Constructor01((string[])null);
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
public void Constructor126()
{
    RerollDicesEventArgs rerollDicesEventArgs;
    int[] ints = new int[1];
    rerollDicesEventArgs = this.Constructor(ints);
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
public void ConstructorThrowsContractException207()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      int[] ints = new int[0];
      rerollDicesEventArgs = this.Constructor(ints);
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
public void ConstructorThrowsContractException717()
{
    try
    {
      RerollDicesEventArgs rerollDicesEventArgs;
      rerollDicesEventArgs = this.Constructor((int[])null);
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