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
				
				if (button.name == "BowAttackButton")
				{	
					button.onClick.AddListener(() => OnSkillButtonClicked(fightFlow, character));
				}
			}
		}

		private void OnSkillButtonClicked(SimpleFightFlow fightFlow, Character character)
		{
			int skillPosition = character.Skills.FindIndex(skill => skill is BowAttackArcher);
			var targetPositions = new List<Position> { new (3, false) };
			fightFlow.TryUseCharacterSkill(character, skillPosition, targetPositions);
		}
	}
}