using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class YoonAnimationController : MonoBehaviour 
{
	private List<string> animationClips = new List<string> ();
	private bool isJumping = false;

	public enum YoonAnimationType 
	{
		IDLE = 0,
		STAND,
		WALK,
		RUN,
		JUMP,
		POSE,
		
		AOQ_IDLE,
		AOQ_WALK,
		AOQ_HIT,
		AOQ_GLAD,
		AOQ_REST_A,
		AOQ_REST_B,
		AOQ_WARP,
		
		FLY_IDLE,
		FLY_UP,
		FLY_DOWN,
		FLY_STRAIGHT,
		FLY_TOLEFT,
		FLY_TORIGHT,
		FLY_DAMAGE,
		FLY_DISAPPO,
		FLY_DISAPPO_LOOP,
		FLY_ITEMGET,
		FLY_ITEMGET_LOOP,
		
		HW_IDLE,
		HW_WAIT_LONG,
		HW_TRICK,
		HW_MAHOU
	}
	
	void Awake ()
	{
		foreach (AnimationState animationState in animation) {
			animationClips.Add (animationState.name);
		}
		animationClips.Sort ();
	}

	public void Walk ()
	{
		animation.CrossFade (animationClips[(int)YoonAnimationType.WALK]);
	}

	public void Idle ()
	{
		animation.CrossFade (animationClips[(int)YoonAnimationType.IDLE]);
	}

	public void Jump ()
	{
		animation.CrossFade (animationClips[(int)YoonAnimationType.JUMP]);
	}
}
