using System;
using System.Threading;

/*namespace Diveria.TicTacToe
{
    class TicTacToe
    {
        const int PLAYERS = 2;
        Board _board;
        Person[] _person;
        Turn _turn;

        public TicTacToe()
        {
            this._board = new Board();
            this._person = new Person[PLAYERS]
                {
                    new Person(new X()),
                    new Person(new Y())
                };
            this._turn = new Turn(this._person.Length);
        }

        static void Main(string[] args)
        {
            new TicTacToe().Play();
        }

        private void Play()
        {
            
            this.DisplayTitle();
            Person p = null;
            do
            {
                p = this._person[this._turn.Next()];
                this.DisplayGame(p);
                this._board.Move(p);
            } while (!this._board.CheckWin() && !this._board.IsFull());
            if (this._board.CheckWin())
            {
                this.DisplayWinner(p);
            }
            else
            {
                this.DisplayDraw();
            }

        }


        private void DisplayGame(Person p)
        {
            Console.Clear();
            p.Display();
            this._board.Display();
        }

        private void DisplayTitle()
        {
            Console.WriteLine(" -- Tic Tac Toe -- ");
            Thread.Sleep(1200);
            Console.Clear();
        }

        private void DisplayDraw()
        {
            Console.WriteLine();
            Console.WriteLine("No one won.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        private void DisplayWinner(Person p)
        {
            Console.Clear();
            this._board.Display();
            Console.WriteLine();

            p.DisplayWinner();
            Console.ReadKey();
        }
    }
    internal class Board
    {
        const int BOARD_SIZE = 9;
        const int COLUMN_SIZE = 3;
        const int ROW_SIZE = 3;
        private Symbol[] _boxs;
        private int _moveCount;

        public Board()
        {
            this._boxs = new Symbol[BOARD_SIZE];
            Symbol n = new NULL();
            for (int i = 0; i < this._boxs.Length ; i++)
            {
                this._boxs[i] = n;
            }
            _moveCount = 0;
        }
        internal bool IsFull()
        {
            return this._moveCount == BOARD_SIZE;
        }

        internal void Move(Person p)
        {
            bool error;
            int selTemp;
            do
            {
                this.ShowEnterMoveMessage(p);
                int.TryParse(Console.ReadLine(), out selTemp);
                error = WrongSelectionEntered(selTemp) || NotVacant(selTemp);
                if (WrongSelectionEntered(selTemp))
                {
                    this.DisplayWrongSelectionEntered();
                }
                else if (NotVacant(selTemp))
                {
                    this.DisplayNotVacantError();
                }
            } while (error);
            this._boxs[selTemp - 1] = p.GetSymbol();
            this._moveCount++;
        }

        private void ShowEnterMoveMessage(Person person)
        {
            Console.WriteLine();
            Console.Write("What box do you want to place " );
            person.GetSymbol().Display();
            Console.Write(" in? (1-9)");
            Console.WriteLine();
            Console.Write("> ");
        }

        private bool NotVacant(int i)
        {
            return !this._boxs[i-1].IsNull();
        }

        private static bool WrongSelectionEntered(int i)
        {
            return i <= 0 || i > BOARD_SIZE;
        }

        internal void Display()
        {
            for (int i = 0; i < ROW_SIZE; i++)
            {
                for (int j = 0; j < COLUMN_SIZE; j++)
                {
                    _boxs[ (i*ROW_SIZE) + j].Display();
                    if ( j != COLUMN_SIZE - 1)
                    {
                        Console.Write('|');
                    }
                    
                }
                if (i<ROW_SIZE-1)
                {
                    Console.WriteLine();
                    Console.WriteLine(" --------- ");
                }
                
            }
        }

        internal bool CheckWin()
        {
            return CheckHorizontalWin() || CheckVerticalWin() || CheckDiagonalWin();
            
        }

        private bool CheckDiagonalWin()
        {
            bool leftDiagonal = this._boxs[0].IsEquals(this._boxs[4]) && this._boxs[0].IsEquals(this._boxs[8]);
            bool rightDiagonal = this._boxs[2].IsEquals(this._boxs[4]) && this._boxs[2].IsEquals(this._boxs[6]);

            return leftDiagonal || rightDiagonal;

        }
        private bool CheckHorizontalWin()
        {
            for (int i = 0; i <= this._boxs.Length-ROW_SIZE ; i=i+ROW_SIZE)
            {
                
                if (this._boxs[i].IsEquals(this._boxs[i + 1]) && this._boxs[i].IsEquals(this._boxs[i+2]))
                    return true;
            }
            return false;

        }
        private bool CheckVerticalWin()
        {
            for (int i = 0; i < COLUMN_SIZE; i++)
            {
                if (this._boxs[i].IsEquals(this._boxs[i + ROW_SIZE]) && this._boxs[i].IsEquals(this._boxs[(ROW_SIZE*2)+i]))
                    return true;
            }
            return false;

        }

        private void DisplayNotVacantError()
        {
            Console.WriteLine();
            Console.WriteLine("Error: box not vacant!");
            Console.WriteLine("Press any key to try again..");
            Console.ReadKey();
        }

        private void DisplayWrongSelectionEntered()
        {
            Console.WriteLine("Wrong selection entered!");
            Console.WriteLine("Press any key to try again..");
            Console.ReadKey();
        }

       

    }
    internal class Person
    {
        private Symbol _symbol;

        public Person(Symbol symbol)
        {
            this._symbol = symbol;
        }

        internal void Display()
        {
            Console.Write("Person ");
            this._symbol.Display();
            Console.WriteLine();
        }

        internal void DisplayWinner()
        {
            Console.Write("The winner is ");
            this._symbol.Display();
            Console.WriteLine("!");
        }

        internal Symbol GetSymbol()
        {
            return this._symbol;
        }
    }
    internal class Turn
    {
        private int _players;
        private int _current;

        public Turn(int players)
        {
            this._players = players;
            this._current = 0;

        }

        internal int Next()
        {
            this._current = (this._current + 1) % _players;
            return this._current;
        }
    }
    internal abstract class Symbol
    {
        private char _symbolChar;
        protected Symbol (char symbolChar)
        {
            _symbolChar = symbolChar;
        }
        internal void Display()
        {
            Console.Write(" {0} " , this._symbolChar);
        }

        internal bool IsEquals(Symbol symbol)
        {
            return (this._symbolChar == symbol._symbolChar && !this.IsNull() && !symbol.IsNull());
        }

        public abstract bool IsNull();
        
    }

    internal class Y : Symbol
    {
        public Y ():base('Y')
        {
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    internal class X : Symbol
    {
        public X() : base('X')
        {
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    internal class NULL : Symbol
    {
        public NULL() : base(' ')
        {
        }

        public override bool IsNull()
        {
            return true;
        }
    }
}*/