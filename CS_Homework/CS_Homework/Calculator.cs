using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        internal int MissileCollide(Screen[,] screenArr, ArrayList missileList, ArrayList enemyList, int playerAtt)
        {
            int getEXP = 0;
            int enemyX;
            int enemyY;
            Missile missile;

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyX = (int)((Enemy)enemyList[i]).CurrentXPos;
                enemyY = (int)((Enemy)enemyList[i]).CurrentYPos;
                for (int j = 0; j < missileList.Count; j++)
                {
                    missile = (Missile)missileList[j];
                    if((missile.YPos == enemyY && missile.XPos == (enemyX + 1))
                        || (missile.YPos == (enemyY+1) && missile.XPos == enemyX )
                        || (missile.YPos == (enemyY+1) && missile.XPos == (enemyX + 1)))
                    {
                        ((Enemy)enemyList[i]).Hp -= playerAtt;
                        missile.DeletePos(screenArr);
                        missileList.RemoveAt(j--);
                    }
                }
                if (((Enemy)enemyList[i]).Hp <= 0)
                {
                    getEXP += ((Enemy)enemyList[i]).Exp;
                    ((Enemy)enemyList[i]).DeletePos(screenArr);
                    enemyList.RemoveAt(i--);
                }
            }

            return getEXP;
        }

        internal void PlayerLevelUp(Player player)
        {
            player.Exp -= player.Level * 100;
            player.Hp += player.Level * 30;
            player.Att += player.Level * 5;
            player.Level++;
        }
    }
}
