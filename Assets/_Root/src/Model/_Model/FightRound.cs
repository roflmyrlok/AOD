using System.Collections.Generic;
using Exception = System.Exception;

namespace Model
{
	public class FightRound : IInteractiveFightRound
	{
		private Field _currentFightField;
		private IFightRoundView _fightRoundView;

		public FightRound(Field currentFightField, IFightRoundView fightRoundView)
		{
			_currentFightField = currentFightField;
			_fightRoundView = fightRoundView;
		}

		public void ShowSkillTargets(int characterPosition, int skillPosition)
		{
			var character = _currentFightField.GetCharacterOnPosition(characterPosition);
			var skill = character.GetAvailableSkills()[skillPosition];
			var targets = skill.GetPositionsCanTarget();
			var resultList = new List<int>();
			foreach (var target in targets)
			{
				if (_currentFightField.IsCharacterPresent(target))
				{
					resultList.Add(target);
				}
			}
			_fightRoundView.ShowTargetCharacters(resultList);
		}

		public void UseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition)
		{
			var character = _currentFightField.GetCharacterOnPosition(characterPosition);
			var skill = character.GetAvailableSkills()[skillPosition - 1];
			var targets = new List<Character>();
			foreach (var pos in targetPosition)
			{
				targets.Add(_currentFightField.GetCharacterOnPosition(pos));
			}
			skill.PerformSkill(character, targets);
		}

		public void CharacterChangePosition(int oldPosition, int newPosition)
		{
			if (!_currentFightField.IsCharacterPresent(oldPosition))
			{
				throw new Exception("no character at position");
			}

			if (!_currentFightField.IsCharacterPresent(newPosition))
			{
				_currentFightField.GetCharacterOnPosition(oldPosition).SetCurrentPosition(newPosition);
			}
			else
			{
				var tmp1 = _currentFightField.GetCharacterOnPosition(oldPosition);
				var tmp2 = _currentFightField.GetCharacterOnPosition(newPosition);
				tmp1.SetCurrentPosition(newPosition);
				tmp2.SetCurrentPosition(oldPosition);

			}
		}

	}
}