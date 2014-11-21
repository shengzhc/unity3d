using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class YoonAnimationState : MonoBehaviour 
{
	private List<string> animationClips = new List<string> ();
	private int index = 0;

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
}
