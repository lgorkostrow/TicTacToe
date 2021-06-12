using System;
using System.Linq;
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
            return Data.All(item => item != EmptyCellValue);
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

        public bool IsWinningCombinationExists()
        {
            return CheckColumns() || CheckRows() || CheckDiagonals();
        }

        public MarkerEnum GetWinedMark()
        {
            if (!IsWinningCombinationExists())
            {
                throw new Exception("No wined combination");
            }

            if (CheckColumns())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Data[i] != " " && Data[i] == Data[i + 3] && Data[i] == Data[i + 6])
                    {
                        return (MarkerEnum) Convert.ToChar(Data[i]);
                    }
                }
            }

            if (CheckRows())
            {
                for (int i = 0; i < Data.Length; i += 3)
                {
                    if (Data[i] != " " && Data[i] == Data[i + 1] && Data[i] == Data[i + 2])
                    {
                        return (MarkerEnum) Convert.ToChar(Data[i]);
                    }
                }
            }
            
            return (MarkerEnum) Convert.ToChar(Data[4]);
        }

        internal bool IsCellEmpty(int index)
        {
            if (index >= Data.Length)
            {
                throw new Exception($"Undefined index {index}");
            }
            
            return Data[index] == EmptyCellValue;
        }
        
        internal void SetToEmptyValue(int index)
        {
            if (index >= Data.Length)
            {
                throw new Exception($"Undefined index {index}");
            }
            
            Data[index] = EmptyCellValue;
        }
    }
}