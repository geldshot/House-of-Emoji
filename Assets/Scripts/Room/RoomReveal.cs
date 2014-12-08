using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class RoomReveal : MonoBehaviour, IInteract {
	private Animator myAnimate;
	// Use this for initialization
	void Start () {
		myAnimate = gameObject.GetComponent<Animator>();
	}
	
	public void action(){
		myAnimate.SetBool("Presence", true);
	}
	
	public void reset(){
		myAnimate.SetBool("Presence", false);
	}
}
