// <copyright file="BoardTest.FloorTextureGet.g.cs">Copyright �  2011</copyright>
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
using Microsoft.Pex.Framework.Generated;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Model.Board
{
    public partial class BoardTest
    {
[TestMethod]
[PexGeneratedBy(typeof(BoardTest))]
public void FloorTextureGet599()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      global::Descent.Model.Board.Board board;
      Texture2D texture2D;
      board = new global::Descent.Model.Board.Board(2, 2, (Texture2D)null);
      texture2D = this.FloorTextureGet(board);
      disposables.Add((IDisposable)texture2D);
      disposables.Dispose();
      Assert.IsNull((object)texture2D);
      Assert.IsNotNull((object)board);
      Assert.AreEqual<int>(2, board.Width);
      Assert.AreEqual<int>(2, board.Height);
      Assert.IsNotNull(board.FiguresOnBoard);
      Assert.IsNotNull(board.FiguresOnBoard.Comparer);
      Assert.AreEqual<int>(0, board.FiguresOnBoard.Count);
      Assert.IsNull(board.FloorTexture);
    }
}
    }
}
