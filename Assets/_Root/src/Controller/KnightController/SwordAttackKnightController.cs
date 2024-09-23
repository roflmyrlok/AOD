using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class SwordAttackKnightController : SkillController<SwordAttackKnight>
	{
		public override void InitializeController(List<Button> buttons, IInteractiveFightFlow round, Character character)
		{
			foreach (var button in buttons)
			{
				if (button.name == "SwordAttackButton")
				{
					button.onClick.AddListener(() => OnSkillButtonClicked(round, character));
				}
			}
		}

		private void OnSkillButtonClicked(IInteractiveFightFlow round, Character character)
		{
			int position = character.GetCurrentPosition();
			int skillPosition = character.Skills.FindIndex(skill => skill is SwordAttackKnight);
			var targetPositions = new List<int> { Random.Range(5, 6) };
			round.TryUseCharacterSkill(position, skillPosition, targetPositions);
		}
	}
}