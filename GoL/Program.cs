using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GoL
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowInstructions();
            var selectionInfo = Console.ReadKey();
            var primer = PrimeGridFromSelection(selectionInfo);

            var generationCount = 0;
            var grid = new Grid(primer);
            Console.WriteLine();
            while (true) 
            {
                generationCount++;
                DrawGrid(string.Format("Generation {0}", generationCount), grid);
                grid = grid.Evolve();
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.X)
                {
                    break;
                }
            }
            ShowSummary(generationCount);
            Console.ReadKey();
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!");
            Console.WriteLine("Press X after a generation is displayed to exit.");
            Console.WriteLine("Press any other key to see the next generation.");
            Console.WriteLine();
            Console.WriteLine("To start with a classic pattern, enter one of the characters below:");
            Console.WriteLine();
            Console.WriteLine("(B)linker");
            Console.WriteLine("B(e)acon");
            Console.WriteLine("(T)oad");
            Console.WriteLine();
            Console.WriteLine("...or choose (C) to use the customize board from file.");
        }

        private static List<List<Cell>> PrimeGridFromSelection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.B:
                    return Blinker;
                case ConsoleKey.E:
                    return Beacon;
                case ConsoleKey.T:
                    return Toad;
                case ConsoleKey.C:
                    return RowsFromFile();
                default:
                    throw new NotSupportedException(string.Format("The {0} key is not supported!", keyInfo.KeyChar));
            }
        }

        private static List<List<Cell>> RowsFromFile()
        {
            var rows = new List<List<Cell>>();
            var fileDir = ConfigurationManager.AppSettings["InputFile"]; // TODO: magic string
            var lines = System.IO.File.ReadAllLines(fileDir);
            foreach (var line in lines)
            {
                var cells = new List<Cell>();
                var chrs = line.ToCharArray();
                foreach (var chr in chrs)
                {
                    cells.Add(CellFromCharacter(chr.ToString()));
                }
                rows.Add(cells);
            }
            return rows;
        }

        private static Cell CellFromCharacter(string character)
        {
            return new Cell(DisplayChars.FirstOrDefault(v => v.Value == character).Key);
        }

        private static void ShowSummary(int generationCount)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("You viewed {0} generations.", generationCount));
            Console.WriteLine("Thank you for playing Conway's Game of Life! Goodbye!");
            Console.WriteLine("<press any key to exit>");
        }

        private static void DrawGrid(string generation, Grid grid)
        {
            Console.WriteLine(generation);
            foreach (var rowOfCells in grid.RowsOfCells)
            {
                foreach (var cell in rowOfCells)
                {
                    Console.Write(DisplayChars[cell.IsAlive]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // TODO: magic strings
        private static Dictionary<bool, string> DisplayChars = new Dictionary<bool, string> 
        {
            { Cell.ALIVE, ConfigurationManager.AppSettings["AliveDisplay"] },
            { Cell.DEAD, ConfigurationManager.AppSettings["DeadDisplay"] }
        };

        private static List<List<Cell>> Blinker = new List<List<Cell>>
        {
            new List<Cell> { new Cell(), new Cell(Cell.ALIVE), new Cell() },
            new List<Cell> { new Cell(), new Cell(Cell.ALIVE), new Cell() },
            new List<Cell> { new Cell(), new Cell(Cell.ALIVE), new Cell() }
        };

        private static List<List<Cell>> Toad = new List<List<Cell>>
        {
            new List<Cell> { new Cell(), new Cell(), new Cell(), new Cell() },
            new List<Cell> { new Cell(), new Cell(Cell.ALIVE), new Cell(Cell.ALIVE), new Cell(Cell.ALIVE) },
            new List<Cell> { new Cell(Cell.ALIVE), new Cell(Cell.ALIVE), new Cell(Cell.ALIVE), new Cell() },
            new List<Cell> { new Cell(), new Cell(), new Cell(), new Cell() },
        };

        private static List<List<Cell>> Beacon = new List<List<Cell>>
        {
            new List<Cell> { new Cell(Cell.ALIVE), new Cell(Cell.ALIVE), new Cell(), new Cell() },
            new List<Cell> { new Cell(Cell.ALIVE), new Cell(), new Cell(), new Cell() },
            new List<Cell> { new Cell(), new Cell(), new Cell(), new Cell(Cell.ALIVE) },
            new List<Cell> { new Cell(), new Cell(), new Cell(Cell.ALIVE), new Cell(Cell.ALIVE) },
        };
    }
}
