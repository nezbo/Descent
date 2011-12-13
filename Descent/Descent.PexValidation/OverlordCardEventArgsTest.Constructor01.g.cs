// <copyright file="OverlordCardEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class OverlordCardEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException926()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "00:";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException15()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-0:";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException24()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-\0";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException707()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = ":";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException170()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "-";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
public void Constructor01722()
{
    OverlordCardEventArgs overlordCardEventArgs;
    string[] ss = new string[1];
    ss[0] = "0";
    overlordCardEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)overlordCardEventArgs);
    Assert.AreEqual<int>(0, overlordCardEventArgs.OverlordCardId);
    Assert.AreEqual<int>(0, ((GameEventArgs)overlordCardEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)overlordCardEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)overlordCardEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)overlordCardEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException566()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "\u0001";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException568()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "\0";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException386()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      ss[0] = "";
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException196()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[1];
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException681()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      string[] ss = new string[0];
      overlordCardEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException493()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      overlordCardEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
public void Constructor253()
{
    OverlordCardEventArgs overlordCardEventArgs;
    overlordCardEventArgs = this.Constructor(1);
    Assert.IsNotNull((object)overlordCardEventArgs);
    Assert.AreEqual<int>(1, overlordCardEventArgs.OverlordCardId);
    Assert.AreEqual<int>(0, ((GameEventArgs)overlordCardEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)overlordCardEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)overlordCardEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)overlordCardEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(OverlordCardEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException804()
{
    try
    {
      OverlordCardEventArgs overlordCardEventArgs;
      overlordCardEventArgs = this.Constructor(0);
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
