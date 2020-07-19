using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CS_Homework.Constants;
using System.Media;
using System.Runtime;
using System.IO;

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
        private ArrayList missileList;
        private Calculator calculator;
        private int frameCounter;
        private int msgTimer;
        private int damaged;
        private int getEXP;
        private int score;
        private GameState gameState;
        private GameState stageTemp;
        private int defeatNum;

        internal void StartGame()
        {            
            InitializeGame();
            PlaySound();
            painter.DrawStartScreen();
            timer.SetPlayTimeStart(); //총플레이시간 카운트 시작
            while (true)
            {
                switch(gameState)
                {
                    case GameState.PAUSE: GamePause(); break;
                    case GameState.ENDING: painter.DrawEnding(player, score, timer.GetPlayTime(), defeatNum); gameState = GameState.FINISH; break;
                    case GameState.LEVELUP:         break;
                    case GameState.STAGE1:
                    case GameState.STAGE2:
                    case GameState.STAGE3:
                        {
                            //화면 그리기
                            if (isHeaderChanged) painter.DrawHeader(); isHeaderChanged = false;
                            if (isFooterChanged) painter.DrawFooter(); isFooterChanged = false;
                            painter.DrawMainScreen(screenArr);
                            painter.DrawPlayerInfo(player);
                            painter.DrawGameInfo(frameCounter, timer.GetPlayTime(), score, defeatNum, gameState);
                            //1프레임 사이클            
                            if (timer.IsElapsed())
                            {
                                frameCounter++;
                                score++;
                                PlayerProc(); //사용자 조작
                                FlushKey();
                                CreateEnemy();
                                EnemyMove();
                                MissileMove();
                                VerifyCollision();
                                UpdatePlayerInfo();
                            }
                            if (player.Hp <= 0)
                                gameState = GameState.ENDING;
                            StageAdjust();
                        }
                        break;
                }
                if (gameState == GameState.FINISH)
                    break;                  
            }
        }

        private void StageAdjust()
        {
            if (gameState == GameState.STAGE1 && timer.GetPlayTime() > STAGE1_LENGTH)
                gameState = GameState.STAGE2;
            else if (gameState == GameState.STAGE2 && timer.GetPlayTime() > STAGE2_LENGTH)
                gameState = GameState.STAGE3;
            else if (gameState == GameState.STAGE3 && timer.GetPlayTime() > STAGE3_LENGTH)
                gameState = GameState.ENDING;
            else
                return;

            foreach (Enemy e in enemyList)
                e.DeletePos(screenArr);
            enemyList = new ArrayList();
        }

        private void GamePause()
        {
            painter.DrawPause();            
            while (true)
            {
                if (ReadKey(true).Key == ConsoleKey.P)
                {
                    gameState = stageTemp;
                    break;
                }
            }
        }

        private void UpdatePlayerInfo()
        {
            if (player.Exp >= player.Level * 100)
            {
                calculator.PlayerLevelUp(player);
                painter.DrawPlayerInfo(player);
            }
        }

        private void VerifyCollision()
        {
            //적 충돌판정 받은 데미지를 리턴
            damaged = calculator.Collide(screenArr, player, enemyList);
            if (damaged > 0)
            {
                painter.DrawDescription(MsgType.DAMAGE, damaged);
                msgTimer = MSG_DURATION * frameCounter / timer.GetPlayTime();
            }
            //미사일 충돌판정 적 격파시 총 획득 경험치 리턴
            getEXP = calculator.MissileCollide(screenArr, missileList, enemyList, player.Att, ref defeatNum);
            if (getEXP > 0)
            {
                player.Exp += getEXP;
                score += getEXP*10;
                painter.DrawDescription(MsgType.EXP, getEXP);
                msgTimer = MSG_DURATION * frameCounter / timer.GetPlayTime();                
            }
            if (--msgTimer < 0)
                painter.DrawDescription(MsgType.CLEAR, 0);
        }

        private void MissileMove()
        {
            for (int i = 0; i < missileList.Count; i++)
            {
                Missile missile = (Missile)missileList[i];
                missile.DeletePos(screenArr);
                if (++missile.XPos > WINDOW_WIDTH)
                    missileList.RemoveAt(i--);
                else
                    missile.SetPos(screenArr);
            }
        }

        private void EnemyMove()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (((Enemy)enemyList[i]).Move(screenArr, player.YPos))
                    ((Enemy)enemyList[i]).SetPos(screenArr);
                else
                    enemyList.RemoveAt(i--);
            }
        }

        private void CreateEnemy()
        {
            if(frameCounter%5==0)
            {
                Enemy enemy;
                int xPos = WINDOW_WIDTH - 2;
                int yPos = random.Next(0, WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT);
                switch (gameState)
                {
                    case GameState.STAGE2: 
                        if(frameCounter % 3 == 0)
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL1); 
                        else if (frameCounter % 3 == 1)
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL2);
                        else
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL3);
                        break;
                    case GameState.STAGE3:
                        if (frameCounter % 3 == 0)
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL2);
                        else if (frameCounter % 3 == 1)
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL3);
                        else
                            enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL9);
                        break;
                    default: enemy = new Enemy(xPos, yPos, (int)EnemyType.LEVEL1); break;  //stage1
                }
                enemyList.Add(enemy);
                enemy.SetPos(screenArr);
            }
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
                    case ConsoleKey.UpArrow: if(player.YPos > 0 ) player.YPos--; break;
                    case ConsoleKey.DownArrow: if (player.YPos < (WINDOW_HEIGHT - HEADER_HEIGHT - FOOTER_HEIGHT - 2)) player.YPos++; break;
                    case ConsoleKey.LeftArrow: if (player.XPos > 0 ) player.XPos--; break;
                    case ConsoleKey.RightArrow:if (player.XPos < WINDOW_WIDTH - 7) player.XPos++; break;
                    case ConsoleKey.Spacebar:
                        {
                            Missile missile = new Missile(player.XPos + 5, player.YPos);
                            missileList.Add(missile);
                            missile.SetPos(screenArr);
                        }
                        break;
                    case ConsoleKey.P: stageTemp = gameState; gameState = GameState.PAUSE;  break;
                    case ConsoleKey.Z: player.Blink(screenArr, enemyList, calculator); break;
                    case ConsoleKey.X: player.Excalibur(screenArr, enemyList);  break;
                    case ConsoleKey.C: player.Heal();  break;
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
            missileList = new ArrayList();
            calculator = new Calculator();
            frameCounter = 0;
            msgTimer = 0;
            score = 0;
            defeatNum = 0;
            gameState = GameState.STAGE1;

            
            Clear();
        }

        private void PlaySound()
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\bgm.wav";
                soundPlayer.Play();
                WriteLine("배경음악 재생 합니다");
            }
            catch (FileNotFoundException)
            {
                WriteLine("bgm파일이 없습니다. 음악 없이 플레이 합니다");
            }
            finally
            {
                WriteLine("배경음악 파일 이름은 bgm.wav 입니다");
            }
        }
    }
}
