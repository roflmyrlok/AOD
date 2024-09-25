using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Position = Model.Position;

namespace View
{
	public class TargetManager : MonoBehaviour
	{
		[SerializeField] 
		private Button cancelInputMode;
		
		[SerializeField]
		private Transform parentTarget;
		
		[SerializeField]
		private TargetView targetViewPrefab;
		
		public void ShowTarget(CharacterView characterView, List<Position> positionsCanTarget)
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
			
			foreach (var pos in positionsCanTarget)
			{
				Debug.Log(pos.IsPlayerTeam.ToString() + " " + pos.Index);
				var targetView = Instantiate(targetViewPrefab, parentTarget);
				targetView.transform.position = pos.IsPlayerTeam ?
					 performerTeamView.PositionMapping[pos.Index.ToString()] :
					 oppositionTeamView.PositionMapping[pos.Index.ToString()];
			}
			
			
		}
	}
}