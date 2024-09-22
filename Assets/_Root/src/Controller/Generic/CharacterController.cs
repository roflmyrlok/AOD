using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;

namespace Controller
{
	public abstract class CharacterController<TCharacter> : CharacterController
		where TCharacter : Character
	{
		public TCharacter Character { get; private set; }

		public override void InitializeController(Character character, FightRound round, List<Button> buttons)
		{
			if (character is not TCharacter)
			{
				throw new Exception($"Character is not of type {typeof(TCharacter)}");
			}
			else
			{
				Character = (TCharacter)character;
			}
			InitializeCharacterSkills(round, buttons);
		}
		protected abstract void InitializeCharacterSkills(FightRound round, List<Button> buttons);
	}

	public abstract class CharacterController : MonoBehaviour
	{
		public abstract void InitializeController(Character character, FightRound round, List<Button> buttons);
	}
}