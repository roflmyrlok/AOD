using System.Collections.Generic;

namespace Model
{
	public interface IInteractiveSkill
	{
		public void PerformSkill(Character performer, List<Character> targets);
	}
}