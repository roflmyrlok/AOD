using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
	public class BowAttackArcher : Skill<IBowAttackArcherView>
	{
		private readonly float _skillDamageMultiplier = 2.5f;

		public BowAttackArcher()
		{
			Name = "Bow attack";
			PositionsCanTarget = new List<int> {7, 8};
		}

		public override void PerformSkill(Character performer, List<Character> targets)
		{
			
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