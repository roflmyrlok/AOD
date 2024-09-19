using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public abstract class CharacterView<TCharacter> : CharacterView, ICharacterView
		where TCharacter : Character
	{
		[SerializeField]
		private Slider healthSlider; // Reference to the Slider component

		public override bool IsViewFor(Character shape) => shape is TCharacter;

		public override void CharacterPositionChanged(int newPosition)
		{
			if (newPosition < 1 || newPosition > 8)
			{
				Debug.LogError("Invalid position. Must be between 1 and 8.");
				return;
			}

			var currentCanvas = GetComponentInParent<Canvas>();
			PositionalDistribution.MoveCharacterToPosition(transform, newPosition, currentCanvas);
		}

		public override void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			if (healthSlider == null)
			{
				Debug.LogError("HealthSlider is not assigned.");
				return;
			}

			// Use the static HealthBar class
			HealthBar.SetCurrentHealth(healthSlider, currentHealth);
			HealthBar.SetMaxHealth(healthSlider, maxHealth);
		}
	}

	public abstract class CharacterView : MonoBehaviour, ICharacterView
	{ 
		public abstract bool IsViewFor(Character shape);
		public abstract void CharacterPositionChanged(int position);
		public abstract void CharacterHealthChanged(int currentHealth, int maxHealth);
	}
}