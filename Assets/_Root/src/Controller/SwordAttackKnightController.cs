using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Model;
using Random = System.Random;

public class SwordAttackKnightController : SkillController<SwordAttackKnight>
{
	private SwordAttackKnight skill;

	public override void InitializeController(List<Button> buttons, FightRound round, Character character)
	{
	
		skill = character.Skills.OfType<SwordAttackKnight>().FirstOrDefault();

		if (skill == null)
		{
			Debug.LogError("SwordAttackKnight skill not found in character's skills.");
			return;
		}

		foreach (var button in buttons)
		{
			button.onClick.AddListener(() => OnSkillButtonClicked(round, character));
		}
	}

	private void OnSkillButtonClicked(FightRound round, Character character)
	{
		int position = character.GetCurrentPosition();
		int skillPosition = character.Skills.IndexOf(skill);
		var targetPositions = new List<int> { new Random().Next(5,6)};

		round.UseCharacterSkill(position, skillPosition, targetPositions);
	}
}