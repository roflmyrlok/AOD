using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Model
{
    public class Team
    {
        private readonly Dictionary<Position, Character> _characterPositions;
        private ITeamView _teamView;
        [CanBeNull] private Team _opposingTeam;
        public Team(List<Character> characters)
        {
            _characterPositions = new Dictionary<Position, Character>();
            for (int i = 0; i < characters.Count; i++)
            {
                _characterPositions[new Position( i + 1,true)] = characters[i];
            }
        }

        public void InitTeamView(ITeamView teamView)
        {
            _teamView = teamView;
            _teamView.UpdatedCharacterPositions(_characterPositions);
        }

        public bool IsCharacterPresent(Position position)
        {
            return _characterPositions.ContainsKey(position);
        }

        public Character GetCharacterByPosition(Position position)
        {
            if (position.IsPlayerTeam && _characterPositions.TryGetValue(position, out var character))
            {
                return character;
            }
            throw new Exception($"No character found at position {position}");
        }
        
        public Position GetPositionByCharacter(Character character)
        {
            try
            {
                return _characterPositions.FirstOrDefault(pair => pair.Value == character).Key;
            }
            catch 
            {
                throw new Exception($"No character found");
            }
        }

        public Dictionary<Character, int> GetCharactersBySpeed()
        {
            return new Dictionary<Character, int>(_characterPositions.Select(kvp => new KeyValuePair<Character, int>(kvp.Value, kvp.Value.Speed)));
        }

        public bool TryCharacterChangePosition(Character character,Position newPosition)
        {
            var oldPosition = GetPositionByCharacter(character);
            if (!_characterPositions.ContainsKey(oldPosition))
            {
                return false; 
            }

            var characterAtOldPosition = _characterPositions[oldPosition];

            if (!_characterPositions.ContainsKey(newPosition))
            {
                _characterPositions.Remove(oldPosition);
                _characterPositions[newPosition] = characterAtOldPosition;
                _teamView.UpdatedCharacterPositions(_characterPositions);
                return true;
            }
            else
            {
                var characterAtNewPosition = _characterPositions[newPosition];
                _characterPositions[oldPosition] = characterAtNewPosition;
                _characterPositions[newPosition] = characterAtOldPosition;
                _teamView.UpdatedCharacterPositions(_characterPositions);
                return true;
            }
        }

        public bool Contains(Character character)
        {
            return _characterPositions.ContainsValue(character);
        }
    }
}
