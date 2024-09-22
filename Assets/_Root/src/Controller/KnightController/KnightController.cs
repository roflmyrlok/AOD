using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class KnightController : CharacterController<Knight>
	{
		protected override void InitializeCharacterSkills(IInteractiveFightFlow round, List<Button> buttons)
		{
			foreach (var skill in Character.Skills)
			{
				if (skill is SwordAttackKnight)
				{
					var swordAttackController = GetComponentInChildren<SwordAttackKnightController>(true);
					swordAttackController.InitializeController(buttons, round, Character);
				}
			}
		}
	}
}