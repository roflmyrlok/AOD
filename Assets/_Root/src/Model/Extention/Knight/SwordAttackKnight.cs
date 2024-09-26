using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class SwordAttackKnight : Skill<ISwordAttackKnightView>
	{
		private readonly float _skillDamageMultiplier = 1.8f;

		public SwordAttackKnight()
		{
			Name = "Sword Attack";
			PositionsCanTarget = new List<Position>();
			PositionsCanTarget.Add(new Position(1,false));
			PositionsCanTarget.Add(new Position(2, false));
			Index = 1;
		}

		public override void PerformSkill(Character performer, List<Position> targets, Team performerTeam, Team enemyTeam)
		{
			
			foreach (var target in targets)
			{
				
				if (!PositionsCanTarget.Contains(target ))
				{
					throw new Exception("cant target character at position");
				}
				performer.DealAttackMultiDamage(_skillDamageMultiplier, enemyTeam.GetCharacterByPosition(target.OpposingPosition()));
				//TypedView.ShowBowAttackPerformed(target);
			}
			
		}
	}
}