using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueDescription : MonoBehaviour, IInteract {
	public ButtonEnum buttonInteract = ButtonEnum.Fire1;
	public List<string> textDialogue = new List<string>();
	private List<string>.Enumerator nextDialogue;
	// Use this for initialization
	void Start () {
		nextDialogue = textDialogue.GetEnumerator();
		nextDialogue.MoveNext();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void action(){
		if(InputController.GetButton(buttonInteract)){
			//display dialogue
			
			nextDialogue.MoveNext();
		}
	}
	
	public void reset(){
		nextDialogue = textDialogue.GetEnumerator();
		nextDialogue.MoveNext();
		//close dialogue window, what ever it is
	}
}
