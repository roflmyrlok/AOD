using System.Collections.Generic;
using System.Linq;
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
			EnemyTeam.IvLost += (sender, args) => fightView.ShowTeamWon(PlayerTeam, EnemyTeam);
			PlayerTeam.IvLost += (sender, args) => fightView.ShowTeamWon(EnemyTeam, PlayerTeam);
		}

		public virtual void ShowSkillTargets(Character performer, int skillIndex)
		{
			
			FightView.ShowTargetCharacters(performer, performer.Skills.FirstOrDefault(s => s.Index == skillIndex), UseCharacterSkill);
		}

		public virtual void UseCharacterSkill(Character performer, int skillIndex, List<Position> targetPosition)
		{
			bool isPerformerTeam;
			if (PlayerTeam.Contains(performer))
			{
				isPerformerTeam = true;
			}
			else if (EnemyTeam.Contains(performer))
			{
				isPerformerTeam = false;
			}
			else
			{
				throw new Exception("no char");
			}
			
			var performerTeam = isPerformerTeam ? PlayerTeam : EnemyTeam;
			var enemyTeam = isPerformerTeam ? EnemyTeam : PlayerTeam;
			var skill = performer.Skills.FirstOrDefault(s => s.Index == skillIndex);
			skill.PerformSkill(performer,targetPosition, performerTeam, enemyTeam);
		}
		
		/*public bool TryCharacterChangePositionInTeam(Character character, Position newPosition)
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
		}*/
	}
}