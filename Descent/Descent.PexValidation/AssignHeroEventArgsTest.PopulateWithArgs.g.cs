// <copyright file="AssignHeroEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException416()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException999()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgs467()
{
    AssignHeroEventArgs assignHeroEventArgs;
    assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
    ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
    ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
    ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
    ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
    string[] ss = new string[2];
    ss[0] = "1";
    ss[1] = "1";
    this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException354()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0\0";
      ss[1] = "0\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException684()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException31()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException109()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException210()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\u0001\0";
      ss[1] = "\u0001\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException761()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0";
      ss[1] = "\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException563()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException636()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException182()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException202()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      this.PopulateWithArgs(assignHeroEventArgs, (string[])null);
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
public void PopulateWithArgsThrowsContractException976()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      this.PopulateWithArgs(assignHeroEventArgs, (string[])null);
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
public void PopulateWithArgsThrowsContractException19()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException60()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException157()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException862()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0";
      ss[1] = "\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException812()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\u0001\0";
      ss[1] = "\u0001\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException350()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException670()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0";
      ss[1] = "0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException129()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException737()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "0\0";
      ss[1] = "0\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException517()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
public void PopulateWithArgsThrowsContractException885()
{
    try
    {
      AssignHeroEventArgs assignHeroEventArgs;
      assignHeroEventArgs = new AssignHeroEventArgs(1, 1);
      ((GameEventArgs)assignHeroEventArgs).SenderId = 0;
      ((GameEventArgs)assignHeroEventArgs).EventId = (string)null;
      ((GameEventArgs)assignHeroEventArgs).EventType = (EventType)0;
      ((GameEventArgs)assignHeroEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-0";
      this.PopulateWithArgs(assignHeroEventArgs, ss);
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
