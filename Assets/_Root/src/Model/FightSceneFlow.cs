using System;
using Exception = System.Exception;

namespace Model
{
	public class FightSceneFlow : IInteractiveFightScene
	{
		private Field _currentFightField;
		private ISceneView _sceneView;
		private (Character, int)? _characterSkillPressed;

		public FightSceneFlow(Field currentFightField, ISceneView sceneView)
		{
			_currentFightField = currentFightField;
			_sceneView = sceneView;
		}

		public void CharacterSkillHovered(int characterPosition, int skillNumber)
		{
			var character = _currentFightField.GetCharacterOnPosition(characterPosition);
			var skillTargets = character.GetSkillTargets(skillNumber);
			_sceneView.ShowTargetCharacters(skillTargets);
		}

		public void CharacterSkillPressed(int characterPosition, int skillPosition)
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

		public void CharacterAsTargetPressed(int targetPosition)
		{
			if (!_characterSkillPressed.HasValue)
			{
				throw new Exception("Character skill not pressed");
			}

			_characterSkillPressed.Value.Item1.UseSkill(_characterSkillPressed.Value.Item2, targetPosition,
				_currentFightField);
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