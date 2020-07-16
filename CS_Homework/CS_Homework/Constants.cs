using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Homework
{
    static class Constants
    {
        public const int WINDOW_WIDTH = 120;
        public const int WINDOW_HEIGHT = 30;
        public const int HEADER_HEIGHT = 5;     //최소 5 이상
        public const int FOOTER_HEIGHT = 5;
        public const string TITLE = "2045!!!";
        public const string DESCRIPTION = "2020.07.05 oh jong geun";
        public const int FRAME_RATE = 1000 / 20;  //뒤에 숫자가 프레임레이트
        public const int ENEMY_FREQ = (1000 / FRAME_RATE) * 1; // 뒤에숫자가 몇초당 하나 생성

        public enum Screen { BLANK = 1, PLAYER, D_LAUNCHER, ENEMY, S_LAUNCHER, BASIC_MISSILE }
        public enum MsgType { DAMAGE = 1, CLEAR }
        public enum WindowPos { LEFT = 0, MIDDLE, RIGHT }

        public const int INITIAL_XPOS = 20;
        public const int INITIAL_YPOS = 10;
        public const int MSG_DURATION = 2;  //시스템 메시지 지속시간

    }
}
