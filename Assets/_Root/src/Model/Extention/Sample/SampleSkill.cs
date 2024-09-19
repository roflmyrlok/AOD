using System;
using System.Collections.Generic;

namespace Model
{

	public class SampleSkill : Skill<ISampleSkillView>
	{
		public override void PerformSkill(Character performer, List<Character> targets)
		{
			foreach (var target in targets)
			{
				performer.DealAttackMultiDamage(0, target);
			}
		}
	}
}