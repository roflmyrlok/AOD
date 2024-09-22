using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
	public class FightView : MonoBehaviour, IFightView
	{
		private Fight _fight;

		private List<ICharacterView> activeCharacters = new List<ICharacterView>();
		
		public void ShowTargetCharacters(List<int> targetPositions)
		{
			Debug.Log("Showing target characters at positions: " + string.Join(", ", targetPositions));
		}
	}
}