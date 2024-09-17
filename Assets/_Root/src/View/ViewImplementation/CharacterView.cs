using Model;
using UnityEngine;

namespace View
{
	public abstract class CharacterView<TCharacter> : CharacterView, ICharacterView
		where TCharacter : Character
	{
		[SerializeField]
		public HealthBar healthBar;

		public override bool IsViewFor(Character shape) => shape is TCharacter;

		public override void CharacterPositionChanged(int newPosition)
		{
			// Ensure the new position is valid
			if (newPosition < 1 || newPosition > 8)
			{
				Debug.LogError("Invalid position. Must be between 1 and 8.");
				return;
			}

			var currentCanvas = GetComponentInParent<Canvas>();
			// Move the character to the new position using the static method
			PositionalDistribution.MoveCharacterToPosition(transform, newPosition, currentCanvas);
		}

		public override void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			healthBar.SetCurrentHealth(currentHealth);
			healthBar.SetMaxHealth(maxHealth);
		}
	}
}