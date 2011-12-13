// <copyright file="BoardTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Descent.Model.Board
{
    [TestClass]
    [PexClass(typeof(global::Descent.Model.Board.Board))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BoardTest
    {
        [PexMethod]
        public int WidthGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            int result = target.Width;
            return result;
            // TODO: add assertions to method BoardTest.WidthGet(Board)
        }
        [PexMethod]
        public bool SquareVisibleByPlayers(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            int x,
            int y
        )
        {
            bool result = target.SquareVisibleByPlayers(x, y);
            return result;
            // TODO: add assertions to method BoardTest.SquareVisibleByPlayers(Board, Int32, Int32)
        }
        [PexMethod]
        public void RespawnDeadHeroes([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            target.RespawnDeadHeroes();
            // TODO: add assertions to method BoardTest.RespawnDeadHeroes(Board)
        }
        [PexMethod]
        public Door[] RelevantDoorsGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            Door[] result = target.RelevantDoors;
            return result;
            // TODO: add assertions to method BoardTest.RelevantDoorsGet(Board)
        }
        [PexMethod]
        public void PlaceFigure(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            global::Descent.Model.Player.Figure.Figure figure,
            Point point
        )
        {
            target.PlaceFigure(figure, point);
            // TODO: add assertions to method BoardTest.PlaceFigure(Board, Figure, Point)
        }
        [PexMethod]
        public void OpenDoor([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point point)
        {
            target.OpenDoor(point);
            // TODO: add assertions to method BoardTest.OpenDoor(Board, Point)
        }
        [PexMethod]
        public void MoveFigure(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            global::Descent.Model.Player.Figure.Figure figure,
            Point point
        )
        {
            target.MoveFigure(figure, point);
            // TODO: add assertions to method BoardTest.MoveFigure(Board, Figure, Point)
        }
        [PexMethod]
        public void ItemSet01(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            Point p,
            Square value
        )
        {
            target[p] = value;
            // TODO: add assertions to method BoardTest.ItemSet01(Board, Point, Square)
        }
        [PexMethod]
        public void ItemSet(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            int x,
            int y,
            Square value
        )
        {
            target[x, y] = value;
            // TODO: add assertions to method BoardTest.ItemSet(Board, Int32, Int32, Square)
        }
        [PexMethod]
        public Square ItemGet01([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point p)
        {
            Square result = target[p];
            return result;
            // TODO: add assertions to method BoardTest.ItemGet01(Board, Point)
        }
        [PexMethod]
        public Square ItemGet(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            int x,
            int y
        )
        {
            Square result = target[x, y];
            return result;
            // TODO: add assertions to method BoardTest.ItemGet(Board, Int32, Int32)
        }
        [PexMethod]
        public bool IsValidStartSquare([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point point)
        {
            bool result = target.IsValidStartSquare(point);
            return result;
            // TODO: add assertions to method BoardTest.IsValidStartSquare(Board, Point)
        }
        [PexMethod]
        public bool IsThereLineOfSight01(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            global::Descent.Model.Player.Figure.Figure from,
            global::Descent.Model.Player.Figure.Figure to,
            bool ignoreMonsters
        )
        {
            bool result = target.IsThereLineOfSight(from, to, ignoreMonsters);
            return result;
            // TODO: add assertions to method BoardTest.IsThereLineOfSight01(Board, Figure, Figure, Boolean)
        }
        [PexMethod]
        public bool IsThereLineOfSight(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            Point from,
            Point to,
            bool ignoreMonsters
        )
        {
            bool result = target.IsThereLineOfSight(from, to, ignoreMonsters);
            return result;
            // TODO: add assertions to method BoardTest.IsThereLineOfSight(Board, Point, Point, Boolean)
        }
        [PexMethod]
        public bool IsStandable01([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point[] points)
        {
            bool result = target.IsStandable(points);
            return result;
            // TODO: add assertions to method BoardTest.IsStandable01(Board, Point[])
        }
        [PexMethod]
        public bool IsStandable(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            int x,
            int y
        )
        {
            bool result = target.IsStandable(x, y);
            return result;
            // TODO: add assertions to method BoardTest.IsStandable(Board, Int32, Int32)
        }
        [PexMethod]
        public bool IsSquareWithinBoard02([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point[] points)
        {
            bool result = target.IsSquareWithinBoard(points);
            return result;
            // TODO: add assertions to method BoardTest.IsSquareWithinBoard02(Board, Point[])
        }
        [PexMethod]
        public bool IsSquareWithinBoard01([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point point)
        {
            bool result = target.IsSquareWithinBoard(point);
            return result;
            // TODO: add assertions to method BoardTest.IsSquareWithinBoard01(Board, Point)
        }
        [PexMethod]
        public bool IsSquareWithinBoard(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            int x,
            int y
        )
        {
            bool result = target.IsSquareWithinBoard(x, y);
            return result;
            // TODO: add assertions to method BoardTest.IsSquareWithinBoard(Board, Int32, Int32)
        }
        [PexMethod]
        public Hero[] HeroesInTownGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            Hero[] result = target.HeroesInTown;
            return result;
            // TODO: add assertions to method BoardTest.HeroesInTownGet(Board)
        }
        [PexMethod]
        public int HeightGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            int result = target.Height;
            return result;
            // TODO: add assertions to method BoardTest.HeightGet(Board)
        }
        [PexMethod]
        public Texture2D FloorTextureGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            Texture2D result = target.FloorTexture;
            return result;
            // TODO: add assertions to method BoardTest.FloorTextureGet(Board)
        }
        [PexMethod]
        public Point[] FigureSquares([PexAssumeUnderTest]global::Descent.Model.Board.Board target, global::Descent.Model.Player.Figure.Figure figure)
        {
            Point[] result = target.FigureSquares(figure);
            return result;
            // TODO: add assertions to method BoardTest.FigureSquares(Board, Figure)
        }
        [PexMethod]
        public Dictionary<global::Descent.Model.Player.Figure.Figure, Point> FiguresOnBoardGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            Dictionary<global::Descent.Model.Player.Figure.Figure, Point> result = target.FiguresOnBoard;
            return result;
            // TODO: add assertions to method BoardTest.FiguresOnBoardGet(Board)
        }
        [PexMethod]
        public int Distance(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            Point here,
            Point there
        )
        {
            int result = target.Distance(here, there);
            return result;
            // TODO: add assertions to method BoardTest.Distance(Board, Point, Point)
        }
        [PexMethod]
        public global::Descent.Model.Board.Board Constructor(
            int width,
            int height,
            Texture2D floorTexture
        )
        {
            global::Descent.Model.Board.Board target
               = new global::Descent.Model.Board.Board(width, height, floorTexture);
            return target;
            // TODO: add assertions to method BoardTest.Constructor(Int32, Int32, Texture2D)
        }
        [PexMethod]
        public bool CanOverlordSpawn([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point point)
        {
            bool result = target.CanOverlordSpawn(point);
            return result;
            // TODO: add assertions to method BoardTest.CanOverlordSpawn(Board, Point)
        }
        [PexMethod]
        public bool CanOpenDoor([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Point point)
        {
            bool result = target.CanOpenDoor(point);
            return result;
            // TODO: add assertions to method BoardTest.CanOpenDoor(Board, Point)
        }
        [PexMethod]
        public bool CanFigureMoveToPoint(
            [PexAssumeUnderTest]global::Descent.Model.Board.Board target,
            global::Descent.Model.Player.Figure.Figure figure,
            Point point
        )
        {
            bool result = target.CanFigureMoveToPoint(figure, point);
            return result;
            // TODO: add assertions to method BoardTest.CanFigureMoveToPoint(Board, Figure, Point)
        }
        [PexMethod]
        public Door[] AllDoorsGet([PexAssumeUnderTest]global::Descent.Model.Board.Board target)
        {
            Door[] result = target.AllDoors;
            return result;
            // TODO: add assertions to method BoardTest.AllDoorsGet(Board)
        }
        [PexMethod]
        public void AddDoor([PexAssumeUnderTest]global::Descent.Model.Board.Board target, Door door)
        {
            target.AddDoor(door);
            // TODO: add assertions to method BoardTest.AddDoor(Board, Door)
        }
    }
}
