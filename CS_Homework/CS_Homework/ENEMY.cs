using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Enemy : Character,ICoordinateable
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        int ICoordinateable.XPos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int ICoordinateable.YPos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private Screen enemyType;

        public Enemy(int x, int y, int level)
        {
            this.Level = level;
            switch (level)
            {
                case 2: Att = 16; Hp = 150; Exp = 35; enemyType = Screen.ENEMY2;  break;
                case 3: Att = 29; Hp = 250; Exp = 66; enemyType = Screen.ENEMY3; break;
                case 9: Att = 9999; Hp = 9999; Exp = 200; enemyType = Screen.ENEMY9; break;

                default: Att = 10; Hp = 50; Exp = 20; this.Level = 1; enemyType = Screen.ENEMY1; break;
            }
            XPos = x;
            YPos = y;            
        }
        
        public void SetPos(Screen[,] screenArr)
        {
            screenArr[(int)XPos, (int)YPos] = Screen.S_LAUNCHER;
            screenArr[(int)XPos + 1, (int)YPos] = enemyType;
            screenArr[(int)XPos, (int)YPos + 1] = enemyType;
            screenArr[(int)XPos + 1, (int)YPos + 1] = enemyType;
        }

        internal bool Move(Screen[,] screenArr, int playerYPos)
        {
            DeletePos(screenArr);
            XPos -= 0.3;
            if(playerYPos > (int)YPos )
                YPos += 0.2;
            else if(playerYPos < (int)YPos)
                YPos -= 0.2;

            if (XPos < 1)
                return false;
            else
                return true;
        }

        public void  DeletePos(Screen[,] screenArr)
        {
            screenArr[(int)XPos, (int)YPos] = Screen.BLANK;
            screenArr[(int)XPos + 1, (int)YPos] = Screen.BLANK;
            screenArr[(int)XPos, (int)YPos + 1] = Screen.BLANK;
            screenArr[(int)XPos + 1, (int)YPos + 1] = Screen.BLANK;
        }
    }
}
