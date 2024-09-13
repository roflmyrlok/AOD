namespace Model
{
	public class Knight : Character, IPlayerCharacter

	{
		private IKnightView _knightView;
		private IPlayerCharacter _playerCharacterImplementation;

		public IPerformedSkillView PerformedSkillView
		{
			get => _playerCharacterImplementation.PerformedSkillView;
			set => _playerCharacterImplementation.PerformedSkillView = value;
		}
	
		public Knight(ICharacterView characterView, IKnightView knightView, IPerformedSkillView performedSkillView) : base(characterView)
		{
			_knightView = knightView;
			PerformedSkillView = performedSkillView;
			Skills.Add(new SwordAttackKnight(PerformedSkillView));
			Name = "Knight";
			ChangeCurrentHealth(35);
			ChangeMaxHealth(35);
			Attack = 3;
			Defence = 4;
			Speed = 7;
		}
	
	}
}