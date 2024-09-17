using Model;

namespace View
{
	public abstract class CharacterView<TCharacter> : CharacterView, ICharacterView
		where TCharacter : Character
	{
		public HealthBar healthBar;
		public int position;
		
		public override bool IsViewFor(Character shape) => shape is TCharacter;
		
		public override void CharacterPositionChanged(int newPosition)
		{
			position = newPosition;
		}

		public override void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			
		}
	}
}