using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class YoonAnimationController : MonoBehaviour 
{
	private List<string> animationClips = new List<string> ();
	private Transform yoonBody;

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
		HW_MAHOU,
		HW_ATTACK
	}

	AnimationState AnimationStateWithType(YoonAnimationType type) 
	{
		string name = animationClips [(int)type];
		return animation [name];
	}
	
	void Awake ()
	{
		yoonBody = GameObject.Find ("/Yoon/Chr_Reference").transform;
		foreach (AnimationState animationState in animation) {
			animationClips.Add (animationState.name);
		}
		animationClips.Sort ();
		SetupAnimations ();
	}

	void SetupAnimations ()
	{
		AnimationStateWithType (YoonAnimationType.STAND).layer = 0;
		AnimationStateWithType (YoonAnimationType.IDLE).layer = 0;
		AnimationStateWithType (YoonAnimationType.WALK).layer = 0;
		AnimationStateWithType (YoonAnimationType.WALK).weight = 0;
		AnimationStateWithType (YoonAnimationType.RUN).layer = 0;
		AnimationStateWithType (YoonAnimationType.JUMP).layer = 1;
		AnimationStateWithType (YoonAnimationType.HW_ATTACK).layer = 2;
		AnimationStateWithType (YoonAnimationType.HW_ATTACK).blendMode = AnimationBlendMode.Blend;
		AnimationStateWithType (YoonAnimationType.HW_ATTACK).AddMixingTransform (yoonBody);

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
		animation.CrossFade (animationClips[(int)YoonAnimationType.JUMP], 0.05f);
	}

	public void Attack ()
	{
		animation.CrossFade (animationClips [(int)YoonAnimationType.HW_ATTACK], 0.05f);
	}
	
}
