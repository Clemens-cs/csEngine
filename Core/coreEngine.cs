using System;
using System.Threading;
using csEngine.Rendering;
using csEngine.Physics;
namespace csEngine.Core
{
    public class coreEngine
    {
        private bool isRunning;
        private Game game;
        private renderingEngine _renderingEngine;
        private physicsEngine _physicsEngine;
        private int width;
        private int height;
        private double frameTime;

        public renderingEngine getRenderingEngine() { return _renderingEngine; }
        public physicsEngine getPhysicsEngine() { return _physicsEngine; }

        public coreEngine(int width, int height, double framerate, Game game, physicsEngine pEngine)
        {
            this.isRunning = false;
            this.game = game;
            this._physicsEngine = pEngine;
            this.width = width;
            this.height = height;
            this.frameTime = 1.0 / framerate;
            //game.setEngine(this)
        }

        public void createWindow()
        {
            this._renderingEngine = new renderingEngine();
        }

        public void start()
        {
            if (isRunning)
                return;

            run();
        }

        public void stop()
        {
            if (!isRunning)
                return;

            isRunning = false;
        }

        private void run()
        {
            isRunning = true;

            int frames = 0;
            double frameCounter = 0;

            //game.init();

            double lastTime = Time.getTime();
            double unprocessedTime = 0;

            while (isRunning)
            {
                bool render = false;

                double startTime = Time.getTime();
                double passedTime = startTime - lastTime;
                lastTime = startTime;

                unprocessedTime += passedTime;
                frameCounter += passedTime;

                while(unprocessedTime > frameTime)
                {
                    render = true;

                    unprocessedTime -= frameTime;

                    //if(window.iscloserewuested) stop();

                    //game.input((float) frameTime);
                    //Input.update();

                    //game.Update(float frameTime);

                    if(frameCounter >= 1.0)
                    {
                        Console.WriteLine(frames);
                        frames = 0;
                        frameCounter = 0;
                    }
                }

                if (render)
                {
                    //game.render(renderingEngine);
                    //window.render();
                    frames++;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }

            cleanUp();
        }

        private void cleanUp()
        {
            //Window.Dispose();
        }
    }
}
