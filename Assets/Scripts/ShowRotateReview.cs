using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRotateReview : MonoBehaviour {
	public Item item;
	public Vector3 pos;
	public bool isInstant = false;
	public bool renTest; 
	PickUpObject pUO;
	GameObject go;
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InstantRotatePreview(){
		GameObject gO = GameObject.Find ("Main Camera");
		pUO = gO.GetComponent<PickUpObject> ();
		item = pUO.targer.GetComponent<Item> ();
		go = Instantiate (item.thisItem.model, transform.position, Quaternion.identity);
		Destroy (go.GetComponent<Item> ());
		go.transform.parent = this.transform;
		go.layer = 5;
		go.transform.localScale += new Vector3(150f, 150f, 150f);
		var temp = go.transform.position.z;
		temp -= 50f;
		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y, temp);
		Renderer render = go.GetComponent<Renderer> ();
		renTest = render.enabled;
		render.enabled = true;
		Rigidbody rg = go.GetComponent<Rigidbody> ();
		rg.isKinematic = true;
		go.AddComponent<RotatePreview> ();
		isInstant = true;
	}

	public void DestroyRotatePreview(){
		foreach (Transform child in this.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}


}
