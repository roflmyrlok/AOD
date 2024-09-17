namespace Starter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using UnityEngine;
    using View;

    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private List<CharacterView> characters;

        [SerializeField]
        private FightRoundView view;

        [SerializeField]
        private Transform charactersParent;
		
        private void Start()
        {
            var characterModels = new List<Character>()
            {
                new Knight(),
                new Archer(),
                new Archer(),
                new Archer(),
                new Monster(),
                new Monster(),
                new Monster(),
                new Monster()
            };
            var field = new Field(characterModels);
            var charViews = new List<ICharacterView>();

            // for each
            foreach (var character in characterModels)
            {
                // iterate through prefabs

                var prefab = characters.FirstOrDefault(prefab => prefab.IsViewFor(character));
                if (prefab != null)
                {
                    var charView = Instantiate(prefab, charactersParent);
                    charViews.Add(charView);
                    character.InitView(charView);
                }
                else
                {
                    throw new Exception("There is no prefab for Archer");
                }
            }
            
            view.StartRound(new FightRound(field, null), charViews);
            var position = 1;
            foreach (var character in characterModels)
            {
                character.SetCurrentPosition(position);
                position++;
            }
        }
    }
}