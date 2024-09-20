using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Model;
using View; // Ensure you include the namespace for your Model classes

public class Starter : MonoBehaviour
{
    [SerializeField]
    private List<CharacterView> characters; // Prefabs for character views

    [SerializeField]
    private FightRoundView fightRoundView; // This should implement Model.IFightRoundView

    [SerializeField]
    private Transform charactersParent; // Parent transform for instantiated characters

    [SerializeField]
    private FightController fightController; // Reference to the FightController

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
        
        foreach (var character in characterModels.OfType<Knight>())
        {
            var swordAttackSkill = new SwordAttackKnight();
            character.Skills.Add(swordAttackSkill); // Assuming AddSkill is a method to add skills to a character
        }

        // Add the BowAttackArcher skill to each Archer
        foreach (var character in characterModels.OfType<Archer>())
        {
            var bowAttackSkill = new BowAttackArcher();
            character.Skills.Add(bowAttackSkill); // Assuming AddSkill is a method to add skills to a character
        }
        
        

        var field = new Field(characterModels);
        var charViews = new List<ICharacterView>();

        // Dictionary to map buttons to characters
        var buttonToCharacterMap = new Dictionary<Button, Character>();

        foreach (var character in characterModels)
        {
            var prefab = characters.FirstOrDefault(prefab => prefab.IsViewFor(character));
            if (prefab != null)
            {
                var charView = Instantiate(prefab, charactersParent);
                charViews.Add(charView);
                character.InitView(charView);

                // Find skill prefabs and buttons
                var skillViews = charView.GetComponentsInChildren<SkillView>(true);
                foreach (var skillView in skillViews)
                {
                    var buttons = skillView.GetComponentsInChildren<Button>(true);
                    foreach (var button in buttons)
                    {
                        buttonToCharacterMap[button] = character; // Map button to character
                    }
                }
            }
            else
            {
                throw new System.Exception("There is no prefab for character");
            }
        }

        // Initialize FightRound and FightController
        var fightRound = new FightRound(field, fightRoundView);

        if (fightController != null)
        {
            var buttons = GetButtons(); // Retrieve all buttons
            fightController.InitializeController(buttons, fightRound, buttonToCharacterMap);
        }
        else
        {
            Debug.LogError("FightController is not assigned.");
        }

        // Set character positions and update health
        var position = 1;
        foreach (var character in characterModels)
        {
            character.SetCurrentPosition(position);
            position++;
            character.ChangeMaxHealth(100);
            character.ChangeCurrentHealth(100);
            character.Attack = 10;
        }
        characterModels[2].TakeDamage(5, null);
    }

    private List<Button> GetButtons()
    {
        var buttons = new List<Button>();

        // Find all character prefabs in the scene
        var charactersInScene = FindObjectsOfType<CharacterView>(); // Assuming CharacterView is your component for characters

        foreach (var characterView in charactersInScene)
        {
            // Find all skill prefabs within the character prefab
            var skillPrefabs = characterView.GetComponentsInChildren<SkillView>(true); // Replace SkillView with the actual component/script used in skill prefabs

            foreach (var skillView in skillPrefabs)
            {
                // Find all buttons within the skill prefab
                var skillButtons = skillView.GetComponentsInChildren<Button>(true);
                buttons.AddRange(skillButtons);
            }
        }

        return buttons;
    }
}
