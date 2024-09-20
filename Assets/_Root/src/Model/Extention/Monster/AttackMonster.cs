using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class AttackMonster : Skill<IAttackMonsterView>
    {
        private readonly float _skillDamageMultiplier = 1f;

        public AttackMonster()
        {
            Name = "Monster attack";
            PositionsCanTarget = new List<int> {1, 2, 3, 4};
        }

        public override void PerformSkill(Character performer, List<Character> targets)
        {
            if (targets.Count > 1)
            {
                throw new Exception("monster targets can't be more than 1!");
            }
			
            foreach (var target in targets)
            {
				
                if (!PositionsCanTarget.Contains(target.GetCurrentPosition()))
                {
                    throw new Exception($"cant target character at position {target.GetCurrentPosition()}");
                }
                performer.DealAttackMultiDamage(_skillDamageMultiplier, target);
                
                //TypedView.ShowBowAttackPerformed(target);
            }
			
        }
    }
}