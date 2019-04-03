using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profiles : MonoBehaviour {


    public Canvas ProfileCanvas;
    public Text level;
    public Slider experienceslider;
    public Slider hpslider;
    
    public Text health;
    
    public Text attack;
    
    public Text defense;
   
    public Text speed;
    
    public Text experience;
    
    
    
    public Text charactername;
    string ccharactername;



    GameObject pg;//penguingod
    GameObject pp;//penguin priest
    GameObject pm;//penguin master
    GameObject pk;//penguin king

    Penguingodstats pgs;//penguin god stats
    PenguinKingStats pks;//penguin king stats
    PenguinMasterStats pms;//penguin master stats
    PenguinPriestStats pps;//penguin priest stats

    MechStats mstats;//mech stats
    SwordsmanStats smstats;// swordsman stats
    HealerStats hstats;// healer stats
    CubeWarriorStats cwstats;// cube warrior stats

    public GameObject swordsman;// swordsman gameobject
    GameObject swordsmanbody;// body of the swordsman
    swordsmansummoning swordsmansummonscript;// script for summoning swordsman and other functions like selecting
    




    CubeWarriorSummon cws;// script for summoning and selecting among other things the cube warrior
    
    public GameObject mech;// the mech  
    SummonCharacter sc;// summons the mech "poorly named script I know
    HealerSummon healersummonscript;// script for summoning healer and selecting
    
    public GameObject healer;// healer object
    GameObject healerbody;// healer body object

    public GameObject cubewarrior;// cube warrior object
    public GameObject cubewarriorbody; // body of the cubewarrior

    

    List<GameObject> characters = new List<GameObject>();
    List<int> Maxlevel = new List<int>();
    List<int> Level = new List<int>();
    List<float> Attack = new List<float>();
    List<float> Defense = new List<float>();
    List<float> Speed = new List<float>();
    List<float> Experience = new List<float>();
    List<float> ExperienceLeft = new List<float>();
    List<float> Currenthealth = new List<float>();
    List<float> Maxhealth = new List<float>();
    List<Component> Stats = new List<Component>();
    List<bool> ActiveProfile = new List<bool>();
    bool pgon;
    bool pkon;
    bool pmon;
    bool ppon;
    bool cubewarrioron;
    bool mechon;
    bool healeron;
    bool swordsmanon;

    void Awake()
    {
        
        ProfileCanvas.enabled = false;

        pg = GameObject.Find("PenguinGod");
        pp = GameObject.Find("PenguinPriest");
        pk = GameObject.Find("PenguinKing");
        pm = GameObject.Find("PenguinMaster");

       

        pgs = pg.GetComponent<Penguingodstats>();
        pks = pk.GetComponent<PenguinKingStats>();
        pms = pm.GetComponent<PenguinMasterStats>();
        pps = pp.GetComponent<PenguinPriestStats>();

        mstats = mech.GetComponent<MechStats>();
        cwstats = cubewarrior.GetComponent<CubeWarriorStats>();
        hstats = healer.GetComponent<HealerStats>();
        smstats = swordsman.GetComponent<SwordsmanStats>();
        ActiveProfile.Add(pgon);
        ActiveProfile.Add(pkon);
        ActiveProfile.Add(pmon);
        ActiveProfile.Add(ppon);
        ActiveProfile.Add(cubewarrioron);
        ActiveProfile.Add(mechon);
        ActiveProfile.Add(healeron);
        ActiveProfile.Add(swordsmanon);

        characters.Add(pg);
        characters.Add(pk);
        characters.Add(pm);
        characters.Add(pp);
        characters.Add(cubewarriorbody);
        characters.Add(mech);
        characters.Add(healer);
        characters.Add(swordsman);

        Stats.Add(pgs);
        Stats.Add(pks);
        Stats.Add(pms);
        Stats.Add(pps);
        Stats.Add(cwstats);
        Stats.Add(mstats);
        Stats.Add(hstats);
        Stats.Add(smstats);

        Attack.Add(pgs.attack);
        Attack.Add(pks.attack);
        Attack.Add(pms.attack);
        Attack.Add(pps.attack);
        Attack.Add(cwstats.attack);
        Attack.Add(mstats.attack);
        Attack.Add(hstats.attack);
        Attack.Add(smstats.attack);
        
        Defense.Add(pgs.defense);
        Defense.Add(pks.defense);
        Defense.Add(pms.defense);
        Defense.Add(pps.defense);
        Defense.Add(cwstats.defense);
        Defense.Add(mstats.defense);
        Defense.Add(hstats.defense);
        Defense.Add(smstats.defense);
        
        Speed.Add(pgs.speed);
        Speed.Add(pks.speed);
        Speed.Add(pms.speed);
        Speed.Add(pps.speed);
        Speed.Add(cwstats.speed);
        Speed.Add(mstats.speed);
        Speed.Add(hstats.speed);
        Speed.Add(smstats.speed);
        
        Currenthealth.Add(pgs.currentHealth);
        Currenthealth.Add(pks.currentHealth);
        Currenthealth.Add(pms.currentHealth);
        Currenthealth.Add(pps.currentHealth);
        Currenthealth.Add(cwstats.currentHealth);
        Currenthealth.Add(mstats.currentHealth);
        Currenthealth.Add(hstats.currentHealth);
        Currenthealth.Add(smstats.currentHealth);
        
        Maxhealth.Add(pgs.startingHealth);
        Maxhealth.Add(pks.startingHealth);
        Maxhealth.Add(pms.startingHealth);
        Maxhealth.Add(pps.startingHealth);
        Maxhealth.Add(cwstats.startingHealth);
        Maxhealth.Add(mstats.startingHealth);
        Maxhealth.Add(hstats.startingHealth);
        Maxhealth.Add(smstats.startingHealth);
        
        Experience.Add(pgs.experience);
        Experience.Add(pks.experience);
        Experience.Add(pms.experience);
        Experience.Add(pps.experience);
        Experience.Add(cwstats.experience);
        Experience.Add(mstats.experience);
        Experience.Add(hstats.experience);
        Experience.Add(smstats.experience);
        
        ExperienceLeft.Add(pgs.experienceleft);
        ExperienceLeft.Add(pks.experienceleft);
        ExperienceLeft.Add(pms.experienceleft);
        ExperienceLeft.Add(pps.experienceleft);
        ExperienceLeft.Add(cwstats.experienceleft);
        ExperienceLeft.Add(mstats.experienceleft);
        ExperienceLeft.Add(hstats.experienceleft);
        ExperienceLeft.Add(smstats.experienceleft);
        
        Level.Add(pgs.level);
        Level.Add(pks.level);
        Level.Add(pms.level);
        Level.Add(pps.level);
        Level.Add(cwstats.level);
        Level.Add(mstats.level);
        Level.Add(hstats.level);
        Level.Add(smstats.level);
        
        Maxlevel.Add(pgs.maxlevel);
        Maxlevel.Add(pks.maxlevel);
        Maxlevel.Add(pms.maxlevel);
        Maxlevel.Add(pps.maxlevel);
        Maxlevel.Add(cwstats.maxlevel);
        Maxlevel.Add(mstats.maxlevel);
        Maxlevel.Add(hstats.maxlevel);
        Maxlevel.Add(smstats.maxlevel);

    }
    
    void ProfileOn()
    {
        
        int i;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            
            for ( i = 0; i < characters.Count; i++)
            {
                
                
                if (Input.GetKeyUp(KeyCode.Z) && hit.collider.gameObject == characters[i])
                {
                  
                    if (i == 0)
                    {
                        Currenthealth[i] = pgs.currentHealth;
                        Maxhealth[i] = pgs.startingHealth;
                        Attack[i] = pgs.attack;
                        Defense[i] = pgs.defense;
                        Speed[i] = pgs.speed;
                        Experience[i] = pgs.experience;
                        ExperienceLeft[i] = pgs.experienceleft;
                        Level[i] = pgs.level;
                        hpslider.value = pgs.currentHealth / pgs.startingHealth;
                        experienceslider.value = pgs.experience / pgs.experienceleft;

                        experienceslider.value = Experience[i] / ExperienceLeft[i];


                    }
                    else if (i == 1)
                    {
                        Currenthealth[i] = pks.currentHealth;
                        Maxhealth[i] = pks.startingHealth;
                        Attack[i] = pks.attack;
                        Defense[i] = pks.defense;
                        Speed[i] = pks.speed;
                        Experience[i] = pks.experience;
                        ExperienceLeft[i] = pks.experienceleft;
                        Level[i] = pks.level;
                        hpslider.value = pks.currentHealth / pks.startingHealth;
                        experienceslider.value = pks.experience / pks.experienceleft;
                    }
                    else if (i == 2)
                    {
                        Currenthealth[i] = pms.currentHealth;
                        Maxhealth[i] = pms.startingHealth;
                        Attack[i] = pms.attack;
                        Defense[i] = pms.defense;
                        Speed[i] = pms.speed;
                        Experience[i] = pms.experience;
                        ExperienceLeft[i] = pms.experienceleft;
                        Level[i] = pms.level;
                        hpslider.value = pms.currentHealth / pms.startingHealth;
                        experienceslider.value = pms.experience / pms.experienceleft;
                    }
                    else if (i == 3)
                    {
                        Currenthealth[i] = pps.currentHealth;
                        Maxhealth[i] = pps.startingHealth;
                        Attack[i] = pps.attack;
                        Defense[i] = pps.defense;
                        Speed[i] = pps.speed;
                        Experience[i] = pps.experience;
                        ExperienceLeft[i] = pps.experienceleft;
                        Level[i] = pps.level;
                        hpslider.value = pps.currentHealth / pps.startingHealth;
                        experienceslider.value = pps.experience / pps.experienceleft;
                    }
                    else if (i == 4)
                    {
                        Currenthealth[i] = cwstats.currentHealth;
                        Maxhealth[i] = cwstats.startingHealth;
                        Attack[i] = cwstats.attack;
                        Defense[i] = cwstats.defense;
                        Speed[i] = cwstats.speed;
                        Experience[i] = cwstats.experience;
                        ExperienceLeft[i] = cwstats.experienceleft;
                        Level[i] = cwstats.level;
                        hpslider.value = cwstats.currentHealth / cwstats.startingHealth;
                        experienceslider.value = cwstats.experience / cwstats.experienceleft;
                    }
                    else if (i == 5)
                    {
                        Currenthealth[i] = mstats.currentHealth;
                        Maxhealth[i] = mstats.startingHealth;
                        Attack[i] = mstats.attack;
                        Defense[i] = mstats.defense;
                        Speed[i] = mstats.speed;
                        Experience[i] = mstats.experience;
                        ExperienceLeft[i] = mstats.experienceleft;
                        Level[i] = mstats.level;
                        hpslider.value = mstats.currentHealth / mstats.startingHealth;
                        experienceslider.value = mstats.experience / mstats.experienceleft;
                    }
                    else if (i == 6)
                    {
                        Currenthealth[i] = hstats.currentHealth;
                        Maxhealth[i] = hstats.startingHealth;
                        Attack[i] = hstats.attack;
                        Defense[i] = hstats.defense;
                        Speed[i] = hstats.speed;
                        Experience[i] = hstats.experience;
                        ExperienceLeft[i] = hstats.experienceleft;
                        Level[i] = hstats.level;
                        hpslider.value = hstats.currentHealth / hstats.startingHealth;
                        experienceslider.value = hstats.experience / hstats.experienceleft;
                    }
                    else if (i == 7)
                    {
                        Currenthealth[i] = smstats.currentHealth;
                        Maxhealth[i] = smstats.startingHealth;
                        Attack[i] = smstats.attack;
                        Defense[i] = smstats.defense;
                        Speed[i] = smstats.speed;
                        Experience[i] = smstats.experience;
                        ExperienceLeft[i] = smstats.experienceleft;
                        Level[i] = smstats.level;
                        hpslider.value = smstats.currentHealth / smstats.startingHealth;
                        experienceslider.value = smstats.experience / smstats.experienceleft;
                    }

                    attack.text ="Attack " + Attack[i].ToString();
                    
                    defense.text ="Defense " + Defense[i].ToString();
                    speed.text ="Speed" + Speed[i].ToString();
                    level.text = "Level " + Level[i].ToString() + "/" + Maxlevel[i];
                    
                    health.text = "HP " + Currenthealth[i].ToString() + "/" + Maxhealth[i].ToString();
                    experience.text = "Exp " + Experience[i].ToString() + "/" + ExperienceLeft[i];
                    charactername.text = characters[i].ToString();
                    hpslider.value = Currenthealth[i]/Maxhealth[i];
                    
                    experienceslider.value = Experience[i]/ExperienceLeft[i];

                    var charsToRemove = new string[] { "(UnityEngine.GameObject)" };
                    foreach (var c in charsToRemove)
                    {
                        charactername.text = charactername.text.Replace(c, string.Empty);
                    }
                    

                    ProfileCanvas.enabled = true;
                }
                
            }
        }
    }

    void ProfileOff()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            ProfileCanvas.enabled = false;
        }
    }

    void ProfileSwitchOn()
    {
        

    }

    void Update()
    {
        ProfileOn();
        ProfileOff();
        ProfileSwitchOn();
       
       
    }
}
