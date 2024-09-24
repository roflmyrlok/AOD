using System.Collections.Generic;
using Exception = System.Exception;

namespace Model
{
	public abstract class Fight 
	{
		public Team PlayerTeam { get; protected set; }
		public Team EnemyTeam { get; protected set; }
		internal IFightView FightView;

		protected Fight(Team playerTeam, Team enemyTeam, IFightView fightView)
		{
			PlayerTeam = playerTeam;
			EnemyTeam = enemyTeam;
			FightView = fightView;
		}

		public void ShowSkillTargets(Character performer, int skillPosition)
		{
			var targets = performer.Skills[skillPosition - 1].PositionsCanTarget;
			FightView.ShowTargetCharacters(targets, performer);
		}

		public void UseCharacterSkill(Character performer, int skillPosition, List<Position> targetPosition)
		{
			bool isPlayerTeam;
			if (PlayerTeam.Contains(performer))
			{
				isPlayerTeam = true;
			}
			else if (EnemyTeam.Contains(performer))
			{
				isPlayerTeam = false;
			}
			else
			{
				throw new Exception("no char");
			}
			
			var performerTeam = isPlayerTeam ? PlayerTeam : EnemyTeam;
			var enemyTeam = isPlayerTeam ? EnemyTeam : PlayerTeam;
			var skill = performer.Skills[skillPosition];
			skill.PerformSkill(performer,targetPosition, performerTeam, enemyTeam);
		}
		
		public bool TryCharacterChangePositionInTeam(Character character, Position newPosition)
		{
			if (PlayerTeam.Contains(character))
			{
				return PlayerTeam.TryCharacterChangePosition(character, newPosition);
			}
			else if (EnemyTeam.Contains(character))
			{
				return EnemyTeam.TryCharacterChangePosition(character, newPosition);
			}
			else
			{
				throw new Exception("no char");
			}
		}
	}
}