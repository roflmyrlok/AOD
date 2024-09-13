using System;
using System.Collections.Generic;

namespace Model
{
	public class Field
	{
		public List<Character> Characters;

		
		//general functions
		public bool IsCharacterPresent(int position)
		{
			foreach (var character in Characters)
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
			foreach (var character in Characters)
			{
				if (character.GetCurrentPosition() == position)
				{
					return character;
				}
			}

			throw new Exception("Requested character is not present");
		}
	}
}