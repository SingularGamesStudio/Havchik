using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbtn : MonoBehaviour {
	public bool done;
	public System.Random rnd = new System.Random ();
	public float timeout=0;
	public float curtimeout=0;
	public List<GameObject> sppoints = new List<GameObject> ();
	public List<GameObject> sppointsnew = new List<GameObject> ();
	GameObject h;
	GameObject h1;
	bool starter=false;
	public float curt = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (!done && !starter) {
			curt += Time.deltaTime;
			if (curt > 0.6f) {
				starter = true;
			}
		}
		if (!done && starter) {
			curtimeout += Time.deltaTime;
			if (curtimeout >= timeout) {
				int y = rnd.Next (sppoints.Count);
				sppointsnew.Clear();
				for (int i = 0; i < sppoints.Count; i++) {
					sppointsnew.Add (sppoints [i]);
				}
				for (int i = 0; i < y; i++) {
					int y1 = rnd.Next (sppointsnew.Count);
					h=Instantiate(main._m.compref);
					h.transform.position=sppointsnew[y1].transform.position;
					sppointsnew.RemoveAt (y1);
					h.GetComponent<mainunit> ().arenabattler = true;
					y1 = rnd.Next (main._m.units.Count);
					h.GetComponent<mainunit> ().arenahp = main._m.units [y1].hp;
					h.GetComponent<mainunit> ().num = y1+1;
					h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = main._m.units [y1].sp;
					h1 = Instantiate (main._m.emp);
					h1.transform.parent = h.transform;
					h1.transform.localPosition = Vector3.zero;
					h1.tag="arena";
				}
				curtimeout = 0;
				timeout = rnd.Next (10, 70);
				timeout /= 10;
			}
		}
	}
	void OnMouseDown(){
		if (starter) {
			done = true;
			main._m.gamechoose ();
		}
	}
}
