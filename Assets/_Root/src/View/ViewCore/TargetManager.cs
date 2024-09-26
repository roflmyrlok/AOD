using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Position = Model.Position;

namespace View
{
	public class TargetManager : MonoBehaviour
	{
		[SerializeField] 
		private GameObject cancelInputMode;
		
		[SerializeField]
		private Transform parentTarget;
		
		[SerializeField]
		private TargetView targetViewPrefab;

		private List<TargetView> _activeTargetViews;
		private List<UnityEngine.UI.Button> _tempDisabledButtons;

		private void Awake()
		{
			cancelInputMode.gameObject.SetActive(false);
			_activeTargetViews = new List<TargetView>();
			_tempDisabledButtons = new List<UnityEngine.UI.Button>();

			cancelInputMode.GetComponentInChildren<Button>().onClick.AddListener(CancelInputMode);
		}

		public void ShowTarget(CharacterView characterView, Character performer, Skill skill, Action<Character, int, List<Model.Position>> skillToPerform)
		{
			var canvas = characterView.GetComponentInParent<Canvas>();
			var playerTeam = canvas.GetComponentInChildren<PlayerTeamView>();
			var enemyTeam = canvas.GetComponentInChildren<EnemyTeamView>();
			bool isPlayerTeam = false;
			bool present = false;
			foreach (var character in playerTeam.GetComponentsInChildren<CharacterView>())
			{
				if (character == characterView)
				{
					isPlayerTeam = true;
					present = true;
				}
			}
			foreach (var character in enemyTeam.GetComponentsInChildren<CharacterView>())
			{
				if (character == characterView)
				{
					isPlayerTeam = false;
					present = true;
				}
			}

			if (!present)
			{
				throw new Exception("no Player on team");
			}
			
			TeamView performerTeamView = isPlayerTeam ? playerTeam : enemyTeam;
			TeamView oppositionTeamView = isPlayerTeam ? enemyTeam : playerTeam;
			
			foreach (var pos in skill.PositionsCanTarget)
			{
				var targetView = Instantiate(targetViewPrefab, parentTarget);

				var buttonOfTargetView = targetView.GetComponentInChildren<Button>();
				
				// here is logic to call skill onClick of characterView button with position pos skill skill
				
				buttonOfTargetView.onClick.AddListener(() => skillToPerform(performer, 1, new List<Position>{pos})); 
				buttonOfTargetView.onClick.AddListener(CancelInputMode); 

				
				targetView.transform.position = pos.IsPlayerTeam ?
					 performerTeamView.PositionMapping[pos.Index.ToString()] :
					 oppositionTeamView.PositionMapping[pos.Index.ToString()];
				_activeTargetViews.Add(targetView);
			}
			ActivateInputMode();
		}

		private void ActivateInputMode()
		{
			var canvas = GetComponentInParent<Canvas>();
			var buttons = canvas.GetComponentsInChildren<UnityEngine.UI.Button>();
			foreach (var button in buttons)
			{
				if (button.IsActive())
				{
					_tempDisabledButtons.Add(button);
				}
			}

			foreach (var button in _tempDisabledButtons)
			{
				button.interactable = false;
			}

			cancelInputMode.SetActive(true);
			foreach (var targetView in _activeTargetViews)
			{
				targetView.SetEnabled(true);
				targetView.GetComponentInChildren<Button>().interactable = true;
			}
		}
		
		public void CancelInputMode()
		{
			foreach (var button in _tempDisabledButtons)
			{
				button.interactable = true;
			}
			foreach (var targetView in _activeTargetViews)
			{
				targetView.DestroyGameObject();
			}

			_activeTargetViews.Clear();
			_tempDisabledButtons.Clear();

			cancelInputMode.SetActive(false);
			
		}
	}
}