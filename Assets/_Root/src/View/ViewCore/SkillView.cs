using Model;
using UnityEngine;

namespace View
{
	public abstract class SkillView<TSkill> : SkillView
		where TSkill : Skill
	{
		public override bool IsViewFor(Skill skill) => skill is TSkill;
	}
	
	public abstract class SkillView : MonoBehaviour, ISkillView
	{ 
		public abstract bool IsViewFor(Skill skill);
	}
}