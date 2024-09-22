using System.Collections.Generic;
using Exception = System.Exception;

namespace Model
{
	public abstract class Fight : IInteractiveFight
	{
		internal Field CurrentFightField;
		internal IFightView FightView;

		protected Fight(Field currentFightField, IFightView fightView)
		{
			CurrentFightField = currentFightField;
			FightView = fightView;
		}

		public void ShowSkillTargets(int characterPosition, int skillPosition)
		{
			var character = CurrentFightField.GetCharacterOnPosition(characterPosition);
			var skill = character.GetAvailableSkills()[skillPosition];
			var targets = skill.GetPositionsCanTarget();
			var resultList = new List<int>();
			foreach (var target in targets)
			{
				if (CurrentFightField.IsCharacterPresent(target))
				{
					resultList.Add(target);
				}
			}
			FightView.ShowTargetCharacters(resultList);
		}

		public void UseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition)
		{
			var character = CurrentFightField.GetCharacterOnPosition(characterPosition);
			var skill = character.GetAvailableSkills()[skillPosition];
			var targets = new List<Character>();
			foreach (var pos in targetPosition)
			{
				targets.Add(CurrentFightField.GetCharacterOnPosition(pos));
			}
			skill.PerformSkill(character, targets);
		}

		public bool CharacterChangePosition(int oldPosition, int newPosition)
		{
			if (!CurrentFightField.IsCharacterPresent(oldPosition))
			{
				return false;
			}

			if (!CurrentFightField.IsCharacterPresent(newPosition))
			{
				CurrentFightField.GetCharacterOnPosition(oldPosition).SetCurrentPosition(newPosition);
			}
			else
			{
				var tmp1 = CurrentFightField.GetCharacterOnPosition(oldPosition);
				var tmp2 = CurrentFightField.GetCharacterOnPosition(newPosition);
				tmp1.SetCurrentPosition(newPosition);
				tmp2.SetCurrentPosition(oldPosition);
			}
			return true;
		}
		

	}
}