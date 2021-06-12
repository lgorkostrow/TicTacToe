using System;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class Board
    {
        private const string EmptyCellValue = " ";
        
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
            if (Data[index] != EmptyCellValue)
            {
                throw new Exception($"Cell with index: {index} already filled");
            }

            Data[index] = mark.ToString();
        }

        public bool IsFilled()
        {
            foreach (var item in Data)
            {
                if (item == EmptyCellValue)
                {
                    return false;
                }
            }

            return true;
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
            for (int i = 0; i < Data.Length; i += 3)
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