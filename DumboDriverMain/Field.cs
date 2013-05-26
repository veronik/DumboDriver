using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumboDriver
{
    public class Field : IRenderable
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

        public Field( MatrixCoords topLeft)
        {
            this.topLeft = topLeft;
        }

        string strBody = "";
          string strField1 = @"           /          :          :          :          \      
          /                                             \     
          |           :          :          :           |     
          |                                             |     
          |           :          :          :           |     
         /                                               \    
         |            :          :          :            |    
         |                                               |    
         |            :          :          :            |    
        /                                                 \   
        |             :          :          :             |   
        |                                                 |   
        |             :          :          :             |   
       /                                                   \  
       |              :          :          :              |  
       |                                                   |  
       |              :          :          :              |  
      /                                                     \ 
      |               :          :          :               | 
      |                                                     | 
      |               :          :          :               | 
     /                                                       \
     |                :          :          :                |
     |                                                       |
     |                :          :          :                |
                                                              
                                                              ";

          string strField2 = @"           /                                           \      
          /           :          :          :           \     
          |                                             |     
          |           :          :          :           |     
          |                                             |     
         /            :          :          :            \    
         |                                               |    
         |            :          :          :            |    
         |                                               |    
        /             :          :          :             \   
        |                                                 |   
        |             :          :          :             |   
        |                                                 |   
       /              :          :          :              \  
       |                                                   |  
       |              :          :          :              |  
       |                                                   |  
      /               :          :          :               \ 
      |                                                     | 
      |               :          :          :               | 
      |                                                     | 
     /                :          :          :                \
     |                                                       |
     |                :          :          :                |
     |                                                       |
                                                              
                                                              ";


        protected char[,] body;
        public char[,] Body
        {
            get
            {
                if (Timer.IntervalCount % 2 == 0)
                {
                     strBody = strField2;
                }
                else
                {
                     strBody = strField1;
                }
                string[] strBodyArr = strBody.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                char[,] result = new char[strBodyArr.Length, strBodyArr[0].Length];
                for (int i = 0; i < strBodyArr.Length; i++)
                {
                    for (int j = 0; j < strBodyArr[0].Length; j++)
                    {
                        result[i, j] = strBodyArr[i][j];
                    }
                }
                return result;
            }
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
            return this.CopyBodyMatrix(this.Body);
        }
    }
}
