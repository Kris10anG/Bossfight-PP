using System;
using System.Threading;

namespace PP_uke_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isGameRunning = true;
            var hero = new GameCharacter(100, 20, 40, "Hero");
            var boss = new GameCharacter(400, 30, 10, "Boss");
            Console.WriteLine($"Hero health: {hero.Health}  Boss health: {boss.Health}");
            while (isGameRunning)
            {
                isGameRunning = GameCharacter.Fight(hero, boss);
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }
    }
}
