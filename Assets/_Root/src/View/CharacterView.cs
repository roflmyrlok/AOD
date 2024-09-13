using Model;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace View
{
	public class CharacterView : SceneCharacter<Character>, ICharacterView
	{
		public HealthBar healthBar;
		public int position;
		
		public void CharacterPositionChanged(int newPosition)
		{
			position = newPosition;
		}

		public void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			
		}
	}
}