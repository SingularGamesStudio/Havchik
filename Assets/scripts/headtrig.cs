using UnityEngine;
using System.Collections;

public class headtrig : MonoBehaviour {
	// Use this for initialization
	public Vector3 localpoint;
	public float curt=0;
	void Start () {
		Vector2 v;
		v=gameObject.GetComponent<BoxCollider2D> ().offset;
		v=new Vector2(v.x,v.y-gameObject.GetComponent<BoxCollider2D> ().size.y/2);
		localpoint = v;
		//Destroy(gameObject.GetComponent<BoxCollider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		curt += Time.deltaTime;
		if (curt >= 0.2f)
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = -(int)(transform.TransformPoint (localpoint).y*100);
	}
	/*void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "unittrig") {
			gameObject.GetComponent<SpriteRenderer>().sortingOrder=coll.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
		} else if (coll.gameObject.tag == "bokwall") {
			gameObject.GetComponent<SpriteRenderer>().sortingOrder=coll.gameObject.GetComponent<SpriteRenderer>().sortingOrder+1;
		}
	}*/
}
