using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Archer : Character<IArcherView>
	{
		public Archer() : base(){
		}

		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Archer";

			CharacterStats.SetMaxHealth(100);
			CharacterStats.SetHealth(100);
			CharacterStats.SetAttack(30);
			CharacterStats.SetDefence(0);
			CharacterStats.SetSpeed(10);

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