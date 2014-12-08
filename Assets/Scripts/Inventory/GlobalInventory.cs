using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GlobalInventory : MonoBehaviour {
	private Dictionary<string,GameObject> _items;
	// Use this for initialization
	void Start () {
		_items = new Dictionary<string, GameObject>();
		foreach(Transform child in transform){
			_items.Add(child.name,child.gameObject);
			child.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void activateItem(string name){
		GameObject obj = _items[name];
		if(obj != null){
			obj.SetActive(true);
		}else{
			Debug.Log (name + " is not a valid item");
		}
	}
	
	public bool haveItem(string name){
		GameObject obj = _items[name];
		if(obj != null){
			return obj.activeSelf;
		}
		Debug.Log (name + " is not a valid item");
		return false;
	}	
}
