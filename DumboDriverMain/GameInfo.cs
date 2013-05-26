using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
   public abstract class GameInfo : IRenderable
    {
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

        protected char[,] body;
        public char[,] Body
        {
            get { return body; }
            set { body = value; }
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
