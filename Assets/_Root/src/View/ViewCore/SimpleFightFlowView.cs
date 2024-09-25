using System.Collections.Generic;
using Model;
using UnityEngine;
using Position = UnityEngine.UIElements.Position;

namespace View
{
	public class SimpleFightFlowView : MonoBehaviour, IFightFlowView
	{
		private readonly Dictionary<Character, ICharacterView> _characterViews = new Dictionary<Character, ICharacterView>();

		public void RegisterCharacter(Character character, ICharacterView characterView)
		{
			_characterViews[character] = characterView;
			characterView.SetButtonsActive(false);
		}
		
		public void ShowCurrentCharacter(Character character)
		{
			UpdateActiveCharacterUI(character);
		}

		private void UpdateActiveCharacterUI(Character activeCharacter)
		{
			foreach (var kvp in _characterViews)
			{
				var isActive = kvp.Key == activeCharacter;
				kvp.Value.SetButtonsActive(isActive);
			}
		}

		public void ShowTargetCharacters(List<Model.Position> targets, Character performer)
		{
			
		}
	}
}