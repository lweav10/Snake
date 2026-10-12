//Main program

using Snake;

namespace Game
{
    class Program()
    {

        static void Main()
        {
            //Pre loop initialisation

            Grid Board = [];
            KeyManager KeyManager = new();
            Random random = new();
            
            int Frame = 0;
            bool debug = true;
            bool isRunning = true;

            //Init Keyboard Checking
            Dictionary<Direction, bool> KeyState = new();

            KeyState.Add(Direction.Left, false);
            KeyState.Add(Direction.Right, false);
            KeyState.Add(Direction.Up, false);
            KeyState.Add(Direction.Down, false);

            //Init Snake and Apples
            List<VectorInt> Snake = [new(5, 5)];
            List<VectorInt> Apples = [new(random.Next(0, 9), random.Next(0, 9))];

            //Set initial movement direction
            Direction direction = Direction.Right;


            Console.CursorVisible = false;

            //Update Loop
            while (isRunning)
            {

                //Init frame
                Frame++;
                Console.SetCursorPosition(0, 0);
                Board = InitBoard(Board, Apples);

                //Update code here ----------------------------------------------------------------



                KeyState[Direction.Left] = KeyManager.KeyPressed(ConsoleKey.LeftArrow);
                KeyState[Direction.Right] = KeyManager.KeyPressed(ConsoleKey.RightArrow);
                KeyState[Direction.Up] = KeyManager.KeyPressed(ConsoleKey.UpArrow);
                KeyState[Direction.Down] = KeyManager.KeyPressed(ConsoleKey.DownArrow);

                foreach (KeyValuePair<Direction, bool> i in KeyState)
                {
                    if (i.Value && direction != i.Key) direction = i.Key;
                }


                VectorInt move = VectorInt.Zero;

                foreach (VectorInt coord in Snake)
                {
                    Board[coord.Y][coord.X] = 'O';
                }

                foreach (VectorInt coord in Apples)
                {
                    Board[coord.Y][coord.X] = '@';
                }


                if (Frame % 5000 == 0)
                {
                    move = direction switch
                    {
                        Direction.Up => VectorInt.Up,
                        Direction.Down => VectorInt.Down,
                        Direction.Left => VectorInt.Left,
                        Direction.Right => VectorInt.Right,
                        _ => VectorInt.Zero,
                    };
                }





                Snake[0] = VectorInt.Add(Snake[0], move);

                //---------------------------------------------------------------------------------

                //Render the board at the end of the frame
                Renderer.Render(Board, Frame, debug: debug);

                //Exit if ESCAPE pressed
                if (KeyManager.KeyPressed(ConsoleKey.Escape))
                {
                    isRunning = false;
                }
            }
        }



        //Fill a board with empty spaces
        static Grid InitBoard(Grid board, List<VectorInt> Apples, int height = 10, int width = 10)
        {
            board.Clear();
            for (int i = 0; i < height; i++)
            {
                board.Add([]);
            }

            foreach (List<char> list in board)
            {
                for (int j = 0; j < width; j++)
                {
                    list.Add(' ');
                }
            }

            return board;
        }

        static Grid SpawnApple(Grid board)
        {
            Random r = new();

            int width = board[0].Count;
            int height = board.Count;


            foreach (List<char> list in board)
            {
                foreach (char c in list)
                {
                    if (c == '@')
                    {
                        return board;
                    }
                }
            }

            char sel = 'Z';
            VectorInt pos = VectorInt.Zero;
            do
            {
                pos.X = r.Next(0, width - 1);
                pos.Y = r.Next(0, height - 1);

                sel = board[pos.Y][pos.X];
            } while (sel != ' ');

            board[pos.Y][pos.X] = '@';

            return board;
        }
    }
}
