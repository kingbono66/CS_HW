﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Game2045
    {
        private bool isHeaderChanged;
        private bool isFooterChanged;
        private TimeManager timer;
        private Painter painter;
        private Screen[,] screenArr;
        private Player player;
        private Random random;
        private ArrayList enemyList;
        private Calculator calculator;
        private int frameCounter;


        internal void StartGame()
        {
            int msgTimer = 0;
            //초기화
            InitializeGame();

            //시작화면
            painter.DrawStartScreen();
            while (true)
            {
                //화면 그리기
                if (isHeaderChanged) painter.DrawHeader(); isHeaderChanged = false;
                if (isFooterChanged) painter.DrawFooter(); isFooterChanged = false;
                painter.DrawMainScreen(screenArr);
                painter.DrawPlayerInfo(player);
                painter.DrawGameInfo(frameCounter);
                //1프레임 사이클            
                if (timer.IsElapsed())
                {
                    frameCounter++;
                    //사용자 조작
                    PlayerProc();
                    FlushKey();
                    //적 생성
                    if (random.Next(0, ENEMY_FREQ) == 1)
                    {
                        Enemy enemy = new Enemy();
                        enemyList.Add(enemy);
                        enemy.SetPos(screenArr);
                    }
                    //적 이동
                    for ( int i = 0; i < enemyList.Count; i++)
                    {
                        if (((Enemy)enemyList[i]).Move(screenArr))
                            ((Enemy)enemyList[i]).SetPos(screenArr);
                        else
                            enemyList.RemoveAt(i--);
                    }
                    //충돌판정
                    int damaged = calculator.Collide(screenArr, player, enemyList);
                    if (damaged > 0)
                    {
                        painter.DrawDescription(MsgType.DAMAGE, damaged);
                        msgTimer = 10;
                    }
                    if(--msgTimer < 0)
                        painter.DrawDescription(MsgType.CLEAR, 0);



                }
                if (player.Hp <= 0)
                    break;
            }
            painter.DrawEnding();
        }

        private void FlushKey()
        {
            while (KeyAvailable)
                ReadKey(true);
        }

        private void PlayerProc()
        {
            ConsoleKey keys;
            if (KeyAvailable)
            {
                keys = ReadKey(true).Key;
                player.DeletePos(screenArr);
                switch (keys)
                {
                    case ConsoleKey.UpArrow:
                        player.YPos--;
                        break;
                    case ConsoleKey.DownArrow:
                        player.YPos++;
                        break;
                    case ConsoleKey.LeftArrow:
                        player.XPos--;
                        break;
                    case ConsoleKey.RightArrow:
                        player.XPos++;
                        break;
                }
                player.SetPos(screenArr);
            }
        }

        
        

        private void InitializeGame()
        {
            SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            WriteLine("게임 초기화 중입니다");
            CursorVisible = false;
            timer = new TimeManager();
            timer.SetStart();
            painter = new Painter();
            isHeaderChanged = true;
            isFooterChanged = true;
            screenArr = new Screen[WINDOW_WIDTH + 5, WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT + 5];
            for( int i = 0; i < WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT + 5; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH + 5; j++)
                    screenArr[j, i] = Screen.BLANK;
            }
            player = new Player(INITIAL_XPOS, INITIAL_YPOS);
            player.SetPos(screenArr);
            random = new Random();
            enemyList = new ArrayList();
            calculator = new Calculator();
            frameCounter = 0;



            Clear();
        }
        
    }

   


}
