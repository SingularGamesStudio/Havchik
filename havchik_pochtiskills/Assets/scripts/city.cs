using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class city : MonoBehaviour {
	public GameObject citym;
	public main.dial d;
	public int race;
	public List<main.dial> l;
	public List<GameObject> uns=new List<GameObject>();
	public List<GameObject> unsotkat=new List<GameObject>();
	public GameObject sppos;
	public GameObject flag;
	public bool inbattle=false;
	public float curtimeout;
	public float curtimeout1;
	public float curtimeout2;
	public float maxbatrasst=10;
	public int resdob;
	public List<int> resin=new List<int>();
	public List<int> resincol=new List<int>();
	public List<int> unitsin=new List<int>();
	public int resdobready;
	public int resspeed;
	GameObject h;
	public bool inbattle1;
	public System.Random rnd=new System.Random();
	public bool actmain=false;
	public int posolnum;
	public GameObject posol;
	public bool house;
	public city mainhouse;
	public bool maincity;
	public bool grabbed=false;
	public bool canbedest;
	public int destroyglsob;
	public bool hasnoflag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (main._m.ingame) {
			curtimeout1 += Time.deltaTime;
			curtimeout += Time.deltaTime;







			if (curtimeout > 0.05f) {
				if (canbedest && main._m.globalsob [destroyglsob] == 1) {
					Destroy (gameObject);
				}
				if (uns.Count > 0) {
					for (int i = 0; i < uns.Count; i++) {
						if (uns [i] == null) {
							Destroy (unsotkat [i]);
							unsotkat.RemoveAt (i);
							uns.RemoveAt (i);
						}
					}
				} else {
					if (inbattle) {
						main._m.inbattle = false;
						inbattle = false;
						inbattle1 = false;
						for (int i = 0; i < uns.Count; i++) {
							uns [i].SetActive (false);
							uns [i].transform.position = unsotkat [i].transform.position;
							uns [i].GetComponent<defender> ().hp = unsotkat [i].GetComponent<defender> ().hp;
							uns [i].GetComponent<defender> ().type = unsotkat [i].GetComponent<defender> ().type;
						}
					}
				}
				bool k = true;
				for (int i = 0; i < 10; i++) {
					if (main._m.teams [i].mainunit != -1)
					if (Vector3.Distance (main._m.teams [i].comgo.transform.position, gameObject.transform.position) < maxbatrasst)
						k = false;
				}
				if (k) {
					if (inbattle) {
						inbattle1 = false;
						main._m.inbattle = false;
						inbattle = false;
						for (int i = 0; i < uns.Count; i++) {
							uns [i].SetActive (false);
							uns [i].transform.position = unsotkat [i].transform.position;
							uns [i].GetComponent<defender> ().hp = unsotkat [i].GetComponent<defender> ().hp;
							uns [i].GetComponent<defender> ().type = unsotkat [i].GetComponent<defender> ().type;
						}
					}
				}
				curtimeout = 0;
				if (actmain && !hasnoflag)
					flag.GetComponent<SpriteRenderer> ().sprite = main._m.races [race].flag;
			}
			if (curtimeout1 > 20) {
				resdobready += rnd.Next (resspeed);
				curtimeout1 = 0;

			}
			if (!inbattle1 && inbattle && !maincity) {
				h = Instantiate (main._m.compref);
				h.transform.position = gameObject.transform.position;
				h.GetComponent<mainunit> ().tsel = main._m.races [race].com.gameObject.transform.position;
				h.GetComponent<mainunit> ().tseltsel = main._m.races [race].com.gameObject;
				h.GetComponent<mainunit> ().gotsel = true;
				h.GetComponent<mainunit> ().race = race;
				h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = main._m.units [posolnum - 1].sp;
				h.GetComponent<mainunit> ().num = posolnum;
				h.GetComponent<mainunit> ().m = main._m.races [race].com.army.Count;
				h.GetComponent<mainunit> ().isposol = true;
				h.GetComponent<mainunit> ().stoptobattle = false;
				h.GetComponent<mainunit> ().poruch = "podkrepask";
				h.GetComponent<mainunit> ().poruchcol = main._m.races [race].com.citiesinst.IndexOf (gameObject);
				main._m.races [race].com.army.Add (main._m.empteam);
				main._m.races [race].com.army [main._m.races [race].com.army.Count - 1].comgo = h;
				main._m.races [race].com.army [main._m.races [race].com.army.Count - 1].mainunit = posolnum;
				main._m.races [race].com.army [main._m.races [race].com.army.Count - 1].mainunithp = main._m.units [posolnum - 1].hp;
				inbattle1 = true;
			}
		}
	}
	public void podkrep(GameObject ts,int col){
		h=Instantiate (main._m.compref);
		h.transform.position = gameObject.transform.position;
		h.GetComponent<mainunit> ().tsel = ts.transform.position;
		h.GetComponent<mainunit> ().tseltsel = ts;
		h.GetComponent<mainunit> ().gotsel = true;
		h.GetComponent<mainunit> ().race = race;
		h.GetComponent<mainunit> ().stoptobattle = false;
		h.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite=main._m.units[uns[0].GetComponent<defender>().num-1].sp;
		h.GetComponent<mainunit> ().num = uns[0].GetComponent<defender>().num;
		h.GetComponent<mainunit> ().m = main._m.races[race].com.army.Count;
		h.GetComponent<mainunit> ().isposol = true;
		h.GetComponent<mainunit> ().poruch="zachvat";
		main._m.races[race].com.army.Add (main._m.empteam);
		uns.RemoveAt (0);
		unsotkat.RemoveAt (0);
		main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].comgo = h;
		main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].mainunit = h.GetComponent<mainunit> ().num;
		main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].mainunithp = main._m.units[h.GetComponent<mainunit> ().num-1].hp;
		for (int i=0; i<col-1; i++) {
			h=Instantiate (main._m.unitpref);
			h.transform.position = gameObject.transform.position;
			h.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite=main._m.units[uns[0].GetComponent<defender>().num-1].sp;
			h.GetComponent<uniter> ().race = race;
			h.GetComponent<uniter> ().num = uns[0].GetComponent<defender>().num;
			h.GetComponent<uniter> ().m = main._m.races[race].com.army.Count;
			h.GetComponent<uniter> ().topresl = main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].comgo;
			uns.RemoveAt (0);
			unsotkat.RemoveAt (0);
			main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].inst.Add (h);
			main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].units.Add (h.GetComponent<uniter> ().num);
			main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].unitshp.Add (main._m.units[h.GetComponent<uniter> ().num-1].hp);
			main._m.races[race].com.army [main._m.races[race].com.army.Count - 1].now+=0.1f;
		}
	}
	void OnMouseDown(){
		if(!citym.GetComponent<city>().inbattle)
			if(!main._m.dialog.activeSelf)
		if(!main._m.iswikiopen)
		main._m.townenter (citym);
	}
}
