using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public class ArcherController : CharacterController<Archer>
	{
		protected override void InitializeCharacterSkills(IInteractiveFightFlow round, List<Button> buttons)
		{
			foreach (var skill in Character.Skills)
			{
				if (skill is BowAttackArcher)
				{
					var bowAttackController = GetComponentInChildren<BowAttackArcherController>(true);
					bowAttackController.InitializeController(buttons, round, Character);
				}
			}
		}
	}
}