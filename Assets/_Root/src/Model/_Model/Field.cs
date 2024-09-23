using System;
using System.Collections.Generic;

namespace Model
{
	public class Field
	{
		private readonly List<Character> characters;

		public Field(List<Character> characters)
		{
			this.characters = characters;
		}

		//general functions
		public bool IsCharacterPresent(int position)
		{
			foreach (var character in characters)
			{
				if (character.GetCurrentPosition() == position)
				{
					return true;
				}
			}

			return false;
		}
		
		public Character GetCharacterOnPosition(int position)
		{
			foreach (var character in characters)
			{
				if (character.GetCurrentPosition() == position)
				{
					return character;
				}
			}

			throw new Exception("Requested character is not present");
		}

		public Dictionary<Character, int> GetCharactersBySpeed()
		{
			var charSpeed = new Dictionary<Character, int>();
			foreach (var character in characters)
			{
				charSpeed.Add(character, character.Speed);
			}

			return charSpeed;
		}
	}
}