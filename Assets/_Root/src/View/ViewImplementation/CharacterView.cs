using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public abstract class CharacterView<TCharacter> : CharacterView, ICharacterView
        where TCharacter : Character
    {
        [SerializeField]
        private Slider healthSlider; 

        private Vector2[] screenPositions = new Vector2[8];

        protected virtual void Awake()
        {
            InitializeScreenPositions();
        }

        private void InitializeScreenPositions()
        {
            float screenWidth = Screen.width;
            float partWidth = screenWidth / 24f;

            screenPositions[0] = GetMiddlePositionOfParts(4, 5, partWidth); 
            screenPositions[1] = GetMiddlePositionOfParts(6, 7, partWidth); 
            screenPositions[2] = GetMiddlePositionOfParts(8, 9, partWidth); 
            screenPositions[3] = GetMiddlePositionOfParts(10, 11, partWidth); 
            screenPositions[4] = GetMiddlePositionOfParts(14, 15, partWidth); 
            screenPositions[5] = GetMiddlePositionOfParts(16, 17, partWidth); 
            screenPositions[6] = GetMiddlePositionOfParts(18, 19, partWidth); 
            screenPositions[7] = GetMiddlePositionOfParts(20, 21, partWidth); 
        }

        private Vector2 GetMiddlePositionOfParts(int part1, int part2, float partWidth)
        {
            float xPosition = (part1 + part2) / 2f * partWidth;
            return new Vector2(xPosition, Screen.height / 2); 
        }

        public override bool IsViewFor(Character shape) => shape is TCharacter;

        public override void CharacterPositionChanged(int newPosition)
        {
            if (newPosition < 1 || newPosition > 8)
            {
                Debug.LogError("Invalid position. Must be between 1 and 8.");
                return;
            }

            var currentCanvas = GetComponentInParent<Canvas>();
            MoveCharacterToPosition(transform, newPosition, currentCanvas);
        }

        private void MoveCharacterToPosition(Transform characterTransform, int position, Canvas canvas)
        {
            Vector2 targetScreenPosition = screenPositions[position - 1]; 

            Vector3 worldPosition = canvas.worldCamera.ScreenToWorldPoint(new Vector3(targetScreenPosition.x,
                targetScreenPosition.y, canvas.planeDistance));
            
            characterTransform.position = new Vector3(worldPosition.x, worldPosition.y, characterTransform.position.z);

            foreach (Transform child in characterTransform.GetComponentsInChildren<Transform>())
            {
                if (child.CompareTag("CharacterModel"))
                {
                    if (position >= 5 && position <= 8)
                    {
                        child.localRotation = Quaternion.Euler(0, 180, 0); 
                    }
                    else
                    {
                        child.localRotation = Quaternion.Euler(0, 0, 0); 
                    }
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

            SetCurrentHealth(healthSlider, currentHealth);
            SetMaxHealth(healthSlider, maxHealth);
        }

        private void SetMaxHealth(Slider slider, int value)
        {
            slider.maxValue = value;
        }

        private void SetCurrentHealth(Slider slider, int value)
        {
            slider.value = value;
        }
    }

    public abstract class CharacterView : MonoBehaviour, ICharacterView
    { 
        public abstract bool IsViewFor(Character shape);
        public abstract void CharacterPositionChanged(int position);
        public abstract void CharacterHealthChanged(int currentHealth, int maxHealth);
    }
}
