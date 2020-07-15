using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Game2045 game2045 = new Game2045();
            game2045.StartGame();
        }
    }
}



/*
-플레이어 미사일 발사 -> 1일
 -이동범위등 각종 예외 처리 -> 1일
 -하단 상태창에 출력할 점수, 플레이어 경험치 레벨등 설계,구현 -> 2일
 -적 종류별 스탯 구성 -> 1~2일 
 -스테이지 설계 구현 -> 1일
 -최종 테스트, UI조정, 적 출현빈도나 난이도 조정등 -> 2일
======================
 ## 여유가 있다면 ##
 -플레이어 스킬 구현
 -각종 이펙트,스킬 이펙트, 적 충돌이나 격파시 이펙트
 -BGM삽입


*/