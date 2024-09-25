using Model;
using UnityEngine;

namespace View
{
	public class BowAttackArcherView : SkillView<BowAttackArcher>, IBowAttackArcherView
	{
		public void ShowBowAttackPerformed(Character target)
		{
			Debug.Log("Show archer attack performed");
		}
	}
}