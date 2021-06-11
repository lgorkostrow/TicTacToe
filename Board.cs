using System;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public string[] Data { get; } = new string[9];

        public Board()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = " ";
            }
        }

        public void Mark(int index, MarkerEnum mark)
        {
            if (Data[index] != " ")
            {
                throw new Exception($"Cell with index: {index} already filled");
            }

            Data[index] = mark.ToString();
        }

        public bool IsFilled()
        {
            foreach (var item in Data)
            {
                if (item == " ")
                {
                    return false;
                }
            }

            return true;
        }

        public string Print()
        {
            var s = new StringBuilder();
            
            for (int i = 0; i < Data.Length; i++) 
            {
                if ((i + 1) % 3 == 0) 
                {
                    s.Append(Data[i]);
                    
                    if (i != Data.Length - 1) 
                    {
                        s.Append("\n-----\n");
                    }
                    
                    continue;
                } 
                
                s.Append(Data[i] + "|");
            }

            return s.ToString();
        }

        public string PrintCells()
        {
            var s = new StringBuilder();
            
            for (int i = 0; i < Data.Length; i++) 
            {
                if ((i + 1) % 3 == 0)
                {
                    s.Append(i);
                    
                    if (i != Data.Length - 1) 
                    {
                        s.Append("\n-----\n");
                    }
                    
                    continue;
                } 
                
                s.Append(i + "|");
            }

            return s.ToString();
        }

        public bool CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Data[i] != " " && Data[i] == Data[i + 3] && Data[i] == Data[i + 6])
                {
                    return true;
                }
            }
            
            return false;
        }
        
        public bool CheckRows()
        {
            for (int i = 0; i < 3; i += 3)
            {
                if (Data[i] != " " && Data[i] == Data[i + 1] && Data[i] == Data[i + 2])
                {
                    return true;
                }
            }
            
            return false;
        }
        
        public bool CheckDiagonals()
        {
            if (Data[0] != " " && Data[0] == Data[4] && Data[0] == Data[8] 
                || Data[2] != " " && Data[2] == Data[4] && Data[2] == Data[6])
            {
                return true;
            }
            
            return false;
        }
    }
}