using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class DialogueDescription : MonoBehaviour, IInteract {
	public ButtonEnum buttonInteract = ButtonEnum.Fire1;
	public List<string> textDialogue = new List<string>();
	private List<string>.Enumerator nextDialogue;
	[SerializeField]
	private Text box;
	public string ItemName = "";
	// Use this for initialization
	void Start () {
		nextDialogue = textDialogue.GetEnumerator();
	}
	
	void Reset(){
		GameObject obj = new GameObject();
		obj.transform.position = gameObject.transform.position;	
		obj.name = "Dialogue Description";
		obj.transform.parent = gameObject.transform;
		obj.AddComponent<Text>();
		box = obj.GetComponent<Text>();
		
		Canvas canvObj = gameObject.GetComponent<Canvas>();
		canvObj.renderMode = RenderMode.WorldSpace;
		
		RectTransform rectTrans = gameObject.GetComponent<RectTransform>();
		rectTrans.rect.Set(0,0,100, 100);
		rectTrans.transform.localScale.Set(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void action(){
		
		if(InputController.GetButton(buttonInteract)){
			//display dialogue
		if(nextDialogue.MoveNext() && (!isLastDialogue(nextDialogue.Current) || !checkItem())){//check will be true if item is not gotten)
			box.gameObject.SetActive(true);
			box.text = nextDialogue.Current;
		}else{
			addItem();
			reset ();
		}
			
		}
	}
	
	public bool isLastDialogue(string cur){
		if(ItemName != "" && ItemName != null){
			return textDialogue[textDialogue.Count - 1] == cur;
		}else{
			return false;
		}
	}
	
	public bool checkItem(){
		GameObject obj = GameObject.FindGameObjectWithTag("inventory");
		GlobalInventory inv = obj.GetComponent<GlobalInventory>();
		return inv.haveItem(ItemName);
	}
	
	public void addItem(){
		if(ItemName != "" && ItemName != null){
			GameObject obj = GameObject.FindGameObjectWithTag("inventory");
			GlobalInventory inv = obj.GetComponent<GlobalInventory>();
			inv.activateItem(ItemName);
		}
	}
	
	public void reset(){
		nextDialogue = textDialogue.GetEnumerator();
		
		box.gameObject.SetActive(false);
		//close dialogue window, what ever it is
	}
}
