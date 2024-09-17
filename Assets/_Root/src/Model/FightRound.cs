using System;
using System.Collections.Generic;
using Exception = System.Exception;

namespace Model
{
	public class FightRound : IInteractiveFightScene
	{
		private Field _currentFightField;
		private ISceneView _sceneView;
		private (Character, int)? _characterSkillPressed;

		public FightRound(Field currentFightField, ISceneView sceneView)
		{
			_currentFightField = currentFightField;
			_sceneView = sceneView;
		}

		public void ShowSkillTargets(int characterPosition, int skillNumber)
		{
			var character = _currentFightField.GetCharacterOnPosition(characterPosition);
			var skillTargets = character.GetSkillTargets(skillNumber);
			_sceneView.ShowTargetCharacters(skillTargets);
		}

		public void UseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition)
		{
			var character = _currentFightField.GetCharacterOnPosition(characterPosition);
			character.UseSkill(skillPosition, targetPosition[0], _currentFightField);
		}

		public void UseCharacterSkill(int characterPosition, int skillPosition)
		{
			if (!_currentFightField.IsCharacterPresent(characterPosition))
			{
				throw new Exception("Character not present");
			}

			_characterSkillPressed = new ValueTuple<Character, int>()
			{
				Item1 = _currentFightField.GetCharacterOnPosition(characterPosition),
				Item2 = skillPosition
			};

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