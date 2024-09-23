using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using NUnit.Framework;
using UnityEngine;

namespace Model
{
    public class SimpleFightFlow : Fight, IInteractiveFightFlow
    {
        public IFightFlowView FightFlowView;
        private Character _currentCharacter;
        private List<Character> _charactersMadeMove;

        public SimpleFightFlow(Field currentFight, IFightFlowView view) : base(currentFight, view)
        {
            FightFlowView = view;
            Debug.Log(view);
            _charactersMadeMove = new List<Character>();
        }
        
        public void InitialiseSimpleFightFlow()
        {
            SetCurrentCharacter();
        }

        public bool TryShowSkillTargets(int characterPosition, int skillPosition)
        {
            if (!CurrentFightField.IsCharacterPresent(characterPosition))
            {
                return false;
            }

            var character = CurrentFightField.GetCharacterOnPosition(characterPosition);
            if (_currentCharacter != character)
            {
                return false;
            }
            ShowSkillTargets(characterPosition, skillPosition);
            return true;

        }

        public bool TryUseCharacterSkill(int characterPosition, int skillPosition, List<int> targetPosition)
        {
            if (!CurrentFightField.IsCharacterPresent(characterPosition))
            {
                return false;
            }

            var character = CurrentFightField.GetCharacterOnPosition(characterPosition);
            if (_currentCharacter != character)
            {
                return false;
            }
            UseCharacterSkill(characterPosition, skillPosition, targetPosition);
            EndTurnWithCharacterAction(character);
            return true;
        }

        public bool TryCharacterChangePosition(int oldPosition, int newPosition)
        {
            if (!CurrentFightField.IsCharacterPresent(oldPosition))
            {
                return false;
            }

            var character = CurrentFightField.GetCharacterOnPosition(oldPosition);
            if (_currentCharacter != character)
            {
                return false;
            }
            var positionCHanged = CharacterChangePosition(oldPosition, newPosition);
            if (positionCHanged)
            {
                EndTurnWithCharacterAction(character);
                return true;
            }
            return false;
        }

        private void EndTurnWithCharacterAction(Character character)
        {
            _charactersMadeMove.Add(character);
            if (_charactersMadeMove.Count == 8)
            {
                _charactersMadeMove.Clear();
            }
            SetCurrentCharacter();
        }
        private void SetCurrentCharacter()
        {
            var dict = CurrentFightField.GetCharactersBySpeed(); 
            _currentCharacter = dict
                .Where(kvp => !_charactersMadeMove.Contains(kvp.Key))
                .OrderByDescending(kvp => kvp.Value) 
                .Select(kvp => kvp.Key)
                .FirstOrDefault();
            if (_currentCharacter is not null)
            {
                Debug.Log("new current character is " + _currentCharacter.GetCurrentPosition() + ", can make move"); // this must be show in view
                FightFlowView.CurrentCharacter(_currentCharacter);
            }
        }

    }
}