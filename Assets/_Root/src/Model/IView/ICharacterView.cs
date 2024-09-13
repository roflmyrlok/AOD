namespace Model
{
	public interface ICharacterView
	{
		public abstract void CharacterPositionChanged(int position);
		public abstract void CharacterHealthChanged(int currentHealth, int maxHealth);

	}
}