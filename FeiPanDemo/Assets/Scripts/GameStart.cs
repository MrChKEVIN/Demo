using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	private GameManager m_gameManager;
	// Use this for initialization
	void Start () 
	{
		m_gameManager = GameObject.Find ("UI").GetComponent<GameManager> ();
	}

	void OnMouseDown()
	{
		m_gameManager.ChangeGameState (GameManager.GameState.GAME);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
