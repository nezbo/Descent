// <copyright file="TokenEventArgsTest.ToString01.g.cs">Copyright �  2011</copyright>
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

namespace Descent.Messaging.Events
{
    public partial class TokenEventArgsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(TokenEventArgsTest))]
public void ToString01712()
{
    TokenEventArgs tokenEventArgs;
    string s;
    tokenEventArgs = new TokenEventArgs(1);
    ((GameEventArgs)tokenEventArgs).SenderId = 0;
    ((GameEventArgs)tokenEventArgs).EventId = (string)null;
    ((GameEventArgs)tokenEventArgs).EventType = (EventType)0;
    ((GameEventArgs)tokenEventArgs).NeedResponse = false;
    s = this.ToString01(tokenEventArgs);
    Assert.AreEqual<string>("1", s);
    Assert.IsNotNull((object)tokenEventArgs);
    Assert.AreEqual<int>(1, tokenEventArgs.NumberOfTokens);
    Assert.AreEqual<int>(0, ((GameEventArgs)tokenEventArgs).SenderId);
    Assert.AreEqual<string>((string)null, ((GameEventArgs)tokenEventArgs).EventId);
    Assert.AreEqual<EventType>
        ((EventType)0, ((GameEventArgs)tokenEventArgs).EventType);
    Assert.AreEqual<bool>(false, ((GameEventArgs)tokenEventArgs).NeedResponse);
}
    }
}
