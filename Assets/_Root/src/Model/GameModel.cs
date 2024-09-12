namespace Model
{
	public class GameModel : IInteractive
	{
		private int _gameState;
		private IView _view;

		// Model is responsible for managing game state and notifying the view
		public GameModel(IView view)
		{
			_gameState = 0;
			_view = view;
		}

		public void UpdateGameState(int newGameState)
		{
			_gameState = newGameState;
			_view.ShowGameState(_gameState);  // Notify the view about the state change
		}
	}
}