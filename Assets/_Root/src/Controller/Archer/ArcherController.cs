using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class ArcherController : CharacterController<Archer>
	{
		protected override void InitializeCharacterSkills(FightRound round, List<Button> buttons)
		{
			foreach (var skill in Character.Skills)
			{
				if (skill is BowAttackArcher bowAttack)
				{
					var bowAttackController = GetComponentInChildren<BowAttackArcherController>(true);
					if (bowAttackController != null)
					{
						bowAttackController.InitializeController(buttons, round, Character);
					}
					else
					{
						Debug.LogError("No BowAttackArcherController found in Archer view.");
					}
				}
				else
				{
					Debug.LogError($"Unrecognized skill found in Archer: {skill.GetType().Name}");
				}
			}
		}
	}
}