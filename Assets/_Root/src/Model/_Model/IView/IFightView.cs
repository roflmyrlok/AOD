using System.Collections.Generic;

namespace Model
{

	public interface IFightView
	{
		public void ShowTargetCharacters(List<Position> targets, Character performer);
	}
}