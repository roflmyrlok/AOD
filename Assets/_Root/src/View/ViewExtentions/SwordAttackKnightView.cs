using Model;
using UnityEngine;

namespace View
{
    public class SwordAttackKnightView : SkillView<SwordAttackKnight>, ISwordAttackKnightView
    {
        public void ShowSwordAttackPerformed(Character target)
        {
            Debug.Log("Show knight attack performed");
        }
    }
}