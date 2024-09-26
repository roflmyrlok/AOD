using System;

namespace Model
{
    public class Stats
    {
        private int _health;
        private int _maxHealth;
        private int _attack;
        private int _defence;
        private int _speed;

        public event Action<Stats> StatsChanged;

        public int Health
        {
            get => _health;
            private set
            {
                _health = value;
                StatsChanged?.Invoke(this);
            }
        }

        public int MaxHealth
        {
            get => _maxHealth;
            private set
            {
                _maxHealth = value;
                StatsChanged?.Invoke(this);
            }
        }

        public int Attack
        {
            get => _attack;
            private set
            {
                _attack = value;
                StatsChanged?.Invoke(this);
            }
        }

        public int Defence
        {
            get => _defence;
            private set
            {
                _defence = value;
                StatsChanged?.Invoke(this);
            }
        }

        public int Speed
        {
            get => _speed;
            private set
            {
                _speed = value;
                StatsChanged?.Invoke(this);
            }
        }

        public Stats(int health, int maxHealth, int attack, int defence, int speed)
        {
            _health = health;
            _maxHealth = maxHealth;
            _attack = attack;
            _defence = defence;
            _speed = speed;
        }
        
        public Stats()
        {
            
        }

        public void SetHealth(int newValue)
        {
            Health = Math.Clamp(newValue, 0, MaxHealth);
        }

        public void SetMaxHealth(int newValue)
        {
            MaxHealth = newValue;
            Health = Math.Clamp(Health, 0, MaxHealth);
        }

        public void SetAttack(int newValue)
        {
            Attack = newValue;
        }

        public void SetDefence(int newValue)
        {
            Defence = newValue;
        }

        public void SetSpeed(int newValue)
        {
            Speed = newValue;
        }
    }
}
