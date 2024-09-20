using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Model;

public class FightController : MonoBehaviour
{
	[SerializeField]
	private FightRound fightRound; // Model layer reference
	
	private Dictionary<Button, Character> buttonToCharacterMap = new Dictionary<Button, Character>();

	// Initialization method, to be called when fight starts
	public void InitializeController(List<Button> listButtons, FightRound round, Dictionary<Button, Character> buttonToCharacterMapping)
	{
		fightRound = round;
		buttonToCharacterMap = buttonToCharacterMapping;
		
		foreach (Button button in listButtons)
		{
			if (!buttonToCharacterMap.TryGetValue(button, out Character character))
			{
				Debug.LogError("Character component not found for the clicked button.");
				continue;
			}
			
			if (character is Knight)
			{
				button.onClick.AddListener(() => OnKnightAttackButtonClicked(button));
			}
			else if (character is Archer)
			{
				button.onClick.AddListener(() => OnBowAttackButtonClicked(button));
			}
			else
			{
				Debug.LogError("Unhandled character type.");
			}
		}
	}

	public void OnBowAttackButtonClicked(Button clickedButton)
	{
		if (!buttonToCharacterMap.TryGetValue(clickedButton, out Character archerCharacter))
		{
			Debug.LogError("Character component not found for the clicked button.");
			return;
		}

		Debug.Log("OnBowAttackButtonClicked");
        
		// Assume the archer's position and the target positions are predefined
		int archerPosition = archerCharacter.GetCurrentPosition();
		List<int> targetPositions = new List<int> { 7, 8 };

		Debug.Log("archerPosition" + " " + archerPosition);
		// Call model to perform the skill
		var skillPosition = 1; // Have no idea how to get it yet. Since we only have 1 skill it will be always be the first one 
		fightRound.UseCharacterSkill(archerPosition, skillPosition, targetPositions);
	}
	
	public void OnKnightAttackButtonClicked(Button clickedButton)
	{
		Debug.Log("OnKnightAttackButtonClicked");
		if (!buttonToCharacterMap.TryGetValue(clickedButton, out Character knightCharacter))
		{
			Debug.LogError("Character component not found for the clicked button.");
			return;
		}

		Debug.Log("OnKnightAttackButtonClicked");
		
		int knightPosition = knightCharacter.GetCurrentPosition();
		List<int> targetPositions = new List<int> { 5, 6};

		Debug.Log("knightPosition" + " " + knightPosition);
		var skillPosition = 1; 
		fightRound.UseCharacterSkill(knightPosition, skillPosition, targetPositions);
	}
}