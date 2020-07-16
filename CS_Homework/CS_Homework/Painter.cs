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
            SetCursorPosition(WINDOW_WIDTH - (DESCRIPTION.Length + 1), HEADER_HEIGHT / 2 + 1);
            ForegroundColor = ConsoleColor.Blue;
            Write(DESCRIPTION);
            ForegroundColor = ConsoleColor.White;
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

        internal void DrawGameInfo(int frameCounter, int playTime, int score)
        {
            ClearWindow(WindowPos.RIGHT);
            if (playTime == 0) return;
            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1); Write("경과시간/프레임레이트: ");
            ForegroundColor = ConsoleColor.Blue; 
            Write(playTime + "초/ " + frameCounter / playTime + "fps");
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WINDOW_WIDTH * 2 / 3 + 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2); Write("점수: ");
            ForegroundColor = ConsoleColor.Magenta;
            Write(score);


            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(0,0);
        }

        internal void DrawPlayerInfo(Player player)
        {
            ClearWindow(WindowPos.LEFT);
            SetCursorPosition( 2, WINDOW_HEIGHT - FOOTER_HEIGHT + 1); Write("LEVEL: ");
            ForegroundColor = ConsoleColor.Yellow;
            Write(player.Level);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 2); Write("HP/ATT: ");
            ForegroundColor = ConsoleColor.Yellow;
            Write(player.Hp + " / " + player.Att);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(2, WINDOW_HEIGHT - FOOTER_HEIGHT + 3); Write("EXP: ");
            ForegroundColor = ConsoleColor.Yellow;
            Write(player.Exp);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(0,0);
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
                        case Screen.ENEMY:
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

        internal void DrawEnding()
        {
            Clear();
            WriteLine("끝");
            ReadKey();
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
                case MsgType.CLEAR: ClearWindow(WindowPos.MIDDLE);                    
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
