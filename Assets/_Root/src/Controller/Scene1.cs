using Model;
using UnityEngine;
using UnityEngine.InputSystem;

	public class Scene1 : MonoBehaviour
	{
		private GameModel _gameModel;
		public InputAction teamControls;

		// Initialize the controller with the model
		public void Initialize(GameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void OnEnable()
		{
			teamControls.Enable();
		}

		private void OnDisable()
		{
			teamControls.Disable();
		}

		void Update()
		{
			// Read the float value from the input (it should now be a single axis, not Vector2)
			float input = teamControls.ReadValue<float>();

			int gameState = 0;
			if (input > 0)
			{
				gameState = 1;  // Move right
			}
			else if (input < 0)
			{
				gameState = -1;  // Move left
			}

			// Update the model based on the input
			if (_gameModel != null)
			{
				_gameModel.UpdateGameState(gameState);
			}
		}
	}