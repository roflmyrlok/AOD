using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Model;
using View;
using Controller;
using CharacterController = Controller.CharacterController;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private List<CharacterView> characterPrefabs;

    [SerializeField]
    private SimpleFightFlowView fightFlowView;

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

        var fightFlow = new SimpleFightFlow(new Field(characterModels), fightFlowView);

        foreach (var character in characterModels)
        {
            var prefab = characterPrefabs.FirstOrDefault(p => p.IsViewFor(character));
            if (prefab != null)
            {
                var charView = Instantiate(prefab, charactersParent);
                character.InitViewAndStats(charView);

                var skillViews = charView.GetComponentsInChildren<ISkillView>(true).ToList();
                character.InitSkillsAndSkillViews(skillViews);

                var characterController = charView.GetComponentInChildren<CharacterController>();
                if (characterController != null)
                {
                    var buttons = charView.GetComponentsInChildren<Button>(true).ToList();
                    characterController.InitializeController(character, fightFlow, buttons);
                }

                fightFlowView.RegisterCharacter(character, charView);
            }
        }

        int position = 1;
        foreach (var character in characterModels)
        {
            character.SetCurrentPosition(position);
            position++;
        }

        fightFlow.InitialiseSimpleFightFlow();
    }
}
