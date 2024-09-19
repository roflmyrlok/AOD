using System.Collections.Generic;

namespace Model
{

	public interface IFightRoundView
	{
		public void ShowTargetCharacters(List<int> targetPositions);
	}
}