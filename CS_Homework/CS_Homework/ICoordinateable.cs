using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    interface ICoordinateable
    {
        int XPos { get; set; }
        int YPos { get; set; }

        void SetPos(Screen[,] screenArr);
        void DeletePos(Screen[,] screenArr);
    }
}
