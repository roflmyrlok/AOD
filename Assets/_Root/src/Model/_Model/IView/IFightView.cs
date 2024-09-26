using System;
using System.Collections.Generic;

namespace Model
{

	public interface IFightView
	{
		public void ShowTargetCharacters(Character performer, Skill skill, Action<Character, int, List<Position>> skillToPerform);
	}
}