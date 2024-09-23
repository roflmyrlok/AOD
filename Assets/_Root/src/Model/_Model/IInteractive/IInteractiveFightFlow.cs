using System.Collections.Generic;

namespace Model
{
    public interface IInteractiveFightFlow 
    {
        public bool TryShowSkillTargets(int characterPosition, int skillPosition);
        public bool TryUseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition);
        public bool TryCharacterChangePosition(int oldPosition, int newPosition);
    }
}