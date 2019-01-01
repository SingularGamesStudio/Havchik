using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class main : MonoBehaviour
{
	[System.Serializable]
	public class unit
	{
		public string name;
		public int hp;
		public int dmg;
		public Sprite sp;
		public Sprite at1;
		public Sprite at2;
		public Sprite at3;
		public bool fly = false;
		public AudioClip attack;
		public int wikipagenum;
		public int sk;
	}

	[System.Serializable]
	public class team
	{
		public float now;
		public string name;
		public int num;
		public int mainunit;
		public List<int> units;
		public List<int> unitshp;
		public List<Vector3> unsdvig;
		public List<GameObject> inst;
		public GameObject comgo;
		public int mainunithp;
		public bool casting;
		public float curtimeout;
		public float casttime;
		public int caster;
		public int castskillnum;
	}

	[System.Serializable]
	public class race
	{

		public string name;
		public int otnosh;
		public List<int> units;
		public Sprite flag;
		public racecommand com;
	}

	[System.Serializable]
	public class dial
	{
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
	public class wikipage
	{
		public string heading;
		public string type;
		[Multiline]public string txt;
		public Sprite sp;
		public int num;
		public bool open;
	}

	[System.Serializable]
	public class questtxt
	{
		public bool otslezh;
		public List<int> znach;
		public List<string> opis;
	}

	[System.Serializable]
	public class skill
	{
		public bool costunit;
		public bool costres;
		public int resc;
		public int resccol;
		public int unitc;
		public string deyst;
		public int spawnnum;
		public int col;
		public string name;
		public string opis;
		public float castlength;
	}
	public GameObject joy;
	public List<skill> allskills = new List<skill> ();
	public List<Sprite> skillssp = new List<Sprite> ();
	public List<int> skillshave = new List<int> ();
	public List<GameObject> allbuildings = new List<GameObject> ();
	public GameObject builder;
	public GameObject skillmenu;
	public GameObject skillbtn;
	public GameObject skillname;
	public GameObject skilltxt;
	public bool chosingtsel = false;
	public bool skilltsel = false;
	public List<int> waitfor = new List<int> ();
	public List<int> waitforteam = new List<int> ();
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
	public float curtimeout;
	public float curtimeout1;
	public Sprite nulsp;
	public float curtimeout3;
	public float curtimeout2;
	public int chosedteam;
	public int sdvig = 0;
	public float speed = 0.1f;
	public float combdist = 1;
	public GameObject unitpref;
	public GameObject compref;
	public bool creatingteam = false;
	public GameObject crtext;
	public List<int> newteamnums;
	public List<int> u11;
	public List<GameObject> i1;
	public List<int> quests = new List<int> ();
	public List<string> qnames = new List<string> ();
	public List<questtxt> questvis = new List<questtxt> ();
	public List<float> rescourse = new List<float> ();
	public List<string> resnames = new List<string> ();
	public List<int> resource = new List<int> ();
	public List<int> resourcewikipage = new List<int> ();
	public List<race> races = new List<race> ();
	public List<Sprite> ressp = new List<Sprite> ();
	public bool inbattle = false;
	public bool[,] crit = new bool[50, 50];
	//-1
	GameObject hh;
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
	public List<int> chosedwiki = new List<int> ();
	public List<int> universewiki = new List<int> ();
	public List<int> unitswiki = new List<int> ();
	public List<int> racewiki = new List<int> ();
	public List<int> reswiki = new List<int> ();
	public List<int> citywiki = new List<int> ();
	public List<int> logicwiki = new List<int> ();
	public List<wikipage> wiki = new List<wikipage> ();
	public List<string> razdel = new List<string> ();
	public int choosedskill;
	public GameObject dialog;
	public city citnow;
	public Text ans1;
	public Text ans2;
	public Text ans3;
	public Text ans4;
	public Text talk;
	public Image talker;
	public Image cityim;
	public int dialnum = -1;
	public int lastdialnum;
	public List<bool> canans = new List<bool> ();
	public bool youdest = false;
	public GameObject emp;
	public  float sootv;
	public bool gamecreated = false;
	public int soundlevel;
	public int musiclevel;
	public List<SpriteRenderer> soundlevelgo = new List<SpriteRenderer> ();
	public List<SpriteRenderer> musiclevelgo = new List<SpriteRenderer> ();
	public GameObject menu;
	public Sprite empsp;
	public GameObject canv;
	public GameObject games;
	public Text game1;
	public Text game2;
	public Text game3;
	public List<int> globalsob = new List<int> ();
	public List<string> globalsobnames = new List<string> ();
	public bool ingame;
	public int gameopennum;
	public List<city> allcities = new List<city> ();
	public List<GameObject> buildings = new List<GameObject> ();
	public List<Vector3> buildingsbuildedpos = new List<Vector3> ();
	public List<int> buildingsbuilded = new List<int> ();
	public GameObject obuchspawn;
	public GameObject ananasspawn;
	public GameObject sausagespawn;
	public AudioSource mainaud;
	public GameObject audgo;
	public AudioClip menumus;
	public AudioClip fonmus;
	public AudioClip battlemus;
	public AudioClip money;
	public AudioClip bthsound;
	public bool inbattle1;
	public GameObject qname;
	public GameObject qtxt;
	public int qnum;
	public Text skillpodsk;
	public int recschet;
	public bool dead = false;
	public float curtimeout4 = 0;
	public GameObject defer;
	public GameObject defall;
	public bool onuimouse;
	public int radugadrunk;
	public int orkdrunk;
	public GameObject arrow;
	public int tradestate=-1;
	public int tosell;
	public int tobuy;
	public int tobuycol;
	public int tosell1;
	public int tobuy1;
	public int tobuycol1;
	public int togive;
	public int togivecol;
	bool trd = false;
	public bool posunit = false;
	public int topos = 0;
	public GameObject makemainbtn;
	public bool dontpos;
	// Use this for initialization
	void Start ()
	{
		_m = this;
		if (ingame) {
			
			commander.sprite = units [teams [0].mainunit - 1].sp;
			if (teams [0].units.Count > 0)
				u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
			else
				u1.sprite = nulsp;
			if (teams [0].units.Count > 1)
				u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
			else
				u2.sprite = nulsp;
			if (teams [0].units.Count > 2)
				u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
			else
				u3.sprite = nulsp;
			if (teams [0].units.Count > 3)
				u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
			else
				u4.sprite = nulsp;
			if (teams [0].units.Count > 4)
				u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
			else
				u5.sprite = nulsp;
		}
		crit [21, 22] = true;
		crit [14, 4] = true;
		crit [9, 4] = true;
	}
	public void uienter(){
		//onuimouse = true;
	}
	public void uienter1(){
		onuimouse = true;
	}
	public void uiexit(){
		onuimouse = false;
	}
	// Update is called once per frame
	void Update ()
	{
		bool hjg = false;
		for (int i = 0; i < teams.Count; i++) {
			if (teams [0].casting) {
				teams [0].curtimeout += Time.deltaTime;

				if (i == chosedteam) {
					skillpodsk.gameObject.SetActive (true);
					skillpodsk.text = "До активации умения осталось " + ((int)(teams [0].casttime - teams [0].curtimeout)).ToString () + " ананасовых лет";
					hjg = true;
				}
				if (teams [0].curtimeout >= teams [0].casttime) {
					teams [0].casting = false;
					teams [0].curtimeout = 0;
					int p = teams [0].castskillnum;
					if (allskills [p].deyst == "build") {
						h = Instantiate (builder);
						if (teams [0].caster != -1)
							h.transform.position = teams [0].inst [teams [0].caster].transform.position;
						else
							h.transform.position = teams [0].comgo.transform.position;
						h.GetComponent<buildingbuild> ().spawn = allskills [p].spawnnum;
						h.GetComponent<buildingbuild> ().albuildtime = allskills [p].castlength;
					} else if (allskills [p].deyst == "res") {
						resource [allskills [p].spawnnum] += allskills [p].col;
					} else if (allskills [p].deyst == "drinkraduga") {
						radugadrunk += 1;
						if (radugadrunk >= 3) {
							radugadrunk = 0;
							if (teams [0].mainunit == 18) {
								teams [0].mainunit = 42;
								teams [0].mainunithp = units [41].hp;
								teams [0].comgo.GetComponent<mainunit> ().num = 42;
								teams [0].comgo.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [41].sp;
							} else if (teams [0].mainunit == 23) {
								teams [0].mainunit = 45;
								teams [0].mainunithp = units [44].hp;
								teams [0].comgo.GetComponent<mainunit> ().num = 45;
								teams [0].comgo.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [44].sp;
							} else {
								teams [0].mainunit = 41;
								teams [0].mainunithp = units [40].hp;
								teams [0].comgo.GetComponent<mainunit> ().num = 41;
								teams [0].comgo.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [40].sp;
							}
						}
					} else if (allskills [p].deyst == "drinkork") {
						orkdrunk += 1;
						if (orkdrunk >= 3) {
							orkdrunk = 0;
							diealc ();
						}
					}else if (allskills [p].deyst == "unit") {
						  teams [0].units.Add (allskills [p].spawnnum);
						teams [0].unitshp.Add (units [allskills [p].spawnnum - 1].hp);
						h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
						h.GetComponent<uniter> ().race = 11;
						if (teams [0].caster != -1)
							h.transform.position = teams [0].inst [teams [0].caster].transform.position;
						else
							h.transform.position = teams [0].comgo.transform.position;
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [allskills [p].spawnnum - 1].sp;
						h.GetComponent<uniter> ().fly = units [allskills [p].spawnnum - 1].fly;
						h.GetComponent<uniter> ().m = i;
						h.GetComponent<uniter> ().num = allskills [p].spawnnum;
						teams [0].inst.Add (h);
						teams [0].now += 0.1f;
					} else if (allskills [p].deyst == "striketsel" || allskills [p].deyst == "buildtsel" || allskills [p].deyst == "portal" || allskills [p].deyst == "sugarportal") {
						waitfor.Add (p);
						waitforteam.Add (i);
						if (skilltsel == false)
							skilltsel = true;
						if (chosingtsel == false)
							chosingtsel = true;
					}
				}
			}
		}
		if (!hjg) {
			skillpodsk.gameObject.SetActive (false);
			skillpodsk.text = "";
		}
		curtimeout += Time.deltaTime;
		curtimeout1 += Time.deltaTime;
		curtimeout2 += Time.deltaTime;
		curtimeout3 += Time.deltaTime;
		if (inbattle && !inbattle1) {
			musicplay (battlemus);
			inbattle1 = true;
		}
		if (!inbattle && inbattle1) {
			musicplay (fonmus);
			inbattle1 = false;
		}
		if (ingame) {
			if (chosingtsel) {
				skillpodsk.gameObject.SetActive (false);
				skillpodsk.text = "";
				if (Input.GetMouseButton (0)) {
					if (chosingtsel) {
						if (!skilltsel && !posunit) {
							chosingtsel = false;
							mc.fieldOfView = 50;
						} else if (skilltsel) {
							Ray MyRay;
							MyRay = mc.ScreenPointToRay (Input.mousePosition);
							h = Instantiate (emp);
							h.transform.position = new Vector3 (MyRay.origin.x, MyRay.origin.y, 0);
							h.transform.SetParent (mc.transform.parent);
							h.transform.localPosition *= sootv;
							h.transform.position = new Vector3 (h.transform.position.x, h.transform.position.y, 0);
							if (allskills [waitfor [0]].deyst == "buildtsel") {
								hh = Instantiate (builder);
								hh.transform.position = h.transform.position;
								hh.GetComponent<buildingbuild> ().spawn = allskills [waitfor [0]].spawnnum;
								hh.GetComponent<buildingbuild> ().albuildtime = allskills [waitfor [0]].castlength;
							} else if (allskills [waitfor [0]].deyst == "striketsel") {
								hh = Instantiate (allbuildings [allskills [waitfor [0]].spawnnum]);
								hh.transform.position = teams [0].comgo.transform.position;
								hh.transform.LookAt (h.transform.position, Vector3.back);
								hh.transform.rotation = new Quaternion (0, 0, hh.transform.rotation.z, hh.transform.rotation.w);
							} else if (allskills [waitfor [0]].deyst == "portal") {
								teams [0].comgo.transform.position = h.transform.position;
							} else if (allskills [waitfor [0]].deyst == "sugarportal") {
								teams [0].comgo.transform.position = h.transform.position;
								if (teams [0].units.Count > 0) {
									for (int i = 0; i < teams [0].units.Count; i++) {
										teams [0].inst [i].transform.position = h.transform.position;
									}
								}
								resource [1] = 0;
							}
							//Destroy (h);
							waitfor.RemoveAt (0);
							waitforteam.RemoveAt (0);
							if (waitfor.Count != 0) {
								mc.fieldOfView = 50;
								smenacom (waitforteam [0]);
							} else {
								skillpodsk.gameObject.SetActive (false);
								skillpodsk.text = "";
								chosingtsel = false;
								skilltsel = false;
								mc.fieldOfView = 50;
							}
						} else {
							if(!dontpos){
							Ray MyRay;
							MyRay = mc.ScreenPointToRay (Input.mousePosition);
							h = Instantiate (emp);
							h.transform.position = new Vector3 (MyRay.origin.x, MyRay.origin.y, 0);
							h.transform.SetParent (mc.transform.parent);
							h.transform.localPosition *= sootv;
							h.transform.position = new Vector3 (h.transform.position.x, h.transform.position.y, 0);
							teams [0].unsdvig [topos] = h.transform.localPosition;
							chosingtsel = false;
							posunit = false;
							makemainbtn.SetActive (false);
						}else{
							int comn = teams [0].mainunit;
							int ncomn = teams [0].units [topos];
							teams [0].units[topos]=comn;
							teams [0].unitshp[topos]=units[comn-1].hp;
							teams [0].inst [topos].GetComponent<uniter> ().fly = units [comn - 1].fly;
							teams [0].inst [topos].GetComponent<uniter> ().num = comn;
							teams [0].inst [topos].transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [comn - 1].sp;
							teams [0].mainunit=ncomn;
							teams [0].mainunithp=units[ncomn-1].hp;
							teams [0].comgo.GetComponent<mainunit> ().num = ncomn;
							teams [0].comgo.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [ncomn - 1].sp;
							makemainbtn.SetActive (false);
							posunit = false;
								chosingtsel = false;}
						}
					}
				}
			
				if (skilltsel) {
					skillpodsk.gameObject.SetActive (true);
					skillpodsk.text = "Выберите точку активации умения";
				} else if(posunit) {
					skillpodsk.gameObject.SetActive (true);
					skillpodsk.text = "Нажмите, чтобы закрепить юнита.";
				} else {
					skillpodsk.gameObject.SetActive (true);
					skillpodsk.text = "Нажмите, чтобы закрыть карту";
				}

			}

			if (teams [0].units.Count > 0) {
				if (sdvig < 0)
					sdvig = teams [0].units.Count + sdvig;
				sdvig %= teams [0].units.Count;
			}
			curtimeout4 += Time.deltaTime;
			if (curtimeout4 > 60) {
				if (radugadrunk > 0)
					radugadrunk -= 1;
				if (orkdrunk > 0)
					orkdrunk -= 1;
				curtimeout4 = 0;
			}
			if (curtimeout > 0.5f) {
				
				for (int i = 0; i < resource.Count; i++) {
					if (resource [i] < 0)
						resource [i] = 0;
				}
				for (int i = 0; i < 1; i++) {
					if (teams [0].mainunit != -1) {

						for (int j = 0; j < teams [0].unitshp.Count; j++) {
							if (teams [0].unitshp [j] <= 0) {
								Destroy (teams [0].inst [j]);
								teams [0].units.RemoveAt (j);
								teams [0].unitshp.RemoveAt (j);
								teams [0].unsdvig.RemoveAt (j);
								teams [0].inst.RemoveAt (j);
								teams [0].now -= 0.1f;
							}
						}
						if (teams [0].mainunithp <= 0) {

							if (teams [0].units.Count > 0) {
								if (i == chosedteam) {
									mc.gameObject.transform.SetParent (null);
									//mc.gameObject.transform.localPosition=new Vector3(0,0,mc.transform.position.z);
								}
								Destroy (teams [0].comgo);
								h = Instantiate (compref);
								h.GetComponent<mainunit> ().race = 11;
								h.GetComponent<mainunit> ().num = teams [0].units [0];
								h.GetComponent<mainunit> ().m = i;
								h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [0] - 1].sp;
								h.transform.position = teams [0].comgo.transform.position;
								teams [0].mainunit = teams [0].units [0];
								teams [0].mainunithp = teams [0].unitshp [0];
								teams [0].comgo = h;
								teams [0].now -= 0.1f;
								if (i == chosedteam) {
									mc.gameObject.transform.SetParent (teams [0].comgo.transform);
									mc.gameObject.transform.localPosition = new Vector3 (0, 0, mc.transform.position.z);
								}
								Destroy (teams [0].inst [0]);
								teams [0].unsdvig.RemoveAt (0); teams [0].units.RemoveAt (0);
								teams [0].inst.RemoveAt (0);
								teams [0].unitshp.RemoveAt (0);
								for (int j = 0; j < teams [0].units.Count; j++) {
									teams [0].inst [j].GetComponent<uniter> ().m = i;
								}
							} else {
								teams [0].mainunit = -1;
								bool hgt = false;
								for (int j = 0; j < 10; j++) {
									if (teams [0].mainunit != -1) {
										smenacom (j);
										hgt = true;
										break;
									}
								}
								if (!hgt) {
									die ();
								} else
									Destroy (teams [0].comgo);
							}

						}

					}

				}
				commander.sprite = units [teams [0].mainunit - 1].sp;
				if (teams [0].units.Count > 0)
					u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
				else
					u1.sprite = nulsp;
				if (teams [0].units.Count > 1)
					u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
				else
					u2.sprite = nulsp;
				if (teams [0].units.Count > 2)
					u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
				else
					u3.sprite = nulsp;
				if (teams [0].units.Count > 3)
					u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
				else
					u4.sprite = nulsp;
				if (teams [0].units.Count > 4)
					u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
				else
					u5.sprite = nulsp;
				curtimeout = 0;
			}
			if (curtimeout2 > 1) {
				for (int i = 0; i < resource.Count; i++) {
					if (resource [i] > 0)
						wiki [resourcewikipage [i]].open = true;
				}

				for (int i = 0; i < 1; i++) {
					if (teams [0].mainunit != -1) {
						if (units [teams [0].mainunit - 1].hp > teams [0].mainunithp)
							teams [0].mainunithp += 1;
						for (int j = 0; j < teams [0].units.Count; j++) {
							wiki [units [teams [0].units [j] - 1].wikipagenum].open = true;
							if (units [teams [0].units [j] - 1].hp > teams [0].unitshp [j])
								teams [0].unitshp [j] += 1;
						}
					}
				}
				curtimeout2 = 0;
			}
			if (curtimeout3 > 10) {


				int[] ress = new int[resource.Count];
				for (int i = 0; i < allcities.Count; i++) {
					for (int j = 0; j < allcities [i].resin.Count; j++) {
						ress [allcities [i].resin [j]] += allcities [i].resincol [j];
					}
				}
				for (int i = 0; i < resource.Count; i++) {
					ress [i] += resource [i];
				}
				for (int i = 1; i < ress.Length; i++) {
					rescourse [i] = ress [0] / (ress [i] + 1);
				}
				rescourse [0] = 1;

				curtimeout3 = 0;
			}
			if (curtimeout1 > 0.01f) {
				//if (!teams [0].casting) {
				if (Input.GetKey (KeyCode.W)) {
					teams [0].comgo.transform.Translate (teams [0].comgo.transform.up * speed);
					teams [0].comgo.GetComponent<mainunit> ().gotsel = false;
				}
				if (Input.GetKey (KeyCode.S)) {
					teams [0].comgo.transform.Translate (teams [0].comgo.transform.up * -speed);
					teams [0].comgo.GetComponent<mainunit> ().gotsel = false;
				}
				if (Input.GetKey (KeyCode.A)) {
					teams [0].comgo.transform.Translate (teams [0].comgo.transform.right * -speed);
					teams [0].comgo.GetComponent<mainunit> ().gotsel = false;
				}
				if (Input.GetKey (KeyCode.D)) {
					teams [0].comgo.transform.Translate (teams [0].comgo.transform.right * speed);
					teams [0].comgo.GetComponent<mainunit> ().gotsel = false;
				}
				if (SingleJoystick._s != null) {
					Vector3 v1 = SingleJoystick._s.GetInputDirection ();
					teams [0].comgo.transform.Translate (v1 * speed * 2);
					teams [0].comgo.GetComponent<mainunit> ().gotsel = false;
				}
				//}
				if (creatingteam) {
					if (newteamnums.Contains (sdvig))
						u1.color = Color.black;
					else
						u1.color = Color.white;
					if (newteamnums.Contains (sdvig + 1))
						u2.color = Color.black;
					else
						u2.color = Color.white;
					if (newteamnums.Contains (sdvig + 2))
						u3.color = Color.black;
					else
						u3.color = Color.white;
					if (newteamnums.Contains (sdvig + 3))
						u4.color = Color.black;
					else
						u4.color = Color.white;
					if (newteamnums.Contains (sdvig + 4))
						u5.color = Color.black;
					else
						u5.color = Color.white;
				}
				curtimeout1 = 0;
			}
		}
	}
	public void mmunit(){
		
	}
	public void dont(){
		dontpos = true;
	}
	public void dontdont(){
		dontpos = false;
	}
	public void die ()
	{
		PlayerPrefs.SetInt ("stgif", 0);
		Application.LoadLevel (Application.loadedLevel);

	}
	public void diealc ()
	{
		PlayerPrefs.SetInt ("stgif", -1);
		Application.LoadLevel (Application.loadedLevel);

	}
	public void rsdvig ()
	{
		sdvig += 1;
		if (teams [0].units.Count > 0)
			u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
		else
			u1.sprite = nulsp;
		if (teams [0].units.Count > 1)
			u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [0].units.Count > 2)
			u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
		else
			u3.sprite = nulsp;
		if (teams [0].units.Count > 3)
			u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
		else
			u4.sprite = nulsp;
		if (teams [0].units.Count > 4)
			u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
		else
			u5.sprite = nulsp;
	}

	public void lsdvig ()
	{
		sdvig -= 1;
		if (teams [0].units.Count > 0)
			u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
		else
			u1.sprite = nulsp;
		if (teams [0].units.Count > 1)
			u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [0].units.Count > 2)
			u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
		else
			u3.sprite = nulsp;
		if (teams [0].units.Count > 3)
			u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
		else
			u4.sprite = nulsp;
		if (teams [0].units.Count > 4)
			u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
		else
			u5.sprite = nulsp;
	}

	public void smenacom (int a)
	{
		if (!chosingtsel) {
			skillmenu.SetActive (false);

			if (teams [a].mainunit != -1)
				chosedteam = a;
			cancelcreate ();
			commander.sprite = units [teams [0].mainunit - 1].sp;
			if (teams [0].units.Count > 0)
				u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
			else
				u1.sprite = nulsp;
			if (teams [0].units.Count > 1)
				u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
			else
				u2.sprite = nulsp;
			if (teams [0].units.Count > 2)
				u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
			else
				u3.sprite = nulsp;
			if (teams [0].units.Count > 3)
				u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
			else
				u4.sprite = nulsp;
			if (teams [0].units.Count > 4)
				u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
			else
				u5.sprite = nulsp;
			mc.gameObject.transform.SetParent (teams [0].comgo.transform);
			mc.gameObject.transform.localPosition = new Vector3 (0, 0, -10);
		}
	}

	public void combbtn ()
	{
		for (int i = 0; i < 1; i++) {
			if (i != chosedteam)
			if (teams [0].mainunit != -1) {
				if (Vector3.Distance (teams [0].comgo.transform.position, teams [0].comgo.transform.position) < combdist) {
					h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
					h.GetComponent<uniter> ().race = 11;
					h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [teams [0].mainunit - 1].sp;
					h.transform.position = teams [0].comgo.transform.position;
					h.GetComponent<uniter> ().m = chosedteam; 
					h.GetComponent<uniter> ().num = teams [0].mainunit;
					  teams [0].units.Add (teams [0].mainunit);
					teams [0].unitshp.Add (teams [0].mainunithp);
					teams [0].inst.Add (h);
					Destroy (teams [0].comgo);
					teams [0].now += 0.1f;
					if (teams [0].units.Count > 0)
						for (int j = 0; j < teams [0].units.Count; j++) {
							h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
							h.GetComponent<uniter> ().race = 11;
							h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [j] - 1].sp;
							h.transform.position = teams [0].inst [j].transform.position;
							h.GetComponent<uniter> ().m = chosedteam;
							h.GetComponent<uniter> ().num = teams [0].units [j];
							h.GetComponent<uniter> ().fly = teams [0].inst [j].GetComponent<uniter> ().fly;
							  teams [0].units.Add (teams [0].units [j]);
							teams [0].unitshp.Add (teams [0].unitshp [j]);
							teams [0].inst.Add (h);
							Destroy (teams [0].inst [j]);
							teams [0].now += 0.1f;
						}
					teams [0].mainunit = -1; 
					teams [0].inst.Clear ();
					teams [0].units.Clear ();
					teams [0].unitshp.Clear ();
				}
			}
		}

		commander.sprite = units [teams [0].mainunit - 1].sp;
		if (teams [0].units.Count > 0)
			u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
		else
			u1.sprite = nulsp;
		if (teams [0].units.Count > 1)
			u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [0].units.Count > 2)
			u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
		else
			u3.sprite = nulsp;
		if (teams [0].units.Count > 3)
			u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
		else
			u4.sprite = nulsp;
		if (teams [0].units.Count > 4)
			u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
		else
			u5.sprite = nulsp;

	}

	public void createteam ()
	{
		if (!chosingtsel) {
			newteamnums.Clear ();
			creatingteam = true;
			crtext.SetActive (true);
		}
	}

	public void add (int a)
	{
		if (creatingteam) {
			bool b = true;
			for (int i = 0; i < newteamnums.Count; i++) {
				if (newteamnums [i] == (a + sdvig) % (teams [0].units.Count))
					b = false;
			}
			if (b)
				newteamnums.Add ((a + sdvig) % (teams [0].units.Count));
		} else {
			if (!skilltsel && !teams[0].casting) {
				posunit = true;
				topos = (a + sdvig) % (teams [0].units.Count);
				chosingtsel = true;
				makemainbtn.SetActive (true);
			}
		}
	}

	public void endcreatingteam ()
	{
		creatingteam = false;
		string s1 = crtext.transform.GetChild (0).GetChild (0).gameObject.GetComponent<InputField> ().text;
		if (s1 == @"\supercheat") {
			cancelcreate ();
			for (int i = 0; i < units.Count; i++) {
				h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
				h.GetComponent<uniter> ().race = 11;
				h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [i].sp;
				h.transform.position = teams [0].comgo.transform.position;
				h.GetComponent<uniter> ().m = chosedteam;
				h.GetComponent<uniter> ().num = i + 1;
				h.GetComponent<uniter> ().fly = units [i].fly;
				  teams [0].units.Add (i + 1);
				teams [0].unitshp.Add (units [i].hp);
				teams [0].inst.Add (h);
				teams [0].now += 0.1f;
			}
			for (int i = 0; i < resource.Count; i++) {
				resource [i] = 10000;
			}

		} else {
			int a = -1;
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit == -1) {
					a = i;
					break;
				}
			}
			crtext.transform.GetChild (0).GetChild (0).gameObject.GetComponent<InputField> ().text = "";
			crtext.SetActive (false);
			string s2 = "";
			if (s1.Length != 0)
				for (int i = 0; i < s1.Length; i++) {
					if (s1 [i] != ' ')
						s2 += s1 [i];
				}
			if (a != -1 && newteamnums.Count > 0) {
				teams [0].now -= newteamnums.Count * 0.1f;
				teams [a].name = s2;
				h = Instantiate (compref);
				h.GetComponent<mainunit> ().race = 11;
				h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [newteamnums [0]] - 1].sp;
				h.transform.position = teams [0].inst [newteamnums [0]].transform.position;
				h.GetComponent<mainunit> ().num = teams [0].units [newteamnums [0]];
				h.GetComponent<mainunit> ().m = a;
				teams [a].mainunit = teams [0].units [newteamnums [0]];
				teams [a].mainunithp = teams [0].unitshp [newteamnums [0]];
				teams [a].comgo = h;
				Destroy (teams [0].inst [newteamnums [0]]);
				teams [a].now = 0;
				if (newteamnums.Count > 1)
					for (int j = 1; j < newteamnums.Count; j++) {
						h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
						h.GetComponent<uniter> ().race = 11;
						h.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [newteamnums [j]] - 1].sp;
						h.transform.position = teams [0].inst [newteamnums [j]].transform.position;
						h.GetComponent<uniter> ().m = a;
						h.GetComponent<uniter> ().num = teams [0].units [newteamnums [j]];
						h.GetComponent<uniter> ().fly = teams [0].inst [newteamnums [j]].GetComponent<uniter> ().fly;
						teams [a].unsdvig.Add(Vector3.zero); teams [a].units.Add (teams [0].units [newteamnums [j]]);
						teams [a].unitshp.Add (teams [0].unitshp [newteamnums [j]]);
						teams [a].inst.Add (h);
						Destroy (teams [0].inst [newteamnums [j]]);
						teams [a].now += 0.1f;
					}
			}
			for (int i = 0; i < newteamnums.Count; i++) {
				teams [0].units [newteamnums [i]] = -1;
				teams [0].inst [newteamnums [i]] = null;
			}
			for (int i = 0; i < 1000000; i = i) {
				if (teams [0].units [i] == -1) {
					teams [0].units.RemoveAt (i);
					teams [0].inst.RemoveAt (i);
					teams [0].unitshp.RemoveAt (i);
					teams [0].unsdvig.RemoveAt (i);
				} else
					i += 1;
				if (i >= teams [0].units.Count)
					break;

			}
			commander.sprite = units [teams [0].mainunit - 1].sp;
			if (teams [0].units.Count > 0)
				u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
			else
				u1.sprite = nulsp;
			if (teams [0].units.Count > 1)
				u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
			else
				u2.sprite = nulsp;
			if (teams [0].units.Count > 2)
				u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
			else
				u3.sprite = nulsp;
			if (teams [0].units.Count > 3)
				u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
			else
				u4.sprite = nulsp;
			if (teams [0].units.Count > 4)
				u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
			else
				u5.sprite = nulsp;
			u1.color = Color.white;
			u2.color = Color.white;
			u3.color = Color.white;
			u4.color = Color.white;
			u5.color = Color.white;
			newteamnums.Clear ();
		}
	}

	public void cancelcreate ()
	{
		creatingteam = false;
		crtext.SetActive (false);
		commander.sprite = units [teams [0].mainunit - 1].sp;
		if (teams [0].units.Count > 0)
			u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
		else
			u1.sprite = nulsp;
		if (teams [0].units.Count > 1)
			u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
		else
			u2.sprite = nulsp;
		if (teams [0].units.Count > 2)
			u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
		else
			u3.sprite = nulsp;
		if (teams [0].units.Count > 3)
			u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
		else
			u4.sprite = nulsp;
		if (teams [0].units.Count > 4)
			u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
		else
			u5.sprite = nulsp;
		u1.color = Color.white;
		u2.color = Color.white;
		u3.color = Color.white;
		u4.color = Color.white;
		u5.color = Color.white;
		newteamnums.Clear ();
	}

	public void townenter (GameObject town)
	{
		if (!onuimouse) {
			savegame ();
			citnow = town.GetComponent<city> ();
			if (Vector3.Distance (town.transform.position, teams [0].comgo.transform.position) < 3) {
				joy.SetActive (false);
				dialog.SetActive (true);
				dialnum = -1;


				if (citnow.d.usl1 != "") {
					razdel.Add ("");
					for (int i = 0; i < citnow.d.usl1.Length; i++) {
						if (citnow.d.usl1 [i] == ' ') {
							razdel.Add ("");
						} else
							razdel [razdel.Count - 1] += citnow.d.usl1 [i];
					}
					bool bo = true;
					for (int i = 0; i < razdel.Count; i++) {
						if (razdel [i] == "quest") {
							if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "quest-") {
							if (quests [myparse (razdel [i + 1])] == myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "otn") {
							if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "item") {
							if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "race") {
							if (citnow.race != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "race") {
							if (citnow.race != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "you") {
							if (teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "otn-") {
							if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "otn-") {
							if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit") {
							if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit-") {
							if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unitin") {
							if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
								bo = false;
							i += 1;
						} else if (razdel [i] == "itemin") {
							if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
								bo = false;
							else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "your") {
							if (citnow.race != 11)
								bo = false;
						} else if (razdel [i] == "notyour") {
							if (citnow.race == 11)
								bo = false;
						}
					}
					if (bo) {
						ans1.text = citnow.d.a1;
						canans [0] = true;
					} else {
						ans1.text = "";
						canans [0] = false;
					}
					razdel.Clear ();
				} else {
					ans1.text = citnow.d.a1;
					canans [0] = true;
				}
				if (citnow.d.usl2 != "") {
					razdel.Add ("");
					for (int i = 0; i < citnow.d.usl2.Length; i++) {
						if (citnow.d.usl2 [i] == ' ') {
							razdel.Add ("");
						} else
							razdel [razdel.Count - 1] += citnow.d.usl2 [i];
					}
					bool bo = true;
					for (int i = 0; i < razdel.Count; i++) {
						if (razdel [i] == "quest") {
							if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "otn") {
							if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "item") {
							if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "race") {
							if (citnow.race != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "you") {
							if (teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "otn-") {
							if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit") {
							if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit-") {
							if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unitin") {
							if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
								bo = false;
							i += 1;
						} else if (razdel [i] == "itemin") {
							if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
								bo = false;
							else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "your") {
							if (citnow.race != 11)
								bo = false;
						} else if (razdel [i] == "notyour") {
							if (citnow.race == 11)
								bo = false;
						}
					}
					if (bo) {
						ans2.text = citnow.d.a2;
						canans [1] = true;
					} else {
						ans2.text = "";
						canans [1] = false;
					}
					razdel.Clear ();
				} else {
					ans2.text = citnow.d.a2;
					canans [1] = true;
				}
			
				if (citnow.d.usl3 != "") {
					razdel.Add ("");
					for (int i = 0; i < citnow.d.usl3.Length; i++) {
						if (citnow.d.usl3 [i] == ' ') {
							razdel.Add ("");
						} else
							razdel [razdel.Count - 1] += citnow.d.usl3 [i];
					}
					bool bo = true;
					for (int i = 0; i < razdel.Count; i++) {
						if (razdel [i] == "quest") {
							if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "otn") {
							if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "item") {
							if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "race") {
							if (citnow.race != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "you") {
							if (teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "otn-") {
							if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit") {
							if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit-") {
							if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unitin") {
							if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
								bo = false;
							i += 1;
						} else if (razdel [i] == "itemin") {
							if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
								bo = false;
							else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "your") {
							if (citnow.race != 11)
								bo = false;
						} else if (razdel [i] == "notyour") {
							if (citnow.race == 11)
								bo = false;
						}
					}
					if (bo) {
						ans3.text = citnow.d.a3;
						canans [2] = true;
					} else {
						ans3.text = "";
						canans [2] = false;
					}
					razdel.Clear ();
				} else {
					ans3.text = citnow.d.a3;
					canans [2] = true;
				}

			
			
				if (citnow.d.usl4 != "") {
					razdel.Add ("");
					for (int i = 0; i < citnow.d.usl4.Length; i++) {
						if (citnow.d.usl4 [i] == ' ') {
							razdel.Add ("");
						} else
							razdel [razdel.Count - 1] += citnow.d.usl4 [i];
					}
					bool bo = true;
					for (int i = 0; i < razdel.Count; i++) {
						if (razdel [i] == "quest") {
							if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "otn") {
							if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "item") {
							if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "race") {
							if (citnow.race != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "you") {
							if (teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "otn-") {
							if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit") {
							if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unit-") {
							if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
								bo = false;
							i += 1;
						} else if (razdel [i] == "unitin") {
							if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
								bo = false;
							i += 1;
						} else if (razdel [i] == "itemin") {
							if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
								bo = false;
							else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
								bo = false;
							i += 2;
						} else if (razdel [i] == "your") {
							if (citnow.race != 11)
								bo = false;
						} else if (razdel [i] == "notyour") {
							if (citnow.race == 11)
								bo = false;
						}
					}
					if (bo) {
						ans4.text = citnow.d.a4;
						canans [3] = true;
					} else {
						ans4.text = "";
						canans [3] = false;
					}
					razdel.Clear ();
				} else {
					ans4.text = citnow.d.a4;
					canans [3] = true;
				}
				talk.text = txtparse(citnow.d.txt);
				talker.sprite = citnow.d.talker;

				cityim.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;
			}
		}
	}

	public void ans (int num)
	{
		bool exit = false;
		if (!trd) {
			if (dialnum == -1) {
				if (num == 0) {
					if (citnow.d.act1 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.d.act1 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 1) {
					if (citnow.d.act2 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.d.act2 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 2) {
					if (citnow.d.act3 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.d.act3 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 3) {
					if (citnow.d.act4 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.d.act4 == "admin") {
						trd = true;//f
						tradestate = -2;
					}
				}
			} else {
				if (num == 0) {
					if (citnow.l [dialnum].act1 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.l [dialnum].act1 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 1) {
					if (citnow.l [dialnum].act2 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.l [dialnum].act2 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 2) {
					if (citnow.l [dialnum].act3 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.l [dialnum].act3 == "admin") {
						trd = true;
						tradestate = -2;
					}
				} else if (num == 3) {
					if (citnow.l [dialnum].act4 == "trade") {
						trd = true;
						tradestate = -1;
					} else if (citnow.l [dialnum].act4 == "admin") {
						trd = true;
						tradestate = -2;
					}
				}
			}
		}
		if (trd) {
			if (tradestate == -1) {
				tradestate = 0;
				talk.text = "Меню торговли" + "\n";
				tobuy = rnd.Next (citnow.resin.Count);
				tobuycol = rnd.Next (citnow.resincol [tobuy] - 1) + 1;
				tobuy = citnow.resin [tobuy];
				while (true) {
					tosell = rnd.Next (resource.Count);
					if (resource [tosell] * rescourse [tosell] > 0) {
						break;
					}
				}
				talk.text += "Покупка: " + tobuycol.ToString () + " " + resnames [tobuy].ToString () + " за " + Mathf.Ceil ((rescourse [tobuy] * tobuycol / rescourse [tosell])).ToString () + " " + resnames [tosell].ToString () + " (Есть " + resource [tosell] + ")\n";
				tobuy1 = rnd.Next (citnow.resin.Count);
				tobuycol1 = rnd.Next (citnow.resincol [tobuy1] - 1) + 1;
				tobuy1 = citnow.resin [tobuy1];
				while (true) {
					tosell1 = rnd.Next (resource.Count);
					if (resource [tosell1] * rescourse [tosell1] > 0) {
						break;
					}
				}
				talk.text += "Покупка: " + tobuycol1.ToString () + " " + resnames [tobuy1].ToString () + " за " + Mathf.Ceil ((rescourse [tobuy1] * tobuycol1 / rescourse [tosell1])).ToString () + " " + resnames [tosell1].ToString () + " (Есть " + resource [tosell1] + ")\n";

				while (true) {
					togive = rnd.Next (resource.Count);
					if (resource [togive] * rescourse [togive] > 0) {
						break;
					}
				}
				togivecol = rnd.Next (resource [togive] - 1) + 1;
				talk.text += "Подарить: " + togivecol.ToString () + " " + resnames [togive] + " (Есть " + resource [togive] + ")";
				talker.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;
				ans1.text = "Купить " + resnames [tobuy].ToString ();
				ans2.text = "Купить " + resnames [tobuy1].ToString ();
				ans3.text = "Подарить " + resnames [togive].ToString ();
				ans4.text = "Уйти";
			} else if (tradestate == 0) {
				if (num == 3) {
					citnow = null;
					dialog.SetActive (false);
					joy.SetActive (true);
					exit = true;
					trd = false;
				} else if (num == 2) {
					if (resource [togive] >= togivecol) {
						resource [togive] -= togivecol;
						races [citnow.race].otnosh += (int)rescourse [togive] * togivecol / 100;
						ans1.text = "Уйти";
						ans2.text = "";
						ans3.text = "";
						ans4.text = "";
						talk.text = "Жители рады вашему подарку";
						tradestate = 1;
					} else {
						ans1.text = "Уйти";
						ans2.text = "";
						ans3.text = "";
						ans4.text = "";
						talk.text = "Недостаточно ресурсов";
						tradestate = 1;
					}
				} else if (num == 1) {
					if (resource [tosell1] >= Mathf.Ceil ((rescourse [tobuy1] * tobuycol1 / rescourse [tosell1]))) {
						if (citnow.resin.Contains (tobuy1) && citnow.resincol [citnow.resin.IndexOf (tobuy1)] >= tobuycol1) {
							resource [tosell1] -= (int)Mathf.Ceil (rescourse [tobuy1] * tobuycol1 / rescourse [tosell1]);
							resource [tobuy1] += tobuycol1;
							citnow.resincol [citnow.resin.IndexOf (tobuy1)] -= tobuycol1;
							ans1.text = "Уйти";
							ans2.text = "";
							ans3.text = "";
							ans4.text = "";
							talk.text = "Покупка совершена";
							tradestate = 1;
						} else {
							ans1.text = "Уйти";
							ans2.text = "";
							ans3.text = "";
							ans4.text = "";
							talk.text = "В городе закончился данный ресурс";
							tradestate = 1;
						}
					} else {
						ans1.text = "Уйти";
						ans2.text = "";
						ans3.text = "";
						ans4.text = "";
						talk.text = "Недостаточно ресурсов";
						tradestate = 1;
					}
				} else {
					if (resource [tosell] >= Mathf.Ceil ((rescourse [tobuy] * tobuycol / rescourse [tosell]))) {
						if (citnow.resin.Contains (tobuy) && citnow.resincol [citnow.resin.IndexOf (tobuy)] >= tobuycol) {
							resource [tosell] -= (int)Mathf.Ceil ((rescourse [tobuy] * tobuycol / rescourse [tosell]));
							resource [tobuy] += tobuycol;
							citnow.resincol [citnow.resin.IndexOf (tobuy)] -= tobuycol;
							ans1.text = "Уйти";
							ans2.text = "";
							ans3.text = "";
							ans4.text = "";
							talk.text = "Покупка совершена";
							tradestate = 1;
						} else {
							ans1.text = "Уйти";
							ans2.text = "";
							ans3.text = "";
							ans4.text = "";
							talk.text = "В городе закончился данный ресурс";
							tradestate = 1;
						}
					} else {
						ans1.text = "Уйти";
						ans2.text = "";
						ans3.text = "";
						ans4.text = "";
						talk.text = "Недостаточно ресурсов";
						tradestate = 1;
					}
				}
			} else if (tradestate == 1) {
				if (num == 0) {
					citnow = null;
					dialog.SetActive (false);
					joy.SetActive (true);
					exit = true;
					trd = false;
				}
			} else if (tradestate == -2) {
				ans1.text = "Собрать налоги : "+resnames[citnow.resdob]+" (до "+citnow.resincol [citnow.resin.IndexOf (citnow.resdob)]+")";
				ans2.text = "";
				ans3.text = "";
				ans4.text = "";
				talk.text = "Настройки (Админ)";
			}
				
		} else {
			if (canans [num]) {
				if (num == 0) {//num0
					if (dialnum == -1) {
						if (citnow.d.d1 != -1) {
							dialnum = citnow.d.d1;
							lastdialnum = -1;
						} else {
							if (citnow.d.act1 != "none") {
								razdel.Add ("");
								for (int i = 0; i < citnow.d.act1.Length; i++) {
									if (citnow.d.act1 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act1 [i];
								}
								for (int i = 0; i < razdel.Count; i++) {
									if (razdel [i] == "quest") {
										quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "add") {
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
											resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
										}
										i += 2;
									} else if (razdel [i] == "addskill") {
										skillshave.Add (myparse (razdel [i + 1]));
										i += 1;
									} else if (razdel [i] == "del") {
										moneyplay ();
										resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
										else {
											citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
											citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
										}
										i += 2;
									} else if (razdel [i] == "exit") {
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else if (razdel [i] == "otn") {
										races [citnow.race].otnosh += myparse (razdel [i + 1]);
										i += 1;
									} else if (razdel [i] == "delunit") {
										if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
											int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
											Destroy (teams [0].inst [o]);
											teams [0].inst.RemoveAt (o);
											teams [0].now -= 0.1f;
										} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].mainunithp = -10;
										}
										i += 1;
									} else if (razdel [i] == "addunit") {
										if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
											  teams [0].units.Add (myparse (razdel [i + 1]));
											teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
											h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
											if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
												for (int j = 0; j < citnow.uns.Count; j++) {
													citnow.uns [j].SetActive (true);
												}
												teams [0].comgo.transform.position = citnow.sppos.transform.position;
												for (int j = 0; j < teams [0].units.Count; j++) {
													teams [0].inst [j].transform.position = citnow.sppos.transform.position;
												}
												citnow.inbattle = true;
												inbattle = true;
												citnow = null;
												dialog.SetActive (false); joy.SetActive(true);
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
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
											exit = true;
											break;
										} else {
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
										
									
											for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
												int yur = rnd.Next (5);
												if (yur == 1) {
													  teams [0].units.Add (citnow.unitsin [j1]);
													teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
													h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
													h.GetComponent<uniter> ().race = 11;
													h.transform.position = teams [0].comgo.gameObject.transform.position;
													h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
													h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
													h.GetComponent<uniter> ().m = chosedteam;
													h.GetComponent<uniter> ().num = citnow.unitsin [j1];
													teams [0].inst.Add (h);
													teams [0].now += 0.1f;
													i += 1;
													citnow.unitsin.RemoveAt (j1);
												}
											}
											citnow.grabbed = true;
										}
									} else if (razdel [i] == "colony") {
									
									} else if (razdel [i] == "nalog") {
										int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
										resource [citnow.resdob] += g;
										citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
									} else if (razdel [i] == "openwiki") {
										wiki [myparse (razdel [i + 1])].open = true;
										i += 1;
									} else if (razdel [i] == "addunitan") {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										i += 1;
									} else if (razdel [i] == "addan") {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "pos") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										}
										i += 2;
									} else if (razdel [i] == "anplen") {
										startgame (true);
									} else if (razdel [i] == "soplen") {
										startgame (false);
									} else if (razdel [i] == "poswout") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										i += 2;
									} else if (razdel [i] == "zachvatall") {
										for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
											main._m.races [citnow.race].com.cities [j1].race = 11;
										}
										Destroy (main._m.races [citnow.race].com);
										citnow.race = 11;
									}
								
								}
								razdel.Clear ();
							} else
								exit = true;
						}
					} else if (citnow.l [dialnum].d1 != -1) {
						lastdialnum = dialnum;
						dialnum = citnow.l [dialnum].d1; 
					} else {
						if (citnow.l [dialnum].act1 != "none") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].act1.Length; i++) {
								if (citnow.l [dialnum].act1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].act1 [i];
							}
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "add") {
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
									}
									i += 2;
								} else if (razdel [i] == "addskill") {
									skillshave.Add (myparse (razdel [i + 1]));
									i += 1;
								} else if (razdel [i] == "del") {
									moneyplay ();
									resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
									else {
										citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
										citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
									}
									i += 2;
								} else if (razdel [i] == "exit") {
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else if (razdel [i] == "otn") {
									races [citnow.race].otnosh += myparse (razdel [i + 1]);
									i += 1;
								} else if (razdel [i] == "delunit") {
									if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
										int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
										Destroy (teams [0].inst [o]);
										teams [0].inst.RemoveAt (o);
										teams [0].now -= 0.1f;
									} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].mainunithp = -10;
									}
									i += 1;
								} else if (razdel [i] == "addunit") {
									if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
										if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
											for (int j = 0; j < citnow.uns.Count; j++) {
												citnow.uns [j].SetActive (true);
											}
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else {
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
								
										for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
											int yur = rnd.Next (5);
											if (yur == 1) {
												  teams [0].units.Add (citnow.unitsin [j1]);
												teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
												h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
												h.GetComponent<uniter> ().race = 11;
												h.transform.position = teams [0].comgo.gameObject.transform.position;
												h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
												h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
												h.GetComponent<uniter> ().m = chosedteam;
												h.GetComponent<uniter> ().num = citnow.unitsin [j1];
												teams [0].inst.Add (h);
												teams [0].now += 0.1f;
												i += 1;
												citnow.unitsin.RemoveAt (j1);
											}
										}
										citnow.grabbed = true;
									}
								} else if (razdel [i] == "colony") {
								
								} else if (razdel [i] == "nalog") {
									int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
									resource [citnow.resdob] += g;
									citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
								} else if (razdel [i] == "openwiki") {
									wiki [myparse (razdel [i + 1])].open = true;
									i += 1;
								} else if (razdel [i] == "addunitan") {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									i += 1;
								} else if (razdel [i] == "addan") {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "pos") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									}
									i += 2;
								} else if (razdel [i] == "anplen") {
									startgame (true);
								} else if (razdel [i] == "soplen") {
									startgame (false);
								} else if (razdel [i] == "poswout") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									i += 2;
								} else if (razdel [i] == "zachvatall") {
									for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
										main._m.races [citnow.race].com.cities [j1].race = 11;
									}
									Destroy (main._m.races [citnow.race].com);
									citnow.race = 11;
								}
							
							}
							razdel.Clear ();
						} else
							exit = true;
					}
					if (!exit) {
						if (citnow.l [dialnum].usl1 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl1.Length; i++) {
								if (citnow.l [dialnum].usl1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl1 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans1.text = citnow.l [dialnum].a1;
								canans [0] = true;
							} else {
								ans1.text = "";
								canans [0] = false;
							}
							razdel.Clear ();
						} else {
							ans1.text = citnow.l [dialnum].a1;
							canans [0] = true;
						}
						if (citnow.l [dialnum].usl2 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl2.Length; i++) {
								if (citnow.l [dialnum].usl2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl2 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans2.text = citnow.l [dialnum].a2;
								canans [1] = true;
							} else {
								ans2.text = "";
								canans [1] = false;
							}
							razdel.Clear ();
						} else {
							ans2.text = citnow.l [dialnum].a2;
							canans [1] = true;
						}
				
						if (citnow.l [dialnum].usl3 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl3.Length; i++) {
								if (citnow.l [dialnum].usl3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl3 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans3.text = citnow.l [dialnum].a3;
								canans [2] = true;
							} else {
								ans3.text = "";
								canans [2] = false;
							}
							razdel.Clear ();
						} else {
							ans3.text = citnow.l [dialnum].a3;
							canans [2] = true;
						}
				
				
				
						if (citnow.l [dialnum].usl4 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl4.Length; i++) {
								if (citnow.l [dialnum].usl4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl4 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans4.text = citnow.l [dialnum].a4;
								canans [3] = true;
							} else {
								ans4.text = "";
								canans [3] = false;
							}
							razdel.Clear ();
						} else {
							ans4.text = citnow.l [dialnum].a4;
							canans [3] = true;
						}
					
					
						razdel.Add ("");
						if (lastdialnum == -1) {
							if (num == 0)
								for (int i = 0; i < citnow.d.act1.Length; i++) {
									if (citnow.d.act1 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act1 [i];
								}
							else if (num == 1)
								for (int i = 0; i < citnow.d.act2.Length; i++) {
									if (citnow.d.act2 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act2 [i];
								}
							else if (num == 2)
								for (int i = 0; i < citnow.d.act3.Length; i++) {
									if (citnow.d.act3 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act3 [i];
								}
							else
								for (int i = 0; i < citnow.d.act4.Length; i++) {
									if (citnow.d.act4 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act4 [i];
								}
						} else if (num == 0)
							for (int i = 0; i < citnow.l [lastdialnum].act1.Length; i++) {
								if (citnow.l [lastdialnum].act1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act1 [i];
							}
						else if (num == 1)
							for (int i = 0; i < citnow.l [lastdialnum].act2.Length; i++) {
								if (citnow.l [lastdialnum].act2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act2 [i];
							}
						else if (num == 2)
							for (int i = 0; i < citnow.l [lastdialnum].act3.Length; i++) {
								if (citnow.l [lastdialnum].act3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act3 [i];
							}
						else
							for (int i = 0; i < citnow.l [lastdialnum].act4.Length; i++) {
								if (citnow.l [lastdialnum].act4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act4 [i];
							}

						for (int i = 0; i < razdel.Count; i++) {
							if (razdel [i] == "quest") {
								quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "add") {
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
								}
								i += 2;
							} else if (razdel [i] == "addskill") {
								skillshave.Add (myparse (razdel [i + 1]));
								i += 1;
							} else if (razdel [i] == "del") {
								moneyplay ();
								resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
								else {
									citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
									citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
								}
								i += 2;
							} else if (razdel [i] == "exit") {
								citnow = null;
								dialog.SetActive (false); joy.SetActive(true);
								exit = true;
								break;
							} else if (razdel [i] == "otn") {
								races [citnow.race].otnosh += myparse (razdel [i + 1]);
								i += 1;
							} else if (razdel [i] == "delunit") {
								if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
									int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
									Destroy (teams [0].inst [o]);
									teams [0].inst.RemoveAt (o);
									teams [0].now -= 0.1f;
								
								} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].mainunithp = -10;
								}
								i += 1;
							} else if (razdel [i] == "addunit") {
								if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
									if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
										for (int j = 0; j < citnow.uns.Count; j++) {
											citnow.uns [j].SetActive (true);
										}
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
									teams [0].comgo.transform.position = citnow.sppos.transform.position;
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = citnow.sppos.transform.position;
									}
									citnow.inbattle = true;
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									inbattle = true;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else {
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
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
									for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
										int yur = rnd.Next (5);
										if (yur == 1) {
											  teams [0].units.Add (citnow.unitsin [j1]);
											teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
											h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = citnow.unitsin [j1];
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											i += 1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
									citnow.grabbed = true;
								}
							} else if (razdel [i] == "colony") {
							
							} else if (razdel [i] == "nalog") {
								int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
								resource [citnow.resdob] += g;
								citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
							} else if (razdel [i] == "openwiki") {
								wiki [myparse (razdel [i + 1])].open = true;
								i += 1;
							} else if (razdel [i] == "addunitan") {
								  teams [0].units.Add (myparse (razdel [i + 1]));
								teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
								h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
								h.GetComponent<uniter> ().race = 11;
								h.transform.position = teams [0].comgo.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
								h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
								h.GetComponent<uniter> ().m = chosedteam;
								h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
								teams [0].inst.Add (h);
								teams [0].now += 0.1f;
								i += 1;
							} else if (razdel [i] == "addan") {
								resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "pos") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								for (int j = 0; j < teams [0].units.Count; j++) {
									teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								}
								i += 2;
							} else if (razdel [i] == "anplen") {
								startgame (true);
							} else if (razdel [i] == "soplen") {
								startgame (false);
							} else if (razdel [i] == "poswout") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								i += 2;
							} else if (razdel [i] == "zachvatall") {
								for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
									main._m.races [citnow.race].com.cities [j1].race = 11;
								}
								Destroy (main._m.races [citnow.race].com);
								citnow.race = 11;
							}
						
						}
						if (!exit) {
							razdel.Clear ();
							talk.text = txtparse(citnow.l [dialnum].txt);
							talker.sprite = citnow.l [dialnum].talker;
				
							cityim.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;
				
						}
					}








				}


				if (num == 1) {//num1
				
				
				
				
				
				
				
				
				
					if (dialnum == -1) {
						if (citnow.d.d2 != -1) {
							lastdialnum = -1;
							dialnum = citnow.d.d2;
						} else {
							if (citnow.d.act2 != "none") {
								razdel.Add ("");
								for (int i = 0; i < citnow.d.act2.Length; i++) {
									if (citnow.d.act2 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act2 [i];
								}
								for (int i = 0; i < razdel.Count; i++) {
									if (razdel [i] == "quest") {
										quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "add") {
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
											resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
										}
										i += 2;
									} else if (razdel [i] == "addskill") {
										skillshave.Add (myparse (razdel [i + 1]));
										i += 1;
									} else if (razdel [i] == "del") {
										moneyplay ();
										resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
										else {
											citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
											citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
										}
										i += 2;
									} else if (razdel [i] == "exit") {
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else if (razdel [i] == "otn") {
										races [citnow.race].otnosh += myparse (razdel [i + 1]);
										i += 1;
									} else if (razdel [i] == "delunit") {
										if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
											int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
											Destroy (teams [0].inst [o]);
											teams [0].inst.RemoveAt (o);
											teams [0].now -= 0.1f;
										} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].mainunithp = -10;
										}
										i += 1;
									} else if (razdel [i] == "addunit") {
										if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
											  teams [0].units.Add (myparse (razdel [i + 1]));
											teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
											h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
											if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
												for (int j = 0; j < citnow.uns.Count; j++) {
													citnow.uns [j].SetActive (true);
												}
												teams [0].comgo.transform.position = citnow.sppos.transform.position;
												for (int j = 0; j < teams [0].units.Count; j++) {
													teams [0].inst [j].transform.position = citnow.sppos.transform.position;
												}
												citnow.inbattle = true;
												inbattle = true;
												citnow = null;
												dialog.SetActive (false); joy.SetActive(true);
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
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
											exit = true;
											break;
										} else {
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
									
											for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
												int yur = rnd.Next (5);
												if (yur == 1) {
													  teams [0].units.Add (citnow.unitsin [j1]);
													teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
													h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
													h.GetComponent<uniter> ().race = 11;
													h.transform.position = teams [0].comgo.gameObject.transform.position;
													h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
													h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
													h.GetComponent<uniter> ().m = chosedteam;
													h.GetComponent<uniter> ().num = citnow.unitsin [j1];
													teams [0].inst.Add (h);
													teams [0].now += 0.1f;
													i += 1;
													citnow.unitsin.RemoveAt (j1);
												}
											}
											citnow.grabbed = true;
										}
									} else if (razdel [i] == "colony") {
									
									} else if (razdel [i] == "nalog") {
										int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
										resource [citnow.resdob] += g;
										citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
									} else if (razdel [i] == "openwiki") {
										wiki [myparse (razdel [i + 1])].open = true;
										i += 1;
									} else if (razdel [i] == "addunitan") {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										i += 1;
									} else if (razdel [i] == "addan") {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "pos") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										}
										i += 2;
									} else if (razdel [i] == "anplen") {
										startgame (true);
									} else if (razdel [i] == "soplen") {
										startgame (false);
									} else if (razdel [i] == "poswout") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										i += 2;
									} else if (razdel [i] == "zachvatall") {
										for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
											main._m.races [citnow.race].com.cities [j1].race = 11;
										}
										Destroy (main._m.races [citnow.race].com);
										races.RemoveAt (citnow.race);
										citnow.race = 11;
									}
								
								}
								razdel.Clear ();
							} else
								exit = true;
						}
					} else if (citnow.l [dialnum].d2 != -1) {
						lastdialnum = dialnum;
						dialnum = citnow.l [dialnum].d2; 
					} else {
						if (citnow.l [dialnum].act2 != "none") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].act2.Length; i++) {
								if (citnow.l [dialnum].act2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].act2 [i];
							}
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "add") {
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
									}
									i += 2;
								} else if (razdel [i] == "addskill") {
									skillshave.Add (myparse (razdel [i + 1]));
									i += 1;
								} else if (razdel [i] == "del") {
									moneyplay ();
									resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
									else {
										citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
										citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
									}
									i += 2;
								} else if (razdel [i] == "exit") {
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else if (razdel [i] == "otn") {
									races [citnow.race].otnosh += myparse (razdel [i + 1]);
									i += 1;
								} else if (razdel [i] == "delunit") {
									if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
										int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
										Destroy (teams [0].inst [o]);
										teams [0].inst.RemoveAt (o);
										teams [0].now -= 0.1f;
									} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].mainunithp = -10;
									}
									i += 1;
								} else if (razdel [i] == "addunit") {
									if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
										if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
											for (int j = 0; j < citnow.uns.Count; j++) {
												citnow.uns [j].SetActive (true);
											}
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else {
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
								
										for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
											int yur = rnd.Next (5);
											if (yur == 1) {
												  teams [0].units.Add (citnow.unitsin [j1]);
												teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
												h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
												h.GetComponent<uniter> ().race = 11;
												h.transform.position = teams [0].comgo.gameObject.transform.position;
												h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
												h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
												h.GetComponent<uniter> ().m = chosedteam;
												h.GetComponent<uniter> ().num = citnow.unitsin [j1];
												teams [0].inst.Add (h);
												teams [0].now += 0.1f;
												i += 1;
												citnow.unitsin.RemoveAt (j1);
											}
										}
										citnow.grabbed = true;
									}
								} else if (razdel [i] == "colony") {
								
								} else if (razdel [i] == "nalog") {
									int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
									resource [citnow.resdob] += g;
									citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
								} else if (razdel [i] == "openwiki") {
									wiki [myparse (razdel [i + 1])].open = true;
									i += 1;
								} else if (razdel [i] == "addunitan") {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									i += 1;
								} else if (razdel [i] == "addan") {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "pos") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									}
									i += 2;
								} else if (razdel [i] == "anplen") {
									startgame (true);
								} else if (razdel [i] == "soplen") {
									startgame (false);
								} else if (razdel [i] == "poswout") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									i += 2;
								} else if (razdel [i] == "zachvatall") {
									for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
										main._m.races [citnow.race].com.cities [j1].race = 11;
									}
									Destroy (main._m.races [citnow.race].com);
									citnow.race = 11;
								}
							
							}
							razdel.Clear ();
						} else
							exit = true;
					}
					if (!exit) {
						if (citnow.l [dialnum].usl1 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl1.Length; i++) {
								if (citnow.l [dialnum].usl1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl1 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans1.text = citnow.l [dialnum].a1;
								canans [0] = true;
							} else {
								ans1.text = "";
								canans [0] = false;
							}
							razdel.Clear ();
						} else {
							ans1.text = citnow.l [dialnum].a1;
							canans [0] = true;
						}
						if (citnow.l [dialnum].usl2 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl2.Length; i++) {
								if (citnow.l [dialnum].usl2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl2 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans2.text = citnow.l [dialnum].a2;
								canans [1] = true;
							} else {
								ans2.text = "";
								canans [1] = false;
							}
							razdel.Clear ();
						} else {
							ans2.text = citnow.l [dialnum].a2;
							canans [1] = true;
						}
					
						if (citnow.l [dialnum].usl3 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl3.Length; i++) {
								if (citnow.l [dialnum].usl3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl3 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans3.text = citnow.l [dialnum].a3;
								canans [2] = true;
							} else {
								ans3.text = "";
								canans [2] = false;
							}
							razdel.Clear ();
						} else {
							ans3.text = citnow.l [dialnum].a3;
							canans [2] = true;
						}
					
					
					
						if (citnow.l [dialnum].usl4 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl4.Length; i++) {
								if (citnow.l [dialnum].usl4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl4 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans4.text = citnow.l [dialnum].a4;
								canans [3] = true;
							} else {
								ans4.text = "";
								canans [3] = false;
							}
							razdel.Clear ();
						} else {
							ans4.text = citnow.l [dialnum].a4;
							canans [3] = true;
						}
					
					
						razdel.Add ("");
						if (lastdialnum == -1) {
							if (num == 0)
								for (int i = 0; i < citnow.d.act1.Length; i++) {
									if (citnow.d.act1 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act1 [i];
								}
							else if (num == 1)
								for (int i = 0; i < citnow.d.act2.Length; i++) {
									if (citnow.d.act2 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act2 [i];
								}
							else if (num == 2)
								for (int i = 0; i < citnow.d.act3.Length; i++) {
									if (citnow.d.act3 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act3 [i];
								}
							else
								for (int i = 0; i < citnow.d.act4.Length; i++) {
									if (citnow.d.act4 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act4 [i];
								}
						} else if (num == 0)
							for (int i = 0; i < citnow.l [lastdialnum].act1.Length; i++) {
								if (citnow.l [lastdialnum].act1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act1 [i];
							}
						else if (num == 1)
							for (int i = 0; i < citnow.l [lastdialnum].act2.Length; i++) {
								if (citnow.l [lastdialnum].act2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act2 [i];
							}
						else if (num == 2)
							for (int i = 0; i < citnow.l [lastdialnum].act3.Length; i++) {
								if (citnow.l [lastdialnum].act3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act3 [i];
							}
						else
							for (int i = 0; i < citnow.l [lastdialnum].act4.Length; i++) {
								if (citnow.l [lastdialnum].act4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act4 [i];
							}

						for (int i = 0; i < razdel.Count; i++) {
							if (razdel [i] == "quest") {
								quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "add") {
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
								}
								i += 2;
							} else if (razdel [i] == "addskill") {
								skillshave.Add (myparse (razdel [i + 1]));
								i += 1;
							} else if (razdel [i] == "del") {
								moneyplay ();
								resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
								else {
									citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
									citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
								}
								i += 2;
							} else if (razdel [i] == "exit") {
								citnow = null;
								dialog.SetActive (false); joy.SetActive(true);
								exit = true;
								break;
							} else if (razdel [i] == "otn") {
								races [citnow.race].otnosh += myparse (razdel [i + 1]);
								i += 1;
							} else if (razdel [i] == "delunit") {
								if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
									int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
									Destroy (teams [0].inst [o]);
									teams [0].inst.RemoveAt (o);
									teams [0].now -= 0.1f;
								} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].mainunithp = -10;
								}
								i += 1;
							} else if (razdel [i] == "addunit") {
								if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
									if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
										for (int j = 0; j < citnow.uns.Count; j++) {
											citnow.uns [j].SetActive (true);
										}
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
									teams [0].comgo.transform.position = citnow.sppos.transform.position;
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = citnow.sppos.transform.position;
									}
									citnow.inbattle = true;
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									inbattle = true;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else {
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
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
							
									for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
										int yur = rnd.Next (5);
										if (yur == 1) {
											  teams [0].units.Add (citnow.unitsin [j1]);
											teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
											h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = citnow.unitsin [j1];
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											i += 1;
											citnow.unitsin.RemoveAt (j1);

										}
									}
									citnow.grabbed = true;
								}
							} else if (razdel [i] == "colony") {
							
							} else if (razdel [i] == "nalog") {
								int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
								resource [citnow.resdob] += g;
								citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
							} else if (razdel [i] == "openwiki") {
								wiki [myparse (razdel [i + 1])].open = true;
								i += 1;
							} else if (razdel [i] == "addunitan") {
								  teams [0].units.Add (myparse (razdel [i + 1]));
								teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
								h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
								h.GetComponent<uniter> ().race = 11;
								h.transform.position = teams [0].comgo.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
								h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
								h.GetComponent<uniter> ().m = chosedteam;
								h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
								teams [0].inst.Add (h);
								teams [0].now += 0.1f;
								i += 1;
							} else if (razdel [i] == "addan") {
								resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "pos") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								for (int j = 0; j < teams [0].units.Count; j++) {
									teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								}
								i += 2;
							} else if (razdel [i] == "anplen") {
								startgame (true);
							} else if (razdel [i] == "soplen") {
								startgame (false);
							} else if (razdel [i] == "poswout") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								i += 2;
							} else if (razdel [i] == "zachvatall") {
								for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
									main._m.races [citnow.race].com.cities [j1].race = 11;
								}
								Destroy (main._m.races [citnow.race].com);
								citnow.race = 11;
							}
						
						}
						if (!exit) {
							razdel.Clear ();
							talk.text = txtparse(citnow.l [dialnum].txt);
							talker.sprite = citnow.l [dialnum].talker;
					
							cityim.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;
						}
					}
				
				
				
				
				
				}
				if (num == 2) {//num2
					
					
					
					
					
					
					
					
					
					if (dialnum == -1) {
						if (citnow.d.d3 != -1) {
							dialnum = citnow.d.d3;
							lastdialnum = -1;
						} else {
							if (citnow.d.act3 != "none") {
								razdel.Add ("");
								for (int i = 0; i < citnow.d.act3.Length; i++) {
									if (citnow.d.act3 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act3 [i];
								}
								for (int i = 0; i < razdel.Count; i++) {
									if (razdel [i] == "quest") {
										quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "add") {
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
											resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
										}
										i += 2;
									} else if (razdel [i] == "addskill") {
										skillshave.Add (myparse (razdel [i + 1]));
										i += 1;
									} else if (razdel [i] == "del") {
										moneyplay ();
										resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
										else {
											citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
											citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
										}
										i += 2;
									} else if (razdel [i] == "exit") {
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else if (razdel [i] == "otn") {
										races [citnow.race].otnosh += myparse (razdel [i + 1]);
										i += 1;
									} else if (razdel [i] == "delunit") {
										if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
											int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
											Destroy (teams [0].inst [o]);
											teams [0].inst.RemoveAt (o);
											teams [0].now -= 0.1f;
										} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].mainunithp = -10;
										}
										i += 1;
									} else if (razdel [i] == "addunit") {
										if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
											  teams [0].units.Add (myparse (razdel [i + 1]));
											teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
											h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
											if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
												for (int j = 0; j < citnow.uns.Count; j++) {
													citnow.uns [j].SetActive (true);
												}
												teams [0].comgo.transform.position = citnow.sppos.transform.position;
												for (int j = 0; j < teams [0].units.Count; j++) {
													teams [0].inst [j].transform.position = citnow.sppos.transform.position;
												}
												citnow.inbattle = true;
												inbattle = true;
												citnow = null;
												dialog.SetActive (false); joy.SetActive(true);
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
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
											exit = true;
											break;
										} else {
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
									
											for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
												int yur = rnd.Next (5);
												if (yur == 1) {
													  teams [0].units.Add (citnow.unitsin [j1]);
													teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
													h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
													h.GetComponent<uniter> ().race = 11;
													h.transform.position = teams [0].comgo.gameObject.transform.position;
													h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
													h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
													h.GetComponent<uniter> ().m = chosedteam;
													h.GetComponent<uniter> ().num = citnow.unitsin [j1];
													teams [0].inst.Add (h);
													teams [0].now += 0.1f;
													i += 1;
													citnow.unitsin.RemoveAt (j1);
												}
											}
											citnow.grabbed = true;
										}
									} else if (razdel [i] == "colony") {
									
									} else if (razdel [i] == "nalog") {
										int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
										resource [citnow.resdob] += g;
										citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
									} else if (razdel [i] == "openwiki") {
										wiki [myparse (razdel [i + 1])].open = true;
										i += 1;
									} else if (razdel [i] == "addunitan") {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										i += 1;
									} else if (razdel [i] == "addan") {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "pos") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										}
										i += 2;
									} else if (razdel [i] == "anplen") {
										startgame (true);
									} else if (razdel [i] == "soplen") {
										startgame (false);
									} else if (razdel [i] == "poswout") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										i += 2;
									} else if (razdel [i] == "zachvatall") {
										for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
											main._m.races [citnow.race].com.cities [j1].race = 11;
										}
										Destroy (main._m.races [citnow.race].com);
										citnow.race = 11;
									}
								
								}
								razdel.Clear ();
							} else
								exit = true;
						}
					} else if (citnow.l [dialnum].d3 != -1) {
						lastdialnum = dialnum;
						dialnum = citnow.l [dialnum].d3; 
					} else {
						if (citnow.l [dialnum].act3 != "none") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].act3.Length; i++) {
								if (citnow.l [dialnum].act3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].act3 [i];
							}
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "add") {
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
									}
									i += 2;
								} else if (razdel [i] == "addskill") {
									skillshave.Add (myparse (razdel [i + 1]));
									i += 1;
								} else if (razdel [i] == "del") {
									moneyplay ();
									resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
									else {
										citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
										citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
									}
									i += 2;
								} else if (razdel [i] == "exit") {
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else if (razdel [i] == "otn") {
									races [citnow.race].otnosh += myparse (razdel [i + 1]);
									i += 1;
								} else if (razdel [i] == "delunit") {
									if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
										int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
										Destroy (teams [0].inst [o]);
										teams [0].inst.RemoveAt (o);
										teams [0].now -= 0.1f;
									} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].mainunithp = -10;
									}
									i += 1;
								} else if (razdel [i] == "addunit") {
									if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
										if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
											for (int j = 0; j < citnow.uns.Count; j++) {
												citnow.uns [j].SetActive (true);
											}
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else {
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
										for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
											int yur = rnd.Next (5);
											if (yur == 1) {
												  teams [0].units.Add (citnow.unitsin [j1]);
												teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
												h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
												h.GetComponent<uniter> ().race = 11;
												h.transform.position = teams [0].comgo.gameObject.transform.position;
												h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
												h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
												h.GetComponent<uniter> ().m = chosedteam;
												h.GetComponent<uniter> ().num = citnow.unitsin [j1];
												teams [0].inst.Add (h);
												teams [0].now += 0.1f;
												i += 1;
												citnow.unitsin.RemoveAt (j1);
											}
										}
										citnow.grabbed = true;
									}
								} else if (razdel [i] == "colony") {
								
								} else if (razdel [i] == "nalog") {
									int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
									resource [citnow.resdob] += g;
									citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
								} else if (razdel [i] == "openwiki") {
									wiki [myparse (razdel [i + 1])].open = true;
									i += 1;
								} else if (razdel [i] == "addunitan") {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									i += 1;
								} else if (razdel [i] == "addan") {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "pos") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									}
									i += 2;
								} else if (razdel [i] == "anplen") {
									startgame (true);
								} else if (razdel [i] == "soplen") {
									startgame (false);
								} else if (razdel [i] == "poswout") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									i += 2;
								} else if (razdel [i] == "zachvatall") {
									for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
										main._m.races [citnow.race].com.cities [j1].race = 11;
									}
									Destroy (main._m.races [citnow.race].com);
									citnow.race = 11;
								}
							
							}
							razdel.Clear ();
						} else
							exit = true;
					}
					if (!exit) {
						if (citnow.l [dialnum].usl1 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl1.Length; i++) {
								if (citnow.l [dialnum].usl1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl1 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans1.text = citnow.l [dialnum].a1;
								canans [0] = true;
							} else {
								ans1.text = "";
								canans [0] = false;
							}
							razdel.Clear ();
						} else {
							ans1.text = citnow.l [dialnum].a1;
							canans [0] = true;
						}
						if (citnow.l [dialnum].usl2 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl2.Length; i++) {
								if (citnow.l [dialnum].usl2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl2 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans2.text = citnow.l [dialnum].a2;
								canans [1] = true;
							} else {
								ans2.text = "";
								canans [1] = false;
							}
							razdel.Clear ();
						} else {
							ans2.text = citnow.l [dialnum].a2;
							canans [1] = true;
						}
						
						if (citnow.l [dialnum].usl3 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl3.Length; i++) {
								if (citnow.l [dialnum].usl3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl3 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans3.text = citnow.l [dialnum].a3;
								canans [2] = true;
							} else {
								ans3.text = "";
								canans [2] = false;
							}
							razdel.Clear ();
						} else {
							ans3.text = citnow.l [dialnum].a3;
							canans [2] = true;
						}
						
						
						
						if (citnow.l [dialnum].usl4 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl4.Length; i++) {
								if (citnow.l [dialnum].usl4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl4 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans4.text = citnow.l [dialnum].a4;
								canans [3] = true;
							} else {
								ans4.text = "";
								canans [3] = false;
							}
							razdel.Clear ();
						} else {
							ans4.text = citnow.l [dialnum].a4;
							canans [3] = true;
						}
					
					
						razdel.Add ("");
						if (lastdialnum == -1) {
							if (num == 0)
								for (int i = 0; i < citnow.d.act1.Length; i++) {
									if (citnow.d.act1 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act1 [i];
								}
							else if (num == 1)
								for (int i = 0; i < citnow.d.act2.Length; i++) {
									if (citnow.d.act2 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act2 [i];
								}
							else if (num == 2)
								for (int i = 0; i < citnow.d.act3.Length; i++) {
									if (citnow.d.act3 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act3 [i];
								}
							else
								for (int i = 0; i < citnow.d.act4.Length; i++) {
									if (citnow.d.act4 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act4 [i];
								}
						} else if (num == 0)
							for (int i = 0; i < citnow.l [lastdialnum].act1.Length; i++) {
								if (citnow.l [lastdialnum].act1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act1 [i];
							}
						else if (num == 1)
							for (int i = 0; i < citnow.l [lastdialnum].act2.Length; i++) {
								if (citnow.l [lastdialnum].act2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act2 [i];
							}
						else if (num == 2)
							for (int i = 0; i < citnow.l [lastdialnum].act3.Length; i++) {
								if (citnow.l [lastdialnum].act3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act3 [i];
							}
						else
							for (int i = 0; i < citnow.l [lastdialnum].act4.Length; i++) {
								if (citnow.l [lastdialnum].act4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act4 [i];
							}

						for (int i = 0; i < razdel.Count; i++) {
							if (razdel [i] == "quest") {
								quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "add") {
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
								}
								i += 2;
							} else if (razdel [i] == "addskill") {
								skillshave.Add (myparse (razdel [i + 1]));
								i += 1;
							} else if (razdel [i] == "del") {
								moneyplay ();
								resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
								else {
									citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
									citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
								}
								i += 2;
							} else if (razdel [i] == "exit") {
								citnow = null;
								dialog.SetActive (false); joy.SetActive(true);
								exit = true;
								break;
							} else if (razdel [i] == "otn") {
								races [citnow.race].otnosh += myparse (razdel [i + 1]);
								i += 1;
							} else if (razdel [i] == "delunit") {
								if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
									int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
									Destroy (teams [0].inst [o]);
									teams [0].inst.RemoveAt (o);
									teams [0].now -= 0.1f;
								} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].mainunithp = -10;
								}
								i += 1;
							} else if (razdel [i] == "addunit") {
								if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
									if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
										for (int j = 0; j < citnow.uns.Count; j++) {
											citnow.uns [j].SetActive (true);
										}
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
									teams [0].comgo.transform.position = citnow.sppos.transform.position;
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = citnow.sppos.transform.position;
									}
									citnow.inbattle = true;
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									inbattle = true;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else {
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
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
							
									for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
										int yur = rnd.Next (5);
										if (yur == 1) {
											  teams [0].units.Add (citnow.unitsin [j1]);
											teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
											h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = citnow.unitsin [j1];
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											i += 1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
									citnow.grabbed = true;
								}
							} else if (razdel [i] == "colony") {
							
							} else if (razdel [i] == "nalog") {
								int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
								resource [citnow.resdob] += g;
								citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
							} else if (razdel [i] == "openwiki") {
								wiki [myparse (razdel [i + 1])].open = true;
								i += 1;
							} else if (razdel [i] == "addunitan") {
								  teams [0].units.Add (myparse (razdel [i + 1]));
								teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
								h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
								h.GetComponent<uniter> ().race = 11;
								h.transform.position = teams [0].comgo.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
								h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
								h.GetComponent<uniter> ().m = chosedteam;
								h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
								teams [0].inst.Add (h);
								teams [0].now += 0.1f;
								i += 1;
							} else if (razdel [i] == "addan") {
								resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "pos") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								for (int j = 0; j < teams [0].units.Count; j++) {
									teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								}
								i += 2;
							} else if (razdel [i] == "anplen") {
								startgame (true);
							} else if (razdel [i] == "soplen") {
								startgame (false);
							} else if (razdel [i] == "poswout") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								i += 2;
							} else if (razdel [i] == "zachvatall") {
								for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
									main._m.races [citnow.race].com.cities [j1].race = 11;
								}
								Destroy (main._m.races [citnow.race].com);
								citnow.race = 11;
							}
						
						}
						if (!exit) {
							razdel.Clear ();
							talk.text = txtparse(citnow.l [dialnum].txt);
							talker.sprite = citnow.l [dialnum].talker;
						
							cityim.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;
						}
					}
					
					
					
					
					
					
				}
				if (num == 3) {//num3
						
						
						
						
						
						
						
						
						
					if (dialnum == -1) {
						if (citnow.d.d4 != -1) {
							dialnum = citnow.d.d4;
							lastdialnum = -1;
						} else {
							if (citnow.d.act4 != "none") {
								razdel.Add ("");
								for (int i = 0; i < citnow.d.act4.Length; i++) {
									if (citnow.d.act4 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act4 [i];
								}
								for (int i = 0; i < razdel.Count; i++) {
									if (razdel [i] == "quest") {
										quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "add") {
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
											resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
										}
										i += 2;
									} else if (razdel [i] == "addskill") {
										skillshave.Add (myparse (razdel [i + 1]));
										i += 1;
									} else if (razdel [i] == "del") {
										moneyplay ();
										resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
										if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
											citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
										else {
											citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
											citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
										}
										i += 2;
									} else if (razdel [i] == "exit") {
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else if (razdel [i] == "otn") {
										races [citnow.race].otnosh += myparse (razdel [i + 1]);
										i += 1;
									} else if (razdel [i] == "delunit") {
										if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
											int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
											Destroy (teams [0].inst [o]);
											teams [0].inst.RemoveAt (o);
											teams [0].now -= 0.1f;
										} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
											citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
											teams [0].mainunithp = -10;
										}
										i += 1;
									} else if (razdel [i] == "addunit") {
										if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
											  teams [0].units.Add (myparse (razdel [i + 1]));
											teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = teams [0].comgo.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
											h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
											if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
												for (int j = 0; j < citnow.uns.Count; j++) {
													citnow.uns [j].SetActive (true);
												}
												teams [0].comgo.transform.position = citnow.sppos.transform.position;
												for (int j = 0; j < teams [0].units.Count; j++) {
													teams [0].inst [j].transform.position = citnow.sppos.transform.position;
												}
												citnow.inbattle = true;
												inbattle = true;
												citnow = null;
												dialog.SetActive (false); joy.SetActive(true);
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
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
											exit = true;
											break;
										} else {
											if (citnow.nowhasarrow)
												Destroy (citnow.arrow);
											Destroy (citnow.gameObject);
											if (citnow.canbedest)
												globalsob [citnow.destroyglsob] = 1;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
									
											for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
												int yur = rnd.Next (5);
												if (yur == 1) {
													  teams [0].units.Add (citnow.unitsin [j1]);
													teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
													h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
													h.GetComponent<uniter> ().race = 11;
													h.transform.position = teams [0].comgo.gameObject.transform.position;
													h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
													h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
													h.GetComponent<uniter> ().m = chosedteam;
													h.GetComponent<uniter> ().num = citnow.unitsin [j1];
													teams [0].inst.Add (h);
													teams [0].now += 0.1f;
													i += 1;
													citnow.unitsin.RemoveAt (j1);
												}
											}
											citnow.grabbed = true;
										}
									} else if (razdel [i] == "colony") {
									
									} else if (razdel [i] == "nalog") {
										int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
										resource [citnow.resdob] += g;
										citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
									} else if (razdel [i] == "openwiki") {
										wiki [myparse (razdel [i + 1])].open = true;
										i += 1;
									} else if (razdel [i] == "addunitan") {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										i += 1;
									} else if (razdel [i] == "addan") {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										i += 2;
									} else if (razdel [i] == "pos") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										}
										i += 2;
									} else if (razdel [i] == "anplen") {
										startgame (true);
									} else if (razdel [i] == "soplen") {
										startgame (false);
									} else if (razdel [i] == "poswout") {
										teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
										i += 2;
									} else if (razdel [i] == "zachvatall") {
										for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
											main._m.races [citnow.race].com.cities [j1].race = 11;
										}
										Destroy (main._m.races [citnow.race].com);
										citnow.race = 11;
									}
								
								}
								razdel.Clear ();
							} else
								exit = true;
						}
					} else if (citnow.l [dialnum].d4 != -1) {
						lastdialnum = dialnum;
						dialnum = citnow.l [dialnum].d4; 
					} else {
						if (citnow.l [dialnum].act4 != "none") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].act4.Length; i++) {
								if (citnow.l [dialnum].act4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].act4 [i];
							}
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "add") {
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
										resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
									}
									i += 2;
								} else if (razdel [i] == "addskill") {
									skillshave.Add (myparse (razdel [i + 1]));
									i += 1;
								} else if (razdel [i] == "del") {
									moneyplay ();
									resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
									if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
									else {
										citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
										citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
									}
									i += 2;
								} else if (razdel [i] == "exit") {
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else if (razdel [i] == "otn") {
									races [citnow.race].otnosh += myparse (razdel [i + 1]);
									i += 1;
								} else if (razdel [i] == "delunit") {
									if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
										int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
										Destroy (teams [0].inst [o]);
										teams [0].inst.RemoveAt (o);
										teams [0].now -= 0.1f;
									} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
										citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
										teams [0].mainunithp = -10;
									}
									i += 1;
								} else if (razdel [i] == "addunit") {
									if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
										  teams [0].units.Add (myparse (razdel [i + 1]));
										teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
										h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
										h.GetComponent<uniter> ().race = 11;
										h.transform.position = teams [0].comgo.gameObject.transform.position;
										h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
										h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
										h.GetComponent<uniter> ().m = chosedteam;
										h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
										teams [0].inst.Add (h);
										teams [0].now += 0.1f;
										citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
										if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
											for (int j = 0; j < citnow.uns.Count; j++) {
												citnow.uns [j].SetActive (true);
											}
											teams [0].comgo.transform.position = citnow.sppos.transform.position;
											for (int j = 0; j < teams [0].units.Count; j++) {
												teams [0].inst [j].transform.position = citnow.sppos.transform.position;
											}
											citnow.inbattle = true;
											inbattle = true;
											citnow = null;
											dialog.SetActive (false); joy.SetActive(true);
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
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
										exit = true;
										break;
									} else {
										if (citnow.nowhasarrow)
											Destroy (citnow.arrow);
										Destroy (citnow.gameObject);
										if (citnow.canbedest)
											globalsob [citnow.destroyglsob] = 1;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
								
										for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
											int yur = rnd.Next (5);
											if (yur == 1) {
												  teams [0].units.Add (citnow.unitsin [j1]);
												teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
												h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
												h.GetComponent<uniter> ().race = 11;
												h.transform.position = teams [0].comgo.gameObject.transform.position;
												h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
												h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
												h.GetComponent<uniter> ().m = chosedteam;
												h.GetComponent<uniter> ().num = citnow.unitsin [j1];
												teams [0].inst.Add (h);
												teams [0].now += 0.1f;
												i += 1;
												citnow.unitsin.RemoveAt (j1);
											}
										}
										citnow.grabbed = true;
									}
								} else if (razdel [i] == "colony") {
								
								} else if (razdel [i] == "nalog") {
									int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
									resource [citnow.resdob] += g;
									citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
								} else if (razdel [i] == "openwiki") {
									wiki [myparse (razdel [i + 1])].open = true;
									i += 1;
								} else if (razdel [i] == "addunitan") {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = teams [0].comgo.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									i += 1;
								} else if (razdel [i] == "addan") {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									i += 2;
								} else if (razdel [i] == "pos") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									}
									i += 2;
								} else if (razdel [i] == "anplen") {
									startgame (true);
								} else if (razdel [i] == "soplen") {
									startgame (false);
								} else if (razdel [i] == "poswout") {
									teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
									i += 2;
								} else if (razdel [i] == "zachvatall") {
									for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
										main._m.races [citnow.race].com.cities [j1].race = 11;
									}
									Destroy (main._m.races [citnow.race].com);
									citnow.race = 11;
								}
							
							}
							razdel.Clear ();
						} else
							exit = true;
					}
					if (!exit) {
						if (citnow.l [dialnum].usl1 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl1.Length; i++) {
								if (citnow.l [dialnum].usl1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl1 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans1.text = citnow.l [dialnum].a1;
								canans [0] = true;
							} else {
								ans1.text = "";
								canans [0] = false;
							}
							razdel.Clear ();
						} else {
							ans1.text = citnow.l [dialnum].a1;
							canans [0] = true;
						}
						if (citnow.l [dialnum].usl2 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl2.Length; i++) {
								if (citnow.l [dialnum].usl2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl2 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans2.text = citnow.l [dialnum].a2;
								canans [1] = true;
							} else {
								ans2.text = "";
								canans [1] = false;
							}
							razdel.Clear ();
						} else {
							ans2.text = citnow.l [dialnum].a2;
							canans [1] = true;
						}
							
						if (citnow.l [dialnum].usl3 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl3.Length; i++) {
								if (citnow.l [dialnum].usl3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl3 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans3.text = citnow.l [dialnum].a3;
								canans [2] = true;
							} else {
								ans3.text = "";
								canans [2] = false;
							}
							razdel.Clear ();
						} else {
							ans3.text = citnow.l [dialnum].a3;
							canans [2] = true;
						}
							
							
							
						if (citnow.l [dialnum].usl4 != "") {
							razdel.Add ("");
							for (int i = 0; i < citnow.l [dialnum].usl4.Length; i++) {
								if (citnow.l [dialnum].usl4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [dialnum].usl4 [i];
							}
							bool bo = true;
							for (int i = 0; i < razdel.Count; i++) {
								if (razdel [i] == "quest") {
									if (quests [myparse (razdel [i + 1])] != myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "otn") {
									if (races [citnow.race].otnosh < myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "item") {
									if (resource [myparse (razdel [i + 1])] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "race") {
									if (citnow.race != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "you") {
									if (teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "otn-") {
									if (races [citnow.race].otnosh >= myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit") {
									if (!teams [0].units.Contains (myparse (razdel [i + 1])) && teams [0].mainunit != myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unit-") {
									if (teams [0].units.Contains (myparse (razdel [i + 1])) || teams [0].mainunit == myparse (razdel [i + 1]))
										bo = false;
									i += 1;
								} else if (razdel [i] == "unitin") {
									if (!citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1])))
										bo = false;
									i += 1;
								} else if (razdel [i] == "itemin") {
									if (!citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
										bo = false;
									else if (citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] < myparse (razdel [i + 2]))
										bo = false;
									i += 2;
								} else if (razdel [i] == "your") {
									if (citnow.race != 11)
										bo = false;
								} else if (razdel [i] == "notyour") {
									if (citnow.race == 11)
										bo = false;
								}
							}
							if (bo) {
								ans4.text = citnow.l [dialnum].a4;
								canans [3] = true;
							} else {
								ans4.text = "";
								canans [3] = false;
							}
							razdel.Clear ();
						} else {
							ans4.text = citnow.l [dialnum].a4;
							canans [3] = true;
						}


							
						razdel.Add ("");
						if (lastdialnum == -1) {
							if (num == 0)
								for (int i = 0; i < citnow.d.act1.Length; i++) {
									if (citnow.d.act1 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act1 [i];
								}
							else if (num == 1)
								for (int i = 0; i < citnow.d.act2.Length; i++) {
									if (citnow.d.act2 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act2 [i];
								}
							else if (num == 2)
								for (int i = 0; i < citnow.d.act3.Length; i++) {
									if (citnow.d.act3 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act3 [i];
								}
							else
								for (int i = 0; i < citnow.d.act4.Length; i++) {
									if (citnow.d.act4 [i] == ' ') {
										razdel.Add ("");
									} else
										razdel [razdel.Count - 1] += citnow.d.act4 [i];
								}
						} else if (num == 0)
							for (int i = 0; i < citnow.l [lastdialnum].act1.Length; i++) {
								if (citnow.l [lastdialnum].act1 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act1 [i];
							}
						else if (num == 1)
							for (int i = 0; i < citnow.l [lastdialnum].act2.Length; i++) {
								if (citnow.l [lastdialnum].act2 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act2 [i];
							}
						else if (num == 2)
							for (int i = 0; i < citnow.l [lastdialnum].act3.Length; i++) {
								if (citnow.l [lastdialnum].act3 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act3 [i];
							}
						else
							for (int i = 0; i < citnow.l [lastdialnum].act4.Length; i++) {
								if (citnow.l [lastdialnum].act4 [i] == ' ') {
									razdel.Add ("");
								} else
									razdel [razdel.Count - 1] += citnow.l [lastdialnum].act4 [i];
							}
							
						for (int i = 0; i < razdel.Count; i++) {
							if (razdel [i] == "quest") {
								quests [myparse (razdel [i + 1])] = myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "add") {
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])) && citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] >= myparse (razdel [i + 2])) {
									resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] -= myparse (razdel [i + 2]);
								}
								i += 2;
							} else if (razdel [i] == "addskill") {
								skillshave.Add (myparse (razdel [i + 1]));
								i += 1;
							} else if (razdel [i] == "del") {
								moneyplay ();
								resource [myparse (razdel [i + 1])] -= myparse (razdel [i + 2]);
								if (citnow.mainhouse.resin.Contains (myparse (razdel [i + 1])))
									citnow.mainhouse.resincol [citnow.mainhouse.resin.IndexOf (myparse (razdel [i + 1]))] += myparse (razdel [i + 2]);
								else {
									citnow.mainhouse.resin.Add (myparse (razdel [i + 1]));
									citnow.mainhouse.resincol.Add (myparse (razdel [i + 2]));
								}
								i += 2;
							} else if (razdel [i] == "exit") {
								citnow = null;
								dialog.SetActive (false); joy.SetActive(true);
								exit = true;
								break;
							} else if (razdel [i] == "otn") {
								races [citnow.race].otnosh += myparse (razdel [i + 1]);
								i += 1;
							} else if (razdel [i] == "delunit") {
								if (teams [0].units.Contains (myparse (razdel [i + 1]))) {
									int o = teams [0].units.IndexOf (myparse (razdel [i + 1]));
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].unsdvig.RemoveAt (o); teams [0].units.RemoveAt (o);
									Destroy (teams [0].inst [o]);
									teams [0].inst.RemoveAt (o);
									teams [0].now -= 0.1f;
								} else if (teams [0].mainunit == myparse (razdel [i + 1])) {
									citnow.mainhouse.unitsin.Add (myparse (razdel [i + 1]));
									teams [0].mainunithp = -10;
								}
								i += 1;
							} else if (razdel [i] == "addunit") {
								if (citnow.mainhouse.unitsin.Contains (myparse (razdel [i + 1]))) {
									  teams [0].units.Add (myparse (razdel [i + 1]));
									teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
									h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
									h.GetComponent<uniter> ().race = 11;
									h.transform.position = citnow.gameObject.transform.position;
									h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
									h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
									h.GetComponent<uniter> ().m = chosedteam;
									h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
									teams [0].inst.Add (h);
									teams [0].now += 0.1f;
									citnow.mainhouse.unitsin.RemoveAt (citnow.mainhouse.unitsin.IndexOf (myparse (razdel [i + 1])));
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
									if (((int)citnow.uns.Count * 1.5f) >= teams [0].units.Count + 1) {
										for (int j = 0; j < citnow.uns.Count; j++) {
											citnow.uns [j].SetActive (true);
										}
										teams [0].comgo.transform.position = citnow.sppos.transform.position;
										for (int j = 0; j < teams [0].units.Count; j++) {
											teams [0].inst [j].transform.position = citnow.sppos.transform.position;
										}
										citnow.inbattle = true;
										inbattle = true;
										citnow = null;
										dialog.SetActive (false); joy.SetActive(true);
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
									teams [0].comgo.transform.position = citnow.sppos.transform.position;
									for (int j = 0; j < teams [0].units.Count; j++) {
										teams [0].inst [j].transform.position = citnow.sppos.transform.position;
									}
									citnow.inbattle = true;
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									inbattle = true;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
									exit = true;
									break;
								} else {
									if (citnow.nowhasarrow)
										Destroy (citnow.arrow);
									Destroy (citnow.gameObject);
									if (citnow.canbedest)
										globalsob [citnow.destroyglsob] = 1;
									citnow = null;
									dialog.SetActive (false); joy.SetActive(true);
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
							
									for (int j1 = 0; j1 < citnow.unitsin.Count; j1++) {
										int yur = rnd.Next (5);
										if (yur == 1) {
											  teams [0].units.Add (citnow.unitsin [j1]);
											teams [0].unitshp.Add (units [citnow.unitsin [j1] - 1].hp);
											h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));
											h.GetComponent<uniter> ().race = 11;
											h.transform.position = citnow.gameObject.transform.position;
											h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [citnow.unitsin [j1] - 1].sp;
											h.GetComponent<uniter> ().fly = units [citnow.unitsin [j1] - 1].fly;
											h.GetComponent<uniter> ().m = chosedteam;
											h.GetComponent<uniter> ().num = citnow.unitsin [j1];
											teams [0].inst.Add (h);
											teams [0].now += 0.1f;
											i += 1;
											citnow.unitsin.RemoveAt (j1);
										}
									}
									citnow.grabbed = true;
								}
							} else if (razdel [i] == "colony") {
							} else if (razdel [i] == "nalog") { 
								int g = rnd.Next (citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2) + citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] / 2;
								resource [citnow.resdob] += g;
								citnow.resincol [citnow.resin.IndexOf (citnow.resdob)] -= g;
							} else if (razdel [i] == "openwiki") {
								wiki [myparse (razdel [i + 1])].open = true;
								i += 1;
							} else if (razdel [i] == "addunitan") {
								  teams [0].units.Add (myparse (razdel [i + 1]));
								teams [0].unitshp.Add (units [myparse (razdel [i + 1]) - 1].hp);
								h = Instantiate (unitpref); teams [0].unsdvig.Add (new Vector3 (rnd.Next (-45, 45) / 10.0f, rnd.Next (-29, 29) / 10.0f));

								h.GetComponent<uniter> ().race = 11;
								h.transform.position = teams [0].comgo.gameObject.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [myparse (razdel [i + 1]) - 1].sp;
								h.GetComponent<uniter> ().fly = units [myparse (razdel [i + 1]) - 1].fly;
								h.GetComponent<uniter> ().m = chosedteam;
								h.GetComponent<uniter> ().num = myparse (razdel [i + 1]);
								teams [0].inst.Add (h);
								teams [0].now += 0.1f;
								i += 1;
							} else if (razdel [i] == "addan") {
								resource [myparse (razdel [i + 1])] += myparse (razdel [i + 2]);
								i += 2;
							} else if (razdel [i] == "pos") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								for (int j = 0; j < teams [0].units.Count; j++) {
									teams [0].inst [j].transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								}
								i += 2;
							} else if (razdel [i] == "anplen") {
								startgame (true);
							} else if (razdel [i] == "soplen") {
								startgame (false);
							} else if (razdel [i] == "poswout") {
								teams [0].comgo.transform.position = new Vector3 (float.Parse (razdel [i + 1]), float.Parse (razdel [i + 2]), 0);
								i += 2;
							} else if (razdel [i] == "zachvatall") {
								for (int j1 = 0; j1 < main._m.races [citnow.race].com.cities.Count; j1++) {
									main._m.races [citnow.race].com.cities [j1].race = 11;
								}
								Destroy (main._m.races [citnow.race].com);
								citnow.race = 11;
							}
							
						}
						if (!exit) {
							razdel.Clear ();





							talk.text = txtparse(citnow.l [dialnum].txt);
							talker.sprite = citnow.l [dialnum].talker;
							
							cityim.sprite = citnow.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite;

						}
					}
				}
				


				if (teams [0].units.Count > 0)
					u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
				else
					u1.sprite = nulsp;
				if (teams [0].units.Count > 1)
					u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
				else
					u2.sprite = nulsp;
				if (teams [0].units.Count > 2)
					u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
				else
					u3.sprite = nulsp;
				if (teams [0].units.Count > 3)
					u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
				else
					u4.sprite = nulsp;
				if (teams [0].units.Count > 4)
					u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
				else
					u5.sprite = nulsp;



			}
		}
	}

	public void wikiopen ()
	{
		wikigo.SetActive (true);
		wikinext (0);
		joy.SetActive (false);
		iswikiopen = true;
	}

	public void wikiclose ()
	{
		wikigo.SetActive (false);
		joy.SetActive (true);
		iswikiopen = false;
	}

	public void wikinext (int sdf)
	{
		chosedwiki [0] = -1;
		chosedwiki [1] = -1;
		chosedwiki [2] = -1;
		chosedwiki [3] = -1;
		chosedwiki [4] = -1;
		List<int> yh = new List<int> ();
		if (wikiname == "unit")
			yh = unitswiki;
		else if (wikiname == "universe")
			yh = universewiki;
		else if (wikiname == "res")
			yh = reswiki;
		else if (wikiname == "race")
			yh = racewiki;
		else if (wikiname == "city")
			yh = citywiki;
		else if (wikiname == "logic")
			yh = logicwiki;
		wikisdvig = (wikisdvig + sdf) % yh.Count;

		bool found = false;

		for (int i = wikisdvig; i < yh.Count; i++) {
			if (wiki [yh [i]].open) {
				wiki1.GetComponent<Text> ().text = wiki [yh [i]].heading;
				chosedwiki [0] = yh [i];
				found = true;
				break;
			}
		}
		if (!found && wikisdvig != 0) {
			for (int i = 0; i < wikisdvig; i++) {
				if (wiki [yh [i]].open) {
					wiki1.GetComponent<Text> ().text = wiki [yh [i]].heading;
					chosedwiki [0] = yh [i];
					found = true;
					break;
				}
			}
		}
		if (found) {

			found = false;
			for (int i = wikisdvig; i < yh.Count; i++) {
				if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
					wiki2.GetComponent<Text> ().text = wiki [yh [i]].heading;
					chosedwiki [1] = yh [i];
					found = true;
					break;
				}
			}
			if (!found && wikisdvig != 0) {
				for (int i = 0; i < wikisdvig; i++) {
					if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
						wiki2.GetComponent<Text> ().text = wiki [yh [i]].heading;
						chosedwiki [1] = yh [i];
						found = true;
						break;
					}
				}
			}
			if (found) {

				found = false;

				for (int i = wikisdvig; i < yh.Count; i++) {
					if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
						wiki3.GetComponent<Text> ().text = wiki [yh [i]].heading;
						chosedwiki [2] = yh [i];
						found = true;
						break;
					}
				}
				if (!found && wikisdvig != 0) {
					for (int i = 0; i < wikisdvig; i++) {
						if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
							wiki3.GetComponent<Text> ().text = wiki [yh [i]].heading;
							chosedwiki [2] = yh [i];
							found = true;
							break;
						}
					}
				}
				if (found) {

					found = false;

					for (int i = wikisdvig; i < yh.Count; i++) {
						if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
							wiki4.GetComponent<Text> ().text = wiki [yh [i]].heading;
							chosedwiki [3] = yh [i];
							found = true;
							break;
						}
					}
					if (!found && wikisdvig != 0) {
						for (int i = 0; i < wikisdvig; i++) {
							if (wiki [yh [i]].open && !chosedwiki.Contains (yh [i])) {
								wiki4.GetComponent<Text> ().text = wiki [yh [i]].heading;
								chosedwiki [3] = yh [i];
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
								chosedwiki [4] = yh [i];
								found = true;
								break;
							}
						}
						if (!found && wikisdvig != 0) {
							for (int i = 0; i < wikisdvig; i++) {
								if (wiki [yh [i]].open && !chosedwiki.Contains (i)) {
									wiki5.GetComponent<Text> ().text = wiki [yh [i]].heading;
									chosedwiki [4] = yh [i];
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

	public void wikichoose (string wiki11)
	{
		wikiname = wiki11;
		wikinext (0);
	}

	public void wikichooseitem (int num)
	{
		wikihead.GetComponent<Text> ().text = wiki [chosedwiki [num]].heading;
		wikitxt.GetComponent<Text> ().text = wiki [chosedwiki [num]].txt;
		wikisp.GetComponent<Image> ().sprite = wiki [chosedwiki [num]].sp;
		if (wiki [chosedwiki [num]].type == "unit")
			wikitxt.GetComponent<Text> ().text += "\n\nУрон: " + units [wiki [chosedwiki [num]].num - 1].dmg + "\nЗдоровье: " + units [wiki [chosedwiki [num]].num - 1].hp;
		else if (wiki [chosedwiki [num]].type == "res")
			wikitxt.GetComponent<Text> ().text += "\n\nУ вас есть: " + resource [wiki [chosedwiki [num]].num];
	}

	public void gotot (int fow)
	{
		chosingtsel = true;
		mc.fieldOfView = fow;
	}

	public void gameopen (int num)
	{
		musicplay (fonmus);
		gameopennum = num;
		bool loaded = true;
		games.SetActive (false);
		canv.SetActive (true);
		if (num == 1) {
			
			if (PlayerPrefs.GetString ("gamecreated1") == "1") {
				Debug.Log (PlayerPrefs.GetString ("quests1"));
				Debug.Log (PlayerPrefs.GetString ("res1"));
				Debug.Log (PlayerPrefs.GetString ("globalsob1"));
				Debug.Log (PlayerPrefs.GetString ("wiki1"));
				Debug.Log (PlayerPrefs.GetString ("cities1"));
				Debug.Log (PlayerPrefs.GetString ("teams1"));
				Debug.Log (PlayerPrefs.GetString ("buildings1"));
				Debug.Log (PlayerPrefs.GetString ("skills1"));
				Debug.Log ("");

				razdel.Clear ();
				razdel.Add ("");
				string s = PlayerPrefs.GetString ("quests1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					quests [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("res1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					resource [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("globalsob1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					globalsob [i - 1] = myparse (razdel [i]);
				}

				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("skills1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				if(y>0)
					for (int i = 1; i < razdel.Count; i++) {
						skillshave.Add(myparse (razdel [i]));
					}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("wiki1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					if (myparse (razdel [i]) == 1)
						wiki [i - 1].open = true;
					else
						wiki [i - 1].open = false;
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("cities1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < y + 1; i++) {
					allcities [i - 1].race = myparse (razdel [i]);
				}
				for (int i = y + 1; i < 2 * y + 1; i++) {
					allcities [i - y - 1].grabbed = (myparse (razdel [i]) == 1) ? true : false;
				}
				for (int i = 0; i < y; i++) {
					allcities [i].unitsin.Clear ();
					allcities [i].alldef.Clear ();
					allcities [i].resin.Clear ();
					allcities [i].resincol.Clear ();
				}
				int[] p = new int[y];
				for (int i = 2 * y + 1; i < 3 * y + 1; i++) {
					p [i - 2 * y - 1] = myparse (razdel [i]);
				}
				int psum = 0;
				for (int i = 0; i < y; i++) {
					if(p[i]!=0)
					for (int j = 0; j < p [i]; j++) {
						allcities [i].unitsin.Add (myparse (razdel [3 * y + 1 + psum + j]));
					}
					psum += p [i];
				}
				int lsum = psum;
				psum = 0;
				for (int i = 3 * y + 1+lsum; i < 4 * y + 1+lsum; i++) {
					p [i - 3 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
					for (int j = 0; j < p [i]; j++) {
						allcities [i].resin.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
					}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
					for (int j = 0; j < p [i]; j++) {
						allcities [i].resincol.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
					}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i = 4 * y + 1+lsum; i < 5 * y + 1+lsum; i++) {
					p [i - 4 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
					for (int j = 0; j < p [i]; j++) {
						allcities [i].alldef.Add (myparse (razdel [5 * y + 1+lsum + psum + j]));
					}
					psum += p [i];
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("teams1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int g = -1;
				bool cameraplaced = false;
				for (int i = 0; i < 1; i++) {
					g += 1;
					if (razdel [g] == "1") {
						g += 1;
						teams [0].name = razdel [g];
						h = Instantiate (compref);
						g += 1;
						teams [0].mainunit = myparse (razdel [g]);
						h.GetComponent<mainunit> ().num = myparse (razdel [g]);
						g += 1;
						teams [0].mainunithp = myparse (razdel [g]);
						h.GetComponent<mainunit> ().m = i;
						g += 2;
						h.transform.position = new Vector3 (float.Parse (razdel [g - 1]), float.Parse (razdel [g]));
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [h.GetComponent<mainunit> ().num - 1].sp;
						teams [0].comgo = h;
						g += 1;
						int r = myparse (razdel [g]);
						teams [0].now = r * 0.1f;
						if (!cameraplaced) {
							mc.transform.SetParent (teams [0].comgo.transform);
							mc.transform.localPosition = new Vector3 (0, 0, -10);
							mc.fieldOfView = 50;
							cameraplaced = true;
							chosedteam = i;
						}
						if (r != 0) {
							g += 1;
							for (int j = 0; j < r; j++) {
								teams [0].units.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < r; j++) {
								teams [0].unitshp.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < 2*r; j++) {
								teams [0].unsdvig.Add (new Vector3(float.Parse (razdel [g + j]),float.Parse (razdel [g + j+1])));
								j++;
							}
							g += 2*r - 1;
							for (int j = 0; j < teams [0].units.Count; j++) {
								h = Instantiate (unitpref);
								h.GetComponent<uniter> ().topresl = teams [0].comgo;
								h.GetComponent<uniter> ().m = i;
								h.GetComponent<uniter> ().num = teams [0].units [j];
								h.GetComponent<uniter> ().fly = units [teams [0].units [j] - 1].fly;
								h.transform.position = teams [0].comgo.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [j] - 1].sp;
								teams [0].inst.Add (h);
							}
						}
					}
				}
				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("buildings1");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse(razdel [0]);
				if(y!=0){
					for (int i = 1; i < y + 1; i++) {
						buildingsbuilded.Add (myparse(razdel [i]));
					}
					for (int i = y+1; i < 3*y + 1; i++) {
						buildingsbuildedpos.Add (new Vector3(float.Parse(razdel [i]),float.Parse(razdel[i+1]),0));
						i += 1;
					}
					for (int i = 0; i < buildingsbuilded.Count; i++) {
						h = Instantiate (allbuildings [buildingsbuilded [i]]);
						h.transform.position = buildingsbuildedpos [i];
					}
				}

				commander.sprite = units [teams [0].mainunit - 1].sp;
				if (teams [0].units.Count > 0)
					u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
				else
					u1.sprite = nulsp;
				if (teams [0].units.Count > 1)
					u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
				else
					u2.sprite = nulsp;
				if (teams [0].units.Count > 2)
					u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
				else
					u3.sprite = nulsp;
				if (teams [0].units.Count > 3)
					u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
				else
					u4.sprite = nulsp;
				if (teams [0].units.Count > 4)
					u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
				else
					u5.sprite = nulsp;
				ingame = true;
				gameopennum = 1;
				int[] ress = new int[resource.Count];
				for (int i = 0; i < allcities.Count; i++) {
					for (int j = 0; j < allcities [i].resin.Count; j++) {
						ress [allcities [i].resin [j]] += allcities [i].resincol [j];
					}
				}
				for (int i = 0; i < resource.Count; i++) {
					ress [i] += resource [i];
				}
				for (int i = 1; i < ress.Length; i++) {
					rescourse [i] = ress [0] / (ress [i] + 1);
				}
				rescourse [0] = 1;

				curtimeout3 = 0;
			} else
				loaded = false;
		} else if (num == 2) {

			if (PlayerPrefs.GetString ("gamecreated2") == "1") {
				Debug.Log (PlayerPrefs.GetString ("quests2"));
				Debug.Log (PlayerPrefs.GetString ("res2"));
				Debug.Log (PlayerPrefs.GetString ("globalsob2"));
				Debug.Log (PlayerPrefs.GetString ("wiki2"));
				Debug.Log (PlayerPrefs.GetString ("cities2"));
				Debug.Log (PlayerPrefs.GetString ("teams2"));
				Debug.Log (PlayerPrefs.GetString ("buildings2"));
				razdel.Clear ();
				razdel.Add ("");
				string s = PlayerPrefs.GetString ("quests2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					quests [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("res2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					resource [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("globalsob2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					globalsob [i - 1] = myparse (razdel [i]);
				}

				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("skills2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				if(y>0)
					for (int i = 1; i < razdel.Count; i++) {
						skillshave.Add(myparse (razdel [i]));
					}

				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("wiki2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					if (myparse (razdel [i]) == 1)
						wiki [i - 1].open = true;
					else
						wiki [i - 1].open = false;
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("cities2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < y + 1; i++) {
					allcities [i - 1].race = myparse (razdel [i]);
				}
				for (int i = y + 1; i < 2 * y + 1; i++) {
					allcities [i - y - 1].grabbed = (myparse (razdel [i]) == 1) ? true : false;
				}
				for (int i = 0; i < y; i++) {
					allcities [i].unitsin.Clear ();
					allcities [i].alldef.Clear ();
					allcities [i].resin.Clear ();
					allcities [i].resincol.Clear ();
				}
				int[] p = new int[y];
				for (int i = 2 * y + 1; i < 3 * y + 1; i++) {
					p [i - 2 * y - 1] = myparse (razdel [i]);
				}
				int psum = 0;
				for (int i = 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].unitsin.Add (myparse (razdel [3 * y + 1 + psum + j]));
						}
					psum += p [i];
				}
				int lsum = psum;
				psum = 0;
				for (int i = 3 * y + 1+lsum; i < 4 * y + 1+lsum; i++) {
					p [i - 3 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].resin.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].resincol.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i = 4 * y + 1+lsum; i < 5 * y + 1+lsum; i++) {
					p [i - 4 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].alldef.Add (myparse (razdel [5 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("teams2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int g = -1;
				bool cameraplaced = false;
				for (int i = 0; i < 1; i++) {
					g += 1;
					if (razdel [g] == "1") {
						g += 1;
						teams [0].name = razdel [g];
						h = Instantiate (compref);
						g += 1;
						teams [0].mainunit = myparse (razdel [g]);
						h.GetComponent<mainunit> ().num = myparse (razdel [g]);
						g += 1;
						teams [0].mainunithp = myparse (razdel [g]);
						h.GetComponent<mainunit> ().m = i;
						g += 2;
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [h.GetComponent<mainunit> ().num - 1].sp;
						h.transform.position = new Vector3 (float.Parse (razdel [g - 1]), float.Parse (razdel [g]));
						teams [0].comgo = h;
						g += 1;
						int r = myparse (razdel [g]);
						teams [0].now = r * 0.1f;
						if (!cameraplaced) {
							mc.transform.SetParent (teams [0].comgo.transform);
							mc.transform.localPosition = new Vector3 (0, 0, -10);
							mc.fieldOfView = 50;
							cameraplaced = true;
							chosedteam = i;
						}
						if (r != 0) {
							g += 1;
							for (int j = 0; j < r; j++) {
								teams [0].units.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < r; j++) {
								teams [0].unitshp.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < 2*r; j++) {
								teams [0].unsdvig.Add (new Vector3(float.Parse (razdel [g + j]),float.Parse (razdel [g + j+1])));
								j++;
							}
							g += 2*r - 1;
							for (int j = 0; j < teams [0].units.Count; j++) {
								h = Instantiate (unitpref);
								h.GetComponent<uniter> ().topresl = teams [0].comgo;
								h.GetComponent<uniter> ().m = i;
								h.GetComponent<uniter> ().num = teams [0].units [j];
								h.GetComponent<uniter> ().fly = units [teams [0].units [j] - 1].fly;
								h.transform.position = teams [0].comgo.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [j] - 1].sp;
								teams [0].inst.Add (h);
							}
						}
					}
				}
				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("buildings2");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse(razdel [0]);
				if(y!=0){
					for (int i = 1; i < y + 1; i++) {
						buildingsbuilded.Add (myparse(razdel [i]));
					}
					for (int i = y+1; i < 3*y + 1; i++) {
						buildingsbuildedpos.Add (new Vector3(float.Parse(razdel [i]),float.Parse(razdel[i+1]),0));
						i += 1;
					}
					for (int i = 0; i < buildingsbuilded.Count; i++) {
						h = Instantiate (allbuildings [buildingsbuilded [i]]);
						h.transform.position = buildingsbuildedpos [i];
					}
				}

				commander.sprite = units [teams [0].mainunit - 1].sp;
				if (teams [0].units.Count > 0)
					u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
				else
					u1.sprite = nulsp;
				if (teams [0].units.Count > 1)
					u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
				else
					u2.sprite = nulsp;
				if (teams [0].units.Count > 2)
					u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
				else
					u3.sprite = nulsp;
				if (teams [0].units.Count > 3)
					u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
				else
					u4.sprite = nulsp;
				if (teams [0].units.Count > 4)
					u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
				else
					u5.sprite = nulsp;
				ingame = true;
				gameopennum = 2;
				int[] ress = new int[resource.Count];
				for (int i = 0; i < allcities.Count; i++) {
					for (int j = 0; j < allcities [i].resin.Count; j++) {
						ress [allcities [i].resin [j]] += allcities [i].resincol [j];
					}
				}
				for (int i = 0; i < resource.Count; i++) {
					ress [i] += resource [i];
				}
				for (int i = 1; i < ress.Length; i++) {
					rescourse [i] = ress [0] / (ress [i] + 1);
				}
				rescourse [0] = 1;

				curtimeout3 = 0;
			} else
				loaded = false;
		} else if (num == 3) {

			if (PlayerPrefs.GetString ("gamecreated3") == "1") {
				Debug.Log (PlayerPrefs.GetString ("quests3"));
				Debug.Log (PlayerPrefs.GetString ("res3"));
				Debug.Log (PlayerPrefs.GetString ("globalsob3"));
				Debug.Log (PlayerPrefs.GetString ("wiki3"));
				Debug.Log (PlayerPrefs.GetString ("cities3"));
				Debug.Log (PlayerPrefs.GetString ("teams3"));
				Debug.Log (PlayerPrefs.GetString ("buildings3"));
				razdel.Clear ();
				razdel.Add ("");
				string s = PlayerPrefs.GetString ("quests3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					quests [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("res3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					resource [i - 1] = myparse (razdel [i]);
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("globalsob3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					globalsob [i - 1] = myparse (razdel [i]);
				}

				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("skills3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				if(y>0)
				for (int i = 1; i < razdel.Count; i++) {
						skillshave.Add(myparse (razdel [i]));
				}

				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("wiki3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < razdel.Count; i++) {
					if (myparse (razdel [i]) == 1)
						wiki [i - 1].open = true;
					else
						wiki [i - 1].open = false;
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("cities3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse (razdel [0]);
				for (int i = 1; i < y + 1; i++) {
					allcities [i - 1].race = myparse (razdel [i]);
				}
				for (int i = y + 1; i < 2 * y + 1; i++) {
					allcities [i - y - 1].grabbed = (myparse (razdel [i]) == 1) ? true : false;
				}
				for (int i = 0; i < y; i++) {
					allcities [i].unitsin.Clear ();
					allcities [i].alldef.Clear ();
					allcities [i].resin.Clear ();
					allcities [i].resincol.Clear ();
				}
				int[] p = new int[y];
				for (int i = 2 * y + 1; i < 3 * y + 1; i++) {
					p [i - 2 * y - 1] = myparse (razdel [i]);
				}
				int psum = 0;
				for (int i = 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].unitsin.Add (myparse (razdel [3 * y + 1 + psum + j]));
						}
					psum += p [i];
				}
				int lsum = psum;
				psum = 0;
				for (int i = 3 * y + 1+lsum; i < 4 * y + 1+lsum; i++) {
					p [i - 3 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].resin.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].resincol.Add (myparse (razdel [4 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}
				lsum += psum;
				psum = 0;
				for (int i = 4 * y + 1+lsum; i < 5 * y + 1+lsum; i++) {
					p [i - 4 * y - 1-lsum] = myparse (razdel [i]);
				}
				for (int i= 0; i < y; i++) {
					if(p[i]!=0)
						for (int j = 0; j < p [i]; j++) {
							allcities [i].alldef.Add (myparse (razdel [5 * y + 1+lsum + psum + j]));
						}
					psum += p [i];
				}


				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("teams3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				int g = -1;
				bool cameraplaced = false;
				for (int i = 0; i < 1; i++) {
					g += 1;
					if (razdel [g] == "1") {
						g += 1;
						teams [0].name = razdel [g];
						h = Instantiate (compref);
						g += 1;
						teams [0].mainunit = myparse (razdel [g]);
						h.GetComponent<mainunit> ().num = myparse (razdel [g]);
						h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [h.GetComponent<mainunit> ().num - 1].sp;
						g += 1;
						teams [0].mainunithp = myparse (razdel [g]);
						h.GetComponent<mainunit> ().m = i;
						g += 2;
						h.transform.position = new Vector3 (float.Parse (razdel [g - 1]), float.Parse (razdel [g]));
						teams [0].comgo = h;
						g += 1;
						int r = myparse (razdel [g]);
						teams [0].now = r * 0.1f;
						if (!cameraplaced) {
							mc.transform.SetParent (teams [0].comgo.transform);
							mc.transform.localPosition = new Vector3 (0, 0, -10);
							mc.fieldOfView = 50;
							cameraplaced = true;
							chosedteam = i;
						}
						if (r != 0) {
							g += 1;

							for (int j = 0; j < r; j++) {
								  teams [0].units.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < r; j++) {
								teams [0].unitshp.Add (myparse (razdel [g + j]));
							}
							g += r;
							for (int j = 0; j < 2*r; j++) {
								teams [0].unsdvig.Add (new Vector3(float.Parse (razdel [g + j]),float.Parse (razdel [g + j+1])));
								j++;
							}
							g += 2*r - 1;
							for (int j = 0; j < teams [0].units.Count; j++) {
								h = Instantiate (unitpref);
								h.GetComponent<uniter> ().topresl = teams [0].comgo;
								h.GetComponent<uniter> ().m = i;
								h.GetComponent<uniter> ().num = teams [0].units [j];
								h.GetComponent<uniter> ().fly = units [teams [0].units [j] - 1].fly;
								h.transform.position = teams [0].comgo.transform.position;
								h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [j] - 1].sp;
								teams [0].inst.Add (h);
							}
						}
					}
				}
				razdel.Clear ();
				razdel.Add ("");
				s = PlayerPrefs.GetString ("buildings3");
				for (int i = 0; i < s.Length; i++) {
					if (s [i] == ' ') {
						razdel.Add ("");
					} else
						razdel [razdel.Count - 1] += s [i];
				}
				y = myparse(razdel [0]);
				if(y!=0){
				for (int i = 1; i < y + 1; i++) {
						buildingsbuilded.Add (myparse(razdel [i]));
				}
				for (int i = y+1; i < 3*y + 1; i++) {
						buildingsbuildedpos.Add (new Vector3(float.Parse(razdel [i]),float.Parse(razdel[i+1]),0));
					i += 1;
				}
					for (int i = 0; i < buildingsbuilded.Count; i++) {
						h = Instantiate (allbuildings [buildingsbuilded [i]]);
						h.transform.position = buildingsbuildedpos [i];
					}
				}


				commander.sprite = units [teams [0].mainunit - 1].sp;
				if (teams [0].units.Count > 0)
					u1.sprite = units [teams [0].units [(sdvig) % (teams [0].units.Count)] - 1].sp;
				else
					u1.sprite = nulsp;
				if (teams [0].units.Count > 1)
					u2.sprite = units [teams [0].units [(sdvig + 1) % (teams [0].units.Count)] - 1].sp;
				else
					u2.sprite = nulsp;
				if (teams [0].units.Count > 2)
					u3.sprite = units [teams [0].units [(sdvig + 2) % (teams [0].units.Count)] - 1].sp;
				else
					u3.sprite = nulsp;
				if (teams [0].units.Count > 3)
					u4.sprite = units [teams [0].units [(sdvig + 3) % (teams [0].units.Count)] - 1].sp;
				else
					u4.sprite = nulsp;
				if (teams [0].units.Count > 4)
					u5.sprite = units [teams [0].units [(sdvig + 4) % (teams [0].units.Count)] - 1].sp;
				else
					u5.sprite = nulsp;
				ingame = true;
				gameopennum = 3;
				int[] ress = new int[resource.Count];
				for (int i = 0; i < allcities.Count; i++) {
					for (int j = 0; j < allcities [i].resin.Count; j++) {
						ress [allcities [i].resin [j]] += allcities [i].resincol [j];
					}
				}
				for (int i = 0; i < resource.Count; i++) {
					ress [i] += resource [i];
				}
				for (int i = 1; i < ress.Length; i++) {
					rescourse [i] = ress [0] / (ress [i] + 1);
				}
				rescourse [0] = 1;

				curtimeout3 = 0;
			} else
				loaded = false;
		}
		if (!loaded) {
			teams [0].mainunit = 34;
			teams [0].mainunithp = 10;
			h = Instantiate (compref);
			h.transform.position = obuchspawn.transform.position;
			h.GetComponent<mainunit> ().m = 0;
			h.GetComponent<mainunit> ().num = 34;
			h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [33].sp;
			chosedteam = 0;
			learn ("Используйте джойстик (планета в правом нижнем углу) для ходьбы.");
			teams [0].name = "Команда1";
			teams [0].comgo = h;
			mc.transform.SetParent (teams [0].comgo.transform);
			mc.transform.localPosition = new Vector3 (0, 0, -10);
			mc.fieldOfView = 50;
			chosedteam = 0;

		}
		ingame = true;
	}

	public void gamedel (int num)
	{
		if (num == 1) {
			PlayerPrefs.SetString ("gamecreated1", "0");
		} else if (num == 2) {
			PlayerPrefs.SetString ("gamecreated2", "0");
		} else if (num == 3) {
			PlayerPrefs.SetString ("gamecreated3", "0");
		}
		gamechoose ();
	}

	public void gamechoose ()
	{
		menu.SetActive (false);
		games.SetActive (true);
		if (PlayerPrefs.GetString ("gamecreated1") == "1") {
			game1.text = "Слот сохранения 1 (Продолжить)";
		} else
			game1.text = "Слот сохранения 1 (Новая игра)";
		if (PlayerPrefs.GetString ("gamecreated2") == "1") {
			game2.text = "Слот сохранения 2 (Продолжить)";
		} else
			game2.text = "Слот сохранения 2 (Новая игра)";
		if (PlayerPrefs.GetString ("gamecreated3") == "1") {
			game3.text = "Слот сохранения 3 (Продолжить)";
		} else
			game3.text = "Слот сохранения 3 (Новая игра)";
	}

	public void soundlevelset (int level)
	{
		soundlevel = level;
		Debug.Log ("1");
		if (level == 0)
			nosound ();
		else {
			for (int i = 0; i < level; i++) {
				soundlevelgo [i].sprite = soundlevelgo [i].gameObject.GetComponent<anysoundlevel> ().sp;
			}
			for (int i = level; i < soundlevelgo.Count; i++) {
				soundlevelgo [i].sprite = empsp;
			}
		}
	}

	public void musiclevelset (int level)
	{
		mainaud.volume = level * 0.2f;
		musiclevel = level;
		Debug.Log ("2");
		if (level == 0)
			nomusic ();
		else {
			for (int i = 0; i < level; i++) {
				musiclevelgo [i].sprite = musiclevelgo [i].gameObject.GetComponent<anysoundlevel> ().sp;
			}
			for (int i = level; i < musiclevelgo.Count; i++) {
				musiclevelgo [i].sprite = empsp;
			}
		}
	}

	public void savegame ()
	{
		if (gameopennum == 1) {
			string s = "";
			s += quests.Count.ToString ();
			for (int i = 0; i < quests.Count; i++) {
				s += " ";
				s += quests [i].ToString ();
			}
			PlayerPrefs.SetString ("quests1", s);

			s = "";
			s += resource.Count.ToString ();
			for (int i = 0; i < resource.Count; i++) {
				s += " ";
				s += resource [i].ToString ();
			}
			PlayerPrefs.SetString ("res1", s);

			s = "";
			s += globalsob.Count.ToString ();
			for (int i = 0; i < globalsob.Count; i++) {
				s += " ";
				s += globalsob [i].ToString ();
			}
			PlayerPrefs.SetString ("globalsob1", s);

			s = "";
			s += skillshave.Count.ToString ();
			for (int i = 0; i < skillshave.Count; i++) {
				s += " ";
				s += skillshave [i].ToString ();
			}
			PlayerPrefs.SetString ("skills1", s);

			s = "";
			s += wiki.Count.ToString ();
			for (int i = 0; i < wiki.Count; i++) {
				s += " ";
				if (wiki [i].open) {
					s += "1";
				} else
					s += "0";
			}
			PlayerPrefs.SetString ("wiki1", s);

			PlayerPrefs.SetString ("gamecreated1", "1");

			s = "";
			s += allcities.Count.ToString ();
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].race;
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += (allcities [i].grabbed == true) ? "1" : "0";
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].unitsin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].unitsin.Count; j++) {
					s += " ";
					s += allcities [i].unitsin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].resin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resincol [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].alldef.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].alldef.Count; j++) {
					s += " ";
					s += allcities [i].alldef [j];
				}
			}
			PlayerPrefs.SetString ("cities1", s);
			s = "";
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit != -1) {
					s += "1 ";
					s += teams [0].name;
					s += " ";
					s += teams [0].mainunit.ToString ();
					s += " ";
					s += teams [0].mainunithp.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.x.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.y.ToString ();
					s += " ";
					s += teams [0].units.Count.ToString ();
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].units [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unitshp [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unsdvig [j].x.ToString ();
						s += " ";
						s += teams [0].unsdvig [j].y.ToString ();
					}
				} else
					s += "0";
				if (i != 9)
					s += " ";
			}
			PlayerPrefs.SetString ("teams1", s);
			s = buildingsbuilded.Count.ToString();
			if (buildingsbuilded.Count > 0) {
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuilded [i].ToString ();
				}
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuildedpos [i].x.ToString ();
					s += " ";
					s += buildingsbuildedpos [i].y.ToString ();
				}
			}
			PlayerPrefs.SetString ("buildings1", s);
		} else if (gameopennum == 2) {
			string s = "";
			s += quests.Count.ToString ();
			for (int i = 0; i < quests.Count; i++) {
				s += " ";
				s += quests [i].ToString ();
			}
			PlayerPrefs.SetString ("quests2", s);

			s = "";
			s += resource.Count.ToString ();
			for (int i = 0; i < resource.Count; i++) {
				s += " ";
				s += resource [i].ToString ();
			}
			PlayerPrefs.SetString ("res2", s);

			s = "";
			s += globalsob.Count.ToString ();
			for (int i = 0; i < globalsob.Count; i++) {
				s += " ";
				s += globalsob [i].ToString ();
			}
			PlayerPrefs.SetString ("globalsob2", s);

			s = "";
			s += skillshave.Count.ToString ();
			for (int i = 0; i < skillshave.Count; i++) {
				s += " ";
				s += skillshave [i].ToString ();
			}
			PlayerPrefs.SetString ("skills2", s);

			s = "";
			s += wiki.Count.ToString ();
			for (int i = 0; i < wiki.Count; i++) {
				s += " ";
				if (wiki [i].open) {
					s += "1";
				} else
					s += "0";
			}
			PlayerPrefs.SetString ("wiki2", s);

			PlayerPrefs.SetString ("gamecreated2", "1");

			s = "";
			s += allcities.Count.ToString ();
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].race;
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += (allcities [i].grabbed == true) ? "1" : "0";
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].unitsin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].unitsin.Count; j++) {
					s += " ";
					s += allcities [i].unitsin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].resin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resincol [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].alldef.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].alldef.Count; j++) {
					s += " ";
					s += allcities [i].alldef [j];
				}
			}
			PlayerPrefs.SetString ("cities2", s);

			s = "";
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit != -1) {
					s += "1 ";
					s += teams [0].name;
					s += " ";
					s += teams [0].mainunit.ToString ();
					s += " ";
					s += teams [0].mainunithp.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.x.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.y.ToString ();
					s += " ";
					s += teams [0].units.Count.ToString ();
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].units [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unitshp [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unsdvig [j].x.ToString ();
						s += " ";
						s += teams [0].unsdvig [j].y.ToString ();
					}
				} else
					s += "0";
				if (i != 9)
					s += " ";
			}
			PlayerPrefs.SetString ("teams2", s);
			s = buildingsbuilded.Count.ToString();
			if (buildingsbuilded.Count > 0) {
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuilded [i].ToString ();
				}
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuildedpos [i].x.ToString ();
					s += " ";
					s += buildingsbuildedpos [i].y.ToString ();
				}
			}
			PlayerPrefs.SetString ("buildings2", s);
		} else if (gameopennum == 3) {
			string s = "";
			s += quests.Count.ToString ();
			for (int i = 0; i < quests.Count; i++) {
				s += " ";
				s += quests [i].ToString ();
			}
			PlayerPrefs.SetString ("quests3", s);

			s = "";
			s += resource.Count.ToString ();
			for (int i = 0; i < resource.Count; i++) {
				s += " ";
				s += resource [i].ToString ();
			}
			PlayerPrefs.SetString ("res3", s);

			s = "";
			s += skillshave.Count.ToString ();
			for (int i = 0; i < skillshave.Count; i++) {
				s += " ";
				s += skillshave [i].ToString ();
			}
			PlayerPrefs.SetString ("skills3", s);

			s = "";
			s += globalsob.Count.ToString ();
			for (int i = 0; i < globalsob.Count; i++) {
				s += " ";
				s += globalsob [i].ToString ();
			}
			PlayerPrefs.SetString ("globalsob3", s);

			s = "";
			s += wiki.Count.ToString ();
			for (int i = 0; i < wiki.Count; i++) {
				s += " ";
				if (wiki [i].open) {
					s += "1";
				} else
					s += "0";
			}
			PlayerPrefs.SetString ("wiki3", s);

			PlayerPrefs.SetString ("gamecreated3", "1");

			s = "";
			s += allcities.Count.ToString ();
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].race;
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += (allcities [i].grabbed == true) ? "1" : "0";
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].unitsin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].unitsin.Count; j++) {
					s += " ";
					s += allcities [i].unitsin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].resin.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resin [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					s += " ";
					s += allcities [i].resincol [j];
				}
			}
			for (int i = 0; i < allcities.Count; i++) {
				s += " ";
				s += allcities [i].alldef.Count;
			}
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].alldef.Count; j++) {
					s += " ";
					s += allcities [i].alldef [j];
				}
			}
			PlayerPrefs.SetString ("cities3", s);

			s = "";
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit != -1) {
					s += "1 ";
					s += teams [0].name;
					s += " ";
					s += teams [0].mainunit.ToString ();
					s += " ";
					s += teams [0].mainunithp.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.x.ToString ();
					s += " ";
					s += teams [0].comgo.transform.position.y.ToString ();
					s += " ";
					s += teams [0].units.Count.ToString ();
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].units [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unitshp [j].ToString ();
					}
					for (int j = 0; j < teams [0].units.Count; j++) {
						s += " ";
						s += teams [0].unsdvig [j].x.ToString ();
						s += " ";
						s += teams [0].unsdvig [j].y.ToString ();
					}
				} else
					s += "0";
				if (i != 9)
					s += " ";
			}
			PlayerPrefs.SetString ("teams3", s);
			s = buildingsbuilded.Count.ToString();
			if (buildingsbuilded.Count > 0) {
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuilded [i].ToString ();
				}
				for (int i = 0; i < buildingsbuilded.Count; i++) {
					s += " ";
					s += buildingsbuildedpos [i].x.ToString ();
					s += " ";
					s += buildingsbuildedpos [i].y.ToString ();
				}
			}
			PlayerPrefs.SetString ("buildings3", s);
		}
	}

	public void nosound ()
	{
		for (int i = 0; i < soundlevelgo.Count; i++) {
			soundlevelgo [i].sprite = empsp;
		}
	}

	public void nomusic ()
	{
		for (int i = 0; i < musiclevelgo.Count; i++) {
			musiclevelgo [i].sprite = empsp;
		}
	}

	public void startgame (bool ananas)
	{
		if (ananas) {
			mc.transform.SetParent (null);
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit != -1) {
					Destroy (teams [0].comgo);
					for (int j = 0; j < teams [0].units.Count; j++) {
						Destroy (teams [0].inst [j]);
					}
				}
			}
			skillshave.Add (0);
			skillshave.Add (32);
			skillshave.Add (33);
			for (int i = 0; i < 1; i++) {
				teams [0].mainunit = -1;
				teams [0].comgo = null;
				teams [0].inst.Clear ();
				teams [0].mainunithp = 0;
				teams [0].name = "";
				teams [0].now = 0;
				teams [0].units.Clear ();
				teams [0].unitshp.Clear ();
			}
			quests [12] = 0;
			teams [0].mainunit = 3;
			teams [0].mainunithp = 50;
			h = Instantiate (compref);
			h.transform.position = ananasspawn.transform.position;
			h.GetComponent<mainunit> ().m = 0;
			h.GetComponent<mainunit> ().num = 3;
			h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [2].sp;
			chosedteam = 0;
			teams [0].name = "Команда1";
			teams [0].comgo = h;
			resource [0] = 5000;
			resource [1] = 1000;
			teams [0].unsdvig.Add(Vector3.right); teams [0].units.Add (1);
			teams [0].unsdvig.Add(Vector3.left); teams [0].units.Add (1);
			teams [0].unsdvig.Add(Vector3.up); teams [0].units.Add (1);
			teams [0].unsdvig.Add(Vector3.down); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.up+Vector3.left); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.up+Vector3.right); teams [0].units.Add (2);
			teams [0].unitshp.Add (15);
			teams [0].unitshp.Add (15);
			teams [0].unitshp.Add (15);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (30);
			for (int i = 0; i < 6; i++) {

				h = Instantiate (unitpref);
				h.GetComponent<uniter> ().race = 11;
				h.transform.position = teams [0].comgo.gameObject.transform.position+teams[0].unsdvig[i];
				h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [i] - 1].sp;
				h.GetComponent<uniter> ().fly = units [teams [0].units [i] - 1].fly;
				h.GetComponent<uniter> ().m = chosedteam;
				h.GetComponent<uniter> ().num = teams [0].units [i];
				teams [0].inst.Add (h);
				teams [0].now += 0.1f;

			}
			mc.transform.SetParent (teams [0].comgo.transform);
			mc.transform.localPosition = new Vector3 (0, 0, -10);
			mc.fieldOfView = 50;
			races [0].otnosh = -10;
			races [1].otnosh = 30;
			int[] ress = new int[resource.Count];
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					ress [allcities [i].resin [j]] += allcities [i].resincol [j];
				}
			}
			for (int i = 0; i < resource.Count; i++) {
				ress [i] += resource [i];
			}
			for (int i = 1; i < ress.Length; i++) {
				rescourse [i] = ress [0] / (ress [i] + 1);
			}
			rescourse [0] = 1;

			curtimeout3 = 0;
		} else {
			mc.transform.SetParent (null);
			for (int i = 0; i < 1; i++) {
				if (teams [0].mainunit != -1) {
					Destroy (teams [0].comgo);
					for (int j = 0; j < teams [0].units.Count; j++) {
						Destroy (teams [0].inst [j]);
					}
				}
			}
			for (int i = 0; i < 1; i++) {
				teams [0].mainunit = -1;
				teams [0].comgo = null;
				teams [0].inst.Clear ();
				teams [0].mainunithp = 0;
				teams [0].name = "";
				teams [0].now = 0;
				teams [0].units.Clear ();
				teams [0].unitshp.Clear ();
			}
			skillshave.Add (0);
			skillshave.Add (32);
			skillshave.Add (33);
			teams [0].mainunit = 4;
			teams [0].mainunithp = 50;
			quests [12] = 0;
			h = Instantiate (compref);
			h.transform.position = sausagespawn.transform.position;
			h.GetComponent<mainunit> ().m = 0;
			h.GetComponent<mainunit> ().num = 4;
			h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [3].sp;
			chosedteam = 0;
			teams [0].name = "Команда1";
			teams [0].comgo = h;
			resource [0] = 5000;
			resource [1] = 1000;
			teams [0].unsdvig.Add(Vector3.right); teams [0].units.Add (1);
			teams [0].unsdvig.Add(Vector3.left); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.up); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.down); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.up+Vector3.right); teams [0].units.Add (5);
			teams [0].unsdvig.Add(Vector3.up+Vector3.left); teams [0].units.Add (6);
			teams [0].unitshp.Add (15);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (18);
			teams [0].unitshp.Add (25);
			for (int i = 0; i < 6; i++) {

				h = Instantiate (unitpref);
				h.GetComponent<uniter> ().race = 11;
				h.transform.position = teams [0].comgo.gameObject.transform.position;
				h.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = units [teams [0].units [i] - 1].sp;
				h.GetComponent<uniter> ().fly = units [teams [0].units [i] - 1].fly;
				h.GetComponent<uniter> ().m = chosedteam;
				h.GetComponent<uniter> ().num = teams [0].units [i];
				teams [0].inst.Add (h);
				teams [0].now += 0.1f;

			}
			mc.transform.SetParent (teams [0].comgo.transform);
			mc.transform.localPosition = new Vector3 (0, 0, -10);
			mc.fieldOfView = 50;
			races [0].otnosh = 30;
			races [1].otnosh = -10;
			int[] ress = new int[resource.Count];
			for (int i = 0; i < allcities.Count; i++) {
				for (int j = 0; j < allcities [i].resin.Count; j++) {
					ress [allcities [i].resin [j]] += allcities [i].resincol [j];
				}
			}
			for (int i = 0; i < resource.Count; i++) {
				ress [i] += resource [i];
			}
			for (int i = 1; i < ress.Length; i++) {
				rescourse [i] = ress [0] / (ress [i] + 1);
			}
			rescourse [0] = 1;

			curtimeout3 = 0;
		}
	}

	public void musicplay (AudioClip mus)
	{
		mainaud.Stop ();
		mainaud.clip = mus;
		mainaud.Play ();
	}

	public void soundplay (AudioClip sound, float x, float y)
	{
		h = Instantiate (audgo);
		h.transform.position = new Vector3 (x, y, -10);
		h.GetComponent<AudioSource> ().clip = sound;
		h.GetComponent<AudioSource> ().volume = soundlevel * 0.2f;
		h.GetComponent<AudioSource> ().Play ();
	}

	public void buttonplay ()
	{
		soundplay (bthsound, teams [0].comgo.transform.position.x, teams [0].comgo.transform.position.y);
	}

	public void moneyplay ()
	{
		Debug.Log ("1");
		soundplay (money, teams [0].comgo.transform.position.x, teams [0].comgo.transform.position.y);
	}
	public GameObject lrgo;
	public Text lrtxt;
	public void learn(string lrn){
		lrgo.SetActive (true);
		lrtxt.text = lrn;
	}
	public void learnclose(){
		lrgo.SetActive (false);
	}
	public void nextquest ()
	{
		qnum = (qnum + 1) % quests.Count;
	}

	public void queopen ()
	{
		qname.transform.parent.gameObject.SetActive (true);
		joy.SetActive (false);
		int n = qnum;
		nextquest ();
		while (questvis [qnum].otslezh == false || quests [qnum] == -1) {
			nextquest ();
			if (qnum == n) {
				break;
			}
		}
		for (int i = 0; i < questvis [qnum].znach.Count; i++) {
			if (quests [qnum] == questvis [qnum].znach [i]) {
				qname.GetComponent<Text> ().text = qnames [qnum];
				qtxt.GetComponent<Text> ().text = questvis [qnum].opis [i];
				break;
			}
		}
	}

	public void queclose ()
	{
		joy.SetActive (true);
		qname.transform.parent.gameObject.SetActive (false);
	}

	public void skillsmenu ()
	{
		if (!creatingteam && !chosingtsel) {
			if (!teams [0].casting) {
				skilltxt.GetComponent<Text> ().text = "";
				skillname.GetComponent<Text> ().text = "";
				choosedskill = -1;
				bool found = false;
				skillmenu.SetActive (true);
				if (teams [0].units.Count > 0)
					for (int i = 0; i < teams [0].units.Count; i++) {
						if (units [teams [0].units [i] - 1].sk != -1) {
							choosedskill = i;
							found = true;
							skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
							skilltxt.GetComponent<Text> ().text = "Нужно: \n";
							if (allskills [units [teams [0].units [i] - 1].sk].costres)
								skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
							if (allskills [units [teams [0].units [i] - 1].sk].costunit)
							if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
								skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
							} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
							break;
						}
					}
				if (!found) {
					if (units [teams [0].mainunit - 1].sk != -1) {
						choosedskill = teams [0].units.Count;
						found = true;
						skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
						skilltxt.GetComponent<Text> ().text = "Нужно: \n";
						if (allskills [units [teams [0].mainunit - 1].sk].costres)
							skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
						if (allskills [units [teams [0].mainunit - 1].sk].costunit)
						if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
							skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
						} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
					}
				}
				if (!found)
				if (skillshave.Count > 0) {
					choosedskill = teams [0].units.Count + 1;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [skillshave [0]].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
					if (allskills [skillshave [0]].costunit)
					if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
					}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
				}
				if (!found)
					skillmenu.SetActive (false);
			}
		}
	}

	public void nextskill ()
	{
		skilltxt.GetComponent<Text> ().text = "";
		skillname.GetComponent<Text> ().text = "";
		int lastchoose = choosedskill;
		int lastskill = -1;
		if (choosedskill < teams [0].units.Count) {
			lastskill = units [teams [0].units [choosedskill] - 1].sk;
		} else if (choosedskill == teams [0].units.Count) {
			lastskill = units [teams [0].mainunit - 1].sk;
		} else {
			lastskill = skillshave [choosedskill - teams [0].units.Count - 1];
		}
		if (choosedskill == -1) {
			bool found = false;
			skillmenu.SetActive (true);
			if (teams [0].units.Count > 0)
				for (int i = 0; i < teams [0].units.Count; i++) {
					if (units [teams [0].units [i] - 1].sk != -1) {
						skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
						choosedskill = i;
						found = true;
						skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
						skilltxt.GetComponent<Text> ().text = "Нужно: \n";
						if (allskills [units [teams [0].units [i] - 1].sk].costres)
							skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
						if (allskills [units [teams [0].units [i] - 1].sk].costunit)
						if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
							skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
						} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
						break;
					}
				}
			if (!found) {
				if (units [teams [0].mainunit - 1].sk != -1) {
					skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].opis + "\n";
					choosedskill = teams [0].units.Count;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [units [teams [0].mainunit - 1].sk].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
					if (allskills [units [teams [0].mainunit - 1].sk].costunit)
					if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
					} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
				}
			}
			if (!found)
			if (skillshave.Count > 0) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [0]].opis + "\n";
				choosedskill = teams [0].units.Count + 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [0]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
				if (allskills [skillshave [0]].costunit)
				if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
				}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
			}
			if (!found)
				skillmenu.SetActive (false);
		} else if (choosedskill < teams [0].units.Count - 1) {
			bool found = false;
			skillmenu.SetActive (true);
			if (teams [0].units.Count > 0)
				for (int i = choosedskill + 1; i < teams [0].units.Count; i++) {
					if (units [teams [0].units [i] - 1].sk != -1) {
						skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
						choosedskill = i;
						found = true;
						skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
						skilltxt.GetComponent<Text> ().text = "Нужно: \n";
						if (allskills [units [teams [0].units [i] - 1].sk].costres)
							skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
						if (allskills [units [teams [0].units [i] - 1].sk].costunit)
						if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
							skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
						} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
						break;
					}
				}
			if (!found) {
				if (units [teams [0].mainunit - 1].sk != -1) {
					skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].opis + "\n";
					choosedskill = teams [0].units.Count;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [units [teams [0].mainunit - 1].sk].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
					if (allskills [units [teams [0].mainunit - 1].sk].costunit)
					if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
					} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
				}
			}
			if (!found)
			if (skillshave.Count > 0) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [0]].opis + "\n";
				choosedskill = teams [0].units.Count + 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [0]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
				if (allskills [skillshave [0]].costunit)
				if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
				}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
			}
			if (!found) {
				if (teams [0].units.Count > 0)
					for (int i = 0; i < choosedskill + 1; i++) {
						if (units [teams [0].units [i] - 1].sk != -1) {
							skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
							choosedskill = i;
							found = true;
							skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
							skilltxt.GetComponent<Text> ().text = "Нужно: \n";
							if (allskills [units [teams [0].units [i] - 1].sk].costres)
								skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
							if (allskills [units [teams [0].units [i] - 1].sk].costunit)
							if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
								skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
							} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
							break;
						}
					}
			}
		} else if (choosedskill == teams [0].units.Count - 1) {
			bool found = false;
			if (!found) {
				if (units [teams [0].mainunit - 1].sk != -1) {
					skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].opis + "\n";
					choosedskill = teams [0].units.Count;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [units [teams [0].mainunit - 1].sk].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
					if (allskills [units [teams [0].mainunit - 1].sk].costunit)
					if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
					} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
				}
			}
			if (!found)
			if (skillshave.Count > 0) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [0]].opis + "\n";
				choosedskill = teams [0].units.Count + 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [0]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
				if (allskills [skillshave [0]].costunit)
				if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
				}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
			}
			if (!found) {
				if (teams [0].units.Count > 0)
					for (int i = 0; i < teams [0].units.Count; i++) {
						if (units [teams [0].units [i] - 1].sk != -1) {
							skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
							choosedskill = i;
							found = true;
							skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
							skilltxt.GetComponent<Text> ().text = "Нужно: \n";
							if (allskills [units [teams [0].units [i] - 1].sk].costres)
								skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
							if (allskills [units [teams [0].units [i] - 1].sk].costunit)
							if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
								skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
							} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
							break;
						}
					}
			}
		} else if (choosedskill == teams [0].units.Count) {
			
			bool found = false;
			if (!found)
			if (skillshave.Count > 0) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [0]].opis + "\n";
				choosedskill = teams [0].units.Count + 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [0]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
				if (allskills [skillshave [0]].costunit)
				if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
				}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
			}
			if (!found) {
				if (teams [0].units.Count > 0)
					for (int i = 0; i < teams [0].units.Count; i++) {
						if (units [teams [0].units [i] - 1].sk != -1) {
							skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
							choosedskill = i;
							found = true;
							skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
							skilltxt.GetComponent<Text> ().text = "Нужно: \n";
							if (allskills [units [teams [0].units [i] - 1].sk].costres)
								skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
							if (allskills [units [teams [0].units [i] - 1].sk].costunit)
							if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
								skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
							} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
							break;
						}
					}
			}
			if (!found) {
				if (units [teams [0].mainunit - 1].sk != -1) {
					skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].opis + "\n";
					choosedskill = teams [0].units.Count;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [units [teams [0].mainunit - 1].sk].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
					if (allskills [units [teams [0].mainunit - 1].sk].costunit)
					if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
					} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
				}
			}
		} else {
			bool found = false;
			if (!found)
			if (skillshave.Count > choosedskill - teams [0].units.Count) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [choosedskill - teams [0].units.Count]].opis + "\n";
				choosedskill += 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [choosedskill - teams [0].units.Count - 1]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [choosedskill - teams [0].units.Count - 1]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [choosedskill - teams [0].units.Count - 1]].resc] + ": " + allskills [skillshave [choosedskill - teams [0].units.Count - 1]].resccol.ToString () + " (Есть: " + resource [allskills [skillshave [choosedskill - teams [0].units.Count - 1]].resc] + ")\n";
				if (allskills [skillshave [choosedskill - teams [0].units.Count - 1]].costunit)
				if (teams [0].units.Contains (allskills [skillshave [choosedskill - teams [0].units.Count - 1]].unitc)||teams[0].mainunit==allskills [skillshave [choosedskill - teams [0].units.Count - 1]].unitc) {
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [choosedskill - teams [0].units.Count - 1]].unitc - 1].name+ " (Есть в команде)";	
				} else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [choosedskill - teams [0].units.Count - 1]].unitc - 1].name+ " (Нет в команде)";
			}
			if (!found) {
				if (teams [0].units.Count > 0)
					for (int i = 0; i < teams [0].units.Count; i++) {
						if (units [teams [0].units [i] - 1].sk != -1) {
							skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].opis + "\n";
							choosedskill = i;
							found = true;
							skillname.GetComponent<Text> ().text = allskills [units [teams [0].units [i] - 1].sk].name;
							skilltxt.GetComponent<Text> ().text = "Нужно: \n";
							if (allskills [units [teams [0].units [i] - 1].sk].costres)
								skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].units [i] - 1].sk].resc] + ": " + allskills [units [teams [0].units [i] - 1].sk].resccol.ToString ()+" (Есть: "+ resource[allskills [units [teams [0].units [i] - 1].sk].resc] + ")\n";
							if (allskills [units [teams [0].units [i] - 1].sk].costunit)
							if (teams[0].units.Contains(allskills [units [teams [0].units [i] - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].units [i] - 1].sk].unitc){
								skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Есть в команде)";
							} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].units [i] - 1].sk].unitc - 1].name +" (Нет в команде)";
							break;
						}
					}
			}
			if (!found) {
				if (units [teams [0].mainunit - 1].sk != -1) {
					skilltxt.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].opis + "\n";
					choosedskill = teams [0].units.Count;
					found = true;
					skillname.GetComponent<Text> ().text = allskills [units [teams [0].mainunit - 1].sk].name;
					skilltxt.GetComponent<Text> ().text = "Нужно: \n";
					if (allskills [units [teams [0].mainunit - 1].sk].costres)
						skilltxt.GetComponent<Text> ().text += resnames [allskills [units [teams [0].mainunit - 1].sk].resc] + ": " + allskills [units [teams [0].mainunit - 1].sk].resccol.ToString () +" (Есть: "+ resource[allskills [units [teams [0].mainunit - 1].sk].resc] + ")\n";
					if (allskills [units [teams [0].mainunit - 1].sk].costunit)
					if(teams[0].units.Contains(allskills [units [teams [0].mainunit - 1].sk].unitc)||teams[0].mainunit==allskills [units [teams [0].mainunit - 1].sk].unitc){
						skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name + " (Есть в команде)";
					} else skilltxt.GetComponent<Text> ().text += units [allskills [units [teams [0].mainunit - 1].sk].unitc - 1].name +" (Нет в команде)";
				}
			}
			if (!found)
			if (skillshave.Count > 0) {
				skilltxt.GetComponent<Text> ().text = allskills [skillshave [0]].opis + "\n";
				choosedskill = teams [0].units.Count + 1;
				found = true;
				skillname.GetComponent<Text> ().text = allskills [skillshave [0]].name;
				skilltxt.GetComponent<Text> ().text = "Нужно: \n";
				if (allskills [skillshave [0]].costres)
					skilltxt.GetComponent<Text> ().text += resnames [allskills [skillshave [0]].resc] + ": " + allskills [skillshave [0]].resccol.ToString () +" (Есть: "+ resource[allskills [skillshave [0]].resc] + ")\n";
				if (allskills [skillshave [0]].costunit)
				if (teams[0].units.Contains(allskills [skillshave [0]].unitc)||teams[0].mainunit==allskills [skillshave [0]].unitc){
					skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Есть в команде)";
				}else skilltxt.GetComponent<Text> ().text += units [allskills [skillshave [0]].unitc - 1].name+" (Нет в команде)";
			}
		}
		int p = -1;
		if (choosedskill < teams [0].units.Count) {
			p = units [teams [0].units [choosedskill] - 1].sk;
		} else if (choosedskill == teams [0].units.Count) {
			p = units [teams [0].mainunit - 1].sk;
		} else {
			p = skillshave [choosedskill - teams [0].units.Count - 1];
		}
		if (recschet < teams [0].units.Count + skillshave.Count) {
			if (lastskill == p && lastchoose != choosedskill) {
				recschet += 1;
				nextskill ();
			}
		} else {
			recschet = 0;
		}
	}

	public void cancelskil ()
	{
		choosedskill = -1;
		skillmenu.SetActive (false);
	}

	public void skilluse ()
	{
		if (choosedskill != -1) {
			int p = -1;
			if (choosedskill < teams [0].units.Count) {
				p = units [teams [0].units [choosedskill] - 1].sk;
			} else if (choosedskill == teams [0].units.Count) {
				p = units [teams [0].mainunit - 1].sk;
			} else {
				p = skillshave [choosedskill - teams [0].units.Count - 1];
			}
			bool canuse = true;
			if (allskills [p].costres == true) {
				if (resource [allskills [p].resc] < allskills [p].resccol) {
					canuse = false;
				}
			}
			if (allskills [p].costunit == true) {
				if (!teams [0].units.Contains (allskills [p].unitc) && teams [0].mainunit != allskills [p].unitc) {
					canuse = false;
				}
			}
			if (canuse) {
				if (allskills [p].costres == true) {
					resource [allskills [p].resc] -= allskills [p].resccol;
				}
				if (allskills [p].costunit == true) {
					if (teams [0].units.Contains (allskills [p].unitc)) {
						int ju = teams [0].units.IndexOf (allskills [p].unitc);
						teams [0].units.RemoveAt (ju);
						teams [0].unitshp.RemoveAt (ju);
						teams [0].unsdvig.RemoveAt (ju);
						Destroy (teams [0].inst [ju]);
						teams [0].inst.RemoveAt (ju);
					}
					else
						teams [0].mainunithp = -10;
				}
				teams [0].casting = true;
				if (choosedskill < teams [0].units.Count) {
					teams [0].caster = choosedskill;
				} else
					teams [0].caster = -1;
				if (allskills [p].deyst != "build" && allskills [p].deyst != "buildtsel")
					teams [0].casttime = allskills [p].castlength;
				else
					teams [0].casttime = 0;
				teams [0].castskillnum = p;
			}
			cancelskil ();
		}
	}
	public string txtparse(string toparse){
		string res="";
		for (int i = 0; i < toparse.Length; i++) {
			if (toparse [i] == '*') {
				if (i < toparse.Length - 1) {
					if (toparse [i+1] == '*') {
						int ghg = i + 2;
						string ssss = "";
						while (true) {
							if (toparse [ghg] != '*') {
								ssss += toparse [ghg];
								ghg += 1;
							} else {
								i = ghg + 1;
								res += myparse (ssss).ToString ();
								break;
							}
						}

					} else
						res += toparse [i];
				} else res += toparse [i];
			} else
				res += toparse [i];
		}
		return res;
	}
	public int myparse (string toparse)
	{
		int aqw;
		if (int.TryParse (toparse, out aqw)) {
			return int.Parse (toparse);	
		} else {
			string s = toparse;
			string c1 = "";
			string c2 = "";
			string c3 = "";
			int ccc = 0;
			for (int i = 0; i < s.Length; i++) {
				if (s [i] != '_') {
					if (ccc == 0)
						c1 += s [i];
					if (ccc == 1)
						c2 += s [i];
					if (ccc == 2)
						c3 += s [i];
				} else
					ccc += 1;
			}
			Debug.Log (c1);
			Debug.Log (c2);
			Debug.Log (c3);
			int a = ((int)((rescourse [int.Parse (c1)] * int.Parse (c2)) / rescourse [int.Parse (c3)]));
			return (a == 0) ? 1 : a;

		}
	}
}

//quests	col n n n n n
//res	col n n n n n
//wiki	col n n n n n (open: 1/0)
//globalsob	col n n n n n
//gamecreated 1/0
//cities	col race race race def def def
//buildings	col n x y n x y n x y n x y n x y 																	//!!!!!!
//teams (((isteam(0/1) name mainunit mainunithp mainunitpos.x mainunitpos.y unitscol num num num hp hp hp)))x10