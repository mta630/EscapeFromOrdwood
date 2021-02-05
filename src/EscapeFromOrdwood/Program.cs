using System;
using Project.EscapeFromOrdwood;

namespace EscapeFromOrdwood
{
    class Program
    {
        static void Main(string[] args)
        {
            GameService game = new GameService();
            
            game.Setup();
            game.StartGame();

        }
    }
}
