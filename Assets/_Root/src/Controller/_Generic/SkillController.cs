using System.Collections.Generic;
using Model;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
	public abstract class SkillController : MonoBehaviour
	{
		public abstract void InitializeController(List<Button> buttons, SimpleFightFlow fightFlow, Character character);
		
	}

	public abstract class SkillController<TSkill> : SkillController where TSkill : Skill
	{
		public abstract override void InitializeController(List<Button> buttons, SimpleFightFlow fightFlow, Character character);
	}
}