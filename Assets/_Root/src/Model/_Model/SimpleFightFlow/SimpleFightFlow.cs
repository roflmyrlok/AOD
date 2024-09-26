using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class SimpleFightFlow : Fight
    {
        public IFightFlowView FightFlowView;
        private Character _currentCharacter;
        private List<Character> _charactersMadeMove;

        public SimpleFightFlow(Team playerTeam, Team enemyTeam, IFightFlowView view) : base(playerTeam, enemyTeam, view)
        {
            FightFlowView = view;
            _charactersMadeMove = new List<Character>();
        }
        
        public void InitialiseSimpleFightFlow()
        {
            SetCurrentCharacter();
        }

        public override void ShowSkillTargets(Character character, int skillIndex)
        {
            if (!_currentCharacter.Equals(character))
            {
                throw new Exception("bruh");
            }
            FightView.ShowTargetCharacters(character, character.Skills.FirstOrDefault(s => s.Index == skillIndex), UseCharacterSkill);
        }
        public override void UseCharacterSkill(Character character, int skillIndex, List<Position> targetPosition)
        {
            if (!_currentCharacter.Equals(character))
            {
                throw new Exception("bruh");
            }
            
            base.UseCharacterSkill( character, skillIndex, targetPosition);

            EndTurnWithCharacterAction(character);
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
            // Combine characters from both teams
            var allCharacters = PlayerTeam.GetCharactersBySpeed()
                .Concat(EnemyTeam.GetCharactersBySpeed())
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value); // Combine into a single dictionary

            _currentCharacter = allCharacters
                .Where(kvp => !_charactersMadeMove.Contains(kvp.Key))
                .OrderByDescending(kvp => kvp.Value) // Order by speed
                .Select(kvp => kvp.Key)
                .FirstOrDefault();

            if (_currentCharacter is not null)
            {
                FightFlowView.ShowCurrentCharacter(_currentCharacter);
            }
            if (_currentCharacter is null)
            {
                _charactersMadeMove.Clear();
                SetCurrentCharacter();
            }
        }
    }
}
