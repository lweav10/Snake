using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Renderer
    {
        public Renderer() { }
        
        public static void Render(Grid board, int frame, int ignoreTop = 0, bool debug = false)
        {
            string buffer = "";
            int height = board.Count;
            int width = board[0].Count;

            board = FormatBoard(board, width);

            int r = 0;
            string header = "";
            do
            {
                header += "=";
                r++;
            } while (r != (width*2)+2);

            buffer += header+"\n";
            
            for (int i = ignoreTop; i < height; i++)
            {
                string line = "|";
                for (int j = 0; j < width; j++)
                {
                    line += " ";
                    line += board[i][j].ToString();
                }
                line += "|";
                buffer += line+"\n";
            }
            buffer += header + "\n";

            Console.WriteLine(buffer);
            if (debug) Console.WriteLine($"Frame: {frame}");
        }

        private static Grid FormatBoard(Grid board, int width)
        {
            foreach (List<char> l in board)
            {
                if (l.Count > width)
                {
                    do
                    {
                        l.RemoveAt(l.Count - 1);
                    } while (l.Count != width);
                }
                else if (l.Count > width)
                {
                    do
                    {
                        l.Add('X');
                    } while (l.Count != width);

                }
            }

            return board;
        }
    }
}
