using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickpos : MonoBehaviour {
	public RectTransform d;
	public RectTransform r;
	public RectTransform g;
	// Use this for initialization
	void Start () {
		g = gameObject.GetComponent<RectTransform> ();
		gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (r.anchoredPosition.x - r.sizeDelta.x/2 - g.sizeDelta.x/2,d.anchoredPosition.y + d.sizeDelta.y/2 + g.sizeDelta.y/2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
