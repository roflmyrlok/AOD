using System;
using System.Collections.Generic;

namespace Model
{

	public class NotImplementedSkill : Skill
	{


		public NotImplementedSkill(IPerformedSkillView interactionView) : base(interactionView)
		{
			Name = "Not implemented skill";
			_positionsCanTarget = new List<int>() { };
		}

		public override void Perform(Field field, int target, Character performer)
		{
			base.Perform(field, target, performer);
			if (!field.IsCharacterPresent(target))
			{
				throw new Exception("Perform args not available target");
			}

			var targetCharacter = field.GetCharacterOnPosition(target);
			// targetCharacter.doNothing();
		}

	}
}