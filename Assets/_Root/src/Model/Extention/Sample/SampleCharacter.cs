using System.Collections.Generic;
using System.Linq;

namespace Model
{
	using System;

	public class SampleCharacter : Character<ISampleView>
	{
		SampleCharacter()
		{
			TypedView.ShowSampleAction();
		}

		public override void InitViewAndStats(ICharacterView view)
		{
			base.InitViewAndStats(view);
			Name = "Sample";
			ChangeMaxHealth(0);
			ChangeCurrentHealth(0);
			Attack = 0;
			Defence = 0;
			Speed = 0;
			Skills = new List<Skill>();
		}
		
		public override void InitSkillsAndSkillViews(List<ISkillView> skillViews)
		{
			var sampleSkill = new SampleSkill();
			if (skillViews.FirstOrDefault(view => view is ISampleSkillView) is ISampleSkillView sampleSkillView)
			{
				sampleSkill.InitView(sampleSkillView);
				Skills.Add(sampleSkill);
			}
			else
			{
				throw new Exception("sampleSkillView not found in skill views");
			}
		}
	}
}