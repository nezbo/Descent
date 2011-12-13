// <copyright file="PlaceHeroEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class PlaceHeroEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
public void Constructor01990()
{
    PlaceHeroEventArgs placeHeroEventArgs;
    string[] ss = new string[3];
    ss[0] = "1";
    ss[1] = "0";
    ss[2] = "0";
    placeHeroEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)placeHeroEventArgs);
    Assert.AreEqual<int>(1, placeHeroEventArgs.PlayerId);
    Assert.AreEqual<int>(0, placeHeroEventArgs.X);
    Assert.AreEqual<int>(0, placeHeroEventArgs.Y);
    Assert.AreEqual<int>(0, ((GameEventArgs)placeHeroEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)placeHeroEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)placeHeroEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)placeHeroEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException626()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "-0";
      ss[1] = "-0";
      ss[2] = "-0";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException104()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "-\0";
      ss[1] = "-\0";
      ss[2] = "-\0";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException17101()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "0\0";
      ss[1] = "0\0";
      ss[2] = "0\0";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException534()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = ":";
      ss[1] = ":";
      ss[2] = ":";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException938()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "-";
      ss[1] = "-";
      ss[2] = "-";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException595()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "0";
      ss[1] = "0";
      ss[2] = "0";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException171()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "\u0001";
      ss[1] = "\u0001";
      ss[2] = "\u0001";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException220()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "\0\0";
      ss[1] = "\0\0";
      ss[2] = "\0\0";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException727()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      ss[0] = "";
      ss[1] = "";
      ss[2] = "";
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException242()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[3];
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException288()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      string[] ss = new string[0];
      placeHeroEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException413()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      placeHeroEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
public void Constructor870()
{
    PlaceHeroEventArgs placeHeroEventArgs;
    placeHeroEventArgs = this.Constructor(1, 0, 0);
    Assert.IsNotNull((object)placeHeroEventArgs);
    Assert.AreEqual<int>(1, placeHeroEventArgs.PlayerId);
    Assert.AreEqual<int>(0, placeHeroEventArgs.X);
    Assert.AreEqual<int>(0, placeHeroEventArgs.Y);
    Assert.AreEqual<int>(0, ((GameEventArgs)placeHeroEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)placeHeroEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)placeHeroEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)placeHeroEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(PlaceHeroEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException205()
{
    try
    {
      PlaceHeroEventArgs placeHeroEventArgs;
      placeHeroEventArgs = this.Constructor(0, 0, 0);
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
