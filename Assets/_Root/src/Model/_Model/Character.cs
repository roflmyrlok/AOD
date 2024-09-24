using System;
using System.Collections.Generic;
using UnityEditor;

namespace Model
{
	public abstract class Character
	{
		protected abstract ICharacterView CharacterView { get; }
		public string Name;
		private int _health;
		private int _maxHealth;
		public int Attack;
		public int Defence;
		public int Speed;
		public List<Skill> Skills;

		public Character()
		{
		}

		public abstract void InitViewAndStats(ICharacterView view);
		public abstract void InitSkillsAndSkillViews(List<ISkillView> skillViews);

		public void TakeDamage(float damage, Character performer)
		{
			if (GetCurrentHealth() > damage)
			{
				var newHealth = GetCurrentHealth() -damage;
				ChangeCurrentHealth((int)newHealth);
			}
			else
			{
				ChangeCurrentHealth(0);
			}
		}

		public void DealAttackMultiDamage(float multiplier, Character target)
		{
			target.TakeDamage(this.Attack * multiplier, this);
		}

		public bool IsAlive()
		{
			return GetCurrentHealth() != 0;
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

		public override void InitViewAndStats(ICharacterView view)
		{
			if (view is not TView typed)
			{
				throw new Exception($"trying to assign {view} to Archer");
			}
			TypedView = typed;
		}

		public abstract override void InitSkillsAndSkillViews(List<ISkillView> skillViews);

	}
}