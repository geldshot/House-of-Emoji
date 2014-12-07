using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class MotorAnimate : MonoBehaviour {
	private float _horizontal = 0f;
	private float _vertical = 0f;
	private Animator myAnimate;
	public float horizontal
	{
		get { return _horizontal;}
		set 
		{
			if( value != _horizontal){
				_horizontal = value;
				updateAnimator();
			}
		}
	}
	public float vertical
	{
		get { return _vertical; }
		set
		{
			if( value != _vertical){
				_vertical = value;
				updateAnimator();
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		myAnimate = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vec = InputController.GetMovementVector();
		vertical = vec.y;
		horizontal = vec.x;
	}
	
	private void updateAnimator(){
		myAnimate.SetFloat("horizontal", this.horizontal);
		myAnimate.SetFloat("vertical", this.vertical);
	}
}
