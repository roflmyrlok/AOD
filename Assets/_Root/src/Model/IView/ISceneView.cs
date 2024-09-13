using System.Collections.Generic;

namespace Model
{

	public interface ISceneView
	{
		public void ShowTargetCharacters(List<int> targetPositions);
	}
}