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
			PositionsCanTarget = new List<int>() {5, 6};
		}

		public override void PerformSkill(Character performer, List<Character> targets)
		{
			foreach (var target in targets)
			{
				if (!PositionsCanTarget.Contains(target.GetCurrentPosition()))
				{
					throw new Exception($"{Name} cannot target position {target.GetCurrentPosition()}");
				}
				performer.DealAttackMultiDamage(_skillDamageMultiplier, target);
				//TypedView.ShowSwordAttackPerformed(target);
			}
			
		}
	}
}