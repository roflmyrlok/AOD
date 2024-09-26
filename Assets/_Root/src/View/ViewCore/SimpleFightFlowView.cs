using System.Collections.Generic;
using Model;
using UnityEngine;
using Position = UnityEngine.UIElements.Position;

namespace View
{
	public class SimpleFightFlowView : MonoBehaviour, IFightFlowView
	{
		private readonly Dictionary<Character, CharacterView> _characterViews = new Dictionary<Character, CharacterView>();
		

		public void RegisterCharacter(Character character, CharacterView characterView)
		{
			_characterViews[character] = characterView;
			characterView.SetButtonsState(false);
		}
		
		public void ShowCurrentCharacter(Character character)
		{
			UpdateActiveCharacterUI(character);
		}

		private void UpdateActiveCharacterUI(Character activeCharacter)
		{
			
			foreach (RectTransform child in GetComponentInChildren<RectTransform>(true))
			{
				if (child.CompareTag("ActiveCharacterMark"))
				{
					child.transform.position = _characterViews[activeCharacter].transform.position;
				}
			}
			
			foreach (var kvp in _characterViews)
			{
				var isActive = kvp.Key == activeCharacter;
				kvp.Value.SetButtonsState(isActive);
			}
		}

		public void ShowTargetCharacters( Character performer, Skill skill)
		{
			Canvas parentCanvas = GetComponentInParent<Canvas>();

			if (parentCanvas != null)
			{
				TargetManager targetManager = parentCanvas.GetComponentInChildren<TargetManager>();
				targetManager.ShowTarget(_characterViews[performer], skill);
			}
		}
	}
}