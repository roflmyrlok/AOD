using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Knight : Character<IKnightView>
	{
		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Knight";
			ChangeMaxHealth(200);
			ChangeCurrentHealth(200);
			Attack = 8;
			Defence = 0;
			Speed = 5;
			Skills = new List<Skill>();
		}
		
		public override void InitSkillsAndSkillViews(List<ISkillView> skillViews)
		{
			var swordAttackKnight = new SwordAttackKnight();
			if (skillViews.FirstOrDefault(view => view is ISwordAttackKnightView) is ISwordAttackKnightView swordAttackKnightView)
			{
				swordAttackKnight.InitView(swordAttackKnightView);
				Skills.Add(swordAttackKnight);
			}
			else
			{
				throw new Exception("swordAttackKnightView not found in skill views");
			}
		}
	}
}