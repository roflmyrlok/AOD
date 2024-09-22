using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
	public class SimpleFightFlowView : MonoBehaviour, IFightFlowView
	{
		private Fight _fight;

		private List<ICharacterView> activeCharacters = new List<ICharacterView>();
		
		public void ShowTargetCharacters(List<int> targetPositions)
		{
			Debug.Log("Showing target characters at positions: " + string.Join(", ", targetPositions));
		}

		public void CurrentCharacter(Character character)
		{
			Debug.Log(character.GetCurrentPosition()+" is current character");
		}
	}
}