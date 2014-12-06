using UnityEngine;
using System.Collections;

public static class InputController{
	public static Vector2 GetMovementVector(){
		Vector2 dir = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		return dir;
	}
	
	public static bool GetButton(ButtonEnum but){
		switch(but){
			case ButtonEnum.Fire1:
				return Input.GetButton("fire1");
			case ButtonEnum.Fire2:
				return Input.GetButton("fire2");
			case ButtonEnum.Fire3:
				return Input.GetButton("fire3");
			default:
				return false;	
		}
	}
}
