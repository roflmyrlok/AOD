using UnityEngine;
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
    private Transform playerCharParent;
    
    [SerializeField]
    private Transform enemyCharParent;
    
    [SerializeField] 
    private EnemyTeamView enemyTeamView;
    
    [SerializeField]
    private PlayerTeamView playerTeamView;

    [SerializeField] 
    private TargetManager targetManager;
    
    private void Start()
    {
        var characterModels = new List<Character>
        {
            new Knight(),
            new Archer(),
            new Archer(),
            new Archer(),
            new Knight(),
            new Archer(),
            new Archer(),
            new Archer()
        };

        var playerTeam = new Team(characterModels.GetRange(0, 4));
        var enemyTeam = new Team(characterModels.GetRange(4, 4));

        var fightFlow = new SimpleFightFlow(playerTeam, enemyTeam, fightFlowView);
        

        foreach (var character in characterModels)
        {
            var prefab = characterPrefabs.FirstOrDefault(p => p.IsViewFor(character));
            if (prefab != null)
            {
                var isPlayerTeam = playerTeam.Contains(character);
                var parent = isPlayerTeam ? playerCharParent : enemyCharParent;
                var charView = Instantiate(prefab,  parent);
                character.InitViewAndStats(charView);
                var skillViews = charView.GetComponentsInChildren<ISkillView>(true).ToList();
                character.InitSkillsAndSkillViews(skillViews);
                
                var characterController = charView.GetComponentInChildren<CharacterController>();
                if (characterController != null)
                { 
                    var buttons = charView.GetComponentsInChildren<UnityEngine.UI.Button>(true).ToList();
                    characterController.InitializeController(character, fightFlow, buttons);
                }

                if (isPlayerTeam)
                {
                    playerTeamView.RegisterCharacter(character, charView);
                }
                else
                {
                    enemyTeamView.RegisterCharacter(character, charView);
                }
                fightFlowView.RegisterCharacter(character, charView);
            }
            else
            {
                Debug.LogError($"Prefab for {character.GetType().Name} does not match the expected CharacterView type.");
            }
        }

        playerTeam.InitTeamView(playerTeamView);
        enemyTeam.InitTeamView(enemyTeamView);
        fightFlow.InitialiseSimpleFightFlow();
    }
}
