using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Calculator
    {

        
        internal int Collide(Screen[,] screenArr, Player player, ArrayList enemyList)
        {
            int damaged = 0;
            int playerX = player.XPos;
            int playerY = player.YPos;
            foreach(Enemy e in enemyList)
            {
                int enemyX = (int)e.CurrentXPos;
                int enemyY = (int)e.CurrentYPos;
                if (( playerY == enemyY + 1 && playerX - enemyX <= -1 && playerX - enemyX >= - 3)
                    ||(playerY == enemyY && playerX - enemyX <= 1 && playerX - enemyX >= -6)
                    ||(playerY == enemyY - 1 && playerX - enemyX <= 1 && playerX - enemyX >= -5))
                {
                    player.Hp -= e.Att;
                    damaged = e.Att;
                    e.DeletePos(screenArr);
                    enemyList.Remove(e);
                    break;
                }
            }
            return damaged;
        }
    }
}
