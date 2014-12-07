using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
public class Motor : MonoBehaviour {
	private Vector2 _move = Vector2.zero;
	private Vector2 _direction = Vector2.zero;
	public Vector2 direction
	{
		get{ return _direction; }
		set{ 
			_direction = value;
			_move = _direction.normalized;
			_move = _move * _speed;
		}
	}
	[SerializeField]
	private float _speed = 0f;
	public float speed
	{
		get{ return _speed; }
		set{
			_speed = value;
			_move = _direction.normalized;
			_move = _move * _speed;
		}
	}
	private float _magSpeed = 1;//essentially throttle for input controls
	public float magSpeed
	{
		get{ return _magSpeed; }
		set{
			_magSpeed = value;
			_move = _direction.normalized;
			_move = _move * _speed * _magSpeed;
		}
	}
	public bool TieToInput = false;
	void FixedUpdate(){
		if(TieToInput){
			this.direction = InputController.GetMovementVector();
			this.magSpeed = this.direction.magnitude;	
		}
		rigidbody2D.velocity = _move;
	}
}