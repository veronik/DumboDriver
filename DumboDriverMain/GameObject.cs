using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public abstract class GameObject : IRenderable, ICollidable
    {
        protected int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private Lane lane;
        public Lane Lane
        {
            get { return lane; }
            set { lane = value; }
        }

        protected MatrixCoords topLeft;
        public MatrixCoords TopLeft
        {
            get
            {
                return new MatrixCoords(topLeft.Row, topLeft.Col);
            }

            protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col);
            }
        }        

        private char[,] body;
        public char[,] Body
        {
            get { return body; }
            set { body = value; }
        }

        protected bool isDestroyed;
        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        protected GameObject(MatrixCoords topLeft, char[,] body, Lane lane)
        {
            this.TopLeft = topLeft;
            this.lane = lane;
            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);
            this.body = this.CopyBodyMatrix(body);
        }

        public virtual void Update()
        {
            this.topLeft.Row += this.speed;
        }

        public virtual void RespondToCollision(DumboCar car)
        {
        }

        public virtual void ExitScreen()
        {
            this.isDestroyed = true;
        }

        char[,] CopyBodyMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }
            return result;
        }

        public virtual MatrixCoords GetTopLeft()
        {
            return this.TopLeft;
        }

        public virtual char[,] GetImage()
        {
            return this.CopyBodyMatrix(this.body);
        }
    }
}
