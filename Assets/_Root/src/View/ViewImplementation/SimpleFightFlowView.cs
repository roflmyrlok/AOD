using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
	public class SimpleFightFlowView : MonoBehaviour, IFightFlowView
	{
		private Fight _fight;
		private Dictionary<Character, ICharacterView> characterViews = new Dictionary<Character, ICharacterView>();

		public void RegisterCharacter(Character character, ICharacterView characterView)
		{
			characterViews[character] = characterView;
		}

		public void ShowTargetCharacters(List<int> targetPositions)
		{
			Debug.Log("Showing target characters at positions: " + string.Join(", ", targetPositions));
		}

		public void CurrentCharacter(Character character)
		{
			Debug.Log(character.GetCurrentPosition() + " is current character");
			UpdateActiveCharacterUI(character);
		}

		private void UpdateActiveCharacterUI(Character activeCharacter)
		{
			foreach (var kvp in characterViews)
			{
				var isActive = kvp.Key == activeCharacter;
				kvp.Value.SetButtonsActive(isActive); // Assuming SetButtonsActive is a method in ICharacterView
			}
		}
	}
}