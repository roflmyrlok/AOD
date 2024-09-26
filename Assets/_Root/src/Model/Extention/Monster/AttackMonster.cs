using System;
using System.Collections.Generic;
using UnityEngine;
using Exception = System.Exception;

namespace Model
{
    public class AttackMonster : Skill<IAttackMonsterView>
    {
        private readonly float _skillDamageMultiplier = 1f;

        public AttackMonster()
        {
            Name = "Monster attack";
            PositionsCanTarget = new List<Position>();
            PositionsCanTarget.Add(new Position(1, false));
            PositionsCanTarget.Add(new Position(2, false));
            PositionsCanTarget.Add(new Position(3, false));
            PositionsCanTarget.Add(new Position(4, false));
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