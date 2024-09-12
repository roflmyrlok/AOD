using Model;
using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameModel _gameModel;
    private Scene1 _controller;
    private View _view;

    void Start()
    {
        // Find or create instances of View, Controller, and Model

        // Assume View and Controller are attached to objects in the scene
        _view = FindObjectOfType<View>();
        _controller = FindObjectOfType<Scene1>();

        if (_view == null || _controller == null)
        {
            Debug.LogError("View or Controller not found in the scene.");
            return;
        }

        // Create and initialize the GameModel, passing in the view
        _gameModel = new GameModel(_view);

        // Initialize the controller with the model
        _controller.Initialize(_gameModel);

        Debug.Log("MVC Setup Complete.");
    }
}
