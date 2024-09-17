using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class Character : IInteractiveCharacter
	{
		protected abstract ICharacterView CharacterView { get; }
		public string Name;
		private int _health;
		private int _maxHealth;
		public int Attack;
		public int Defence;
		public int Speed;
		private int _currentPosition;
		public List<Skill> Skills;

		public Character()
		{
			Skills = new List<Skill>() {};
			Name = "";
			//ChangeCurrentHealth(0);
			//ChangeMaxHealth(1);
			Attack = 0;
			Defence = 0;
			Speed = 0;
			_currentPosition = Int32.MaxValue;
		}

		public abstract void InitView(ICharacterView view);

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
			CharacterView.CharacterPositionChanged(_currentPosition);
		}

		public void ChangeCurrentHealth(int newValue)
		{
			if (this._maxHealth <= newValue)
			{
				_health = _maxHealth;
			}
			this._health = newValue;
			CharacterView.CharacterHealthChanged(GetCurrentHealth(), GetMaxHealth());
		}
		
		public void ChangeMaxHealth(int newValue)
		{
			_maxHealth = newValue;
			CharacterView.CharacterHealthChanged(GetCurrentHealth(), GetMaxHealth());
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

	public abstract class Character<TView> : Character where TView : ICharacterView
	{
		protected TView TypedView { get; private set; } 

		protected override ICharacterView CharacterView => TypedView;

		public override void InitView(ICharacterView view)
		{
			if (view is not TView typed)
			{
				throw new Exception($"trying to assign {view} to Archer");
			}

			TypedView = typed;
		}
	}
}