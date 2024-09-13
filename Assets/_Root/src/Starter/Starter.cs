using System.Collections.Generic;
using Model;
using Model.Shapes;
using Project.View.Objects;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private CircleView circleView;

    [SerializeField]
    private TriangleView triangleView;

    [SerializeField]
    private List<SceneObject> sceneObjects;
    
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

        SetupExample_Harder();
    }

    private void SetupExample()
    {
        var circle = new Circle();
        var triangle = new Triangle();

        var circleSceneView = Instantiate(circleView, new Vector3(1, 0, 0), Quaternion.identity);
        var triangleceneView = Instantiate(triangleView, new Vector3(-1, 0, 0), Quaternion.identity);
        
        //1. event-based
        circle.OnYield += circleSceneView.OnCircleYield;
        
        //2. interface
        circle.InitView(circleSceneView);
    }
    
    private void SetupExample_Harder()
    {
        var objects = new List<Shape>() { new Circle(), new Triangle() };

        foreach (var shape in objects)
        {
            foreach (var sceneObject in sceneObjects)
            {
                if (sceneObject.IsViewFor(shape))
                {
                    var view = Instantiate(sceneObject, Vector3.one, Quaternion.identity);
                }
            }
        }
        
    }
}
