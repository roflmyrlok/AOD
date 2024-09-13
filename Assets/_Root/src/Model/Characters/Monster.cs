namespace Model
{
	public class Monster : Character
	{
		private IMonsterView _monsterView;

		Monster(ICharacterView characterView,IMonsterView monsterView) : base(characterView)
		{
			_monsterView = monsterView;
			Name = "Monster";
			ChangeCurrentHealth(20);
			ChangeMaxHealth(20);
			Attack = 2;
			Defence = 1;
			Speed = 1;

		}
	}
}