using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Model;

public abstract class SkillController : MonoBehaviour
{
	public abstract void InitializeController(List<Button> buttons, Fight round, Character character);
}

public abstract class SkillController<TypedSkill> : SkillController where TypedSkill : Skill
{
	public abstract override void InitializeController(List<Button> buttons, Fight round, Character character);
}