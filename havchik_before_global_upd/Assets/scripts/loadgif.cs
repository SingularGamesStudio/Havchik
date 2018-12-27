using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loadgif : MonoBehaviour {
	public List<Sprite> load = new List<Sprite> ();
	public List<float> loadtime = new List<float> ();
	public List<Sprite> dead = new List<Sprite> ();
	public List<float> deadtime = new List<float> ();
	public List<Sprite> drunk = new List<Sprite> ();
	public List<float> drunktime = new List<float> ();
	public float curtimeout;
	public int n=0;
	public startbtn st;
	public string type = "";
	public bool can=false;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("stgif")) {
			Debug.Log (PlayerPrefs.GetInt ("stgif"));
			if (PlayerPrefs.GetInt ("stgif") == 0) {
				PlayerPrefs.SetInt ("stgif", 1);
				type = "die";
			} else if (PlayerPrefs.GetInt ("stgif") == 1) {
				type = "start";
			} else {
				PlayerPrefs.SetInt ("stgif", 1);
				type = "drunk";

			}
		} else {
			Debug.Log ("NO");
			PlayerPrefs.SetInt ("stgif", 1);
			type = "start";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0) && can) {
			st.done = false;
			//main._m.musicplay (main._m.menumus);
			Destroy (gameObject);
		}
		curtimeout += Time.deltaTime;
		if (type == "start") {
			if(!can) gameObject.GetComponent<Image> ().sprite = load [0];
			if (curtimeout > loadtime [n]) {
				can=true;
				n += 1;
				curtimeout = 0;
				if (n == load.Count) {
					st.done = false;
					//main._m.musicplay (main._m.menumus);
					Destroy (gameObject);
				} else
					gameObject.GetComponent<Image> ().sprite = load [n];
			}
		} else if (type == "die") {
			if(!can) gameObject.GetComponent<Image> ().sprite = dead [0];
			if (curtimeout > deadtime [n]) {
				can=true;
				n += 1;
				curtimeout = 0;
				if (n == dead.Count) {
					st.done = false;
					//main._m.musicplay (main._m.menumus);
					Destroy (gameObject);
				} else
					gameObject.GetComponent<Image> ().sprite = dead [n];
			}
		} else if (type == "drunk") {
			if(!can) gameObject.GetComponent<Image> ().sprite = drunk [0];
			if (curtimeout > drunktime [n]) {
				can=true;
				n += 1;
				curtimeout = 0;
				if (n == drunk.Count) {
					st.done = false;
					//main._m.musicplay (main._m.menumus);
					Destroy (gameObject);
				} else
					gameObject.GetComponent<Image> ().sprite = drunk [n];
			}
		} else {
			st.done = false;
			//main._m.musicplay (main._m.menumus);
			Destroy (gameObject);
		}
	}
}
