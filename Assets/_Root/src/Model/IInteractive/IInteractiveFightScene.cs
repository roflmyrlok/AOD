namespace Model
{

	public interface IInteractiveFightScene
	{
		public void CharacterSkillHovered(int characterPosition, int skillNumber);
		public void CharacterSkillPressed(int characterPosition, int skillPosition);
		public void CharacterAsTargetPressed(int targetPosition);
		public void CharacterChangePosition(int oldPosition, int newPosition);
	}
}