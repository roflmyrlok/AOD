using System.Collections.Generic;

namespace Model
{
	public abstract class Skill
	{
		private IPerformedSkillView _performedSkillView;
		protected List<int> _positionsCanTarget;
		public string Name;

		protected Skill(IPerformedSkillView interactionView)
		{
			_performedSkillView = interactionView;
			_positionsCanTarget = new List<int>();
			Name = "";
		}

		public List<int> GetPositionsCanTarget()
		{
			return _positionsCanTarget;
		}

		public virtual void Perform(Field field, int target, Character performer)
		{
		}
	}
}