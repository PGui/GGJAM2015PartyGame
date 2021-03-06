﻿using UnityEngine;
using System.Collections;

public class InGameInterface : MonoBehaviour {

    private GameObject[] m_players;

    private int rectWidth = 250;
    private int rectHeight = 100;

    PlayerManager PM;

    public bool _debug = false;

    public GUISkin mySkin;

    private float ratioX = 1920.0f / Screen.width;
    private float ratioY = 1080.0f / Screen.height;

	// Use this for initialization
	void OnEnable ()
    {
        if (!_debug)
        {
            PM = GameObject.Find("PlayersManager").GetComponent<PlayerManager>();
			//StartCoroutine("GetPlayers");

        }
	}

    void Start()
    {
        if (_debug)
        {
			PM = GameObject.Find("PlayersManager").GetComponent<PlayerManager>();
			//StartCoroutine("GetPlayers");
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        ratioX = Screen.width / 1920.0f;
        ratioY = Screen.width / 1080.0f;

		if(m_players == null)
		{
			m_players = GameObject.FindGameObjectsWithTag("Player");
		}
		/*
        if (PM.m_playerVictory)
        {
            for (int i = 0; i < PM.GetMaxPlayer() ; ++i)
            {
                if (Input.GetButtonDown("P" + (i + 1).ToString() + " Start") && PM.GetPlayerTab()[i])
                {
                    int newlevel = 0;
                    if (PM.GetCurrentPlayerNumber() == 2)
                    {
                        newlevel = Random.Range(2, 6);
                        while (newlevel == PM.currentLevel)
                        {
                            newlevel = Random.Range(2, 6);
                        }


                    }
                    else
                    {
                        newlevel = Random.Range(2, 5);
                        while (newlevel == PM.currentLevel)
                        {
                            newlevel = Random.Range(2, 5);
                        }
                    }
                    PM.currentLevel = newlevel;
                    PM.Reset();
                    Application.LoadLevel(newlevel);
                    
                }

                if (Input.GetButtonDown("P" + (i + 1).ToString() + " B") && PM.GetPlayerTab()[i])
                {
                    PM.ResetToMenu();
                    GameObject.Destroy(GameObject.Find("PlayersManager"));
                    Application.LoadLevel("Menu");
                }
            }
        }
        */

		if (PM.m_playerVictory)
		{
			for (int i = 0; i < PM.GetMaxPlayer() ; ++i)
			{
				if (Input.GetButtonDown("P" + (i + 1).ToString() + " Start") && PM.GetPlayerTab()[i])
				{
					PM.ResetToMenu();
					GameObject.Destroy(GameObject.Find("PlayersManager"));
					Application.LoadLevel("Menu");
				}
				if (Input.GetButtonDown("P" + (i + 1).ToString() + " Start") && PM.GetPlayerTab()[i])
				{
					PM.ResetToMenu();
					GameObject.Destroy(GameObject.Find("PlayersManager"));
					Application.LoadLevel("Menu");
				}
				if (Input.GetButtonDown("P" + (i + 1).ToString() + " Start") && PM.GetPlayerTab()[i])
				{
					PM.ResetToMenu();
					GameObject.Destroy(GameObject.Find("PlayersManager"));
					Application.LoadLevel("Menu");
				}
			}
		}
	}

    void OnGUI()
    {
        GUI.skin = mySkin;
        Color oldColor = GUI.color;

		PM.m_playerVictory = PM.m_playerVictory;

		if (!PM.m_playerVictory && m_players != null)
        {
            if (m_players.Length >= 1)
            {
				Color col = new Color(0.51f,0.929f,0.709f);
				GUI.color = col;
				GUI.Box(new Rect((Screen.width/4.0f) * 0.0f * ratioX, 0, rectWidth * ratioX, rectHeight * ratioY), "Player 1 \n " + m_players[0].GetComponent<PlayerScore>().m_playerScore.ToString());
            }

            if (m_players.Length >= 2)
            {
				Color col = new Color(0.709f,0.007f,0.07f);
				GUI.color = col;
				GUI.Box(new Rect((Screen.width/4.0f) * 1.0f * ratioX, 0, rectWidth * ratioX, rectHeight * ratioY), "Player 2 \n " + m_players[1].GetComponent<PlayerScore>().m_playerScore.ToString());
            }

            if (m_players.Length >= 3)
            {
				Color col =    new Color(0.470f,0.830f,0.8940f);
				GUI.color = col;
				GUI.Box(new Rect((Screen.width/4.0f) * 2.0f * ratioX, 0, rectWidth * ratioX, rectHeight * ratioY), "Player 3 \n " + m_players[2].GetComponent<PlayerScore>().m_playerScore.ToString());
            }

            if (m_players.Length >= 4)
            {
				Color col =   new Color(1.0f,0.890f,0.4860f);
				GUI.color = col;
				GUI.Box(new Rect((Screen.width/4.0f) * 3.0f * ratioX, 0, rectWidth * ratioX, rectHeight * ratioY), "Player 4 \n " + m_players[3].GetComponent<PlayerScore>().m_playerScore.ToString());
            }
        }
        else
        {
			if(m_players != null)
			{
            	GUI.Box(new Rect(Screen.width/2 - 300.0f/2, Screen.height/2 - 60.0f/2, 300.0f, 60.0f), "Player " + GameObject.Find("PlayersManager").GetComponent<PlayerManager>().m_playerWinner.GetComponent<PlayerID>().GetPlayerID().ToString() + " Win !!");
            	GUI.Box(new Rect(Screen.width / 2 - 300.0f / 2, Screen.height / 2 - 100.0f / 2 + 100.0f, 300.0f, 100.0f), "Start to Menu");
			}
		}
    }

	IEnumerator GetPlayers() 
	{
		yield return new WaitForSeconds(0.2f);
		m_players = GameObject.FindGameObjectsWithTag("Player");
	}
}
