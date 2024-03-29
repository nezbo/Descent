// <copyright file="ChatMessageEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class ChatMessageEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
public void Constructor01191()
{
    ChatMessageEventArgs chatMessageEventArgs;
    string[] ss = new string[1];
    ss[0] = "";
    chatMessageEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)chatMessageEventArgs);
    Assert.AreEqual<string>("", chatMessageEventArgs.Message);
    Assert.AreEqual<int>(0, ((GameEventArgs)chatMessageEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)chatMessageEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)chatMessageEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)chatMessageEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException717()
{
    try
    {
      ChatMessageEventArgs chatMessageEventArgs;
      string[] ss = new string[0];
      chatMessageEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException893()
{
    try
    {
      ChatMessageEventArgs chatMessageEventArgs;
      chatMessageEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
public void Constructor413()
{
    ChatMessageEventArgs chatMessageEventArgs;
    chatMessageEventArgs = this.Constructor("\0");
    Assert.IsNotNull((object)chatMessageEventArgs);
    Assert.AreEqual<string>("\0", chatMessageEventArgs.Message);
    Assert.AreEqual<int>(0, ((GameEventArgs)chatMessageEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)chatMessageEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)chatMessageEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)chatMessageEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException230()
{
    try
    {
      ChatMessageEventArgs chatMessageEventArgs;
      chatMessageEventArgs = this.Constructor((string)null);
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
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException935()
{
    try
    {
      ChatMessageEventArgs chatMessageEventArgs;
      chatMessageEventArgs = this.Constructor("");
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
[PexGeneratedBy(typeof(ChatMessageEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException362()
{
    try
    {
      ChatMessageEventArgs chatMessageEventArgs;
      string[] ss = new string[1];
      chatMessageEventArgs = this.Constructor01(ss);
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
