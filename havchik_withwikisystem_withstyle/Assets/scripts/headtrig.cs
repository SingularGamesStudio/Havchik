using UnityEngine;
using System.Collections;

public class headtrig : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "unittrig") {
			gameObject.GetComponent<SpriteRenderer>().sortingOrder=coll.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
		} else if (coll.gameObject.tag == "bokwall") {
			gameObject.GetComponent<SpriteRenderer>().sortingOrder=coll.gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
		}
	}
}
