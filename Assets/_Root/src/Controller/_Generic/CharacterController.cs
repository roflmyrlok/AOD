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

		public override void InitializeController(Character character, SimpleFightFlow fightFlow, List<Button> buttons)
		{
			if (character is not TCharacter typedCharacter)
			{
				throw new Exception($"Character is not of type {typeof(TCharacter)}");
			}

			Character = typedCharacter;
			InitializeCharacterSkills(fightFlow, buttons);
		}

		protected abstract void InitializeCharacterSkills(SimpleFightFlow fightFlow, List<Button> buttons);
	}

	public abstract class CharacterController : MonoBehaviour
	{
		public abstract void InitializeController(Character character, SimpleFightFlow fightFlow, List<Button> buttons);
	}
}