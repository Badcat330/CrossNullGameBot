using System;

namespace VVP3_4
{
    public delegate bool Comands(string comandName);
    
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Game game = new Game();
                game.StartGame();
                Console.WriteLine("Press F to Finish....");
            } while (Console.ReadKey(true).Key != ConsoleKey.F);
        }
    }
}
