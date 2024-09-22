using System.Collections.Generic;
using NUnit.Framework;

namespace Model
{
    public class FightFlow : IInteractiveFightFlow
    {
        public Fight currentFight;
        public IFightFlowView view;
        private Character currentCharacter;
        private List<Character> charactersMadeMove;
        
        public bool TryShowSkillTargets(int characterPosition, int skillPosition)
        {
            throw new System.NotImplementedException();
        }

        public bool TryUseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition)
        {
            Character character = currentFight.GetCharacterAtPosition(characterPosition);
            Skill skill = character.GetSkillAtPosition(skillPosition);

            if (character == null || skill == null || targetPosition == null)
            {
                return false; 
            }
            
            foreach (int targetPositions in targetPosition)
            {
                if (!IsTargetValid(characterPosition, targetPositions, skill))
                {
                    return false; // Invalid target
                }
            }

            
            foreach (int targetPositions in targetPosition)
            {
                Character target = currentFight.GetCharacterAtPosition(targetPositions);
                skill.Apply(character, target); // Assuming Apply is the method for executing the skill
            }

            CharacterMadeAction(character);
            return true;
        }

        public bool TryCharacterChangePosition(int oldPosition, int newPosition)
        {
            throw new System.NotImplementedException();
        }

        private void CharacterMadeAction(Character character)
        {
            charactersMadeMove.Add(character);
            if (charactersMadeMove.Count == 8)
            {
                charactersMadeMove.Clear();
            }
        }
    }
}