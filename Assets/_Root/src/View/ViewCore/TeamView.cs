using System.Collections.Generic;
using JetBrains.Annotations;
using Model;
using UnityEngine;
using Character = Model.Character;

namespace View
{
	public abstract class TeamView : MonoBehaviour, ITeamView
	{
		public Dictionary<string, Vector3> PositionMapping { get; protected set; }
		[ItemCanBeNull] protected Dictionary<Character, CharacterView> CharacterViews;

		public void Awake()
		{
			PositionMapping = new Dictionary<string, Vector3>();
			CharacterViews = new Dictionary<Character, CharacterView>();
			foreach (var position in GetComponentsInChildren<Transform>(true))
			{
				PositionMapping.Add(position.name, position.transform.position);
			}
			
		}

		public void RegisterCharacter(Character character, CharacterView characterView)
		{
			CharacterViews[character] = characterView;
		}

		public abstract void UpdatedCharacterPositions(Dictionary<Position, Character> characterPositions);
		
		public void RemoveCharacterFromTeam(Character character)
		{
			CharacterViews.Remove(character);
		}

		public abstract void Rotate(CharacterView characterView);
	}
}