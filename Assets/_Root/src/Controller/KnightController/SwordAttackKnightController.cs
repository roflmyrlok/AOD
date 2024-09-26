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
			var skill = character.Skills.FirstOrDefault(skill => skill is SwordAttackKnight);
			var skillIndex = skill.Index;
			Debug.Log(skillIndex);
			simpleFightFlow.ShowSkillTargets(character, skillIndex);
		}
	}
}