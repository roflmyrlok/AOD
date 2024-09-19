using UnityEngine;

namespace Starter
{
	using System;
	using System.Collections.Generic;
	using Model;
	using View;

	public class FightRoundView : MonoBehaviour
	{
		private FightRound fightRound;

		private List<ICharacterView> activeCharacters = new List<ICharacterView>();

		public void StartRound(FightRound round, List<ICharacterView> characters)
		{
			
		}

		public void OnHover()
		{
			// ...
		}
	}

}
