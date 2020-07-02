using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CS_Homework
{
    //몬스터 상속관계 만들기
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Orc
    {
        protected int hp;
        protected int att;

        public void Move() { }
    }
    class GroundOrc : Orc
    {

        public void Attack() { }
        public void Patrol() { }
    }    
    class GroundMagicalOrc : GroundOrc
    {
        protected int mp;
        protected int masteryGrade;
    }
    class Grunt : GroundOrc
    {
        private int weaponRange;
        private bool isAttackFlying;

    }
    class Raider : GroundOrc
    {
        private int weaponRange;
        private bool isAttackFlying;

        public void Ensnare() { }
    }
    class Shamen : GroundMagicalOrc
    {
        private int mpRegen;
        public void Purge() { }
        public void LighteningShield() { }
        public void BloodLust() { }

    }
    class TrollWitchDoctor : GroundMagicalOrc
    {
        private int hpRegen;
        public void CentryWard() { }
        public void StasisTrap() { }
        public void HealingWard() { }
    }
    class FlyingOrc : Orc
    {
        public void Fly() { }
    }
    class WindRider : FlyingOrc
    {
        private int venomOverlap;
        void EnvenomedSpear() { }
    }
    class TrollBatRider : FlyingOrc
    {
        private int accelConstant;
        void LiquidFire() { }
        void UnstableConcoction() { }
    }
}
