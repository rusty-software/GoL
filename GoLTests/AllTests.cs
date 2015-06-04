using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GoL;

namespace GoLTests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void FewerThanTwoLiveNeighborsCausesDeath()
        {
            var row1 = new List<Cell> {new Cell(), new Cell()};
            var row2 = new List<Cell> {new Cell(true), new Cell()};
            var cells = new List<List<Cell>> { row1, row2 };
            var grid = new Grid(cells);

            var evolvedGrid = grid.Evolve();

            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
        }

        [TestMethod]
        public void MoreThanThreeLiveNeighborsCausesDeath()
        {
            var row1 = new List<Cell> { new Cell(true), new Cell(true), new Cell(true) };
            var row2 = new List<Cell> { new Cell(true), new Cell(true), new Cell(true) };
            var row3 = new List<Cell> { new Cell(true), new Cell(true), new Cell(true) };
            var cells = new List<List<Cell>> { row1, row2, row3 };
            var grid = new Grid(cells);

            var evolvedGrid = grid.Evolve();

            Assert.IsTrue(evolvedGrid.RowsOfCells[0][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][1].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][2].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][1].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][2].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][1].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][2].IsAlive);
        }

        [TestMethod]
        public void TwoNeighborsLives()
        {
            var row1 = new List<Cell> { new Cell(true), new Cell(), new Cell() };
            var row2 = new List<Cell> { new Cell(), new Cell(true), new Cell() };
            var row3 = new List<Cell> { new Cell(), new Cell(), new Cell(true) };
            var cells = new List<List<Cell>> { row1, row2, row3 };
            var grid = new Grid(cells);

            var evolvedGrid = grid.Evolve();

            Assert.IsTrue(evolvedGrid.RowsOfCells[0][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][1].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][2].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][1].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][2].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][0].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[2][0].IsDead);
        }

        [TestMethod]
        public void ThreeNeighborsLives()
        {
            var row1 = new List<Cell> { new Cell(true), new Cell(true), new Cell() };
            var row2 = new List<Cell> { new Cell(true), new Cell(true), new Cell() };
            var cells = new List<List<Cell>> { row1, row2 };
            var grid = new Grid(cells);

            var evolvedGrid = grid.Evolve();

            Assert.IsTrue(evolvedGrid.RowsOfCells[0][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][1].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][2].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][1].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][2].IsDead);
        }

        [TestMethod]
        public void DeadWithThreeNeighborsComesToLife()
        {
            var row1 = new List<Cell> { new Cell(true), new Cell(true), new Cell() };
            var row2 = new List<Cell> { new Cell(true), new Cell(), new Cell() };
            var cells = new List<List<Cell>> { row1, row2 };
            var grid = new Grid(cells);

            var evolvedGrid = grid.Evolve();

            Assert.IsTrue(evolvedGrid.RowsOfCells[0][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][1].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[0][2].IsDead);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][0].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][1].IsAlive);
            Assert.IsTrue(evolvedGrid.RowsOfCells[1][2].IsDead);
        }
    }


}
