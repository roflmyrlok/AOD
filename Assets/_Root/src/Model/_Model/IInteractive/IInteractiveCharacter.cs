using System.Collections.Generic;

namespace Model
{

	public interface IInteractiveCharacter
	{
		public void TakeDamage(float damage, Character performer);
		public void DealAttackMultiDamage(float damage, Character target);
		public bool IsAlive();
		public List<Skill> GetAvailableSkills();
		public bool IsAvailableSkill(Skill skill);
	}
}