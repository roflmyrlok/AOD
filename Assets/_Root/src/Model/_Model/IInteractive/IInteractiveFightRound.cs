using System.Collections.Generic;

namespace Model
{

	public interface IInteractiveFightRound
	{
		public void ShowSkillTargets(int characterPosition, int skillPosition);
		public void UseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition);
		public void CharacterChangePosition(int oldPosition, int newPosition);
	}
}