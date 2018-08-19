using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loadgif : MonoBehaviour {
	public List<Sprite> load = new List<Sprite> ();
	public List<float> loadtime = new List<float> ();
	public float curtimeout;
	public int n=0;
	public startbtn st;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curtimeout += Time.deltaTime;
		if (curtimeout > loadtime [n]) {
			n += 1;
			curtimeout = 0;
			if (n == load.Count) {
				st.done = false;
				main._m.musicplay (main._m.menumus);
				Destroy (gameObject);
			} else 
			gameObject.GetComponent<Image> ().sprite = load [n];
		}
	}
}
