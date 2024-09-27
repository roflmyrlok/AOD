using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Collections;
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

		public void ShowTeamWon(Team winner, Team loser)
		{
			var obj = transform.root.Find("Victory");
			Debug.Log("1");
			Text victory = obj.GetComponent<Text>();
			Debug.Log("2");
			victory.text = "GG noobs";

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

			var stats = _characterViews[activeCharacter].Stats;
			Transform statsView = GameObject.Find("Canvas").transform.Find("StatsView");
			if (statsView == null)
			{
				Debug.LogError("StatsView not found in the canvas.");
				return;
			}
			var lifeText = statsView.Find("Life")?.GetComponent<Text>();
			Text attackText = statsView.Find("Attack")?.GetComponent<Text>();
			Text speedText = statsView.Find("Speed")?.GetComponent<Text>();
			Text defenseText = statsView.Find("Defense")?.GetComponent<Text>();

			if (lifeText != null)
				lifeText.text = "Health: " +  $"{stats.Health}/{stats.MaxHealth}";

			if (attackText != null)
				attackText.text = "Attack: " +  stats.Attack.ToString();

			if (speedText != null)
				speedText.text = "Speed: " + stats.Speed.ToString();

			if (defenseText != null)
				defenseText.text = "Defence: 0";
			
			foreach (var kvp in _characterViews)
			{
				var isActive = kvp.Key == activeCharacter;
				kvp.Value.SetButtonsState(isActive);
			}
		}
		
		public void ShowTargetCharacters(Character performer, Skill skill, Action<Character, int, List<Model.Position>> skillToPerform)
		{
			Canvas parentCanvas = GetComponentInParent<Canvas>();

			if (parentCanvas != null)
			{
				TargetManager targetManager = parentCanvas.GetComponentInChildren<TargetManager>();
				targetManager.ShowTarget(_characterViews[performer], performer, skill, skillToPerform);
			}
		}
	}
}