using System;
using System.Collections.Generic;

namespace Model
{
	public class BowAttackArcher : Skill
	{
		private IPerformedSkillView _interactionView;
		private readonly float _skillDamageMultiplier = 2.5f;

		public BowAttackArcher(IPerformedSkillView interactionView): base(interactionView)
		{
			_interactionView = interactionView;
			Name = "Archer's Bow Attack";
			_positionsCanTarget = new List<int>() {7, 8};
		}
		

		public override void Perform(Field field, int target, Character performer)
		{
			base.Perform(field, target, performer);
			
			if (!field.IsCharacterPresent(target))
			{
				throw new Exception("Perform args not available target");
			}

			var targetCharacter = field.GetCharacterOnPosition(target);
			performer.DealDamage(Convert.ToInt32(performer.Attack * _skillDamageMultiplier), targetCharacter);
		}
	}
}