using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class KnightController : CharacterController<Knight>
	{
		protected override void InitializeCharacterSkills(FightRound round, List<Button> buttons)
		{
			foreach (var skill in Character.Skills)
			{
				if (skill is SwordAttackKnight swordAttack)
				{
					var swordAttackController = GetComponentInChildren<SwordAttackKnightController>(true);
					if (swordAttackController != null)
					{
						swordAttackController.InitializeController(buttons, round, Character);
					}
					else
					{
						Debug.LogError("No SwordAttackKnightController found in Knight view.");
					}
				}
				else
				{
					Debug.LogError($"Unrecognized skill found in Knight: {skill.GetType().Name}");
				}
			}
		}
	}
}