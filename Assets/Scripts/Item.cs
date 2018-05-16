using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public Renderer render;
	public bool testRen;
	public Clue thisItem;

	void Start () {
		render = GetComponent<Renderer>();
		render.enabled = false;
	}

	void Update () {
		testRen = render.enabled;
	}

	public void Pickup(){
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MainCamera") {
			render.enabled = true;
		}
	}

}
