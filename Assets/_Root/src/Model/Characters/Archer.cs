namespace Model
{
	public class Archer : Character
	{
		private IArcherView _archerView;
		private IPlayerCharacter _playerCharacterImplementation;
		
		public IPerformedSkillView PerformedSkillView
		{
			get => _playerCharacterImplementation.PerformedSkillView;
			set => _playerCharacterImplementation.PerformedSkillView = value;
		}

		Archer(ICharacterView characterView,IArcherView archerView, IPerformedSkillView performedSkillView) : base(characterView)
		{
			_archerView = archerView;
			PerformedSkillView = performedSkillView;
			Skills.Add(new BowAttackArcher(PerformedSkillView));
			Name = "Archer";
			ChangeCurrentHealth(20);
			ChangeMaxHealth(20);
			Attack = 4;
			Defence = 2;
			Speed = 10;

		}
	}
}