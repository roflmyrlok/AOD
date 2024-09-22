using Model;

public interface ICharacterView
{
	bool IsViewFor(Character shape);
	void CharacterPositionChanged(int position);
	void CharacterHealthChanged(int currentHealth, int maxHealth);
	void SetButtonsActive(bool isActive);
}
