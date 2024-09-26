using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;
using UnityEngine.UI;
using Position = Model.Position;

namespace Controller
{
	public class BowAttackArcherController : SkillController<BowAttackArcher>
	{
		public override void InitializeController(List<Button> buttons, SimpleFightFlow fightFlow, Character character)
		{
			foreach (var button in buttons)
			{
				
				if (button.name == "BowAttackShow")
				{	
					button.onClick.AddListener(() => OnSkillButtonClicked(fightFlow, character));
				}
				
			}
		}

		private void OnSkillButtonClicked(SimpleFightFlow simpleFightFlow, Character character)
		{
			var skill = character.Skills.FirstOrDefault(skill => skill is BowAttackArcher);
			var skillIndex = skill.Index;
			simpleFightFlow.ShowSkillTargets(character, skillIndex);
		}
	}
}