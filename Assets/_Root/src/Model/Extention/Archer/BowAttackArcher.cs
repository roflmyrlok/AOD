using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Model
{
	public class BowAttackArcher : Skill<IBowAttackArcherView>
	{
		private readonly float _skillDamageMultiplier = 2.5f;

		public BowAttackArcher()
		{
			Name = "Bow attack";
			PositionsCanTarget = new List<Position>();
			PositionsCanTarget.Add(new Position(1, false));
			PositionsCanTarget.Add(new Position(2, false));
			PositionsCanTarget.Add(new Position(4, false));
			PositionsCanTarget.Add(new Position(3, false));
			Index = 1;
		}

		public override void PerformSkill(Character performer, List<Position> targets, Team performerTeam, Team enemyTeam)
		{
			foreach (var target in targets)
			{
				if (!PositionsCanTarget.Contains(target))
				{
					throw new Exception("cant target character at position");
				}

				performer.DealAttackMultiDamage(_skillDamageMultiplier,
					target.IsPlayerTeam
						? performerTeam.GetCharacterByPosition(target)
						: enemyTeam.GetCharacterByPosition(target.OpposingPosition()));
				//TypedView.ShowBowAttackPerformed(target);
			}
			
		}
	}
}