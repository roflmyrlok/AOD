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

        public bool TryShowSkillTargets(Character character, int skillPosition)
        {
            if (!_currentCharacter.Equals(character))
            {
                return false;
            }
            ShowSkillTargets(character, skillPosition);
            return true;
        }

        public bool TryUseCharacterSkill(Character character, int skillPosition, List<Position> targetPosition)
        {
            if (!_currentCharacter.Equals(character))
            {
                return false;
            }
            
            UseCharacterSkill( character, skillPosition, targetPosition);

            EndTurnWithCharacterAction(character);
            return true;
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
                Debug.Log("New current character is " + _currentCharacter.Name + ", can make move"); // This must be shown in view
                FightFlowView.ShowCurrentCharacter(_currentCharacter);
            }
        }
    }
}
