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

		// Initialize buttons and add listeners
		foreach (Button button in listButtons)
		{
			button.onClick.AddListener(() => OnBowAttackButtonClicked(button));
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
}