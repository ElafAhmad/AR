using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemPic : MonoBehaviour {
	public Item item;
	public Vector3 pos;
	public bool isInstant = false;
	public bool renTest; 
	PickUpObject pUO;
	GameObject go;

	// Use this for initialization
	void Start () {
//		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		GameObject gO = GameObject.Find ("Main Camera");
//		pUO = gO.GetComponent<PickUpObject> ();
//		item = pUO.targer.GetComponent<Item> ();
//		if (!isInstant) {
//			go = Instantiate (item.thisItem.model, transform.position, Quaternion.identity);
////			var posX = go.transform.position.x;
////			var posZ = go.transform.position.z;
////			posX += 25;
////			posZ -= 100;
////			Vector3 pos = new Vector3 (posX, go.transform.position.y, posZ);
////			go.transform.position = pos;
//			Destroy (go.GetComponent<Item> ());
//			go.transform.parent = this.transform;
//			go.layer = 5;
//			go.transform.localScale += new Vector3(100f, 100f, 100f);
//			Renderer render = go.GetComponent<Renderer> ();
//			renTest = render.enabled;
//			render.enabled = true;
//			Rigidbody rg = go.GetComponent<Rigidbody> ();
//			rg.isKinematic = true;
////			item.render.enabled = true;
//			isInstant = true;
//		}
		if (isInstant) {
			go.transform.Rotate (Vector3.up * 10 * Time.deltaTime);
		}
	}

	public void InstantPreview(){
//		if (!isInstant) {
			GameObject gO = GameObject.Find ("Main Camera");
			pUO = gO.GetComponent<PickUpObject> ();
			item = pUO.targer.GetComponent<Item> ();
			go = Instantiate (item.thisItem.model, transform.position, Quaternion.identity);
			//			var posX = go.transform.position.x;
			//			var posZ = go.transform.position.z;
			//			posX += 25;
			//			posZ -= 100;
			//			Vector3 pos = new Vector3 (posX, go.transform.position.y, posZ);
			//			go.transform.position = pos;
			Destroy (go.GetComponent<Item> ());
			go.transform.parent = this.transform;
			go.layer = 5;
			go.transform.localScale += new Vector3(100f, 100f, 100f);
			Renderer render = go.GetComponent<Renderer> ();
			renTest = render.enabled;
			render.enabled = true;
			Rigidbody rg = go.GetComponent<Rigidbody> ();
			rg.isKinematic = true;
			//			item.render.enabled = true;
			isInstant = true;
//		}
	}

	public void DestroyPreview(){
		foreach (Transform child in this.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void SetActivePreview(bool n){
		foreach (Transform child in this.transform) {
			child.gameObject.SetActive (n);
		}
	}

}
