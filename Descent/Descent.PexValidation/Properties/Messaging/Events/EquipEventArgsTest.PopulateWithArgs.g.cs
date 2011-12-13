// <copyright file="EquipEventArgsTest.PopulateWithArgs.g.cs">Copyright �  2011</copyright>
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
    public partial class EquipEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException71()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException527()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-00";
      ss[1] = "-00-";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException892()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "\0\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException21()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException49()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException322()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException362()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
public void PopulateWithArgs794()
{
    EquipEventArgs equipEventArgs;
    equipEventArgs = new EquipEventArgs(1, 0);
    ((GameEventArgs)equipEventArgs).SenderId = 0;
    ((GameEventArgs)equipEventArgs).EventId = (string)null;
    ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
    ((GameEventArgs)equipEventArgs).NeedResponse = false;
    string[] ss = new string[2];
    ss[0] = "0";
    ss[1] = "0";
    this.PopulateWithArgs(equipEventArgs, ss);
    Assert.IsNotNull((object)equipEventArgs);
    Assert.AreEqual<int>(0, equipEventArgs.EquipmentId);
    Assert.AreEqual<int>(0, equipEventArgs.InventoryField);
    Assert.AreEqual<int>(0, ((GameEventArgs)equipEventArgs).SenderId);
    Assert.AreEqual<string>((string)null, ((GameEventArgs)equipEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)equipEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)equipEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException252()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0\0";
      ss[1] = "\0\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException512()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException244()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException195()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException489()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      this.PopulateWithArgs(equipEventArgs, (string[])null);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException687()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      this.PopulateWithArgs(equipEventArgs, (string[])null);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException945()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[0];
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException401()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException464()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "";
      ss[1] = "";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException633()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "\0\0";
      ss[1] = "\0\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException873()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = ":";
      ss[1] = ":";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException72()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-";
      ss[1] = "-";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException136()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-\0";
      ss[1] = "-\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException105()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException225()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0\0";
      ss[1] = "\0\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException748()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-00";
      ss[1] = "-00-";
      this.PopulateWithArgs(equipEventArgs, ss);
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
[PexGeneratedBy(typeof(EquipEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PopulateWithArgsThrowsContractException202()
{
    try
    {
      EquipEventArgs equipEventArgs;
      equipEventArgs = new EquipEventArgs(1, 0);
      ((GameEventArgs)equipEventArgs).SenderId = 0;
      ((GameEventArgs)equipEventArgs).EventId = (string)null;
      ((GameEventArgs)equipEventArgs).EventType = (EventType)0;
      ((GameEventArgs)equipEventArgs).NeedResponse = false;
      string[] ss = new string[2];
      ss[0] = "-0";
      ss[1] = "-\0";
      this.PopulateWithArgs(equipEventArgs, ss);
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