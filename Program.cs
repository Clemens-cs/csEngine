using System;
using csEngine.Core;
using csEngine.Physics;

namespace csEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("csEngine!");
            Game game = new Game();
            physicsEngine physics = new physicsEngine();
            coreEngine engine = new coreEngine(300,300,60,game,physics);

            engine.start();
        }
    }
}


