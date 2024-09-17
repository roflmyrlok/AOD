namespace Model
{
	using System;

	public class Archer : Character<IArcherView>
	{
		private IArcherView _archerView;
		private IPlayerCharacter _playerCharacterImplementation;
		
		public IPerformedSkillView PerformedSkillView
		{
			get => _playerCharacterImplementation.PerformedSkillView;
			set => _playerCharacterImplementation.PerformedSkillView = value;
		}

		public Archer()
		{
			//Skills.Add(new BowAttackArcher(PerformedSkillView));
			Name = "Archer";
			//ChangeCurrentHealth(20);
			//ChangeMaxHealth(20);
			Attack = 4;
			Defence = 2;
			Speed = 10;

		}

	}
}