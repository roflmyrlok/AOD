using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class BowAttackArcherController : SkillController<BowAttackArcher>
	{
		public override void InitializeController(List<Button> buttons, IInteractiveFightFlow round, Character character)
		{
			foreach (var button in buttons)
			{
				
				if (button.name == "BowAttackButton")
				{	
					button.onClick.AddListener(() => OnSkillButtonClicked(round, character));
				}
			}
		}

		private void OnSkillButtonClicked(IInteractiveFightFlow round, Character character)
		{
			int position = character.GetCurrentPosition();
			int skillPosition = character.Skills.FindIndex(skill => skill is BowAttackArcher);
			var targetPositions = new List<int> { Random.Range(7, 8) };
			round.TryUseCharacterSkill(position, skillPosition, targetPositions);
		}
	}
}