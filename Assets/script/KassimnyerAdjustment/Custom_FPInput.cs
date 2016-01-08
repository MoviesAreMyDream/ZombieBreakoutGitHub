using UnityEngine;
using System.Collections;

public class Custom_FPInput : vp_FPInput {

	public vp_FPPlayerEventHandler FPPlayer;

	protected override void InputAttack()
	{
		if (vp_Input.GetAxisRaw ("RTrigger")>0.5) {
			FPPlayer.Attack.TryStart ();
		} 

		else
		{
			FPPlayer.Attack.TryStop();
		}
	}
	
}
