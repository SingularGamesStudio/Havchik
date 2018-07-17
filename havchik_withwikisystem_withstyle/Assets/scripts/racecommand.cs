using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class racecommand : MonoBehaviour {
	public List<int> otn=new List<int>();
	public int bezbash;
	public int race;
	public List<city> cities=new List<city>();
	public List<GameObject> citiesinst=new List<GameObject>();
	public List<bool> zachvat = new List<bool> ();
	public List<city> otryad=new List<city>();
	public List<main.team> army=new List<main.team>();
	public int posolnum;
	public GameObject posol;
	public float curtimeout2;
	GameObject h;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		curtimeout2 += Time.deltaTime;
		
		
		
		
		
		if (curtimeout2 > 0.5f) {
			for (int i=0; i<army.Count; i++) {
				if (army [i].mainunit != -1) {
					for (int j=0; j<army[i].unitshp.Count; j++) {
						if (army [i].unitshp [j] <= 0) {
							Destroy (army [i].inst [j]);
							army [i].units.RemoveAt (j);
							army [i].unitshp.RemoveAt (j);
							army [i].inst.RemoveAt (j);
							army [i].now -= 0.1f;
						}
					}
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
							army [i].mainunit = -1;
							Destroy (army [i].comgo);
						}
						
					}
					
				}
			}
			curtimeout2=0;
		}
	}
	public void cityindanger(int num){
		int n = 0;
		int nnum = 0;
		for (int i=0; i<cities.Count; i++)
			if (cities [i].uns.Count > n &&!zachvat[i]) {
			nnum=i;
			n=cities [i].uns.Count;
		}
		h=Instantiate (main._m.compref);
		h.transform.position = gameObject.transform.position;
		h.GetComponent<mainunit> ().tsel = citiesinst [nnum].transform.position;
		h.GetComponent<mainunit> ().tseltsel = citiesinst [nnum];
		h.GetComponent<mainunit> ().gotsel = true;
		h.GetComponent<mainunit> ().race = race;
		h.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite=main._m.units[posolnum-1].sp;
		h.GetComponent<mainunit> ().num = posolnum;
		h.GetComponent<mainunit> ().m = army.Count;
		h.GetComponent<mainunit> ().isposol = true;
		h.GetComponent<mainunit> ().stoptobattle = false;
		h.GetComponent<mainunit> ().poruch="podkrep";
		h.GetComponent<mainunit> ().poruchcol=bezbash;
		h.GetComponent<mainunit> ().poruchtsel=citiesinst[num];
		army.Add (main._m.empteam);
		army [army.Count - 1].comgo = h;
		army [army.Count - 1].mainunit = posolnum;
		army [army.Count - 1].mainunithp = main._m.units[posolnum-1].hp;

	}
}
