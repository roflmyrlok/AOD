using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class View : MonoBehaviour, IView
{
	private int _gameState;
    
	void Start()
	{
		// Initialization, if needed
	}

	void Update()
	{
		// Visual update logic, for example:
		if (_gameState == 1)
		{
			transform.Translate(Vector3.right * Time.deltaTime);
		}
		else if (_gameState == -1)
		{
			transform.Translate(Vector3.left * Time.deltaTime);
		}
	}

	public void ShowGameState(int gameState)
	{
		_gameState = gameState;
		// React visually based on the updated game state
	}
}