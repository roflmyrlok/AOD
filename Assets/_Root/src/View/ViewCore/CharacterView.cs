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
		public abstract void CharacterHealthChanged(int currentHealth, int maxHealth);
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
			foreach (Transform child in transform.GetComponentsInChildren<Transform>())
			{
				if (child.CompareTag("CharacterModel"))
				{
					child.localRotation = Quaternion.Euler(0, 180, 0);
				}
			}
		}

		public override void CharacterHealthChanged(int currentHealth, int maxHealth)
		{
			if (healthSlider == null)
			{
				Debug.LogError("HealthSlider is not assigned.");
				return;
			}

			SetMaxHealth(healthSlider, maxHealth);
			SetCurrentHealth(healthSlider, currentHealth);
		}

		private void SetMaxHealth(Slider slider, int value)
		{
			slider.maxValue = value;
		}

		private void SetCurrentHealth(Slider slider, int value)
		{
			slider.value = value;
		}

		public override void SetButtonsState(bool isActive)
		{
			var buttons = GetComponentsInChildren<Button>(true);
			Canvas parentCanvas = GetComponentInParent<Canvas>();

			if (parentCanvas != null)
			{
				ButtonManager buttonManager = parentCanvas.GetComponentInChildren<ButtonManager>();

				if (buttonManager != null)
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
						buttonManager.PutButtonsToTheLayout(buttonReturnParentDict);
					}
				}
			}
		}

	}
}