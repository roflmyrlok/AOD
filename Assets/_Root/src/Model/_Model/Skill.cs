using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class Skill
	{
		protected abstract ISkillView SkillView { get; }
		
		public int Index { get; protected set; }
		public List<Position> PositionsCanTarget { get; protected set; }
		public string Name;
		public abstract void InitView(ISkillView view);
		public abstract void PerformSkill(Character performer, List<Position> targets, Team performerTeam, Team enemyTeam);
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