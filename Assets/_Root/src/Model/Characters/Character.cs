using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class Character : IInteractiveCharacter
	{
		private ICharacterView _characterView;
		public string Name;
		private int _health;
		private int _maxHealth;
		public int Attack;
		public int Defence;
		public int Speed;
		private int _currentPosition;
		public List<Skill> Skills;

		public Character(ICharacterView characterView)
		{
			_characterView = characterView;
			Skills = new List<Skill>() {};
			Name = "";
			ChangeCurrentHealth(0);
			ChangeMaxHealth(1);
			Attack = 0;
			Defence = 0;
			Speed = 0;
			_currentPosition = Int32.MaxValue;
		}

		public void TakeDamage(int damage, Character performer)
		{
			if (GetCurrentHealth() > damage)
			{
				var newHealth = GetCurrentHealth() -damage;
				ChangeCurrentHealth(newHealth);
			}
			else
			{
				ChangeCurrentHealth(0);
			}
		}

		public void DealDamage(int damage, Character target)
		{
			target.TakeDamage(damage, this);
		}

		public bool IsAlive()
		{
			return GetCurrentHealth() != 0;
		}

		public List<int> GetSkillTargets(int skillNumber)
		{
			return Skills[skillNumber - 1].GetPositionsCanTarget();
		}

		public virtual void UseSkill(int skillNumber, int skillTarget, Field currentField)
		{
			if (Skills.Count < skillNumber)
			{
				throw new Exception("no such skill");
			}
			Skills[skillNumber - 1].Perform(currentField, skillTarget, this);
		}

		
		public int GetCurrentPosition()
		{
			return _currentPosition;
		}
		public void SetCurrentPosition(int newPosition)
		{
			_currentPosition = newPosition;
			_characterView.CharacterPositionChanged(_currentPosition);
		}

		public void ChangeCurrentHealth(int newValue)
		{
			if (this._maxHealth <= newValue)
			{
				_health = _maxHealth;
			}
			this._health = newValue;
			_characterView.CharacterHealthChanged(GetCurrentHealth(), GetMaxHealth());
		}
		
		public void ChangeMaxHealth(int newValue)
		{
			_maxHealth = newValue;
			_characterView.CharacterHealthChanged(GetCurrentHealth(), GetMaxHealth());
		}

		public int GetCurrentHealth()
		{
			return _health;
		}

		public int GetMaxHealth()
		{
			return _maxHealth;
		}
	}
}