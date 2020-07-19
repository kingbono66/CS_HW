using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CS_Homework.Constants;

namespace CS_Homework
{
    class Painter
    {
        public void DrawHeader()
        {
            ClearLines(0, HEADER_HEIGHT);            
            DrawHorizontal(0);
            DrawHorizontal(HEADER_HEIGHT - 1);            
            DrawVertical(0, 0, HEADER_HEIGHT);
            DrawVertical(WINDOW_WIDTH - 1, 0, HEADER_HEIGHT);

            SetCursorPosition((WINDOW_WIDTH - TITLE.Length) / 2, HEADER_HEIGHT / 2);
            ForegroundColor = ConsoleColor.Green;
            Write(TITLE);
            SetCursorPosition(WINDOW_WIDTH - (DESCRIPTION.Length + 6), HEADER_HEIGHT -2 );
            ForegroundColor = ConsoleColor.Blue;
            Write(DESCRIPTION);
            ForegroundColor = ConsoleColor.White;

            //설명서
            SetCursorPosition(2, 1);
            Write("적종류");
            SetCursorPosition(2, 2);
            Write("노랑:레벨1  초록:레벨2  ");
            SetCursorPosition(2, 3);
            Write("파랑:레벨3  빨강:파괴불가(스킬로만 가능)");
            SetCursorPosition(2, 4);
            Write("스테이지1: 레벨1만 나옴");
            SetCursorPosition(2, 5);
            Write("스테이지2: 레벨1,2,3 나옴");
            SetCursorPosition(2, 6);
            Write("스테이지3: 레벨1만 안나옴");







            SetCursorPosition(0, 0);
        }
        public void DrawFooter()
        {
            int footerStartPos = WINDOW_HEIGHT - FOOTER_HEIGHT;

            ClearLines(footerStartPos, FOOTER_HEIGHT);            
            DrawHorizontal(footerStartPos);
            DrawHorizontal(WINDOW_HEIGHT - 1);            
            DrawVertical(0, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH - 1, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH / 3, footerStartPos, FOOTER_HEIGHT);
            DrawVertical(WINDOW_WIDTH * 2 / 3, footerStartPos, FOOTER_HEIGHT);
            SetCursorPosition(0, 0);
        }

        internal void DrawGameInfo(int frameCounter, int playTime, int score, int defeatNum, GameState gameState)
        {
            ClearWindow(WindowPos.RIGHT);
            if (playTime == 0) return;

            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1); Write("진행도: ");
            ForegroundColor = ConsoleColor.Magenta;
            Write((int)gameState + "스테이지");
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2); Write("경과시간/프레임레이트: ");
            ForegroundColor = ConsoleColor.Blue; 
            Write(playTime + "초/ " + frameCounter / playTime + "fps");
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 3); Write("점수: ");
            ForegroundColor = ConsoleColor.Magenta;
            Write(score);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 4); Write("적 격파수: ");
            ForegroundColor = ConsoleColor.Blue;
            Write(defeatNum);


            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(0,0);
        }

        internal void DrawPlayerInfo(Player player)
        {
            ClearWindow(WindowPos.LEFT);
            DrawLine(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1, ConsoleColor.White, "LEVEL: ");
            DrawLine(8, WINDOW_HEIGHT - FOOTER_HEIGHT + 1, ConsoleColor.Yellow, player.Level.ToString());
            DrawLine(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2, ConsoleColor.White, "HP: ");
            DrawLine(8, WINDOW_HEIGHT - FOOTER_HEIGHT + 2, ConsoleColor.Yellow, player.Hp.ToString());
            DrawLine(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 3, ConsoleColor.White, "ATT: ");
            DrawLine(8, WINDOW_HEIGHT - FOOTER_HEIGHT + 3, ConsoleColor.Yellow, player.Att.ToString());
            DrawLine(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 4, ConsoleColor.White, "EXP: ");
            DrawLine(8, WINDOW_HEIGHT - FOOTER_HEIGHT + 4, ConsoleColor.Yellow, player.Exp.ToString());

            DrawLine(20, WINDOW_HEIGHT - FOOTER_HEIGHT + 1, ConsoleColor.Red, "스킬");
            DrawLine(20, WINDOW_HEIGHT - FOOTER_HEIGHT + 2, ConsoleColor.White, "LEVEL1: ");
            DrawLine(30, WINDOW_HEIGHT - FOOTER_HEIGHT + 2, ConsoleColor.Green, "Blink");
            DrawLine(20, WINDOW_HEIGHT - FOOTER_HEIGHT + 3, ConsoleColor.White, "LEVEL2: ");
            DrawLine(30, WINDOW_HEIGHT - FOOTER_HEIGHT + 3, ConsoleColor.Green, "ExCalibur");
            DrawLine(20, WINDOW_HEIGHT - FOOTER_HEIGHT + 4, ConsoleColor.White, "LEVEL3: ");
            DrawLine(30, WINDOW_HEIGHT - FOOTER_HEIGHT + 4, ConsoleColor.Green, "Heal");

            SetCursorPosition(0, 0);
        }

        internal void DrawPause()
        {
            DrawLine(WINDOW_WIDTH / 3, HEADER_HEIGHT + 4, ConsoleColor.Magenta, "P    A    U    S    E");           
            SetCursorPosition(0, 0);
        }

        internal void DrawMainScreen(Screen[,] screenArr)
        {
            int screenHeiht = WINDOW_HEIGHT - FOOTER_HEIGHT;
            for( int i = HEADER_HEIGHT; i < screenHeiht; i++)
            {
                SetCursorPosition(0, i);
                for( int j = 0; j < WINDOW_WIDTH; j++)
                {
                    switch(screenArr[j,i - HEADER_HEIGHT])
                    {
                        case Screen.PLAYER: BackgroundColor = ConsoleColor.White; 
                            Write(" ");
                            BackgroundColor = ConsoleColor.Black;
                            break;
                        case Screen.D_LAUNCHER:
                            Write("=");
                            break;
                        case Screen.ENEMY1:
                            BackgroundColor = ConsoleColor.Yellow;
                            Write(" ");
                            BackgroundColor = ConsoleColor.Black;
                            break;
                        case Screen.ENEMY2:
                            BackgroundColor = ConsoleColor.Green;
                            Write(" ");
                            BackgroundColor = ConsoleColor.Black;
                            break;
                        case Screen.ENEMY3:
                            BackgroundColor = ConsoleColor.Blue;
                            Write(" ");
                            BackgroundColor = ConsoleColor.Black;
                            break;
                        case Screen.ENEMY9:
                            BackgroundColor = ConsoleColor.Red;
                            Write(" ");
                            BackgroundColor = ConsoleColor.Black;
                            break;
                        case Screen.S_LAUNCHER:
                            Write("-");
                            break;
                        case Screen.BASIC_MISSILE:
                            Write("@");
                            break;
                        default: Write(" ");
                            break;
                    }
                }
            }
        }

        internal void DrawEnding(Player player, int score, int playTime, int defeatNum)
        {
            Clear();
            SetWindowSize(51, 11);
            for (int i = 0; i < 50; i++)
                Write("=");
            for (int i = 0; i < 10; i++)
                WriteLine();
            for (int i = 0; i < 50; i++)
                Write("=");
            DrawVertical(0, 0, 11);
            DrawVertical(50, 0, 11);
            if(player.Hp <= 0)
                DrawLine(2,2, ConsoleColor.White,"GAME OVER");
            else
                DrawLine(2,2, ConsoleColor.White,"클리어를 축하합니다");
            DrawLine(2, 3, ConsoleColor.White, "남은 HP: ");
            DrawLine(18, 3, ConsoleColor.Green, player.Hp.ToString());
            DrawLine(2, 4, ConsoleColor.White, "적 격파수: ");
            DrawLine(18, 5, ConsoleColor.Green, defeatNum.ToString());
            DrawLine(2, 5, ConsoleColor.White, "총플레이타임: ");
            DrawLine(18, 5, ConsoleColor.Green, playTime.ToString());
            DrawLine(2, 6, ConsoleColor.White, "점수: ");
            DrawLine(18, 6, ConsoleColor.Green, score.ToString());
            DrawLine(14, 8, ConsoleColor.Red, "아무키나 누르고 종료하세요");
            ReadKey();
        }

        private void DrawLine(int x, int y, ConsoleColor color, string s)
        {
            SetCursorPosition(x, y);
            ForegroundColor = color;
            Write(s);
            ForegroundColor = ConsoleColor.White;
        }

        internal void DrawDescription(MsgType msgType, int value)
        {
            ClearWindow(WindowPos.MIDDLE);
            switch ( msgType)
            {
                case MsgType.DAMAGE: 
                    SetCursorPosition(WINDOW_WIDTH / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1); Write("피격당했습니다");
                    SetCursorPosition(WINDOW_WIDTH / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2);
                    ForegroundColor = ConsoleColor.Red;
                    Write($" {value}");
                    ForegroundColor = ConsoleColor.White;
                    Write("의 데미지를 입었습니다!!!");
                    SetCursorPosition(0, 0);
                    break;
                case MsgType.EXP:
                    SetCursorPosition(WINDOW_WIDTH / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1); Write("경험치");
                    SetCursorPosition(WINDOW_WIDTH / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2);
                    ForegroundColor = ConsoleColor.Blue;
                    Write($" {value}");
                    ForegroundColor = ConsoleColor.White;
                    Write("을 획득했습니다");
                    SetCursorPosition(0, 0);
                    break;                
                default: break;
            }

        }
        private void ClearWindow(WindowPos window)
        {
            for (int i = 0; i < FOOTER_HEIGHT - 2; i++)
            {
                SetCursorPosition(WINDOW_WIDTH  * (int)window / 3 + 1, WINDOW_HEIGHT - FOOTER_HEIGHT + 1 + i);
                for (int j = 0; j < WINDOW_WIDTH / 3 - 2; j++)
                    Write(" ");
            }
        }

        private void DrawVertical(int startPosX, int startPosY, int lineNum)
        {
            for (int i = 0; i < lineNum; i++)
            {
                SetCursorPosition(startPosX, startPosY + i);
                Write("|");
            }
        }
        private void DrawHorizontal(int y)
        {
            SetCursorPosition(0, y);
            for (int i = 0; i < WINDOW_WIDTH; i++)
                Write("=");
        }

        private void ClearLines(int startYPos, int lineNum)
        {
            SetCursorPosition(0, startYPos);
            for (int i = 0; i < lineNum; i++)
            {
                for (int j = 0; j < WINDOW_WIDTH; j++)
                    Write(" ");
                WriteLine();
            }
        }

        public void DrawStartScreen()
        {
            WriteLine("게임을 시작합니다");





            WriteLine("아무키나 누르세요"); ReadKey();
            Clear();
        }
    }
}
