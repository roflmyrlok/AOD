using System.Collections.Generic;

namespace Model
{

	public interface IInteractiveFight
	{
		public void ShowSkillTargets(int characterPosition, int skillPosition);
		public void UseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition);
		public bool CharacterChangePosition(int oldPosition, int newPosition);
	}
}