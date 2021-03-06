﻿using UnityEngine;
using System.Collections;

public class Twinkle : MonoBehaviour {

    public float twinkleDuration = 3.0f;
    public float twinkleSpeed = 30.0f;
    float twinkleTime = 0.0f;

    float time = 0.0f;

    public bool _debug = false;

    private GameObject PlayerName;
	private GameObject PlayerRenderer;

	// Use this for initialization
    void OnEnable() 
    {
        twinkleTime = 0.0f;
        time = 0.0f;

        if(!_debug)
            this.GetComponent<Control>().m_hasControl = false;
        else
			this.GetComponent<Control>().m_hasControl = true;

        foreach (Transform t in transform)
         {
             if(t.name == "PlayerName")
             {
                 PlayerName = t.gameObject;
             }
         }

		//Get the player renderer
		foreach (Transform t in transform)
		{
			if(t.name == "PlayerRenderer")
			{
				PlayerRenderer = t.gameObject;
			}
		}

        PlayerName.renderer.enabled = true;
        PlayerName.GetComponent<TextMesh>().text = "P "+ GetComponent<PlayerID>().GetPlayerID().ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Mathf.Sin(twinkleTime) > 0)
        {
			PlayerRenderer.renderer.enabled = true;
        }
        else
        {
			PlayerRenderer.renderer.enabled = false;
        }

        twinkleTime += Time.deltaTime * twinkleSpeed;

        time += Time.deltaTime;

        if (time >= twinkleDuration)
        {
            this.GetComponent<Control>().m_hasControl = true;
            PlayerName.renderer.enabled = false;
			PlayerRenderer.renderer.enabled = true;
            enabled = false;
        }
	
	}

    
}
