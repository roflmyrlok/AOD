namespace Model
{
	public class Monster : Character
	{
		private IMonsterView _monsterView;

		Monster(IMonsterView monsterView) 
		{
			_monsterView = monsterView;
			Name = "Monster";
			//ChangeCurrentHealth(20);
			//ChangeMaxHealth(20);
			Attack = 2;
			Defence = 1;
			Speed = 1;

		}

		protected override ICharacterView CharacterView { get; }

		public override void InitView(ICharacterView view)
		{
			throw new System.NotImplementedException();
		}
	}
}