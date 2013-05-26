using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class Engine
    {        
        IRenderer renderer;
        IUserController userController;
        List<GameObject> allObjects;
        Field field = new Field(new MatrixCoords(0, 0));        
        
        static RandomObjectGenerator randomObjectGenerator = new RandomObjectGenerator();
        private double sleepTime;

        public Engine(IRenderer renderer, IUserController userController)
        {
            this.renderer = renderer;
            this.userController = userController;
            this.allObjects = new List<GameObject>();
        }

        public virtual void MovePlayerCarLeft()
        {
            DumboCar.getInstance(new MatrixCoords(20, 47), Lane.Right, 40).MoveLeft();
        }

        public virtual void MovePlayerCarRight()
        {
            DumboCar.getInstance(new MatrixCoords(20, 47), Lane.Right, 40).MoveRight();
        }

        public virtual void Run()
        {
            Timer.StartTime = DateTime.Now;
            Timer.timeToReachCheckpoint = 30;
            Timer.TimeLeft = Timer.timeToReachCheckpoint;
            var playerCar = DumboCar.getInstance(new MatrixCoords(20, 47), Lane.Right, 40);
            playerCar.Speed = 40;
            playerCar.Points = 0;

            while (true)
            {
                this.renderer.RenderAll();

                if (playerCar.Speed == 0)
                {
                    sleepTime = 1000;
                }
                else
                {
                    sleepTime = (1 - playerCar.Speed / 310.0) * 900;
                }

                System.Threading.Thread.Sleep((int)sleepTime);

                this.userController.ProcessInput();

                this.renderer.ClearQueue();
                this.allObjects.RemoveAll(obj => obj.IsDestroyed);

                this.renderer.EnqueueForRendering(field);
                this.renderer.EnqueueForRendering(playerCar);


                SpeedInfo speedInfo = new SpeedInfo(playerCar.Speed);
                this.renderer.EnqueueForRendering(speedInfo);

                TimeLeftInfo timeInfo = new TimeLeftInfo(Timer.TimeLeft);
                this.renderer.EnqueueForRendering(timeInfo);

                PointsInfo pointsInfo = new PointsInfo(playerCar.Points);
                this.renderer.EnqueueForRendering(pointsInfo);

                playerCar.Update();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDetector.HandleCollisions(playerCar, allObjects);
                CollisionDetector.HandleScreenExit(allObjects, field);

                bool isProduced = true;                
                if (allObjects.Count!=0)
                {
                    foreach (var obj in allObjects)
                    {
                        if (obj.TopLeft.Row >= 0 && obj.TopLeft.Row <= 7)
                        {
                            isProduced = false;
                            break;
                        }                        
                    }
                    if (isProduced)
                    {
                        List<GameObject> producedObjects = randomObjectGenerator.GenerateObjects(playerCar);
                        allObjects.AddRange(producedObjects);  
                    }
                }
                else
                {
                    List<GameObject> producedObjects = randomObjectGenerator.GenerateObjects(playerCar);
                    allObjects.AddRange(producedObjects);
                }

                Timer.EndTime = DateTime.Now;
                if (Timer.EndTime > Timer.StartTime.AddSeconds(Timer.timeToReachCheckpoint))
                {
                    break;
                }                
                Timer.Tick();
            }
        }
    }
}
