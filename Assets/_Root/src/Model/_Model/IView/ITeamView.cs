using System.Collections.Generic;

namespace Model
{
	public interface ITeamView
	{
		void UpdatedCharacterPositions(Dictionary<Position, Character> characterPositions);
		void RemoveCharacterFromTeam(Character character);
	}
}