// <copyright file="GiveHeroCardsEventArgsTest.Constructor01.g.cs">Copyright �  2011</copyright>
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
    public partial class GiveHeroCardsEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
public void Constructor01917()
{
    GiveHeroCardsEventArgs giveHeroCardsEventArgs;
    string[] ss = new string[5];
    ss[0] = "1";
    ss[1] = "3";
    ss[2] = "1";
    ss[3] = "1";
    ss[4] = "1";
    giveHeroCardsEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)giveHeroCardsEventArgs);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.PlayerId);
    Assert.IsNotNull(giveHeroCardsEventArgs.HeroCardIds);
    Assert.AreEqual<int>(3, giveHeroCardsEventArgs.HeroCardIds.Length);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds[0]);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds[1]);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds[2]);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveHeroCardsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveHeroCardsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveHeroCardsEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)giveHeroCardsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException673()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[11];
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
      ss[10] = "1";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException726()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[7];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      ss[5] = "1";
      ss[6] = "1";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException510()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[6];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      ss[5] = "1";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException823()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[5];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      ss[4] = "1";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
public void Constructor01210()
{
    GiveHeroCardsEventArgs giveHeroCardsEventArgs;
    string[] ss = new string[3];
    ss[0] = "1";
    ss[1] = "1";
    ss[2] = "1";
    giveHeroCardsEventArgs = this.Constructor01(ss);
    Assert.IsNotNull((object)giveHeroCardsEventArgs);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.PlayerId);
    Assert.IsNotNull(giveHeroCardsEventArgs.HeroCardIds);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds.Length);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveHeroCardsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveHeroCardsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveHeroCardsEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)giveHeroCardsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException209()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "-0";
      ss[1] = "-0";
      ss[2] = "-0";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException279()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[4];
      ss[0] = "1";
      ss[1] = "1";
      ss[2] = "1";
      ss[3] = "1";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException877()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "-\0";
      ss[1] = "-\0";
      ss[2] = "-\0";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException19()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "0\0";
      ss[1] = "0\0";
      ss[2] = "0\0";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException864()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "-";
      ss[1] = "-";
      ss[2] = "-";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException334()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = ":";
      ss[1] = ":";
      ss[2] = ":";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException376()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "0";
      ss[1] = "0";
      ss[2] = "0";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException781()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "\u0001";
      ss[1] = "\u0001";
      ss[2] = "\u0001";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException542()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "\0";
      ss[1] = "\0";
      ss[2] = "\0";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException699()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      ss[0] = "";
      ss[1] = "";
      ss[2] = "";
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException159()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[3];
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException518()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      string[] ss = new string[0];
      giveHeroCardsEventArgs = this.Constructor01(ss);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void Constructor01ThrowsContractException910()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      giveHeroCardsEventArgs = this.Constructor01((string[])null);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
public void Constructor829()
{
    GiveHeroCardsEventArgs giveHeroCardsEventArgs;
    int[] ints = new int[1];
    giveHeroCardsEventArgs = this.Constructor(1, ints);
    Assert.IsNotNull((object)giveHeroCardsEventArgs);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.PlayerId);
    Assert.IsNotNull(giveHeroCardsEventArgs.HeroCardIds);
    Assert.AreEqual<int>(1, giveHeroCardsEventArgs.HeroCardIds.Length);
    Assert.AreEqual<int>(0, giveHeroCardsEventArgs.HeroCardIds[0]);
    Assert.AreEqual<int>(0, ((GameEventArgs)giveHeroCardsEventArgs).SenderId);
    Assert.AreEqual<string>
        ((string)null, ((GameEventArgs)giveHeroCardsEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)giveHeroCardsEventArgs).EventType);
    Assert.AreEqual<bool>
        (false, ((GameEventArgs)giveHeroCardsEventArgs).NeedResponse);
}
[TestMethod]
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException309()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      int[] ints = new int[0];
      giveHeroCardsEventArgs = this.Constructor(1, ints);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException764()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      giveHeroCardsEventArgs = this.Constructor(1, (int[])null);
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
[PexGeneratedBy(typeof(GiveHeroCardsEventArgsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ConstructorThrowsContractException272()
{
    try
    {
      GiveHeroCardsEventArgs giveHeroCardsEventArgs;
      giveHeroCardsEventArgs = this.Constructor(0, (int[])null);
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
