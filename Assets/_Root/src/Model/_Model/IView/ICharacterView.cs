namespace Model
{
	using UnityEngine;

	public interface ICharacterView
	{
		void CharacterPositionChanged(int position);
		void CharacterHealthChanged(int currentHealth, int maxHealth);
	}

	class NullCharacterView : ICharacterView
	{

		public void CharacterPositionChanged(int position)
		{
			Debug.Log($"character po changed: {position}");
		}

		public void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			Debug.Log($"character helth changed: {currentHealth}/{maxHealth}");
		}
	}
}