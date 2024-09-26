using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;

namespace View
{
	public abstract class CharacterView : MonoBehaviour, ICharacterView
	{
		public abstract bool IsViewFor(Character shape);
		public abstract void ChangePosition(Vector3 newPosition);
		public abstract void RotateCharacterModel();

		public abstract void UpdateStats(Stats stats);
		public void CharacterDead()
		{
			foreach (var tr in GetComponentsInChildren<Transform>(true))
			{
                
				if (tr.name == "CorpseSprite")
				{
					tr.gameObject.SetActive(true); 
				}
				if (tr.name == "AliveSprite")
				{
					tr.gameObject.SetActive(false); 
				}
				if (tr.name == "HealthBar")
				{
					tr.gameObject.SetActive(false); 
				}
                
			}
		}


		public abstract void SetButtonsState(bool isActive);

		public Vector3 GetPosition()
		{
			return transform.position;
		}
	}

	public abstract class CharacterView<TCharacter> : CharacterView
		where TCharacter : Character
	{
		[SerializeField]
		private Slider healthSlider;

		protected virtual void Awake()
		{
		}

		public override bool IsViewFor(Character shape) => shape is TCharacter;

		public override void ChangePosition(Vector3 newPosition)
		{
			transform.position = newPosition;
		}

		public override void RotateCharacterModel()
		{
			foreach (Transform child in GetComponentsInChildren<Transform>(true))
			{
				if (child.CompareTag("CharacterModel"))
				{
					child.localRotation = Quaternion.Euler(0, 180, 0);
				}
			}
		}

		public override void UpdateStats(Stats stats)
		{
			if (healthSlider == null)
			{
				Debug.LogError("HealthSlider is not assigned.");
				return;
			}
            
			healthSlider.maxValue = stats.MaxHealth;
			healthSlider.value = stats.Health;
            
			// ToDO: update other stats in proper UI
            
		}

		public override void SetButtonsState(bool isActive)
		{
			var buttons = GetComponentsInChildren<Button>(true);
			Canvas parentCanvas = GetComponentInParent<Canvas>();

			if (parentCanvas != null)
			{
				SkillButtonManager skillButtonManager = parentCanvas.GetComponentInChildren<SkillButtonManager>();

				if (skillButtonManager != null)
				{
					Dictionary<Button, GameObject> buttonReturnParentDict = new Dictionary<Button, GameObject>();

					foreach (var button in buttons)
					{
						if (button != null)
						{
							if (isActive)
							{
								buttonReturnParentDict.Add(button, button.transform.parent.gameObject);
							}
							button.gameObject.SetActive(isActive);
						}
					}

					if (isActive)
					{
						skillButtonManager.PutButtonsToTheLayout(buttonReturnParentDict);
					}
				}
			}
		}
	}
}