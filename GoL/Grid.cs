using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    public class Grid
    {
        public List<List<Cell>> RowsOfCells { get; set; }
        public Grid(List<List<Cell>> cells)
        {
            RowsOfCells = cells;
        }

        public Grid Evolve()
        {
            var evolvedCells = new List<List<Cell>>();
            var yCount = RowsOfCells.Count;
            var xCount = RowsOfCells.First().Count;

            for (var yIndex = 0; yIndex < yCount; yIndex++)
            {
                var gridRow = new List<Cell>();
                for (var xIndex = 0; xIndex < xCount; xIndex++)
                {
                    var currentCell = RowsOfCells[yIndex][xIndex];
                    gridRow.Insert(xIndex, currentCell.EvolveFrom(NeighborsFor(yIndex, xIndex)));
                }
                evolvedCells.Insert(yIndex, gridRow);
            }
            return new Grid(evolvedCells);
        }

        private List<Cell> NeighborsFor(int yIndex, int xIndex)
        {
            var neighbors = new List<Cell>();
            for (var neighborY = yIndex - 1; neighborY <= yIndex + 1; neighborY++)
            {
                for (var neighborX = xIndex - 1; neighborX <= xIndex + 1; neighborX++)
                {
                    if (neighborY == yIndex && neighborX == xIndex)
                    {
                        continue;
                    }
                    if (neighborY < 0 || neighborY > RowsOfCells.Count - 1)
                    {
                        continue;
                    }
                    if (neighborX < 0 || neighborX > RowsOfCells.First().Count - 1)
                    {
                        continue;
                    }
                    neighbors.Add(RowsOfCells[neighborY][neighborX]);
                }
            }
            return neighbors;
        }
    }
}
