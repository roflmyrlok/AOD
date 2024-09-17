using Model;
using UnityEngine;

namespace View
{
	public abstract class CharacterView : MonoBehaviour, ICharacterView
	{ 
		public abstract bool IsViewFor(Character shape);
		public abstract void CharacterPositionChanged(int position);
		public abstract void CharacterHealthChanged(int currentHealth, int maxHealth);
	}
	
}