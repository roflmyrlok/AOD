using System.Collections.Generic;

namespace Model
{

	public interface IFightView
	{
		public void ShowTargetCharacters(Character performer, Skill skill);
	}
}