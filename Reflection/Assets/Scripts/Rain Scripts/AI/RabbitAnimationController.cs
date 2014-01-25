﻿using UnityEngine;
using System.Collections;

public enum RabbitAnimationState
{
	Idle,
	Walk,
	Run,
	Dead,
	Action
}

public class RabbitAnimationController : MonoBehaviour 
{
	
	//------------------------------------------------------------------------
	
	public RabbitAI		rabbitAI;
	public Animator[]	rabbitAnimator;
	
	//------------------------------------------------------------------------

	public void SetAnimationState( RabbitAnimationState	_state )
	{
		if( _state == RabbitAnimationState.Idle )
		{
			SetSpeed(0f);
		}
		else if( _state == RabbitAnimationState.Walk )
		{
			SetSpeed(1f);
		}
		else if( _state == RabbitAnimationState.Run )
		{
			SetSpeed(2f);
		}
		else if( _state == RabbitAnimationState.Dead )
		{
			PlayDeath();
		}
		else if( _state == RabbitAnimationState.Action )
		{
			ActivateAction();
		}
	}

	//------------------------------------------------------------------------

	void SetSpeed (float _speed) 
	{
		for(int i = 0; i < rabbitAnimator.Length; i++)
		{
			rabbitAnimator[i].SetFloat("Speed", _speed);
		}
	}
	
	//------------------------------------------------------------------------
	
	void PlayDeath () 
	{
		for(int i = 0; i < rabbitAnimator.Length; i++)
		{
			rabbitAnimator[i].SetTrigger("Dead");
		}
	}
	
	//------------------------------------------------------------------------
	
	void ActivateAction () 
	{
		for(int i = 0; i < rabbitAnimator.Length; i++)
		{
			rabbitAnimator[i].SetBool( "isHaveBullet", rabbitAI.isHaveBullet );
			rabbitAnimator[i].SetTrigger("Action");
		}
	}
	
	//------------------------------------------------------------------------
	
	public void SetGood (bool _isGood) 
	{
		for(int i = 0; i < rabbitAnimator.Length; i++)
		{
			rabbitAnimator[i].SetBool("isGood", _isGood);
		}
	}
	
	//------------------------------------------------------------------------
}
