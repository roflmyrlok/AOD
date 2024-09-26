using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Knight : Character<IKnightView>
	{
		public Knight() : base()
		{
			
		}
		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Knight";
			CharacterStats.SetMaxHealth(150);
			CharacterStats.SetHealth(150);
			CharacterStats.SetAttack(15);
			CharacterStats.SetDefence(0);
			CharacterStats.SetSpeed(6);
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