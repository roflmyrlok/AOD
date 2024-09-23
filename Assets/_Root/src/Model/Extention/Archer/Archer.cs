using System.Collections.Generic;
using System.Linq;

namespace Model
{
	using System;

	public class Archer : Character<IArcherView>
	{
		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Archer";
			ChangeMaxHealth(100);
			ChangeCurrentHealth(100);
			Attack = 10;
			Defence = 0;
			Speed = 10;
			Skills = new List<Skill>();
		}

		public override void InitSkillsAndSkillViews(List<ISkillView> skillViews)
		{
			var bowAttackArcher = new BowAttackArcher();
			if (skillViews.FirstOrDefault(view => view is IBowAttackArcherView) is IBowAttackArcherView bowAttackArcherView)
			{
				bowAttackArcher.InitView(bowAttackArcherView);
				Skills.Add(bowAttackArcher);
			}
			else
			{
				throw new Exception("BowAttackArcherView not found in skill views");
			}
		}

	}
}