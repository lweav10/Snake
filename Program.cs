//Main program

using System.Numerics;
using Snake;

namespace Game
{
    class Program() {

        static void Main()
        {
            List<VectorInt> Snake = [new(5,5)];
            Direction direction = Direction.Right;
            
            Grid Board = [];
            KeyManager KeyManager = new();
            int Frame = 0;
            bool debug = true;

            bool isRunning = true;

            Console.CursorVisible = false;
            while (isRunning)
            {

                //Init frame
                Frame++;
                Console.SetCursorPosition(0, 0);
                Board = InitBoard(Board);

                //Update code here
                VectorInt move = new VectorInt(0, 0);

                foreach (VectorInt coord in Snake)
                {
                    Board[coord.Y][coord.X] = 'O';
                }

                if (Frame % 5000 == 0)
                {
                    move = direction switch
                    {
                        Direction.Up => new(0, -1),
                        Direction.Down => new(0, 1),
                        Direction.Left => new(-1, 0),
                        Direction.Right => new(1, 0),
                        _ => new(0, 0),
                    };
                }

                Snake[0] = VectorInt.Add(Snake[0],move);


                //render frame
                Renderer.Render(Board, Frame, debug: debug);

                if (KeyManager.KeyPressed(ConsoleKey.Escape))
                {
                    isRunning = false;
                }
            }
        }



        //Fill a board with empty spaces
        static Grid InitBoard(Grid board, int height = 10, int width = 10)
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
    }
}
