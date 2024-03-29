// <copyright file="ChooseActionEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
    public partial class ChooseActionEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException468()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
public void PopulateWithArgs322()
{
    ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
    ((GameEventArgs)s0).SenderId = 0;
    ((GameEventArgs)s0).EventId = (string)null;
    ((GameEventArgs)s0).EventType = (EventType)0;
    ((GameEventArgs)s0).NeedResponse = false;
    string[] ss = new string[1];
    ss[0] = "1";
    this.PopulateWithArgs(s0, ss);
    Assert.IsNotNull((object)s0);
    Assert.AreEqual<ActionType>(ActionType.Advance, s0.ActionType);
    Assert.AreEqual<int>(0, ((GameEventArgs)s0).SenderId);
    Assert.AreEqual<string>((string)null, ((GameEventArgs)s0).EventId);
    Assert.AreEqual<EventType>((EventType)0, ((GameEventArgs)s0).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)s0).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException210()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException167()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "0\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException265()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = ":";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException794()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException36()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException906()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException593()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException520()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException176()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException213()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      this.PopulateWithArgs(s0, (string[])null);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException482()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      this.PopulateWithArgs(s0, (string[])null);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException398()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException7()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException418()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException147()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException203()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException351()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException603()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = ":";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException621()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "0\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException984()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-\0";
      this.PopulateWithArgs(s0, ss);
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
[PexGeneratedBy(typeof(ChooseActionEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException430()
{
    try
    {
      ChooseActionEventArgs s0 = new ChooseActionEventArgs((ActionType)0);
      ((GameEventArgs)s0).SenderId = 0;
      ((GameEventArgs)s0).EventId = (string)null;
      ((GameEventArgs)s0).EventType = (EventType)0;
      ((GameEventArgs)s0).NeedResponse = false;
      string[] ss = new string[1];
      ss[0] = "-0";
      this.PopulateWithArgs(s0, ss);
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
