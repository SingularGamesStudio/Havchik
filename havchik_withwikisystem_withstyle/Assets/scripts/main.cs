using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class main : MonoBehaviour {
	[System.Serializable]
	public class unit{
		public string name;
		public int hp;
		public int dmg;
		public Sprite sp;
		public Sprite at1;
		public Sprite at2;
		public Sprite at3;
		public bool fly=false;
	}
	[System.Serializable]
	public class team{
		public float now;
		public string name;
		public int num;
		public int mainunit;
		public List<int> units;
		public List<int> unitshp;
		public List<GameObject> inst;
		public GameObject comgo;
		public int mainunithp;
	}
	[System.Serializable]
	public class race{

		public string name;
		public int otnosh;
		public List<int> units;public Sprite flag;
		public racecommand com;
	}
	[System.Serializable]
	public class dial{
		[Multiline]public string txt;
		[Multiline]public string a1;
		[Multiline]public string a2;
		[Multiline]public string a3;
		[Multiline]public string a4;
		public string act1;
		public string act2;
		public string act3;
		public string act4;
		public string usl1;
		public string usl2;
		public string usl3;
		public string usl4;
		public int d1;
		public int d2;
		public int d3;
		public int d4;
		public Sprite talker;
	}
	[System.Serializable]
	public class wikipage{
		public string heading;
		public string type;
		[Multiline]public string txt;
		public Sprite sp;
		public int num;
		public bool open;
	}
	public team empteam;
	public static main _m;
	public List<unit> units;
	public List<team> teams;
	GameObject h;
	public Image commander;
	public Image u1;
	public Image u2;
	public Image u3;
	public Image u4;
	public Image u5;
	public Camera mc;
	public List<Text> teamname;
	public float curtimeout;
	public float curtimeout1;
	public Sprite nulsp;
	public float curtimeout2;
	public int chosedteam;
	public int sdvig=0;
	public float speed=0.1f;
	public float combdist=1;
	public GameObject unitpref;
	public GameObject compref;
	public bool creatingteam=false;
	public GameObject crtext;
	public List<int> newteamnums;
	public List<int> u11;
	public List<GameObject> i1;
	public List<int> quests = new List<int> ();
	public List<string> qnames = new List<string> ();
	public List<string> resnames = new List<string> ();
	public List<int> resource = new List<int> ();
	public List<race> races = new List<race> ();
	public List<Sprite> ressp = new List<Sprite> ();
	public bool inbattle=false;
	public bool[,] crit=new bool[40,40]; //-1
	System.Random rnd = new System.Random ();
	public bool iswikiopen = false;
	public string wikiname;
	public int wikisdvig;
	public GameObject wiki1;
	public GameObject wiki2;
	public GameObject wiki3;
	public GameObject wiki4;
	public GameObject wiki5;
	public GameObject wikisp;
	public GameObject wikitxt;
	public GameObject wikihead;
	public GameObject wikigo;
	public List<int> chosedwiki=new List<int>();
	public List<int> universewiki = new List<int> ();
	public List<int> unitswiki = new List<int> ();
	public List<int> racewiki = new List<int> ();
	public List<int> reswiki = new List<int> ();
	public List<int> citywiki = new List<int> ();
	public List<int> logicwiki = new List<int> ();
	public List<wikipage> wiki = new List<wikipage> ();
	public List<string> razdel = new List<string> ();
	public GameObject dialog;
	public city citnow;
	public Text ans1;
	public Text ans2;
	public Text ans3;
	public Text ans4;
	public Text talk;
	public Image talker;
	public Image cityim;
	public int dialnum=-1;
	public int lastdialnum;
	public List<bool> canans=new List<bool>();
	public bool youdest=false;
	// Use this for initialization
	void Start () {
		_m = this;
		commander.sprite = units [teams [chosedteam].mainunit-1].sp;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
		crit [21, 22] = true;
		crit [14, 4] = true;
		crit [9, 4] = true;
	}
	
	// Update is called once per frame
	void Update () {
		curtimeout += Time.deltaTime;
		curtimeout1 += Time.deltaTime;
		curtimeout2 += Time.deltaTime;
		if (teams [chosedteam].units.Count > 0) {
			sdvig %= teams [chosedteam].units.Count;
		}
		if (curtimeout > 0.5f) {
			
			for (int i = 0; i < resource.Count; i++) {
				if (resource [i] < 0)
					resource [i] = 0;
			}
			for(int i=0;i<10;i++){
				if(teams[i].mainunit!=-1){
					teamname[i].text=teams[i].name;

					for(int j=0;j<teams[i].unitshp.Count;j++){
						if(teams[i].unitshp[j]<=0){
							Destroy (teams[i].inst[j]);
							teams[i].units.RemoveAt (j);
							teams[i].unitshp.RemoveAt (j);
							teams[i].inst.RemoveAt (j);
							teams[i].now-=0.1f;
						}
					}
					if(teams[i].mainunithp<=0){

						if(teams[i].units.Count>0){
						if(i==chosedteam){
							mc.gameObject.transform.SetParent (null);
							//mc.gameObject.transform.localPosition=new Vector3(0,0,mc.transform.position.z);
						}
						Destroy (teams[i].comgo);
						h=Instantiate(compref); h.GetComponent<mainunit>().race=11;
						h.GetComponent<mainunit>().num=teams[i].units[0];
						h.GetComponent<mainunit>().m=i;
						h.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=units[teams[i].units[0]-1].sp;
						h.transform.position=teams[i].inst[0].transform.position;
						teams[i].mainunit=teams[i].units[0];
						teams[i].mainunithp=teams[i].unitshp[0];
						teams[i].comgo=h;
						teams[i].now-=0.1f;
						if(i==chosedteam){
							mc.gameObject.transform.SetParent (teams[chosedteam].comgo.transform);
							mc.gameObject.transform.localPosition=new Vector3(0,0,mc.transform.position.z);
						}
							Destroy (teams[i].inst[0]);
							teams[i].units.RemoveAt (0);
							teams[i].inst.RemoveAt (0);
							teams[i].unitshp.RemoveAt (0);
							for(int j=0;j<teams[i].units.Count;j++){
								teams[i].inst[j].GetComponent<uniter>().m=i;
							}
						} else{
							teams[i].mainunit=-1;
							bool hgt=false;
							for(int j=0;j<10;j++){
								if(teams[j].mainunit!=-1){
									smenacom(j);
									hgt=true;
									break;
								}
							}
							if(!hgt) die();
							Destroy (teams[i].comgo);
						}

					}

				}else teamname[i].text="Пусто";

			}
			commander.sprite = units [teams [chosedteam].mainunit-1].sp;
			if(teams [chosedteam].units.Count > 0)
				u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
			else u1.sprite = nulsp;
			if (teams [chosedteam].units.Count > 1)
				u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
			else
				u2.sprite = nulsp;
			if (teams [chosedteam].units.Count > 2)
				u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u3.sprite = nulsp;
			if (teams [chosedteam].units.Count > 3)
				u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u4.sprite = nulsp;
			if (teams [chosedteam].units.Count > 4)
				u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u5.sprite = nulsp;
			curtimeout=0;
		}
		if (curtimeout2 > 1) {
			for (int i=0;i<10;i++){
				if(teams[i].mainunit!=-1){
					if(units[teams[i].mainunit-1].hp>teams[i].mainunithp)
						teams[i].mainunithp+=1;
				for (int j=0;j<teams[i].units.Count;j++){

						if(units[teams[i].units[j]-1].hp>teams[i].unitshp[j])
							teams[i].unitshp[j]+=1;
					}
				}
			}
			curtimeout2=0;
		}
		if (curtimeout1 > 0.01f) {
			if (Input.GetKey (KeyCode.W)) {
				teams [chosedteam].comgo.transform.Translate (teams [chosedteam].comgo.transform.up * speed);
			}
			if (Input.GetKey (KeyCode.S)) {
				teams [chosedteam].comgo.transform.Translate (teams [chosedteam].comgo.transform.up * -speed);
			}
			if (Input.GetKey (KeyCode.A)) {
				teams [chosedteam].comgo.transform.Translate (teams [chosedteam].comgo.transform.right * -speed);
			}
			if (Input.GetKey (KeyCode.D)) {
				teams [chosedteam].comgo.transform.Translate (teams [chosedteam].comgo.transform.right * speed);
			}
			if (creatingteam) {
				if (newteamnums.Contains (sdvig))
					u1.color = Color.black;
				else u1.color = Color.white;
				if (newteamnums.Contains (sdvig+1))
					u2.color = Color.black;
				else u2.color = Color.white;
				if (newteamnums.Contains (sdvig+2))
					u3.color = Color.black;
				else u3.color = Color.white;
				if (newteamnums.Contains (sdvig+3))
					u4.color = Color.black;
				else u4.color = Color.white;
				if (newteamnums.Contains (sdvig+4))
					u5.color = Color.black;
				else u5.color = Color.white;
			}
			curtimeout1=0;
		}
	}
	public void die(){
		Destroy (mc);
	}
	public void rsdvig(){
		sdvig += 1;
		if(teams [chosedteam].units.Count > 0)
		u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
	}
	public void lsdvig(){
		sdvig -= 1;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
	}
	public void smenacom(int a){
		if(teams[a].mainunit!=-1)
		chosedteam = a;
		commander.sprite = units [teams [chosedteam].mainunit-1].sp;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
		u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
		u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
		u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
		mc.gameObject.transform.SetParent (teams[chosedteam].comgo.transform);
		mc.gameObject.transform.localPosition=new Vector3(0,0,mc.transform.position.z);
	}
	public void combbtn(){
		for (int i=0; i<10; i++) {
			if(i!=chosedteam)
			if(teams[i].mainunit!=-1){
				if(Vector3.Distance(teams[chosedteam].comgo.transform.position,teams[i].comgo.transform.position)<combdist){
					h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
					h.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=units[teams[i].mainunit-1].sp;
					h.transform.position=teams[i].comgo.transform.position;
					h.GetComponent<uniter>().m=chosedteam; 
					h.GetComponent<uniter>().num=teams[i].mainunit;
					teams[chosedteam].units.Add (teams[i].mainunit);
					teams[chosedteam].unitshp.Add (teams[i].mainunithp);
					teams[chosedteam].inst.Add (h);
					Destroy (teams[i].comgo);
					teams[chosedteam].now+=0.1f;
					if(teams[i].units.Count>0)
					for(int j=0;j<teams[i].units.Count;j++){
						h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
						h.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite=units[teams[i].units[j]-1].sp;
						h.transform.position=teams[i].inst[j].transform.position;
						h.GetComponent<uniter>().m=chosedteam;
						h.GetComponent<uniter>().num=teams[i].units[j];
						h.GetComponent<uniter>().fly=teams[i].inst[j].GetComponent<uniter>().fly;
						teams[chosedteam].units.Add (teams[i].units[j]);
						teams[chosedteam].unitshp.Add (teams[i].unitshp[j]);
						teams[chosedteam].inst.Add (h);
						Destroy (teams[i].inst[j]);
						teams[chosedteam].now+=0.1f;
					}
					teams[i].mainunit=-1; 
					teams[i].inst.Clear ();
					teams[i].units.Clear ();
					teams[i].unitshp.Clear ();
				}
			}
		}

		commander.sprite = units [teams [chosedteam].mainunit-1].sp;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;

	}
	public void createteam(){
		newteamnums.Clear ();
		creatingteam = true;
		crtext.SetActive (true);
	}
	public void add(int a){
		if (creatingteam) {
			bool b=true;
			for(int i=0;i<newteamnums.Count;i++){
				if(newteamnums[i]==(a+sdvig)%(teams [chosedteam].units.Count))
					b=false;
			}
			if(b)
			newteamnums.Add((a+sdvig)%(teams [chosedteam].units.Count));
		}
	}
	public void endcreatingteam(){
		creatingteam = false;
		string s1 = crtext.transform.GetChild (0).GetChild(0).gameObject.GetComponent<InputField> ().text;
		int a = -1;
		for (int i=0; i<10; i++) {
			if(teams[i].mainunit==-1){
				a=i;
				break;
			}
		}
		crtext.transform.GetChild (0).GetChild(0).gameObject.GetComponent<InputField> ().text="";
		crtext.SetActive (false);
		if (a != -1 && newteamnums.Count>0) {
			teams[chosedteam].now-=newteamnums.Count*0.1f;
			teams[a].name=s1;
			h=Instantiate(compref); h.GetComponent<mainunit>().race=11;
			h.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=units[teams[chosedteam].units[newteamnums[0]]-1].sp;
			h.transform.position=teams[chosedteam].inst[newteamnums[0]].transform.position;
			h.GetComponent<mainunit>().num=teams[chosedteam].units[newteamnums[0]];
			h.GetComponent<mainunit>().m=a;
			teams[a].mainunit=teams[chosedteam].units[newteamnums[0]];
			teams[a].mainunithp=teams[chosedteam].unitshp[newteamnums[0]];
			teams[a].comgo=h;
			Destroy (teams[chosedteam].inst[newteamnums[0]]);
			teams[a].now=0;
			if(newteamnums.Count>1)
			for(int j=1;j<newteamnums.Count;j++){
				h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
				h.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite=units[teams[chosedteam].units[newteamnums[j]]-1].sp;
				h.transform.position=teams[chosedteam].inst[newteamnums[j]].transform.position;
				h.GetComponent<uniter>().m=a;
				h.GetComponent<uniter>().num=teams[chosedteam].units[newteamnums[j]];
				h.GetComponent<uniter>().fly=teams[chosedteam].inst[newteamnums[j]].GetComponent<uniter>().fly;
				teams[a].units.Add (teams[chosedteam].units[newteamnums[j]]);
				teams[a].unitshp.Add (teams[chosedteam].unitshp[newteamnums[j]]);
				teams[a].inst.Add (h);
				Destroy (teams[chosedteam].inst[newteamnums[j]]);
				teams[a].now+=0.1f;
			}
			}
		for (int i=0; i<newteamnums.Count; i++) {
			teams[chosedteam].units[newteamnums[i]]=-1;
			teams[chosedteam].inst[newteamnums[i]]=null;
		}
		for (int i=0; i<1000000; i=i) {
			if(teams[chosedteam].units[i]==-1){
				teams[chosedteam].units.RemoveAt (i);
				teams[chosedteam].inst.RemoveAt (i);
				teams[chosedteam].unitshp.RemoveAt (i);

			} else i+=1;
			if(i>=teams[chosedteam].units.Count) break;

		}
		commander.sprite = units [teams [chosedteam].mainunit-1].sp;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
		u1.color = Color.white;
		u2.color = Color.white;
		u3.color = Color.white;
		u4.color = Color.white;
		u5.color = Color.white;
		newteamnums.Clear ();
		}
	public void cancelcreate(){
		creatingteam = false;
		crtext.SetActive (false);
		commander.sprite = units [teams [chosedteam].mainunit-1].sp;
		if(teams [chosedteam].units.Count > 0)
			u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
		else u1.sprite = nulsp;
		if (teams [chosedteam].units.Count > 1)
			u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [chosedteam].units.Count > 2)
			u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u3.sprite = nulsp;
		if (teams [chosedteam].units.Count > 3)
			u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u4.sprite = nulsp;
		if (teams [chosedteam].units.Count > 4)
			u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
		else
			u5.sprite = nulsp;
		u1.color = Color.white;
		u2.color = Color.white;
		u3.color = Color.white;
		u4.color = Color.white;
		u5.color = Color.white;
		newteamnums.Clear ();
	}
	public void townenter(GameObject town){
		citnow = town.GetComponent<city> ();
		if (Vector3.Distance (town.transform.position, teams [chosedteam].comgo.transform.position) < 2) {
			dialog.SetActive (true);
			dialnum=-1;


			if(citnow.d.usl1!=""){
				razdel.Add ("");
				for (int i=0;i<citnow.d.usl1.Length;i++){
					if(citnow.d.usl1[i]==' '){
						razdel.Add ("");
					}else razdel[razdel.Count-1]+=citnow.d.usl1[i];
				}
				bool bo=true;
				for (int i=0;i<razdel.Count;i++){
					if(razdel[i]=="quest"){
						if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
						    bo=false;
						i+=2;
					} else if(razdel[i]=="quest-"){if (quests[int.Parse (razdel[i+1])]==int.Parse (razdel[i+2])) bo=false; i+=2;} else
					if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
						if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
						if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else 
					if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
						if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					}
					else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else  if(razdel[i]=="unitin"){
						if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						i+=1;
					} else if(razdel[i]=="itemin"){
						if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else if(razdel[i]=="your"){
						if (citnow.race!=11)
							bo=false;
					} else if(razdel[i]=="notyour"){
						if (citnow.race==11)
							bo=false;
					}
				}
				if (bo){
					ans1.text=citnow.d.a1;
					canans[0]=true;
				}else{ ans1.text="";
					canans[0]=false;
				}
				razdel.Clear ();
			}else{
			ans1.text=citnow.d.a1;
				canans[0]=true;
			}
			if(citnow.d.usl2!=""){
				razdel.Add ("");
				for (int i=0;i<citnow.d.usl2.Length;i++){
					if(citnow.d.usl2[i]==' '){
						razdel.Add ("");
					}else razdel[razdel.Count-1]+=citnow.d.usl2[i];
				}
				bool bo=true;
				for (int i=0;i<razdel.Count;i++){
					if(razdel[i]=="quest"){
						if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
						if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
						if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else 
					if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
						if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
						if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						i+=1;
					} else if(razdel[i]=="itemin"){
						if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else if(razdel[i]=="your"){
						if (citnow.race!=11)
							bo=false;
					} else if(razdel[i]=="notyour"){
						if (citnow.race==11)
							bo=false;
					}
				}
				if (bo){
					ans2.text=citnow.d.a2;
					canans[1]=true;
				}else{ ans2.text="";
					canans[1]=false;
				}
				razdel.Clear ();
			}else{
			ans2.text=citnow.d.a2;
				canans[1]=true;
			}
			
			if(citnow.d.usl3!=""){
				razdel.Add ("");
				for (int i=0;i<citnow.d.usl3.Length;i++){
					if(citnow.d.usl3[i]==' '){
						razdel.Add ("");
					}else razdel[razdel.Count-1]+=citnow.d.usl3[i];
				}
				bool bo=true;
				for (int i=0;i<razdel.Count;i++){
					if(razdel[i]=="quest"){
						if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
						if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
						if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else 
					if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
						if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
						if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						i+=1;
					} else if(razdel[i]=="itemin"){
						if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else if(razdel[i]=="your"){
						if (citnow.race!=11)
							bo=false;
					} else if(razdel[i]=="notyour"){
						if (citnow.race==11)
							bo=false;
					}
				}
				if (bo){
					ans3.text=citnow.d.a3;
					canans[2]=true;
				}else{ ans3.text="";
					canans[2]=false;
				}
				razdel.Clear ();
			}else{
				ans3.text=citnow.d.a3;
				canans[2]=true;
			}

			
			
			if(citnow.d.usl4!=""){
				razdel.Add ("");
				for (int i=0;i<citnow.d.usl4.Length;i++){
					if(citnow.d.usl4[i]==' '){
						razdel.Add ("");
					}else razdel[razdel.Count-1]+=citnow.d.usl4[i];
				}
				bool bo=true;
				for (int i=0;i<razdel.Count;i++){
					if(razdel[i]=="quest"){
						if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
						if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else 
					if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
						if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else 
					if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
						if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
							bo=false;
						i+=1;
					} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
						if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						i+=1;
					} else if(razdel[i]=="itemin"){
						if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
							bo=false;
						else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
							bo=false;
						i+=2;
					} else if(razdel[i]=="your"){
						if (citnow.race!=11)
							bo=false;
					} else if(razdel[i]=="notyour"){
						if (citnow.race==11)
							bo=false;
					}
				}
				if (bo){
					ans4.text=citnow.d.a4;
					canans[3]=true;
				} else{ ans4.text="";
					canans[3]=false;
				}
				razdel.Clear ();
			}else{
				ans4.text=citnow.d.a4;
				canans[3]=true;
			}
			talk.text=citnow.d.txt;
			talker.sprite=citnow.d.talker;

			cityim.sprite=citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite;
		}
	}
	public void ans(int num){
		bool exit = false;
		if (canans[num]) {
			if(num==0){//num0









				if(dialnum==-1){
				if(citnow.d.d1!=-1){
				dialnum=citnow.d.d1;
						lastdialnum=-1;
					}else {
						if(citnow.d.act1!="none"){
						razdel.Add ("");
						for (int i=0;i<citnow.d.act1.Length;i++){
							if(citnow.d.act1[i]==' '){
								razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.d.act1[i];
						}
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
									i+=2;
								} else 
								if(razdel[i]=="add"){
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
										resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
										}
									i+=2;
								} else 
								if(razdel[i]=="del"){
									resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
									else{
										citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
										citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
									}
									i+=2;
								} else 
								if(razdel[i]=="exit"){
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else 
								if(razdel[i]=="otn"){
									races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
									i+=1;
								} else 
								if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
									int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
									citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
									teams[chosedteam].units.RemoveAt (o);
									Destroy(teams[chosedteam].inst[o]);
									teams[chosedteam].inst.RemoveAt (o);
									teams[chosedteam].now-=0.1f;
									i+=1;}
								} else 
								if(razdel[i]=="addunit"){
									if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
										teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
										h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
									}
									i+=1;
								}else 
								if(razdel[i]=="downdefence"){
									if(citnow.uns.Count>0){
										Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
										citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
									}
								} else 
								if(razdel[i]=="sdav"){
									if(citnow.race!=11){
										if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
											for (int j=0;j<citnow.uns.Count;j++){
												citnow.uns[j].SetActive (true);
											}
											teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
											for (int j=0;j<teams[chosedteam].units.Count;j++){
												teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
											}
											citnow.inbattle=true;
											inbattle=true;
											citnow=null;
											dialog.SetActive (false);
											exit=true;
											break;
										} else {
											dialnum=11;
										}
									} else {
										dialnum=10;
									}
								} else 
								if(razdel[i]=="destroy"){
									if(razdel[i+1]=="1"){
										if(citnow.uns.Count!=0)
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										Destroy (citnow.gameObject);
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else{
										Destroy (citnow.gameObject);
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									}
								} else if(razdel[i]=="zachvat"){
									citnow.race=11;
								} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
									for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
										int yur=rnd.Next (2);
										if(yur==1){
											int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
											resource[citnow.mainhouse.resin[j1]]+=yur1;
											citnow.mainhouse.resincol[j1]-=yur1;
											}}
									}
									for(int j1=0;j1<citnow.unitsin.Count;j1++){
										int yur=rnd.Next (5);
										if(yur==1){
											teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
											h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
											h.transform.position=citnow.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
											h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
											h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
											teams[chosedteam].inst.Add (h);
											teams[chosedteam].now+=0.1f;
											i+=1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
								} else if(razdel[i]=="colony"){
									
								} else if(razdel[i]=="nalog"){
									int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
									resource[citnow.resdob]+=g;
									citnow.resdobready-=g;
								} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
								} else if(razdel[i]=="addan"){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									i+=2;
								} else if(razdel[i]=="pos"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									}
									i+=2;
								}  else if(razdel[i]=="poswout"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									i+=2;
								} else if(razdel[i]=="zachvatall"){
									for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
										main._m.races[citnow.race].com.cities[j1].race=11;
									}
									Destroy (main._m.races[citnow.race].com);
									citnow.race=11;
								}
								
							}
							razdel.Clear ();
						} else exit=true;
					}}
				else if(citnow.l[dialnum].d1!=-1){
					lastdialnum=dialnum; dialnum=citnow.l[dialnum].d1; 
				}else {
					if(citnow.l[dialnum].act1!="none"){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].act1.Length;i++){
							if(citnow.l[dialnum].act1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].act1[i];
						}
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
								i+=2;
							} else 
							if(razdel[i]=="add"){
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
								}
								i+=2;
							} else 
							if(razdel[i]=="del"){
								resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
								else{
									citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
									citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
								}
								i+=2;
							} else 
							if(razdel[i]=="exit"){
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else 
							if(razdel[i]=="otn"){
								races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
								i+=1;
							} else 
							if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
								int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
								citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
								teams[chosedteam].units.RemoveAt (o);
								Destroy(teams[chosedteam].inst[o]);
								teams[chosedteam].inst.RemoveAt (o);
								teams[chosedteam].now-=0.1f;
							i+=1;}
							} else 
							if(razdel[i]=="addunit"){
								if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
								}
								i+=1;
							}else 
							if(razdel[i]=="downdefence"){
								if(citnow.uns.Count>0){
									Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
									citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
								}
							} else 
							if(razdel[i]=="sdav"){
								if(citnow.race!=11){
									if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else {
										dialnum=11;
									}
								} else {
									dialnum=10;
								}
							} else 
							if(razdel[i]=="destroy"){
								if(razdel[i+1]=="1"){
									if(citnow.uns.Count!=0)
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									Destroy (citnow.gameObject);
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else{
									Destroy (citnow.gameObject);
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								}
							} else if(razdel[i]=="zachvat"){
								citnow.race=11;
							} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
								for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
									int yur=rnd.Next (2);
									if(yur==1){
										int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
										resource[citnow.mainhouse.resin[j1]]+=yur1;
										citnow.mainhouse.resincol[j1]-=yur1;
											}}
								}
								for(int j1=0;j1<citnow.unitsin.Count;j1++){
									int yur=rnd.Next (5);
									if(yur==1){
										teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
										h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										i+=1;
										citnow.unitsin.RemoveAt (j1);
									}
								}
							} else if(razdel[i]=="colony"){
								
							} else if(razdel[i]=="nalog"){
								int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
								resource[citnow.resdob]+=g;
								citnow.resdobready-=g;
							} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								i+=1;
							} else if(razdel[i]=="addan"){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								i+=2;
							} else if(razdel[i]=="pos"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								}
								i+=2;
							}  else if(razdel[i]=="poswout"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								i+=2;
							} else if(razdel[i]=="zachvatall"){
								for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
									main._m.races[citnow.race].com.cities[j1].race=11;
								}
								Destroy (main._m.races[citnow.race].com);
								citnow.race=11;
							}
							
						}
						razdel.Clear ();
					} else exit=true;
				}
				if(!exit){
				if(citnow.l[dialnum].usl1!=""){
					razdel.Add ("");
					for (int i=0;i<citnow.l[dialnum].usl1.Length;i++){
						if(citnow.l[dialnum].usl1[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl1[i];
					}
					bool bo=true;
					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
							if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
							if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
						} else 
						if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
							if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
					}
					if (bo){
						ans1.text=citnow.l[dialnum].a1;
						canans[0]=true;
					}else{ ans1.text="";
						canans[0]=false;
					}
					razdel.Clear ();
				}else{
					ans1.text=citnow.l[dialnum].a1;
					canans[0]=true;
				}
				if(citnow.l[dialnum].usl2!=""){
					razdel.Add ("");
					for (int i=0;i<citnow.l[dialnum].usl2.Length;i++){
						if(citnow.l[dialnum].usl2[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl2[i];
					}
					bool bo=true;
					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
							if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
							if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
						} else 
						if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
							if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
					}
					if (bo){
						ans2.text=citnow.l[dialnum].a2;
						canans[1]=true;
					}else{ ans2.text="";
						canans[1]=false;
					}
					razdel.Clear ();
				}else{
					ans2.text=citnow.l[dialnum].a2;
					canans[1]=true;
				}
				
				if(citnow.l[dialnum].usl3!=""){
					razdel.Add ("");
					for (int i=0;i<citnow.l[dialnum].usl3.Length;i++){
						if(citnow.l[dialnum].usl3[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl3[i];
					}
					bool bo=true;
					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
							if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
							if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
						} else 
						if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
							if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
					}
					if (bo){
						ans3.text=citnow.l[dialnum].a3;
						canans[2]=true;
					}else{ ans3.text="";
						canans[2]=false;
					}
					razdel.Clear ();
				}else{
					ans3.text=citnow.l[dialnum].a3;
					canans[2]=true;
				}
				
				
				
				if(citnow.l[dialnum].usl4!=""){
					razdel.Add ("");
					for (int i=0;i<citnow.l[dialnum].usl4.Length;i++){
						if(citnow.l[dialnum].usl4[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl4[i];
					}
					bool bo=true;
					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
							if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
								bo=false;
							i+=2;
						} else 
						if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
							if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
						} else 
						if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
							if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
								bo=false;
							i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
					}
					if (bo){
						ans4.text=citnow.l[dialnum].a4;
						canans[3]=true;
					} else{ ans4.text="";
						canans[3]=false;
					}
					razdel.Clear ();
				}else{
					ans4.text=citnow.l[dialnum].a4;
					canans[3]=true;
				}
					
					
					razdel.Add ("");
					if(lastdialnum==-1){
						if(num==0)
						for (int i=0;i<citnow.d.act1.Length;i++){
							if(citnow.d.act1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act1[i];
						}
						else if(num==1)
						for (int i=0;i<citnow.d.act2.Length;i++){
							if(citnow.d.act2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act2[i];
						}
						else if(num==2)
						for (int i=0;i<citnow.d.act3.Length;i++){
							if(citnow.d.act3[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act3[i];
						}
						else
						for (int i=0;i<citnow.d.act4.Length;i++){
							if(citnow.d.act4[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act4[i];
						}
					}else
					if(num==0)
					for (int i=0;i<citnow.l[lastdialnum].act1.Length;i++){
						if(citnow.l[lastdialnum].act1[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act1[i];
					}
					else if(num==1)
					for (int i=0;i<citnow.l[lastdialnum].act2.Length;i++){
						if(citnow.l[lastdialnum].act2[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act2[i];
					}
					else if(num==2)
					for (int i=0;i<citnow.l[lastdialnum].act3.Length;i++){
						if(citnow.l[lastdialnum].act3[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act3[i];
					}
					else
					for (int i=0;i<citnow.l[lastdialnum].act4.Length;i++){
						if(citnow.l[lastdialnum].act4[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act4[i];
					}

					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
							i+=2;
						} else 
						if(razdel[i]=="add"){
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
							}
							i+=2;
						} else 
						if(razdel[i]=="del"){
							resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
							else{
								citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
								citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
							}
							i+=2;
						} else 
						if(razdel[i]=="exit"){
							citnow=null;
							dialog.SetActive (false);
							exit=true;
							break;
						} else 
						if(razdel[i]=="otn"){
							races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
							i+=1;
						} else 
						if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
							int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
							citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
							teams[chosedteam].units.RemoveAt (o);
							Destroy(teams[chosedteam].inst[o]);
							teams[chosedteam].inst.RemoveAt (o);
							teams[chosedteam].now-=0.1f;
								i+=1;}
						} else 
						if(razdel[i]=="addunit"){
							if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
							}
							i+=1;
						}else 
						if(razdel[i]=="downdefence"){
							if(citnow.uns.Count>0){
								Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
								citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
							}
						} else 
						if(razdel[i]=="sdav"){
							if(citnow.race!=11){
								if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else {
									dialnum=11;
								}
							} else {
								dialnum=10;
							}
						} else 
						if(razdel[i]=="destroy"){
							if(razdel[i+1]=="1"){
								if(citnow.uns.Count!=0)
								for (int j=0;j<citnow.uns.Count;j++){
									citnow.uns[j].SetActive (true);
								}
								teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
								}
								citnow.inbattle=true;
								Destroy (citnow.gameObject);
								inbattle=true;
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else{
								Destroy (citnow.gameObject);
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							}
						} else if(razdel[i]=="zachvat"){
							citnow.race=11;
						} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
							for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
								int yur=rnd.Next (2);
								if(yur==1){
									int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
									resource[citnow.mainhouse.resin[j1]]+=yur1;
									citnow.mainhouse.resincol[j1]-=yur1;
										}}
							}
							for(int j1=0;j1<citnow.unitsin.Count;j1++){
								int yur=rnd.Next (5);
								if(yur==1){
									teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
									h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
									citnow.unitsin.RemoveAt (j1);
								}
							}
						} else if(razdel[i]=="colony"){
							
						} else if(razdel[i]=="nalog"){
							int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
							resource[citnow.resdob]+=g;
							citnow.resdobready-=g;
						} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
							teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
							h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
							h.transform.position=citnow.gameObject.transform.position;
							h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
							h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
							h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
							teams[chosedteam].inst.Add (h);
							teams[chosedteam].now+=0.1f;
							i+=1;
						} else if(razdel[i]=="addan"){
							resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
							i+=2;
						} else if(razdel[i]=="pos"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							for (int j=0;j<teams[chosedteam].units.Count;j++){
								teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							}
							i+=2;
						}  else if(razdel[i]=="poswout"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							i+=2;
						} else if(razdel[i]=="zachvatall"){
							for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
								main._m.races[citnow.race].com.cities[j1].race=11;
							}
							Destroy (main._m.races[citnow.race].com);
							citnow.race=11;
						}
						
					}
					if(!exit){
					razdel.Clear ();
					talk.text=citnow.l[dialnum].txt;
					talker.sprite=citnow.l[dialnum].talker;
				
				cityim.sprite=citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite;
				
					}}








			}


			if(num==1){//num1
				
				
				
				
				
				
				
				
				
				if(dialnum==-1){
					if(citnow.d.d2!=-1){
						lastdialnum=-1;
						dialnum=citnow.d.d2;
					}else {
						if(citnow.d.act2!="none"){
							razdel.Add ("");
							for (int i=0;i<citnow.d.act2.Length;i++){
								if(citnow.d.act2[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.d.act2[i];
							}
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
									i+=2;
								} else 
								if(razdel[i]=="add"){
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
										resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
									}
									i+=2;
								} else 
								if(razdel[i]=="del"){
									resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
									else{
										citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
										citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
									}
									i+=2;
								} else 
								if(razdel[i]=="exit"){
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else 
								if(razdel[i]=="otn"){
									races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
									i+=1;
								} else 
								if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
									int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
									citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
									teams[chosedteam].units.RemoveAt (o);
									Destroy(teams[chosedteam].inst[o]);
									teams[chosedteam].inst.RemoveAt (o);
									teams[chosedteam].now-=0.1f;
								i+=1;}
								} else 
								if(razdel[i]=="addunit"){
									if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
										teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
										h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
									}
									i+=1;
								}else 
								if(razdel[i]=="downdefence"){
									if(citnow.uns.Count>0){
										Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
										citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
									}
								} else 
								if(razdel[i]=="sdav"){
									if(citnow.race!=11){
										if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
											for (int j=0;j<citnow.uns.Count;j++){
												citnow.uns[j].SetActive (true);
											}
											teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
											for (int j=0;j<teams[chosedteam].units.Count;j++){
												teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
											}
											citnow.inbattle=true;
											inbattle=true;
											citnow=null;
											dialog.SetActive (false);
											exit=true;
											break;
										} else {
											dialnum=11;
										}
									} else {
										dialnum=10;
									}
								} else 
								if(razdel[i]=="destroy"){
									if(razdel[i+1]=="1"){
										if(citnow.uns.Count!=0)
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										Destroy (citnow.gameObject);
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else{
										Destroy (citnow.gameObject);
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									}
								} else if(razdel[i]=="zachvat"){
									citnow.race=11;
								} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
									for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
										int yur=rnd.Next (2);
										if(yur==1){
											int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
											resource[citnow.mainhouse.resin[j1]]+=yur1;
											citnow.mainhouse.resincol[j1]-=yur1;
												}}
									}
									for(int j1=0;j1<citnow.unitsin.Count;j1++){
										int yur=rnd.Next (5);
										if(yur==1){
											teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
											h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
											h.transform.position=citnow.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
											h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
											h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
											teams[chosedteam].inst.Add (h);
											teams[chosedteam].now+=0.1f;
											i+=1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
								} else if(razdel[i]=="colony"){
									
								} else if(razdel[i]=="nalog"){
									int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
									resource[citnow.resdob]+=g;
									citnow.resdobready-=g;
								} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
								} else if(razdel[i]=="addan"){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									i+=2;
								} else if(razdel[i]=="pos"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									}
									i+=2;
								}  else if(razdel[i]=="poswout"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									i+=2;
								} else if(razdel[i]=="zachvatall"){
									for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
										main._m.races[citnow.race].com.cities[j1].race=11;
									}
									Destroy (main._m.races[citnow.race].com);
									races.RemoveAt (citnow.race);
									citnow.race=11;
								}
								
							}
							razdel.Clear ();
						} else exit=true;
					}}
				else if(citnow.l[dialnum].d2!=-1){
					lastdialnum=dialnum; dialnum=citnow.l[dialnum].d2; 
				}else {
					if(citnow.l[dialnum].act2!="none"){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].act2.Length;i++){
							if(citnow.l[dialnum].act2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].act2[i];
						}
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
								i+=2;
							} else 
							if(razdel[i]=="add"){
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
								}
								i+=2;
							} else 
							if(razdel[i]=="del"){
								resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
								else{
									citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
									citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
								}
								i+=2;
							} else 
							if(razdel[i]=="exit"){
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else 
							if(razdel[i]=="otn"){
								races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
								i+=1;
							} else 
							if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
								int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
								citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
								teams[chosedteam].units.RemoveAt (o);
								Destroy(teams[chosedteam].inst[o]);
								teams[chosedteam].inst.RemoveAt (o);
								teams[chosedteam].now-=0.1f;
									i+=1;}
							} else 
							if(razdel[i]=="addunit"){
								if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
								}
								i+=1;
							}else 
							if(razdel[i]=="downdefence"){
								if(citnow.uns.Count>0){
									Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
									citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
								}
							} else 
							if(razdel[i]=="sdav"){
								if(citnow.race!=11){
									if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else {
										dialnum=11;
									}
								} else {
									dialnum=10;
								}
							} else 
							if(razdel[i]=="destroy"){
								if(razdel[i+1]=="1"){
									if(citnow.uns.Count!=0)
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									Destroy (citnow.gameObject);
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else{
									Destroy (citnow.gameObject);
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								}
							} else if(razdel[i]=="zachvat"){
								citnow.race=11;
							} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
								for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
									int yur=rnd.Next (2);
									if(yur==1){
										int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
										resource[citnow.mainhouse.resin[j1]]+=yur1;
										citnow.mainhouse.resincol[j1]-=yur1;
											}}
								}
								for(int j1=0;j1<citnow.unitsin.Count;j1++){
									int yur=rnd.Next (5);
									if(yur==1){
										teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
										h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										i+=1;
										citnow.unitsin.RemoveAt (j1);
									}
								}
							} else if(razdel[i]=="colony"){
								
							} else if(razdel[i]=="nalog"){
								int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
								resource[citnow.resdob]+=g;
								citnow.resdobready-=g;
							} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								i+=1;
							} else if(razdel[i]=="addan"){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								i+=2;
							} else if(razdel[i]=="pos"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								}
								i+=2;
							}  else if(razdel[i]=="poswout"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								i+=2;
							} else if(razdel[i]=="zachvatall"){
								for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
									main._m.races[citnow.race].com.cities[j1].race=11;
								}
								Destroy (main._m.races[citnow.race].com);
								citnow.race=11;
							}
							
						}
						razdel.Clear ();
					} else exit=true;
				}
				if(!exit){
					if(citnow.l[dialnum].usl1!=""){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].usl1.Length;i++){
							if(citnow.l[dialnum].usl1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl1[i];
						}
						bool bo=true;
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
								if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
								if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else 
							if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
								if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
						}
						if (bo){
							ans1.text=citnow.l[dialnum].a1;
							canans[0]=true;
						}else{ ans1.text="";
							canans[0]=false;
						}
						razdel.Clear ();
					}else{
						ans1.text=citnow.l[dialnum].a1;
						canans[0]=true;
					}
					if(citnow.l[dialnum].usl2!=""){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].usl2.Length;i++){
							if(citnow.l[dialnum].usl2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl2[i];
						}
						bool bo=true;
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
								if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
								if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else 
							if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
								if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
						}
						if (bo){
							ans2.text=citnow.l[dialnum].a2;
							canans[1]=true;
						}else{ ans2.text="";
							canans[1]=false;
						}
						razdel.Clear ();
					}else{
						ans2.text=citnow.l[dialnum].a2;
						canans[1]=true;
					}
					
					if(citnow.l[dialnum].usl3!=""){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].usl3.Length;i++){
							if(citnow.l[dialnum].usl3[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl3[i];
						}
						bool bo=true;
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
								if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
								if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else 
							if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
								if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
						}
						if (bo){
							ans3.text=citnow.l[dialnum].a3;
							canans[2]=true;
						}else{ ans3.text="";
							canans[2]=false;
						}
						razdel.Clear ();
					}else{
						ans3.text=citnow.l[dialnum].a3;
						canans[2]=true;
					}
					
					
					
					if(citnow.l[dialnum].usl4!=""){
						razdel.Add ("");
						for (int i=0;i<citnow.l[dialnum].usl4.Length;i++){
							if(citnow.l[dialnum].usl4[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl4[i];
						}
						bool bo=true;
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
								if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else 
							if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
								if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else 
							if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
								if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
									bo=false;
								i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
						}
						if (bo){
							ans4.text=citnow.l[dialnum].a4;
							canans[3]=true;
						} else{ ans4.text="";
							canans[3]=false;
						}
						razdel.Clear ();
					}else{
						ans4.text=citnow.l[dialnum].a4;
						canans[3]=true;
					}
					
					
					razdel.Add ("");
					if(lastdialnum==-1){
						if(num==0)
						for (int i=0;i<citnow.d.act1.Length;i++){
							if(citnow.d.act1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act1[i];
						}
						else if(num==1)
						for (int i=0;i<citnow.d.act2.Length;i++){
							if(citnow.d.act2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act2[i];
						}
						else if(num==2)
						for (int i=0;i<citnow.d.act3.Length;i++){
							if(citnow.d.act3[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act3[i];
						}
						else
						for (int i=0;i<citnow.d.act4.Length;i++){
							if(citnow.d.act4[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act4[i];
						}
					}else
					if(num==0)
					for (int i=0;i<citnow.l[lastdialnum].act1.Length;i++){
						if(citnow.l[lastdialnum].act1[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act1[i];
					}
					else if(num==1)
					for (int i=0;i<citnow.l[lastdialnum].act2.Length;i++){
						if(citnow.l[lastdialnum].act2[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act2[i];
					}
					else if(num==2)
					for (int i=0;i<citnow.l[lastdialnum].act3.Length;i++){
						if(citnow.l[lastdialnum].act3[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act3[i];
					}
					else
					for (int i=0;i<citnow.l[lastdialnum].act4.Length;i++){
						if(citnow.l[lastdialnum].act4[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act4[i];
					}

					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
							i+=2;
						} else 
						if(razdel[i]=="add"){
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
							}
							i+=2;
						} else 
						if(razdel[i]=="del"){
							resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
							else{
								citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
								citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
							}
							i+=2;
						} else 
						if(razdel[i]=="exit"){
							citnow=null;
							dialog.SetActive (false);
							exit=true;
							break;
						} else 
						if(razdel[i]=="otn"){
							races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
							i+=1;
						} else 
						if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
							int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
							citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
							teams[chosedteam].units.RemoveAt (o);
							Destroy(teams[chosedteam].inst[o]);
							teams[chosedteam].inst.RemoveAt (o);
							teams[chosedteam].now-=0.1f;
							i+=1;}
						} else 
						if(razdel[i]=="addunit"){
							if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
							}
							i+=1;
						}else 
						if(razdel[i]=="downdefence"){
							if(citnow.uns.Count>0){
								Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
								citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
							}
						} else 
						if(razdel[i]=="sdav"){
							if(citnow.race!=11){
								if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else {
									dialnum=11;
								}
							} else {
								dialnum=10;
							}
						} else 
						if(razdel[i]=="destroy"){
							if(razdel[i+1]=="1"){
								if(citnow.uns.Count!=0)
								for (int j=0;j<citnow.uns.Count;j++){
									citnow.uns[j].SetActive (true);
								}
								teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
								}
								citnow.inbattle=true;
								Destroy (citnow.gameObject);
								inbattle=true;
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else{
								Destroy (citnow.gameObject);
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							}
						} else if(razdel[i]=="zachvat"){
							citnow.race=11;
						} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
							for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
								int yur=rnd.Next (2);
								if(yur==1){
									int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
									resource[citnow.mainhouse.resin[j1]]+=yur1;
									citnow.mainhouse.resincol[j1]-=yur1;
										}}
							}
							for(int j1=0;j1<citnow.unitsin.Count;j1++){
								int yur=rnd.Next (5);
								if(yur==1){
									teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
									h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
									citnow.unitsin.RemoveAt (j1);

								}
							}
						} else if(razdel[i]=="colony"){
							
						} else if(razdel[i]=="nalog"){
							int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
							resource[citnow.resdob]+=g;
							citnow.resdobready-=g;
						} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
							teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
							h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
							h.transform.position=citnow.gameObject.transform.position;
							h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
							h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
							h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
							teams[chosedteam].inst.Add (h);
							teams[chosedteam].now+=0.1f;
							i+=1;
						} else if(razdel[i]=="addan"){
							resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
							i+=2;
						} else if(razdel[i]=="pos"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							for (int j=0;j<teams[chosedteam].units.Count;j++){
								teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							}
							i+=2;
						}  else if(razdel[i]=="poswout"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							i+=2;
						} else if(razdel[i]=="zachvatall"){
							for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
								main._m.races[citnow.race].com.cities[j1].race=11;
							}
							Destroy (main._m.races[citnow.race].com);
							citnow.race=11;
						}
						
					}
					if(!exit){
					razdel.Clear ();
					talk.text=citnow.l[dialnum].txt;
					talker.sprite=citnow.l[dialnum].talker;
					
					cityim.sprite=citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite;
				}
				}
				
				
				
				
				
			}
			if(num==2){//num2
					
					
					
					
					
					
					
					
					
					if(dialnum==-1){
						if(citnow.d.d3!=-1){
							dialnum=citnow.d.d3;
						lastdialnum=-1;
					}else {
							if(citnow.d.act3!="none"){
								razdel.Add ("");
								for (int i=0;i<citnow.d.act3.Length;i++){
									if(citnow.d.act3[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.d.act3[i];
								}
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
									i+=2;
								} else 
								if(razdel[i]=="add"){
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
										resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
									}
									i+=2;
								} else 
								if(razdel[i]=="del"){
									resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
									else{
										citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
										citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
									}
									i+=2;
								} else 
								if(razdel[i]=="exit"){
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else 
								if(razdel[i]=="otn"){
									races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
									i+=1;
								} else 
								if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
									int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
									citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
									teams[chosedteam].units.RemoveAt (o);
									Destroy(teams[chosedteam].inst[o]);
									teams[chosedteam].inst.RemoveAt (o);
									teams[chosedteam].now-=0.1f;
								i+=1;}
								} else 
								if(razdel[i]=="addunit"){
									if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
										teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
										h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
									}
									i+=1;
								}else 
								if(razdel[i]=="downdefence"){
									if(citnow.uns.Count>0){
										Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
										citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
									}
								} else 
								if(razdel[i]=="sdav"){
									if(citnow.race!=11){
										if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
											for (int j=0;j<citnow.uns.Count;j++){
												citnow.uns[j].SetActive (true);
											}
											teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
											for (int j=0;j<teams[chosedteam].units.Count;j++){
												teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
											}
											citnow.inbattle=true;
											inbattle=true;
											citnow=null;
											dialog.SetActive (false);
											exit=true;
											break;
										} else {
											dialnum=11;
										}
									} else {
										dialnum=10;
									}
								} else 
								if(razdel[i]=="destroy"){
									if(razdel[i+1]=="1"){
										if(citnow.uns.Count!=0)
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										Destroy (citnow.gameObject);
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else{
										Destroy (citnow.gameObject);
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									}
								} else if(razdel[i]=="zachvat"){
									citnow.race=11;
								} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
									for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
										int yur=rnd.Next (2);
										if(yur==1){
											int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
											resource[citnow.mainhouse.resin[j1]]+=yur1;
											citnow.mainhouse.resincol[j1]-=yur1;
												}}
									}
									for(int j1=0;j1<citnow.unitsin.Count;j1++){
										int yur=rnd.Next (5);
										if(yur==1){
											teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
											h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
											h.transform.position=citnow.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
											h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
											h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
											teams[chosedteam].inst.Add (h);
											teams[chosedteam].now+=0.1f;
											i+=1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
								} else if(razdel[i]=="colony"){
									
								} else if(razdel[i]=="nalog"){
									int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
									resource[citnow.resdob]+=g;
									citnow.resdobready-=g;
								} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
								} else if(razdel[i]=="addan"){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									i+=2;
								} else if(razdel[i]=="pos"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									}
									i+=2;
								}  else if(razdel[i]=="poswout"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									i+=2;
								} else if(razdel[i]=="zachvatall"){
									for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
										main._m.races[citnow.race].com.cities[j1].race=11;
									}
									Destroy (main._m.races[citnow.race].com);
									citnow.race=11;
								}
								
							}
								razdel.Clear ();
							} else exit=true;
						}}
					else if(citnow.l[dialnum].d3!=-1){
						lastdialnum=dialnum; dialnum=citnow.l[dialnum].d3; 
				}else {
						if(citnow.l[dialnum].act3!="none"){
							razdel.Add ("");
							for (int i=0;i<citnow.l[dialnum].act3.Length;i++){
								if(citnow.l[dialnum].act3[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[dialnum].act3[i];
							}
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
								i+=2;
							} else 
							if(razdel[i]=="add"){
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
								}
								i+=2;
							} else 
							if(razdel[i]=="del"){
								resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
								else{
									citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
									citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
								}
								i+=2;
							} else 
							if(razdel[i]=="exit"){
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else 
							if(razdel[i]=="otn"){
								races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
								i+=1;
							} else 
							if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
								int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
								citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
								teams[chosedteam].units.RemoveAt (o);
								Destroy(teams[chosedteam].inst[o]);
								teams[chosedteam].inst.RemoveAt (o);
								teams[chosedteam].now-=0.1f;
						i+=1;}
							} else 
							if(razdel[i]=="addunit"){
								if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
								}
								i+=1;
							}else 
							if(razdel[i]=="downdefence"){
								if(citnow.uns.Count>0){
									Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
									citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
								}
							} else 
							if(razdel[i]=="sdav"){
								if(citnow.race!=11){
									if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else {
										dialnum=11;
									}
								} else {
									dialnum=10;
								}
							} else 
							if(razdel[i]=="destroy"){
								if(razdel[i+1]=="1"){
									if(citnow.uns.Count!=0)
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									Destroy (citnow.gameObject);
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else{
									Destroy (citnow.gameObject);
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								}
							} else if(razdel[i]=="zachvat"){
								citnow.race=11;
							} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
								for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
									int yur=rnd.Next (2);
									if(yur==1){
										int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
										resource[citnow.mainhouse.resin[j1]]+=yur1;
										citnow.mainhouse.resincol[j1]-=yur1;
											}}
								}
								for(int j1=0;j1<citnow.unitsin.Count;j1++){
									int yur=rnd.Next (5);
									if(yur==1){
										teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
										h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										i+=1;
										citnow.unitsin.RemoveAt (j1);
									}
								}
							} else if(razdel[i]=="colony"){
								
							} else if(razdel[i]=="nalog"){
								int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
								resource[citnow.resdob]+=g;
								citnow.resdobready-=g;
							} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								i+=1;
							} else if(razdel[i]=="addan"){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								i+=2;
							} else if(razdel[i]=="pos"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								}
								i+=2;
							}  else if(razdel[i]=="poswout"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								i+=2;
							} else if(razdel[i]=="zachvatall"){
								for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
									main._m.races[citnow.race].com.cities[j1].race=11;
								}
								Destroy (main._m.races[citnow.race].com);
								citnow.race=11;
							}
							
						}
							razdel.Clear ();
						} else exit=true;
					}
					if(!exit){
						if(citnow.l[dialnum].usl1!=""){
							razdel.Add ("");
							for (int i=0;i<citnow.l[dialnum].usl1.Length;i++){
								if(citnow.l[dialnum].usl1[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl1[i];
							}
							bool bo=true;
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
									if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
									if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
								} else 
								if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
									if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
							}
							if (bo){
								ans1.text=citnow.l[dialnum].a1;
								canans[0]=true;
							}else{ ans1.text="";
								canans[0]=false;
							}
							razdel.Clear ();
						}else{
							ans1.text=citnow.l[dialnum].a1;
							canans[0]=true;
						}
						if(citnow.l[dialnum].usl2!=""){
							razdel.Add ("");
							for (int i=0;i<citnow.l[dialnum].usl2.Length;i++){
								if(citnow.l[dialnum].usl2[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl2[i];
							}
							bool bo=true;
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
									if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
									if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
								} else 
								if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
									if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
							}
							if (bo){
								ans2.text=citnow.l[dialnum].a2;
								canans[1]=true;
							}else{ ans2.text="";
								canans[1]=false;
							}
							razdel.Clear ();
						}else{
							ans2.text=citnow.l[dialnum].a2;
							canans[1]=true;
						}
						
						if(citnow.l[dialnum].usl3!=""){
							razdel.Add ("");
							for (int i=0;i<citnow.l[dialnum].usl3.Length;i++){
								if(citnow.l[dialnum].usl3[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl3[i];
							}
							bool bo=true;
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
									if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
									if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
								} else 
								if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
									if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
							}
							if (bo){
								ans3.text=citnow.l[dialnum].a3;
								canans[2]=true;
							}else{ ans3.text="";
								canans[2]=false;
							}
							razdel.Clear ();
						}else{
							ans3.text=citnow.l[dialnum].a3;
							canans[2]=true;
						}
						
						
						
						if(citnow.l[dialnum].usl4!=""){
							razdel.Add ("");
							for (int i=0;i<citnow.l[dialnum].usl4.Length;i++){
								if(citnow.l[dialnum].usl4[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl4[i];
							}
							bool bo=true;
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
									if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
										bo=false;
									i+=2;
								} else 
								if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
									if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
								} else 
								if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
									if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
										bo=false;
									i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
							}
							if (bo){
								ans4.text=citnow.l[dialnum].a4;
								canans[3]=true;
							} else{ ans4.text="";
								canans[3]=false;
							}
							razdel.Clear ();
						}else{
							ans4.text=citnow.l[dialnum].a4;
							canans[3]=true;
						}
					
					
					razdel.Add ("");
					if(lastdialnum==-1){
						if(num==0)
						for (int i=0;i<citnow.d.act1.Length;i++){
							if(citnow.d.act1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act1[i];
						}
						else if(num==1)
						for (int i=0;i<citnow.d.act2.Length;i++){
							if(citnow.d.act2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act2[i];
						}
						else if(num==2)
						for (int i=0;i<citnow.d.act3.Length;i++){
							if(citnow.d.act3[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act3[i];
						}
						else
						for (int i=0;i<citnow.d.act4.Length;i++){
							if(citnow.d.act4[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act4[i];
						}
					}else
					if(num==0)
					for (int i=0;i<citnow.l[lastdialnum].act1.Length;i++){
						if(citnow.l[lastdialnum].act1[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act1[i];
					}
					else if(num==1)
					for (int i=0;i<citnow.l[lastdialnum].act2.Length;i++){
						if(citnow.l[lastdialnum].act2[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act2[i];
					}
					else if(num==2)
					for (int i=0;i<citnow.l[lastdialnum].act3.Length;i++){
						if(citnow.l[lastdialnum].act3[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act3[i];
					}
					else
					for (int i=0;i<citnow.l[lastdialnum].act4.Length;i++){
						if(citnow.l[lastdialnum].act4[i]==' '){
							razdel.Add ("");
						}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act4[i];
					}

					for (int i=0;i<razdel.Count;i++){
						if(razdel[i]=="quest"){
							quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
							i+=2;
						} else 
						if(razdel[i]=="add"){
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
							}
							i+=2;
						} else 
						if(razdel[i]=="del"){
							resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
							if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
								citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
							else{
								citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
								citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
							}
							i+=2;
						} else 
						if(razdel[i]=="exit"){
							citnow=null;
							dialog.SetActive (false);
							exit=true;
							break;
						} else 
						if(razdel[i]=="otn"){
							races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
							i+=1;
						} else 
						if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
							int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
							citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
							teams[chosedteam].units.RemoveAt (o);
							Destroy(teams[chosedteam].inst[o]);
							teams[chosedteam].inst.RemoveAt (o);
							teams[chosedteam].now-=0.1f;
				i+=1;}
						} else 
						if(razdel[i]=="addunit"){
							if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
							}
							i+=1;
						}else 
						if(razdel[i]=="downdefence"){
							if(citnow.uns.Count>0){
								Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
								citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
							}
						} else 
						if(razdel[i]=="sdav"){
							if(citnow.race!=11){
								if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else {
									dialnum=11;
								}
							} else {
								dialnum=10;
							}
						} else 
						if(razdel[i]=="destroy"){
							if(razdel[i+1]=="1"){
								if(citnow.uns.Count!=0)
								for (int j=0;j<citnow.uns.Count;j++){
									citnow.uns[j].SetActive (true);
								}
								teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
								}
								citnow.inbattle=true;
								Destroy (citnow.gameObject);
								inbattle=true;
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else{
								Destroy (citnow.gameObject);
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							}
						} else if(razdel[i]=="zachvat"){
							citnow.race=11;
						} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
							for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
								int yur=rnd.Next (2);
								if(yur==1){
									int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
									resource[citnow.mainhouse.resin[j1]]+=yur1;
									citnow.mainhouse.resincol[j1]-=yur1;
										}}
							}
							for(int j1=0;j1<citnow.unitsin.Count;j1++){
								int yur=rnd.Next (5);
								if(yur==1){
									teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
									h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
									citnow.unitsin.RemoveAt (j1);
								}
							}
						} else if(razdel[i]=="colony"){
							
						} else if(razdel[i]=="nalog"){
							int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
							resource[citnow.resdob]+=g;
							citnow.resdobready-=g;
						} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
							teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
							h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
							h.transform.position=citnow.gameObject.transform.position;
							h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
							h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
							h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
							teams[chosedteam].inst.Add (h);
							teams[chosedteam].now+=0.1f;
							i+=1;
						} else if(razdel[i]=="addan"){
							resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
							i+=2;
						} else if(razdel[i]=="pos"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							for (int j=0;j<teams[chosedteam].units.Count;j++){
								teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							}
							i+=2;
						}  else if(razdel[i]=="poswout"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							i+=2;
						} else if(razdel[i]=="zachvatall"){
							for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
								main._m.races[citnow.race].com.cities[j1].race=11;
							}
							Destroy (main._m.races[citnow.race].com);
							citnow.race=11;
						}
						
					}
					if(!exit){
						razdel.Clear ();
						talk.text=citnow.l[dialnum].txt;
						talker.sprite=citnow.l[dialnum].talker;
						
						cityim.sprite=citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite;
					}}
					
					
					
					
					
					
			}
			if(num==3){//num3
						
						
						
						
						
						
						
						
						
						if(dialnum==-1){
							if(citnow.d.d4!=-1){
								dialnum=citnow.d.d4;
						lastdialnum=-1;
					}else {
								if(citnow.d.act4!="none"){
									razdel.Add ("");
									for (int i=0;i<citnow.d.act4.Length;i++){
										if(citnow.d.act4[i]==' '){
											razdel.Add ("");
										}else razdel[razdel.Count-1]+=citnow.d.act4[i];
									}
							for (int i=0;i<razdel.Count;i++){
								if(razdel[i]=="quest"){
									quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
									i+=2;
								} else 
								if(razdel[i]=="add"){
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
										resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
									}
									i+=2;
								} else 
								if(razdel[i]=="del"){
									resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
									if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
										citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
									else{
										citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
										citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
									}
									i+=2;
								} else 
								if(razdel[i]=="exit"){
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else 
								if(razdel[i]=="otn"){
									races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
									i+=1;
								} else 
								if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
									int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
									citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
									teams[chosedteam].units.RemoveAt (o);
									Destroy(teams[chosedteam].inst[o]);
									teams[chosedteam].inst.RemoveAt (o);
									teams[chosedteam].now-=0.1f;
						i+=1;}
								} else 
								if(razdel[i]=="addunit"){
									if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
										teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
										h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
									}
									i+=1;
								}else 
								if(razdel[i]=="downdefence"){
									if(citnow.uns.Count>0){
										Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
										citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
									}
								} else 
								if(razdel[i]=="sdav"){
									if(citnow.race!=11){
										if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
											for (int j=0;j<citnow.uns.Count;j++){
												citnow.uns[j].SetActive (true);
											}
											teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
											for (int j=0;j<teams[chosedteam].units.Count;j++){
												teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
											}
											citnow.inbattle=true;
											inbattle=true;
											citnow=null;
											dialog.SetActive (false);
											exit=true;
											break;
										} else {
											dialnum=11;
										}
									} else {
										dialnum=10;
									}
								} else 
								if(razdel[i]=="destroy"){
									if(razdel[i+1]=="1"){
										if(citnow.uns.Count!=0)
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										Destroy (citnow.gameObject);
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else{
										Destroy (citnow.gameObject);
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									}
								} else if(razdel[i]=="zachvat"){
									citnow.race=11;
								} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
									for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
										int yur=rnd.Next (2);
										if(yur==1){
											int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
											resource[citnow.mainhouse.resin[j1]]+=yur1;
											citnow.mainhouse.resincol[j1]-=yur1;
												}}
									}
									for(int j1=0;j1<citnow.unitsin.Count;j1++){
										int yur=rnd.Next (5);
										if(yur==1){
											teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
											h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
											h.transform.position=citnow.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
											h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
											h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
											teams[chosedteam].inst.Add (h);
											teams[chosedteam].now+=0.1f;
											i+=1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
								} else if(razdel[i]=="colony"){
									
								} else if(razdel[i]=="nalog"){
									int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
									resource[citnow.resdob]+=g;
									citnow.resdobready-=g;
								} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									i+=1;
								} else if(razdel[i]=="addan"){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									i+=2;
								} else if(razdel[i]=="pos"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									}
									i+=2;
								}  else if(razdel[i]=="poswout"){
									teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
									i+=2;
								} else if(razdel[i]=="zachvatall"){
									for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
										main._m.races[citnow.race].com.cities[j1].race=11;
									}
									Destroy (main._m.races[citnow.race].com);
									citnow.race=11;
								}
								
							}
									razdel.Clear ();
								} else exit=true;
							}}
						else if(citnow.l[dialnum].d4!=-1){
							lastdialnum=dialnum; dialnum=citnow.l[dialnum].d4; 
				}	else {
							if(citnow.l[dialnum].act4!="none"){
								razdel.Add ("");
								for (int i=0;i<citnow.l[dialnum].act4.Length;i++){
									if(citnow.l[dialnum].act4[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.l[dialnum].act4[i];
								}
						for (int i=0;i<razdel.Count;i++){
							if(razdel[i]=="quest"){
								quests[int.Parse (razdel[i+1])]=int.Parse (razdel[i+2]);
								i+=2;
							} else 
							if(razdel[i]=="add"){
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])) && citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]>=int.Parse (razdel[i+2])){
									resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]-=int.Parse (razdel[i+2]);
								}
								i+=2;
							} else 
							if(razdel[i]=="del"){
								resource[int.Parse (razdel[i+1])]-=int.Parse (razdel[i+2]);
								if(citnow.mainhouse.resin.Contains (int.Parse (razdel[i+1])))
									citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf (int.Parse (razdel[i+1]))]+=int.Parse (razdel[i+2]);
								else{
									citnow.mainhouse.resin.Add (int.Parse (razdel[i+1]));
									citnow.mainhouse.resincol.Add (int.Parse (razdel[i+2]));
								}
								i+=2;
							} else 
							if(razdel[i]=="exit"){
								citnow=null;
								dialog.SetActive (false);
								exit=true;
								break;
							} else 
							if(razdel[i]=="otn"){
								races[citnow.race].otnosh+=int.Parse (razdel[i+1]);
								i+=1;
							} else 
							if(razdel[i]=="delunit"){if(teams[chosedteam].units.Contains (int.Parse (razdel[i+1]))){
								int o = teams[chosedteam].units.IndexOf(int.Parse (razdel[i+1]));
								citnow.mainhouse.unitsin.Add (int.Parse (razdel[i+1]));
								teams[chosedteam].units.RemoveAt (o);
								Destroy(teams[chosedteam].inst[o]);
								teams[chosedteam].inst.RemoveAt (o);
								teams[chosedteam].now-=0.1f;
				i+=1;}
							} else 
							if(razdel[i]=="addunit"){
								if(citnow.mainhouse.unitsin.Contains (int.Parse (razdel[i+1]))){
									teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
									h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
									h.transform.position=citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
									h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
									h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
									teams[chosedteam].inst.Add (h);
									teams[chosedteam].now+=0.1f;
									citnow.mainhouse.unitsin.RemoveAt(citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel[i+1])));
								}
								i+=1;
							}else 
							if(razdel[i]=="downdefence"){
								if(citnow.uns.Count>0){
									Destroy (citnow.mainhouse.uns[citnow.uns.Count-1]);
									citnow.mainhouse.uns.RemoveAt (citnow.uns.Count-1); Destroy (citnow.mainhouse.unsotkat[citnow.uns.Count-1]); citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count-1);
								}
							} else 
							if(razdel[i]=="sdav"){
								if(citnow.race!=11){
									if(((int)citnow.uns.Count*1.5f)>=teams[chosedteam].units.Count+1){
										for (int j=0;j<citnow.uns.Count;j++){
											citnow.uns[j].SetActive (true);
										}
										teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
										for (int j=0;j<teams[chosedteam].units.Count;j++){
											teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
										}
										citnow.inbattle=true;
										inbattle=true;
										citnow=null;
										dialog.SetActive (false);
										exit=true;
										break;
									} else {
										dialnum=11;
									}
								} else {
									dialnum=10;
								}
							} else 
							if(razdel[i]=="destroy"){
								if(razdel[i+1]=="1"){
									if(citnow.uns.Count!=0)
									for (int j=0;j<citnow.uns.Count;j++){
										citnow.uns[j].SetActive (true);
									}
									teams[chosedteam].comgo.transform.position=citnow.sppos.transform.position;
									for (int j=0;j<teams[chosedteam].units.Count;j++){
										teams[chosedteam].inst[j].transform.position=citnow.sppos.transform.position;
									}
									citnow.inbattle=true;
									Destroy (citnow.gameObject);
									inbattle=true;
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								} else{
									Destroy (citnow.gameObject);
									citnow=null;
									dialog.SetActive (false);
									exit=true;
									break;
								}
							} else if(razdel[i]=="zachvat"){
								citnow.race=11;
							} else if(razdel[i]=="dobycha"){if(!citnow.grabbed){
								for(int j1=0;j1<citnow.mainhouse.resin.Count;j1++){
									int yur=rnd.Next (2);
									if(yur==1){
										int yur1=rnd.Next (citnow.mainhouse.resincol[j1]);
										resource[citnow.mainhouse.resin[j1]]+=yur1;
										citnow.mainhouse.resincol[j1]-=yur1;
											}}
								}
								for(int j1=0;j1<citnow.unitsin.Count;j1++){
									int yur=rnd.Next (5);
									if(yur==1){
										teams[chosedteam].units.Add (citnow.unitsin[j1]); teams[chosedteam].unitshp.Add (units[citnow.unitsin[j1]-1].hp);
										h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
										h.transform.position=citnow.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[citnow.unitsin[j1]-1].sp;
										h.GetComponent<uniter>().fly=units[citnow.unitsin[j1]-1].fly;
										h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=citnow.unitsin[j1];
										teams[chosedteam].inst.Add (h);
										teams[chosedteam].now+=0.1f;
										i+=1;
										citnow.unitsin.RemoveAt (j1);
									}
								}
							} else if(razdel[i]=="colony"){
								
							} else if(razdel[i]=="nalog"){
								int g=rnd.Next (citnow.resdobready/2)+citnow.resdobready/2;
								resource[citnow.resdob]+=g;
								citnow.resdobready-=g;
							} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
								teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
								h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
								h.transform.position=citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
								h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
								h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
								teams[chosedteam].inst.Add (h);
								teams[chosedteam].now+=0.1f;
								i+=1;
							} else if(razdel[i]=="addan"){
								resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
								i+=2;
							} else if(razdel[i]=="pos"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								for (int j=0;j<teams[chosedteam].units.Count;j++){
									teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								}
								i+=2;
							}  else if(razdel[i]=="poswout"){
								teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
								i+=2;
							} else if(razdel[i]=="zachvatall"){
								for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
									main._m.races[citnow.race].com.cities[j1].race=11;
								}
								Destroy (main._m.races[citnow.race].com);
								citnow.race=11;
							}
							
						}
								razdel.Clear ();
							} else exit=true;
						}
						if(!exit){
							if(citnow.l[dialnum].usl1!=""){
								razdel.Add ("");
								for (int i=0;i<citnow.l[dialnum].usl1.Length;i++){
									if(citnow.l[dialnum].usl1[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl1[i];
								}
								bool bo=true;
								for (int i=0;i<razdel.Count;i++){
									if(razdel[i]=="quest"){
										if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
										if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
										if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
									} else 
									if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
										if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
								}
								if (bo){
									ans1.text=citnow.l[dialnum].a1;
									canans[0]=true;
								}else{ ans1.text="";
									canans[0]=false;
								}
								razdel.Clear ();
							}else{
								ans1.text=citnow.l[dialnum].a1;
								canans[0]=true;
							}
							if(citnow.l[dialnum].usl2!=""){
								razdel.Add ("");
								for (int i=0;i<citnow.l[dialnum].usl2.Length;i++){
									if(citnow.l[dialnum].usl2[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl2[i];
								}
								bool bo=true;
								for (int i=0;i<razdel.Count;i++){
									if(razdel[i]=="quest"){
										if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
										if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
										if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
									} else 
									if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
										if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
								}
								if (bo){
									ans2.text=citnow.l[dialnum].a2;
									canans[1]=true;
								}else{ ans2.text="";
									canans[1]=false;
								}
								razdel.Clear ();
							}else{
								ans2.text=citnow.l[dialnum].a2;
								canans[1]=true;
							}
							
							if(citnow.l[dialnum].usl3!=""){
								razdel.Add ("");
								for (int i=0;i<citnow.l[dialnum].usl3.Length;i++){
									if(citnow.l[dialnum].usl3[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl3[i];
								}
								bool bo=true;
								for (int i=0;i<razdel.Count;i++){
									if(razdel[i]=="quest"){
										if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
										if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
									if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
										if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
									} else 
									if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
										if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
								}
								if (bo){
									ans3.text=citnow.l[dialnum].a3;
									canans[2]=true;
								}else{ ans3.text="";
									canans[2]=false;
								}
								razdel.Clear ();
							}else{
								ans3.text=citnow.l[dialnum].a3;
								canans[2]=true;
							}
							
							
							
							if(citnow.l[dialnum].usl4!=""){
								razdel.Add ("");
								for (int i=0;i<citnow.l[dialnum].usl4.Length;i++){
									if(citnow.l[dialnum].usl4[i]==' '){
										razdel.Add ("");
									}else razdel[razdel.Count-1]+=citnow.l[dialnum].usl4[i];
								}
								bool bo=true;
								for (int i=0;i<razdel.Count;i++){
									if(razdel[i]=="quest"){
										if (quests[int.Parse (razdel[i+1])]!=int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else
							if(razdel[i]=="otn"){if(races[citnow.race].otnosh<int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="item"){
										if (resource[int.Parse (razdel[i+1])]<int.Parse (razdel[i+2]))
											bo=false;
										i+=2;
									} else 
							if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="race"){if(citnow.race!=int.Parse (razdel[i+1])) bo=false; i+=1; } else if(razdel[i]=="you"){
										if (teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
									} else 
									if(razdel[i]=="otn-"){if(races[citnow.race].otnosh>=int.Parse (razdel[i+1])) bo=false; i+=1;} else if(razdel[i]=="unit"){
										if (!teams[chosedteam].units.Contains(int.Parse (razdel[i+1])) && teams[chosedteam].mainunit!=int.Parse (razdel[i+1]))
											bo=false;
										i+=1;
							} else if(razdel[i]=="unit-"){if (teams[chosedteam].units.Contains(int.Parse (razdel[i+1]))||teams[chosedteam].mainunit==int.Parse (razdel[i+1]))bo=false;i+=1;} else if(razdel[i]=="unitin"){
								if (!citnow.mainhouse.unitsin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								i+=1;
							} else if(razdel[i]=="itemin"){
								if (!citnow.mainhouse.resin.Contains(int.Parse (razdel[i+1])))
									bo=false;
								else if (citnow.mainhouse.resincol[citnow.mainhouse.resin.IndexOf(int.Parse (razdel[i+1]))]<int.Parse (razdel[i+2]))
									bo=false;
								i+=2;
							} else if(razdel[i]=="your"){
								if (citnow.race!=11)
									bo=false;
							} else if(razdel[i]=="notyour"){
								if (citnow.race==11)
									bo=false;
							}
								}
								if (bo){
									ans4.text=citnow.l[dialnum].a4;
									canans[3]=true;
								} else{ ans4.text="";
									canans[3]=false;
								}
								razdel.Clear ();
							}else{
								ans4.text=citnow.l[dialnum].a4;
								canans[3]=true;
					}


							
							razdel.Add ("");
					if(lastdialnum==-1){
						if(num==0)
						for (int i=0;i<citnow.d.act1.Length;i++){
							if(citnow.d.act1[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act1[i];
						}
						else if(num==1)
						for (int i=0;i<citnow.d.act2.Length;i++){
							if(citnow.d.act2[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act2[i];
						}
						else if(num==2)
						for (int i=0;i<citnow.d.act3.Length;i++){
							if(citnow.d.act3[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act3[i];
						}
						else
						for (int i=0;i<citnow.d.act4.Length;i++){
							if(citnow.d.act4[i]==' '){
								razdel.Add ("");
							}else razdel[razdel.Count-1]+=citnow.d.act4[i];
						}
					}else
							if(num==0)
							for (int i=0;i<citnow.l[lastdialnum].act1.Length;i++){
								if(citnow.l[lastdialnum].act1[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act1[i];
							}
							else if(num==1)
							for (int i=0;i<citnow.l[lastdialnum].act2.Length;i++){
								if(citnow.l[lastdialnum].act2[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act2[i];
							}
							else if(num==2)
							for (int i=0;i<citnow.l[lastdialnum].act3.Length;i++){
								if(citnow.l[lastdialnum].act3[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act3[i];
							}
							else
							for (int i=0;i<citnow.l[lastdialnum].act4.Length;i++){
								if(citnow.l[lastdialnum].act4[i]==' '){
									razdel.Add ("");
								}else razdel[razdel.Count-1]+=citnow.l[lastdialnum].act4[i];
							}
							
							for (int i=0;i<razdel.Count;i++){
						if (razdel [i] == "quest") {
							quests [int.Parse (razdel [i + 1])] = int.Parse (razdel [i + 2]);
							i += 2;
						} else if (razdel [i] == "add") {
							if (citnow.mainhouse.resin.Contains (int.Parse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (int.Parse (razdel [i + 1]))] >= int.Parse (razdel [i + 2])) {
								resource [int.Parse (razdel [i + 1])] += int.Parse (razdel [i + 2]);
								citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (int.Parse (razdel [i + 1]))] -= int.Parse (razdel [i + 2]);
							}
							i += 2;
						} else if (razdel [i] == "del") {
							resource [int.Parse (razdel [i + 1])] -= int.Parse (razdel [i + 2]);
							if (citnow.mainhouse.resin.Contains (int.Parse (razdel [i + 1])))
								citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (int.Parse (razdel [i + 1]))] += int.Parse (razdel [i + 2]);
							else {
								citnow.mainhouse.resin.Add (int.Parse (razdel [i + 1]));
								citnow.mainhouse.resincol.Add (int.Parse (razdel [i + 2]));
							}
							i += 2;
						} else if (razdel [i] == "exit") {
							citnow = null;
							dialog.SetActive (false);
							exit = true;
							break;
						} else if (razdel [i] == "otn") {
							races [citnow.race].otnosh += int.Parse (razdel [i + 1]);
							i += 1;
						} else if (razdel [i] == "delunit") {
							if (teams [chosedteam].units.Contains (int.Parse (razdel [i + 1]))) {
								int o = teams [chosedteam].units.IndexOf (int.Parse (razdel [i + 1]));
								citnow.mainhouse.unitsin.Add (int.Parse (razdel [i + 1]));
								teams [chosedteam].units.RemoveAt (o);
								Destroy (teams [chosedteam].inst [o]);
								teams [chosedteam].inst.RemoveAt (o);
								teams [chosedteam].now -= 0.1f;
								i += 1;
							}
						} else if (razdel [i] == "addunit") {
							if (citnow.mainhouse.unitsin.Contains (int.Parse (razdel [i + 1]))) {
								teams [chosedteam].units.Add (int.Parse (razdel [i + 1]));
								teams [chosedteam].unitshp.Add (units [int.Parse (razdel [i + 1]) - 1].hp);
								h = Instantiate (unitpref);
								h.GetComponent<uniter> ().race = 11;
								h.transform.position = citnow.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [int.Parse (razdel [i + 1]) - 1].sp;
								h.GetComponent<uniter> ().fly = units [int.Parse (razdel [i + 1]) - 1].fly;
								h.GetComponent<uniter> ().m = chosedteam;
								h.GetComponent<uniter> ().num = int.Parse (razdel [i + 1]);
								teams [chosedteam].inst.Add (h);
								teams [chosedteam].now += 0.1f;
								citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (int.Parse (razdel [i + 1])));
							}
							i += 1;
						} else if (razdel [i] == "downdefence") {
							if (citnow.uns.Count > 0) {
								Destroy (citnow.mainhouse.uns [citnow.uns.Count - 1]);
								citnow.mainhouse.uns.RemoveAt (citnow.uns.Count - 1);
								Destroy (citnow.mainhouse.unsotkat [citnow.uns.Count - 1]);
								citnow.mainhouse.unsotkat.RemoveAt (citnow.uns.Count - 1);
							}
						} else if (razdel [i] == "sdav") {
							if (citnow.race != 11) {
								if (((int)citnow.uns.Count * 1.5f) >= teams [chosedteam].units.Count + 1) {
									for (int j = 0; j < citnow.uns.Count; j++) {
										citnow.uns [j].SetActive (true);
									}
									teams [chosedteam].comgo.transform.position = citnow.sppos.transform.position;
									for (int j = 0; j < teams [chosedteam].units.Count; j++) {
										teams [chosedteam].inst [j].transform.position = citnow.sppos.transform.position;
									}
									citnow.inbattle = true;
									inbattle = true;
									citnow = null;
									dialog.SetActive (false);
									exit = true;
									break;
								} else {
									dialnum = 11;
								}
							} else {
								dialnum = 10;
							}
						} else if (razdel [i] == "destroy") {
							if (razdel [i + 1] == "1") {
								if (citnow.uns.Count != 0)
									for (int j = 0; j < citnow.uns.Count; j++) {
										citnow.uns [j].SetActive (true);
									}
								teams [chosedteam].comgo.transform.position = citnow.sppos.transform.position;
								for (int j = 0; j < teams [chosedteam].units.Count; j++) {
									teams [chosedteam].inst [j].transform.position = citnow.sppos.transform.position;
								}
								citnow.inbattle = true;
								Destroy (citnow.gameObject);
								inbattle = true;
								citnow = null;
								dialog.SetActive (false);
								exit = true;
								break;
							} else {
								Destroy (citnow.gameObject);
								citnow = null;
								dialog.SetActive (false);
								exit = true;
								break;
							}
						} else if (razdel [i] == "zachvat") {
							citnow.race = 11;
						} else if (razdel [i] == "dobycha") {
							if (!citnow.grabbed) {
								for (int j1 = 0; j1 < citnow.mainhouse.resin.Count; j1++) {
									int yur = rnd.Next (2);
									if (yur == 1) {
										int yur1 = rnd.Next (citnow.mainhouse.resincol [j1]);
										resource [citnow.mainhouse.resin [j1]] += yur1;
										citnow.mainhouse.resincol [j1] -= yur1;
									}
								}
							}
							for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
								int yur = rnd.Next (5);
								if (yur == 1) {
									teams [chosedteam].units.Add (citnow.unitsin [j1]);
									teams [chosedteam].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
									h = Instantiate (unitpref);
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
									h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = citnow.unitsin [j1];
									teams [chosedteam].inst.Add (h);
									teams [chosedteam].now += 0.1f;
									i += 1;
									citnow.unitsin.RemoveAt (j1);
								}
							}
						} else if (razdel [i] == "colony") {
							
						} else if (razdel [i] == "nalog") {
							int g = rnd.Next (citnow.resdobready / 2) + citnow.resdobready / 2;
							resource [citnow.resdob] += g;
							citnow.resdobready -= g;
						} else if (razdel [i] == "openwiki") {wiki [int.Parse (razdel [i + 1])].open = true;i += 1; } else if(razdel[i]=="addunitan"){
							teams[chosedteam].units.Add (int.Parse (razdel[i+1])); teams[chosedteam].unitshp.Add (units[int.Parse (razdel[i+1])-1].hp);
							h=Instantiate(unitpref); h.GetComponent<uniter>().race=11;
							h.transform.position=citnow.gameObject.transform.position;
							h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite=units[int.Parse (razdel[i+1])-1].sp;
							h.GetComponent<uniter>().fly=units[int.Parse (razdel[i+1])-1].fly;
							h.GetComponent<uniter>().m=chosedteam; h.GetComponent<uniter>().num=int.Parse(razdel[i+1]);
							teams[chosedteam].inst.Add (h);
							teams[chosedteam].now+=0.1f;
							i+=1;
						} else if(razdel[i]=="addan"){
							resource[int.Parse (razdel[i+1])]+=int.Parse (razdel[i+2]);
							i+=2;
						} else if(razdel[i]=="pos"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							for (int j=0;j<teams[chosedteam].units.Count;j++){
								teams[chosedteam].inst[j].transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							}
							i+=2;
						}  else if(razdel[i]=="poswout"){
							teams[chosedteam].comgo.transform.position=new Vector3(float.Parse (razdel[i+1]),float.Parse (razdel[i+2]),0);
							i+=2;
						} else if(razdel[i]=="zachvatall"){
							for(int j1=0;j1<main._m.races[citnow.race].com.cities.Count;j1++){
								main._m.races[citnow.race].com.cities[j1].race=11;
							}
							Destroy (main._m.races[citnow.race].com);
							citnow.race=11;
						}
							
						}
							if(!exit){
							razdel.Clear ();





							talk.text=citnow.l[dialnum].txt;
							talker.sprite=citnow.l[dialnum].talker;
							
							cityim.sprite=citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>().sprite;

					}}}
				


			if(teams [chosedteam].units.Count > 0)
				u1.sprite=units[teams[chosedteam].units[(sdvig)%(teams [chosedteam].units.Count)]-1].sp;
			else u1.sprite = nulsp;
			if (teams [chosedteam].units.Count > 1)
				u2.sprite = units [teams [chosedteam].units [(sdvig + 1) % (teams [chosedteam].units.Count)] - 1].sp;
			else
				u2.sprite = nulsp;
			if (teams [chosedteam].units.Count > 2)
				u3.sprite=units[teams[chosedteam].units[(sdvig+2)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u3.sprite = nulsp;
			if (teams [chosedteam].units.Count > 3)
				u4.sprite=units[teams[chosedteam].units[(sdvig+3)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u4.sprite = nulsp;
			if (teams [chosedteam].units.Count > 4)
				u5.sprite=units[teams[chosedteam].units[(sdvig+4)%(teams [chosedteam].units.Count)]-1].sp;
			else
				u5.sprite = nulsp;



		}
	}
	public void wikiopen(){
		wikigo.SetActive (true);
		wikinext (0);
		iswikiopen = true;
	}
	public void wikiclose(){
		wikigo.SetActive (false);
		iswikiopen = false;
	}
	public void wikinext(int sdf){
		chosedwiki [0] = -1;
		chosedwiki [1] = -1;
		chosedwiki [2] = -1;
		chosedwiki [3] = -1;
		chosedwiki [4] = -1;
		List<int> yh=new List<int>();
		if (wikiname == "unit")
			yh=unitswiki;
		else if (wikiname == "universe")
			yh=universewiki;
		else if (wikiname == "res")yh=reswiki;
		else if (wikiname == "race")yh=racewiki;
		else if (wikiname == "city")yh=citywiki;
		else if (wikiname == "logic")yh=logicwiki;
		wikisdvig = (wikisdvig + sdf) % yh.Count;

			bool found = false;

			for (int i = wikisdvig; i < yh.Count; i++) {
				if (wiki [yh [i]].open) {
					wiki1.GetComponent<Text>().text = wiki [yh [i]].heading;
					chosedwiki [0] = yh[i];
					found = true;
					break;
				}
			}
			if (!found && wikisdvig!=0) {
				for (int i = 0; i < wikisdvig; i++) {
					if (wiki [yh [i]].open) {
						wiki1.GetComponent<Text>().text = wiki [yh [i]].heading;
						chosedwiki [0] = yh[i];
						found = true;
						break;
					}
				}
			}
			if (found) {

				found = false;
				for (int i = wikisdvig; i < yh.Count; i++) {
					if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
						wiki2.GetComponent<Text>().text = wiki [yh [i]].heading;
						chosedwiki [1] = yh[i];
						found = true;
						break;
					}
				}
				if (!found && wikisdvig!=0) {
					for (int i = 0; i < wikisdvig; i++) {
						if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
							wiki2.GetComponent<Text>().text = wiki [yh [i]].heading;
							chosedwiki [1] = yh[i];
							found = true;
							break;
						}
					}
				}
				if (found) {

					found = false;

					for (int i = wikisdvig; i < yh.Count; i++) {
						if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
							wiki3.GetComponent<Text>().text = wiki [yh [i]].heading;
							chosedwiki [2] = yh[i];
							found = true;
							break;
						}
					}
					if (!found && wikisdvig!=0) {
						for (int i = 0; i < wikisdvig; i++) {
							if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
								wiki3.GetComponent<Text>().text = wiki [yh [i]].heading;
								chosedwiki [2] = yh[i];
								found = true;
								break;
							}
						}
					}
					if (found) {

						found = false;

						for (int i = wikisdvig; i < yh.Count; i++) {
							if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
								wiki4.GetComponent<Text>().text = wiki [yh [i]].heading;
								chosedwiki [3] = yh[i];
								found = true;
								break;
							}
						}
						if (!found && wikisdvig!=0) {
							for (int i = 0; i < wikisdvig; i++) {
								if (wiki [yh [i]].open && !chosedwiki.Contains(yh[i])) {
									wiki4.GetComponent<Text>().text = wiki [yh [i]].heading;
									chosedwiki [3] = yh[i];
									found = true;
									break;
								}
							}
						}
						if (found) {

							found = false;

							for (int i = wikisdvig; i < yh.Count; i++) {
								if (wiki [yh [i]].open && !chosedwiki.Contains (i)) {
									wiki5.GetComponent<Text> ().text = wiki [yh [i]].heading;
									chosedwiki [4] = yh[i];
									found = true;
									break;
								}
							}
							if (!found && wikisdvig != 0) {
								for (int i = 0; i < wikisdvig; i++) {
									if (wiki [yh [i]].open && !chosedwiki.Contains (i)) {
										wiki5.GetComponent<Text> ().text = wiki [yh [i]].heading;
										chosedwiki [4] = yh[i];
										found = true;
										break;
									}
								}
							}
							if (!found) {
								wiki5.GetComponent<Text> ().text = "";
							}
						} else {
							wiki5.GetComponent<Text> ().text = "";
							wiki4.GetComponent<Text> ().text = "";
						}
					} else {
						wiki5.GetComponent<Text> ().text = "";
						wiki4.GetComponent<Text> ().text = "";
						wiki3.GetComponent<Text> ().text = "";
					}
				} else {
					wiki5.GetComponent<Text> ().text = "";
					wiki4.GetComponent<Text> ().text = "";
					wiki3.GetComponent<Text> ().text = "";
					wiki2.GetComponent<Text> ().text = "";
				}

			} else {
				wiki5.GetComponent<Text> ().text = "";
				wiki4.GetComponent<Text> ().text = "";
				wiki3.GetComponent<Text> ().text = "";
				wiki2.GetComponent<Text> ().text = "";
				wiki1.GetComponent<Text> ().text = "";
			}

	}
	public void wikichoose(string wiki11){
		wikiname = wiki11;
		wikinext (0);
	}
	public void wikichooseitem(int num){
		wikihead.GetComponent<Text> ().text = wiki [chosedwiki [num]].heading;
		wikitxt.GetComponent<Text> ().text = wiki [chosedwiki [num]].txt;
		wikisp.GetComponent<Image> ().sprite = wiki [chosedwiki [num]].sp;
		if (wiki [chosedwiki [num]].type == "unit")
			wikitxt.GetComponent<Text> ().text += "\n\nУрон: " + units [wiki [chosedwiki [num]].num - 1].dmg + "\nЗдоровье: " + units [wiki [chosedwiki [num]].num - 1].hp;
		else if (wiki [chosedwiki [num]].type == "res")
			wikitxt.GetComponent<Text> ().text += "\n\nУ вас есть: " + resource [wiki [chosedwiki [num]].num];
	}

}