using System.Collections.Generic;

namespace Model
{

	public interface IInteractiveCharacter
	{
		public void TakeDamage(int damage, Character performer);
		public void DealDamage(int damage, Character target);
		public bool IsAlive();
		public List<int> GetSkillTargets(int skillNumber);
		public void UseSkill(int skillNumber, int targetCharacter, Field currentField);
	}
}