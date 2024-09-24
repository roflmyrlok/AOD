using System;
using System.Collections.Generic;

namespace Model
{

	public class SampleSkill : Skill<ISampleSkillView>
	{ 
		public override void PerformSkill(Character performer, List<Position> targets, Team performerTeam, Team enemyTeam)
		{
			foreach (var target in targets)
			{
				performer.DealAttackMultiDamage(0, enemyTeam.GetCharacterByPosition(target.OpposingPosition()));
			}
		}
	}
}