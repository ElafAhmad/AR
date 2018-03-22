using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemPic : MonoBehaviour {
	public Item item;
	public Vector3 pos;
	public bool isInstant = true;
	public bool renTest; 
	PickUpObject pUO;
	GameObject go;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gO = GameObject.Find ("Main Camera");
		pUO = gO.GetComponent<PickUpObject> ();
		item = pUO.targer.GetComponent<Item> ();
		if (isInstant) {
			go = Instantiate (item.thisItem.model, transform.position, Quaternion.identity);
			Destroy (go.GetComponent<Item> ());
			go.transform.parent = this.transform; 
			go.transform.localScale += new Vector3(100f, 100f, 100f);
			Renderer render = go.GetComponent<Renderer> ();
			renTest = render.enabled;
			render.enabled = true;
			Rigidbody rg = go.GetComponent<Rigidbody> ();
			rg.isKinematic = true;
//			item.render.enabled = true;
			isInstant = false;
		}
		go.transform.Rotate (Vector3.up * 10 * Time.deltaTime);
	}
		
}
