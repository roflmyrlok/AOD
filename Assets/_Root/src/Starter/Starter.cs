using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Model;
using View;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private List<CharacterView> characterPrefabs;

    [SerializeField]
    private FightRoundView fightRoundView;

    [SerializeField]
    private Transform charactersParent;

    private void Start()
    {
        var characterModels = new List<Character>
        {
            new Knight(),
            new Archer(),
            new Archer(),
            new Archer(),
            new Archer(),
            new Archer(),
            new Archer(),
            new Archer()
        };
        
        InitializeCharacterSkills(characterModels);
        
        foreach (var character in characterModels)
        {
            var prefab = characterPrefabs.FirstOrDefault(p => p.IsViewFor(character));
            if (prefab != null)
            {
                var charView = Instantiate(prefab, charactersParent);
                character.InitView(charView);
                
                var skillControllers = charView.GetComponentsInChildren<SkillController>(true);
                foreach (var skillController in skillControllers)
                {
                    var buttons = skillController.GetComponentsInChildren<Button>(true);
                    if (buttons.Length == 0)
                    {
                        Debug.LogError($"No buttons found in skill controller: {skillController.name}");
                        continue;
                    }
                    skillController.InitializeController(buttons.ToList(), 
                        new FightRound(new Field(characterModels), fightRoundView), 
                        character);
                }
            }
            else
            {
                throw new System.Exception($"There is no prefab for character: {character.GetType().Name}");
            }
        }
        
        int position = 1;
        foreach (var character in characterModels)
        {
            character.SetCurrentPosition(position);
            character.ChangeMaxHealth(100);
            character.ChangeCurrentHealth(100);
            character.Attack = 10;
            position++;
        }
    }

    private void InitializeCharacterSkills(List<Character> characterModels)
    {
        foreach (var character in characterModels)
        {
            if (character is Knight knight)
            {
                var swordAttackSkill = new SwordAttackKnight();
                knight.Skills.Add(swordAttackSkill);
            }
            else if (character is Archer archer)
            {
                var bowAttackSkill = new BowAttackArcher();
                archer.Skills.Add(bowAttackSkill);
            }
        }
    }
}
