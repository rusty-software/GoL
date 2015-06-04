using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    public class Cell
    {
        public const bool DEAD = false;
        public const bool ALIVE = true;

        private bool isAlive;

        public Cell(bool isAlive = DEAD)
        {
            this.isAlive = isAlive;
        }

        public Cell EvolveFrom(List<Cell> neighbors)
        {
            var liveNeighborCount = neighbors.Count(c => c.IsAlive);
            if (liveNeighborCount < 2 && IsAlive)
            {
                return new Cell(DEAD);
            }
            if (liveNeighborCount > 3 && IsAlive)
            {
                return new Cell(DEAD);
            }
            if ((liveNeighborCount == 2 || liveNeighborCount == 3) && IsAlive)
            {
                return new Cell(ALIVE);
            }
            if (liveNeighborCount == 3 && IsDead)
            {
                return new Cell(ALIVE);
            }
            return new Cell(isAlive);
        }

        public bool IsDead
        {
            get { return !isAlive; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }
    }
}
