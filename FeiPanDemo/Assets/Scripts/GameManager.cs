using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public enum GameState
	{
		START,
		GAME,
		END
	};
	private GameObject m_start;
	private GameObject m_game;
	private GameObject m_end;
	private GUIText scoreGUI;
	private GUIText timeGUI;

	private int m_score;
	private float m_time = 10;
	private bool startTime;

	private GameState gameState;
	private AudioSource bgAudio;
	private HandMove m_hand;
	private FeiPan m_feipan;

	// Use this for initialization
	void Start () 
	{
		m_start = GameObject.Find ("StartUI");
		m_game = GameObject.Find ("GameUI");
		m_end = GameObject.Find ("EndUI");

		scoreGUI = GameObject.Find ("Score").GetComponent<GUIText> ();
		timeGUI = GameObject.Find ("Time").GetComponent<GUIText> ();

		bgAudio = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		m_hand = GameObject.Find ("Weapon").GetComponent<HandMove> ();
		m_feipan = GameObject.Find ("FeiPanParent").GetComponent<FeiPan> ();

		ChangeGameState (GameState.START);
	}
	public void ChangeGameState(GameState gs)
	{
		gameState = gs;
		if(gameState == GameState.START)
		{
			//ui界面切换
			m_start.SetActive (true);
			m_game.SetActive (false);
			m_end.SetActive (false);
			//背景音乐切换
			bgAudio.Stop ();

			m_hand.ChangeCanMove (false);
			startTime = false;
		}
		else if(gameState == GameState.GAME)
		{
			m_start.SetActive (false);
			m_game.SetActive (true);
			m_end.SetActive (false);

			bgAudio.Play ();

			m_hand.ChangeCanMove (true);
			m_feipan.StartCreatFeiPan ();

			startTime = true;

		}
		else if(gameState == GameState.END)
		{
			m_start.SetActive (false);
			m_game.SetActive (false);
			m_end.SetActive (true);

			bgAudio.Stop ();

			m_hand.ChangeCanMove (false);
			m_feipan.StopCreatFeiPan ();

			startTime = false;

		}
	}
	public void AddScore()
	{
		m_score++;
		scoreGUI.text = "分数:" + m_score;
	}
	// Update is called once per frame
	void Update () 
	{
		if (startTime) 
		{
			m_time -= Time.deltaTime;
			timeGUI.text = "时间:" + m_time;
		}

	}
}
