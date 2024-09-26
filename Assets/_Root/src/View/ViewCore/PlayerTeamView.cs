using System.Collections.Generic;
using Model;

namespace View
{
	public class PlayerTeamView : TeamView
	{
		public override void UpdatedCharacterPositions(Dictionary<Position, Character> characterPositions)
		{
			foreach (var entry in characterPositions)
			{
				var transformSearchString = entry.Key.Index.ToString();
				var transform = PositionMapping[transformSearchString];
				var characterView = CharacterViews[entry.Value]; 
				characterView.ChangePosition(transform);
			}
		}
		
		public override void Rotate(CharacterView characterView)
		{
			
		}
	}
}

