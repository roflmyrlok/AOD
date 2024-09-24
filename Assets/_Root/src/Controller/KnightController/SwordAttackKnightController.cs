using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class SwordAttackKnightController : SkillController<SwordAttackKnight>
	{
		public override void InitializeController(List<Button> buttons, SimpleFightFlow simpleFightFlow, Character character)
		{
			foreach (var button in buttons)
			{
				if (button.name == "SwordAttackButton")
				{
					button.onClick.AddListener(() => OnSkillButtonClicked(simpleFightFlow, character));
				}
			}
		}

		private void OnSkillButtonClicked(SimpleFightFlow simpleFightFlow, Character character)
		{
			int skillPosition = character.Skills.FindIndex(skill => skill is SwordAttackKnight);
			var targetPositions = new List<Position> { new Position( 1, false) };
			simpleFightFlow.TryUseCharacterSkill(character, skillPosition, targetPositions);
		}
	}
}