using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class racecommand : MonoBehaviour {
	public List<int> otn=new List<int>();
	public int bezbash;
	public int race;
	public List<main.team> army=new List<main.team>();
	public float curtimeout2;
	GameObject h;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		curtimeout2 += Time.deltaTime;
		if (curtimeout2 > 0.5f) {
			for (int j = 0; j < army [0].unitshp.Count; j++) {
				if (army [0].unitshp [j] <= 0) {
					Destroy (army [0].inst [j]);
					army [0].units.RemoveAt (j);
					army [0].unitshp.RemoveAt (j);
					army [0].inst.RemoveAt (j);
					army [0].now -= 0.1f;
				}
			}
		}
		
		
		
		
		if (curtimeout2 > 0.5f) {
			for (int i=0; i<1; i++) {
				if (army [i].mainunit != -1) {
					
					if (army [i].mainunithp <= 0) {
						
						if (army [i].units.Count > 0) {
							Destroy (army [i].comgo);
							h = Instantiate (main._m.compref);
							h.GetComponent<mainunit> ().race = race;
							h.GetComponent<mainunit> ().num = army [i].units [0];
							h.GetComponent<mainunit> ().m = i;
							h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = main._m.units [army [i].units [0] - 1].sp;
							h.transform.position = army [i].inst [0].transform.position;
							army [i].mainunit = army [i].units [0];
							army [i].mainunithp = army [i].unitshp [0];
							army [i].comgo = h;
							army [i].now -= 0.1f;
							Destroy (army [i].inst [0]);
							army [i].units.RemoveAt (0);
							army [i].inst.RemoveAt (0);
							army [i].unitshp.RemoveAt (0);
							for (int j=0; j<army[i].units.Count; j++) {
								army [i].inst [j].GetComponent<uniter> ().m = i;
							}
						} else {
							for (int j = 0; j < main._m.allcities.Count; i++) {
							
							}
						}
						
					}
					
				}
			}
			curtimeout2=0;
		}
	}
}
