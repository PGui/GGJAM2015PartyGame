﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour 
{

	//Player ID
	private int m_playerID = 0;

	//Speed
	private float speed = 0.0f;
	public float m_maxSpeed = 50.0f;

	//Acc
	public float m_accel = 1.5f;
	public float m_deaccel = 0.8f;

	public  bool m_hasControl  {get; set;}
	private Vector2 m_moveInput;

	public bool m_canDash {get; set;}
	public bool m_isDashing {get; set;}
	public float dashTime = 1.0f;
	public float m_forceDash = 500.0f;
	private float timeElapsedDash = 0.0f;
	private Vector2 m_dashDirection;

	public Transform rendererTransform;

	bool facingRight = false;

	public AudioClip soundDash;
	public AudioClip [] soundSteps;

	public float timeBetweenSteps = 0.5f;
	float timeElapsedSteps = 0.0f;

	public GameObject fxDash;

	// Use this for initialization
	void Start () 
	{
		//Init player ID
		m_playerID = GetComponent<PlayerID>().GetPlayerID();

		m_hasControl = false;

		m_canDash = true;
		m_isDashing = false;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		//Dash
		if(m_canDash && Input.GetButtonDown("P" + m_playerID.ToString() + " A") && !m_isDashing && !GetComponent<Dead>().isDead)
		{
			m_isDashing = true;
			timeElapsedDash = 0.0f;
			m_dashDirection = m_moveInput;
			m_dashDirection.Normalize();
			//rigidbody2D.velocity = Vector2.zero;
			//Debug.Log("---Dashing---");
			GetComponent<AudioSource>().PlayOneShot(soundDash);
			GameObject.Instantiate(fxDash, new Vector2(transform.position.x, transform.position.y - 1.0f),Quaternion.identity);
		}

		transform.position.Set(transform.position.x,transform.position.y,transform.position.y +100);


		if(timeElapsedSteps >= timeBetweenSteps && rigidbody2D.velocity.sqrMagnitude > 1.0f && !m_isDashing)
		{
			timeElapsedSteps = 0.0f;
			GetComponent<AudioSource>().PlayOneShot(soundSteps[Random.Range(0,soundSteps.Length)]);
			///
		}

		timeElapsedSteps+= Time.deltaTime;
	}

	void FixedUpdate()
	{
		if(m_hasControl && !GetComponent<Dead>().isDead)
		{
			//Get the stick input
			m_moveInput = new Vector2(Input.GetAxis("P" + m_playerID.ToString() + " LHorizontal"), Input.GetAxis("P" + m_playerID.ToString() + " LVertical"));


			if(m_moveInput.x > 0.5)
			{
				facingRight = false;
				rendererTransform.localScale = new Vector2(1,1);
			}

			if(m_moveInput.x < -0.5)
			{
				facingRight = true;
				rendererTransform.localScale = new Vector2 (-1,1);
			}

			//Si le player bouge
			if(m_moveInput.SqrMagnitude() > 0.2f && !m_isDashing)
			{
				speed = Mathf.Min( speed + m_accel, m_maxSpeed);
				rigidbody2D.velocity = speed * m_moveInput;
			}
			else if(!m_isDashing)//Sinon il deccelere
			{
				rigidbody2D.velocity *= m_deaccel;
			}

			//Si le joueur dash
			if(m_isDashing)
			{
				//rigidbody2D.velocity = m_dashDirection*
				rigidbody2D.AddForce(m_dashDirection*m_forceDash,ForceMode2D.Force);
			}

			//applyThe good velocity
			//rigidbody2D.velocity = currentVel;

			//Si on est en train de dasher
			if(m_isDashing && (timeElapsedDash > dashTime))
			{
				m_isDashing = false;
				//Debug.Log("You can dash again");
			}
			else if(m_isDashing)
			{
				timeElapsedDash += Time.deltaTime;
			}
			

		}


	}
}
