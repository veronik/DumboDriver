using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DumboDriver
{

    class DumboDriverMain
    {
        const int FieldRows = 27;
        const int FieldCols = 62;

        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }        

        static void Main(string[] args)        {
            RemoveScrollBars();
            Console.WindowHeight = Console.LargestWindowHeight - 20;
            Timer.timeToReachCheckpoint = 30;
            bool inGame = true;
          
            Console.Clear();

            while (inGame)
            {
                IRenderer renderer = new ConsoleRenderer(FieldRows, FieldCols);
                IUserController keyboard = new KeyboardInterface();
                Engine gameEngine = new Engine(renderer, keyboard);

                renderer.RenderAll();                

                keyboard.OnLeftPressed += (sender, eventInfo) =>
                {
                    gameEngine.MovePlayerCarLeft();
                };

                keyboard.OnRightPressed += (sender, eventInfo) =>
                {
                    gameEngine.MovePlayerCarRight();
                };

                gameEngine.Run();

                Console.WriteLine("\nThe time is over!\nPress ENTER to play again and any other key to exit");
                ConsoleKeyInfo result = Console.ReadKey();
                if (result.Key != ConsoleKey.Enter)
                {
                    inGame = false;
                }
                Console.Clear();
            }
        }
    }
}
