using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum eDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    };
    class Index
    {
        public int row { get; set; }
        public int col { get; set; }
        public bool visited { get; set; }
        public int value { get; set; }
        public Index(int i_Row = 0, int i_Col = 0)
        {
            visited = false;
            value = (i_Col + i_Row) % 2;
            row = i_Row;
            col = i_Col;
        }
        public override string ToString()
        {
            return string.Format(@"({0},{1})", this.row, this.col);
        }
    };
    class subMarine
    {
        public Index[,] mat { get; set; }
        private const int row = 6;
        private const int col = 6;
        private Random rnd = new Random();
        public List<List<Index>> subMarines { get; set; }

        public subMarine()
        {
            mat = new Index[row, col];
            initMat();
            printMat();
            Console.WriteLine();
            List<List<Index>> result = searchForSubMarines();
            foreach (var li in result)
            {
                foreach (var item in li)
                {
                    Console.Write(item.ToString() + ",");
                }
                Console.WriteLine();
            }
        }
        private void initMat()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mat[i, j] = new Index();
                    mat[i, j].col = j;
                    mat[i, j].row = i;
                    mat[i, j].visited = false;
                    mat[i, j].value =Math.Abs((i + rnd.Next() + j * rnd.Next()) % 2);
                }
            }
        }
        private void printMat()
        {
           
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(mat[i,j].value + " ");
                    
                }
                Console.WriteLine();
            }
        }

        private List<List<Index>> searchForSubMarines()
        {
            List<List<Index>> subMarines = new List<List<Index>>();
            List<Index> currentSub = new List<Index>();
            eDirection currentSearchDirection = eDirection.NONE;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!mat[i, j].visited && mat[i,j].value == 1)
                    {
                        if (currentSearchDirection == eDirection.NONE)
                        {
                            currentSearchDirection = checkForNeighborsDirection(i, j);
                        }
                        int tempI = i;
                        int tempJ = j;
                        searchForCurrentSub(subMarines, ref currentSub, ref currentSearchDirection, ref tempI, ref tempJ);                    
                        mat[i, j].visited = true;
                    }
                }
            }
            return subMarines;
        }

        private void searchForCurrentSub(List<List<Index>> subMarines, ref List<Index> currentSub, ref eDirection currentSearchDirection, ref int tempI, ref int tempJ)
        {
            while (currentSearchDirection != eDirection.NONE)
            {
                currentSub.Add(mat[tempI, tempJ]);
                mat[tempI, tempJ].visited = true;
                if (currentSearchDirection == eDirection.RIGHT) { tempJ++; }
                if (currentSearchDirection == eDirection.LEFT) { tempJ--; }
                if (currentSearchDirection == eDirection.UP) { tempI--; }
                if (currentSearchDirection == eDirection.DOWN) { tempI++; }
                bool continueDirection = checkForSpecificDirection(currentSearchDirection, tempI, tempJ);
                if (!continueDirection)
                {
                    if (checkCordLimit(tempI, row) && checkCordLimit(tempJ, col))
                    {
                        currentSub.Add(mat[tempI, tempJ]);
                        mat[tempI, tempJ].visited = true;
                    }
                    currentSearchDirection = eDirection.NONE;
                }
            }
            if (currentSub.Count > 1)
            {
                subMarines.Add(currentSub);
            }
            currentSub = new List<Index>();
        }

        private bool checkForSpecificDirection(eDirection i_DirectionToLook ,int i_I,int i_J)
        {
            switch (i_DirectionToLook)
            {
                case eDirection.UP:
                    return checkCordLimit(i_I - 1, row) && mat[i_I - 1, i_J].value == 1 && mat[i_I - 1, i_J].visited == false;
                case eDirection.DOWN:
                    return checkCordLimit(i_I + 1, row) && mat[i_I + 1, i_J].value == 1 && mat[i_I + 1, i_J].visited == false;
                case eDirection.RIGHT:
                    return checkCordLimit(i_J + 1, col) && mat[i_I, i_J + 1].value == 1 && mat[i_I, i_J + 1].visited == false;
                case eDirection.LEFT:
                    return checkCordLimit(i_J - 1, col) && mat[i_I, i_J - 1].value == 1 && mat[i_I, i_J - 1].visited == false;
                default:
                    return false;
            }
        }
        private eDirection checkForNeighborsDirection(int i_I, int i_J)
        {
            if ((checkCordLimit(i_J + 1, col) && mat[i_I, i_J + 1].value == 1))
            {
                return eDirection.RIGHT;
            }
            if ((checkCordLimit(i_I+1,row) && mat[i_I + 1, i_J].value == 1))
            {
                return eDirection.DOWN;
            }
            if ((checkCordLimit(i_J - 1, col) && mat[i_I, i_J - 1].value == 1))
            {
                return eDirection.LEFT;
            }
            if ((checkCordLimit(i_I - 1, row) && mat[i_I - 1, i_J].value == 1))
            {
                return eDirection.UP;
            }
            return eDirection.NONE;
        }

        private bool checkCordLimit(int i_Cord, int i_Limit)
        {
            return i_Cord >= 0 && i_Cord < i_Limit;
        }
    }

}
