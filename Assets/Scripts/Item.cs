using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public Renderer render;
	public Clue thisItem;
	// Use this for initialization
	void Start () {
//		GetComponent(MeshRenderer).enabled = false;
		render = GetComponent<Renderer>();
		render.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pickup(){
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MainCamera") {
			render.enabled = true;
		}
	}
	void GetItemDetail(){
		
	}
}
