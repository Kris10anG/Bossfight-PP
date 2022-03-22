using System;

namespace PP_uke_3
{
  //Enemy hit hero with 5 damage, hero now has 30 health left.
  //Hero hit enemy with 20 damage, enemy has 0 health left.
  //Hero is the winner!
    public class GameCharacter
    {
        private static readonly Random _random = new Random();
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Stamina { get; private set; }
        public int InitialStamina { get; }
        public string Name { get; private set; }

        public GameCharacter(int health, int strength, int stamina, string name)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            InitialStamina = stamina;
            Name = name;
        }

      
      public static bool Fight(GameCharacter hero, GameCharacter boss)
      {
          hero.Attack(boss, hero.Strength);
          if (hero.CheckWin(boss)) return false;

          var bossDamage = _random.Next(0, 31);
          boss.Attack(hero, bossDamage);
          if (boss.CheckWin(hero)) return false;

          return true;
      }

      public bool CheckWin(GameCharacter opponent)
      {
          if (!opponent.HasLost()) return false;
          WonMessage();
          return true;
      }

      public void Attack(GameCharacter opponent, int damage)
      {
          if (IsRecharging()) return;
          opponent.Health -= damage;
          opponent.Health = opponent.Health < 0 ? 0 : opponent.Health;
          AttackMessage(opponent);
          Stamina -= 10;
      }
      
      public bool HasLost() 
      {
        return Health <= 0;
      }

      public void WonMessage()
      {
          Console.WriteLine($"{Name} is the winner!");
      }

      public void AttackMessage(GameCharacter opponent) 
      {
        Console.WriteLine($"{Name} hit {opponent.Name} with {Strength} damage, {opponent.Name} now has {opponent.Health} health left.");
      }

      public void AttackMessage(GameCharacter opponent, int damageHit) 
      {
        Console.WriteLine($"{Name} hit {opponent.Name} with {damageHit} damage, {opponent.Name} now has {opponent.Health} health left.");
      }

      public bool IsRecharging() {
        if(Stamina != 0) return false;
        Recharge();
        return true;
      }

      public void Recharge() 
      {
        Stamina = InitialStamina;
      }
    }
}


