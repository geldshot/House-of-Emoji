using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LockedDoor : MonoBehaviour, IInteract {
	public string lockedMessage = "";
	public string itemCheck = "";
	[SerializeField]
	private Text box;
	// Use this for initialization
	void Start () {
		
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
		if(itemCheck != "" && itemCheck != null){
			GameObject obj = GameObject.FindGameObjectWithTag("inventory");
			GlobalInventory inv = obj.GetComponent<GlobalInventory>();
			if(inv.haveItem(itemCheck)){
				gameObject.SetActive(false);
			}else{
				box.gameObject.SetActive(true);
				box.text = lockedMessage;
			}
		}
	}
	
	public void reset(){
		box.gameObject.SetActive(false);
	}
}
