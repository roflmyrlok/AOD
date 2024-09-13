using System;
using System.Collections.Generic;

namespace Model
{
	public class SwordAttackKnight : Skill
	{
		private IPerformedSkillView _interactionView;
		private float _skillDamageMultiplier = 1.8f;

		public SwordAttackKnight(IPerformedSkillView interactionView) : base(interactionView)
		{
			_interactionView = interactionView;
			Name = "Knight's Sword Attack";
			_positionsCanTarget = new List<int>() {5, 6};
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