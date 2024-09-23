using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class Skill : IInteractiveSkill
	{
		protected abstract ISkillView SkillView { get; }
		protected List<int> PositionsCanTarget;
		public string Name;
		public abstract void InitView(ISkillView view);
		public List<int> GetPositionsCanTarget()
		{
			return PositionsCanTarget;
		}

		public abstract void PerformSkill(Character performer, List<Character> targets);
	}
	
	public abstract class Skill<TView> : Skill where TView : ISkillView
	{
		protected TView TypedView { get; private set; } 

		protected override ISkillView SkillView => TypedView;
		
		public override void InitView(ISkillView view)
		{
			if (view is not TView typed)
			{
				throw new Exception($"trying to assign {view} to not typed");
			}

			TypedView = typed;
		}
	}
}