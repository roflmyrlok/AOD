using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Monster : Character<IMonsterView>
	{
		public Monster() : base()
		{
		}
		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Monster";
			Skills = new List<Skill>();
		}
		
		public override void InitSkillsAndSkillViews(List<ISkillView> skillViews)
		{
			var monsterAttack = new AttackMonster();
			if (skillViews.FirstOrDefault(view => view is IAttackMonsterView) is IAttackMonsterView monsterAttackView)
			{
				monsterAttack.InitView(monsterAttackView);
				Skills.Add(monsterAttack);
			}
			else
			{
				throw new Exception("monsterAttackView not found in skill views");
			}
		}
	}
}