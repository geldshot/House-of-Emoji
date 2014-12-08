using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class RoomReveal : MonoBehaviour, IInteract {
	private Animator myAnimate;
	[Range(0, 1)]
	public float inactiveAlpha = .2f;
	// Use this for initialization
	void Start () {
		myAnimate = gameObject.GetComponent<Animator>();
	}
	
	public void action(){
		myAnimate.SetBool("Presence", true);
		foreach(SpriteRenderer child in transform.GetComponentsInChildren<SpriteRenderer>()){
			child.color = new Color(1, 1, 1, 1);
		}
	}
	
	public void reset(){
		myAnimate.SetBool("Presence", false);
		foreach(SpriteRenderer child in transform.GetComponentsInChildren<SpriteRenderer>()){
			child.color = new Color(1, 1, 1, inactiveAlpha);
		}
	}
	
	
}
