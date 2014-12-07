using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (Rigidbody2D))]
public class InteractControl : MonoBehaviour {
	
	private List<GameObject> _interactables = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(InputController.InputAnyKey())
		{
			DoAllActions();
			Debug.Log("attempt interact");
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		GameObject obj = coll.gameObject;
		DoAction(obj);
		_interactables.Add(obj);
		Debug.Log("Registered Object: " + obj.name);
	}
	
	void OnTriggerExit2D(Collider2D coll){
		_interactables.Remove(coll.gameObject);
		DoReset (coll.gameObject);
		Debug.Log("Unregistered Object: " + coll.gameObject.name);
	}
	
	private void DoAllActions(){
		foreach(GameObject obj in _interactables){
			DoAction(obj);
		}
	}
	
	private void DoAction(GameObject obj){
		IInteract action = obj.GetComponent(typeof(IInteract)) as IInteract;
		
		if(action != null){

			action.action();
		}
	}
	
	private void DoReset(GameObject obj){
		IInteract reset = obj.GetComponent(typeof(IInteract)) as IInteract;
		
		if(reset != null){
			reset.reset();
		}
	}
}
