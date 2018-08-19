using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class debuglog : MonoBehaviour {
	public static debuglog _debug;
	public List<string> log=new List<string>();
	public Text console;
	int g;
	// Use this for initialization
	void Start () {
		_debug = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (log.Count > 5)
			console.text = log [log.Count - 5] + "\n" + log [log.Count - 4] + "\n" + log [log.Count - 3] + "\n" + log [log.Count - 2] + "\n" + log [log.Count - 1];
		else if (log.Count > 4)
			console.text = log [0] + "\n" + log [1] + "\n" + log [2] + "\n" + log [3] + "\n" + log [4];
		else if (log.Count > 3)
			console.text = log [0] + "\n" + log [1] + "\n" + log [2] + "\n" + log [3];
		else if (log.Count > 2)
			console.text = log [0] + "\n" + log [1] + "\n" + log [2];
		else if (log.Count>1)
			console.text = log[0]+"\n"+log[1];
		else if (log.Count>0)
			console.text = log[0];
	}
}
