// <copyright file="AssignHeroEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class AssignHeroEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
public void Constructor01414()
{
    AssignHeroEventArgs assignHeroEventArgs;
    string[] ss = new string[2];
    ss[0] = "1";
    ss[1] = "1";
    assignHeroEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)assignHeroEventArgs);
    Assert.AreEqual<int>(1, assignHeroEventArgs.PlayerId);
    Assert.AreEqual<int>(1, assignHeroEventArgs.HeroId);
    Assert.AreEqual<int>(0, ((GameEventArgs)assignHeroEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)assignHeroEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)assignHeroEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)assignHeroEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException281()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-0";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException924()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException824()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "0\0";
      ss[1] = "0\0";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException813()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException25()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException74()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "0";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException101()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "\u0001";
      ss[1] = "\u0001";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException871()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "\0\0";
      ss[1] = "\0\0";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException780()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException386()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[2];
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException424()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      string[] ss = new string[0];
      assignHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException570()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
public void Constructor703()
{
    AssignHeroEventArgs assignHeroEventArgs;
    assignHeroEventArgs = this.Constructor(1, 1);
    Assert.IsNotNull((object)assignHeroEventArgs);
    Assert.AreEqual<int>(1, assignHeroEventArgs.PlayerId);
    Assert.AreEqual<int>(1, assignHeroEventArgs.HeroId);
    Assert.AreEqual<int>(0, ((GameEventArgs)assignHeroEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)assignHeroEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)assignHeroEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)assignHeroEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException843()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = this.Constructor(1, 0);
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
[PexGeneratedBy(typeof(AssignHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException243()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = this.Constructor(0, 0);
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
