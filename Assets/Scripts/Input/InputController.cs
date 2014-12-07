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
				return Input.GetButtonDown("Fire1");
			case ButtonEnum.Fire2:
				return Input.GetButtonDown("Fire2");
			case ButtonEnum.Fire3:
				return Input.GetButtonDown("Fire3");
			default:
				return false;	
		}
	}
	
	public static bool InputAnyKey(){
		return (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"));
	}
}
