using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {
    public Canvas SkillsCanvas;
    //public Text level;
    public Slider CWS1;
    public Slider CWS2;
    public Slider CWS3;
    public Slider HS1;
    public Slider HS2;
    public Slider HS3;
    public Slider SS1;
    public Slider SS2;
    public Slider SS3;
    public Slider MS1;
    public Slider MS2;
    public Slider MS3;

    public float mskilltimer1;
    public float mskilltimer2;
    public float mskilltimer3;
    public float hskilltimer1;
    public float hskilltimer2;
    public float hskilltimer3;
    public float smskilltimer1;
    public float smskilltimer2;
    public float smskilltimer3;
    public float cwskilltimer1;
    public float cwskilltimer2;
    public float cwskilltimer3;

     float stormcd = 1;
     float darkblazecd = 1;
     float dragonragecd = 1;
     float soothecd = 1;
     float phoenixtearcd = 1;
     float blesscd = 20;
     float hiddenbladecd = 6;
     float fullstrikecd = 20;
     float focusedswordcd = 30;
     float enragecd = 60;
     float ragecd = 45;
     float terrorcd = 45;
    bool stormselected;
    
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
    public GameObject healer;
    public swordsmansummoning swordsmansummonscript;// script for summoning swordsman and other functions like selecting
    
    NewGridTest gridscript;
    GameObject grid;
    Vector3 gridposition;
    Vector3 gridpositionrelativeto;

    float speeddowntimer;
    float ptbtimer;
    bool stormdebuffactive;
    bool appliedstormdebuff;

    float pgspeed;
    float ppspeed;
    float pkspeed;
    float pmspeed;

    float cwdefense;
    float smdefense;
    float hdefense;
    float mdefense;

    CubeWarriorSummon cws;// script for summoning and selecting among other things the cube warrior

    public GameObject mech;// the mech  
    SummonCharacter sc;// summons the mech "poorly named script I know
    HealerSummon healersummonscript;// script for summoning healer and selecting

    
    GameObject healerbody;// healer body object

    public GameObject cubewarrior;// cube warrior object
    public GameObject cubewarriorbody; // body of the cubewarrior
                                       // Use this for initialization

    List<float> CurrentSkillTimes = new List<float>();
    List<float> NeededTime = new List<float>();
    List<Slider> Sliders = new List<Slider>();
    List<GameObject> Enemies = new List<GameObject>();
    List<GameObject> Heroes = new List<GameObject>();
    List<Component> Enemystats = new List<Component>();
    List<Vector3> gridp = new List<Vector3>();
    List<bool> skillselected = new List<bool>();

    void Awake () {
        pg = GameObject.Find("PenguinGod");
        pp = GameObject.Find("PenguinPriest");
        pm = GameObject.Find("PenguinMaster");
        pk = GameObject.Find("PenguinKing");

        pgs = pg.GetComponent<Penguingodstats>();
        pps = pp.GetComponent<PenguinPriestStats>();
        pms = pm.GetComponent<PenguinMasterStats>();
        pks = pk.GetComponent<PenguinKingStats>();

        pgspeed = pgs.speed;
        pkspeed = pks.speed;
        pmspeed = pms.speed;
        ppspeed = pps.speed;

        mstats = mech.GetComponent<MechStats>();
        cwstats = cubewarrior.GetComponent<CubeWarriorStats>();
        hstats = healer.GetComponent<HealerStats>();
        smstats = swordsman.GetComponent<SwordsmanStats>();

        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        Heroes.Add(mech);
        Heroes.Add(healer);
        Heroes.Add(swordsman);
        Heroes.Add(cubewarrior);
        Enemies.Add(pg);
        Enemies.Add(pp);
        Enemies.Add(pk);
        Enemies.Add(pm);

        Enemystats.Add(pgs);
        Enemystats.Add(pps);
        Enemystats.Add(pks);
        Enemystats.Add(pms);

        Sliders.Add(MS1);
        Sliders.Add(MS2);
        Sliders.Add(MS3);
        Sliders.Add(HS1);
        Sliders.Add(HS2);
        Sliders.Add(HS3);
        Sliders.Add(SS1);
        Sliders.Add(SS2);
        Sliders.Add(SS3);       
        Sliders.Add(CWS1);
        Sliders.Add(CWS2);
        Sliders.Add(CWS3);

        CurrentSkillTimes.Add(mskilltimer1);
        CurrentSkillTimes.Add(mskilltimer2);
        CurrentSkillTimes.Add(mskilltimer3);
        CurrentSkillTimes.Add(hskilltimer1);
        CurrentSkillTimes.Add(hskilltimer2);
        CurrentSkillTimes.Add(hskilltimer3);
        CurrentSkillTimes.Add(smskilltimer1);
        CurrentSkillTimes.Add(smskilltimer2);
        CurrentSkillTimes.Add(smskilltimer3);
        CurrentSkillTimes.Add(cwskilltimer1);
        CurrentSkillTimes.Add(cwskilltimer2);
        CurrentSkillTimes.Add(cwskilltimer3);

        NeededTime.Add(stormcd);
        NeededTime.Add(darkblazecd);
        NeededTime.Add(dragonragecd);
        NeededTime.Add(soothecd);
        NeededTime.Add(phoenixtearcd);
        NeededTime.Add(blesscd);
        NeededTime.Add(hiddenbladecd);
        NeededTime.Add(fullstrikecd);
        NeededTime.Add(focusedswordcd);
        NeededTime.Add(enragecd);
        NeededTime.Add(ragecd);
        NeededTime.Add(terrorcd);

        skillselected.Add(stormselected);
        skillselected.Add(alphablazeselected);
        skillselected.Add(dragonrageselected);
        skillselected.Add(sootheselected);

        cwdefense = cwstats.defense;
        smdefense = smstats.defense;
        mdefense = mstats.defense;
        hdefense = hstats.defense;

}

    void allsummoned()
    {
        
        if ( swordsmansummonscript.battlestart == true)
        {
           


            for (int i = 0; i < CurrentSkillTimes.Count; i++)
            {
                if (CurrentSkillTimes[i] == NeededTime[i])
                {

                }
                else
                {
                    CurrentSkillTimes[i] += Time.deltaTime;
                    skillslidersupdate();
                    
                }
            }
        }
    }
    void skillslidersupdate()
    {
        
        int i = 0;
        for(i=0; i<Sliders.Count; i++)
        {
            
            Sliders[i].value = CurrentSkillTimes[i] / NeededTime[i];
        }
        
    }
    void storm()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1) && stormselected == false && Sliders[0].value == Sliders[0].maxValue && mstats.isDead == false)
        {



            cleanboard();
            alphablazeselected = false;
            dragonrageselected = false;
            sootheselected = false;
            /**phoenixtearselected = false;
            blessselected = false;
            hiddenbladeselected = false;
            fullstrikeselected = false;
            focusedswordselected = false;
            enrageselected = false;
            rageselected = false;
            terrorselected = false ;**/
            stormselected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            stormselected = false;
        }
        if (stormselected == true && mstats.isDead == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
            {
                for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length); z++)
                {
                    if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z])


                    {

                        gridposition = gridscript.grid[i, z].transform.position;

                    }
                }
            }
            for (int d = 0; d < Enemies.Count; d++)
            {
                if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == Enemies[d])
                {
                    gridposition = Enemies[d].transform.position;

                }
            }
            gridp.Add(gridposition);

            for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
            {
                for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
                {
                    if (b >= 5)
                    {
                        gridpositionrelativeto = gridscript.grid[c, b].transform.position;
                        if ((gridp[0] - gridpositionrelativeto).magnitude <= 10)
                        {

                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.cyan;

                        }
                        else
                        {
                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;
                        }



                    }
                }

              




            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if ((gridp[0] - pg.transform.position).magnitude <= 10)
                {
                    pgs.TakeDamage(mstats.attack * 3);
                }
                if ((gridp[0] - pk.transform.position).magnitude <= 10)
                {
                    pks.TakeDamage(mstats.attack * 3);
                }
                if ((gridp[0] - pp.transform.position).magnitude <= 10)
                {
                    pps.TakeDamage(mstats.attack * 3);
                }
                if ((gridp[0] - pm.transform.position).magnitude <= 10)
                {
                    pms.TakeDamage(mstats.attack * 3);
                }
                stormdebuffactive = true;
                CurrentSkillTimes[0] = 0;
                stormselected = false;
                
            }
            
            gridp.Clear();
            
        }
    }
    void StormDebuff()
    {
        if (speeddowntimer < 10 && appliedstormdebuff == false)
        {
            
                pgs.speed += -pgspeed / 2;
                pks.speed += -pkspeed / 2;
                pms.speed += -pmspeed / 2;
                pps.speed += -ppspeed / 2;
            appliedstormdebuff = true;
            
        }
        else if(speeddowntimer < 10)
        {

        }
        else
        {
            pgs.speed = pgspeed;
            pks.speed = pkspeed;
            pms.speed = pmspeed;
            pps.speed = ppspeed;
            stormdebuffactive = false;
            appliedstormdebuff = false;
            speeddowntimer = 0;

        }
       
    }

    float darkblazerange = 20;
    float darkblazedamagemultiplier = 2;
    bool alphablazeselected;
    void darkblaze()
    {
        
        
        if (Input.GetKeyUp(KeyCode.Alpha2) && alphablazeselected == false && Sliders[1].value == Sliders[1].maxValue && mstats.isDead == false)
        {
            cleanboard();
            dragonrageselected = false;
            stormselected = false;
            sootheselected = false;
            /**phoenixtearselected = false;
           blessselected = false;
           hiddenbladeselected = false;
           fullstrikeselected = false;
           focusedswordselected = false;
           enrageselected = false;
           rageselected = false;
           terrorselected = false ;**/
            alphablazeselected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            alphablazeselected = false;
        }
        if (alphablazeselected == true && mstats.isDead == false)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
            {
                for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length); z++)
                {
                    if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z])


                    {

                        gridposition = gridscript.grid[i, z].transform.position;

                    }
                }
            }
            for (int d = 0; d < Enemies.Count; d++)
            {
                if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == Enemies[d])
                {
                    gridposition = Enemies[d].transform.position;

                }
            }
            gridp.Add(gridposition);

            for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
            {
                for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
                {
                    if (b >= 5)
                    {
                        gridpositionrelativeto = gridscript.grid[c, b].transform.position;
                        if ((gridp[0] - gridpositionrelativeto).magnitude <= darkblazerange)
                        {

                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.cyan;

                        }
                        else
                        {
                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;
                        }



                    }
                }






            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && alphablazeselected == true)
            {
                if ((gridp[0] - pg.transform.position).magnitude <= darkblazerange)
                {
                    pgs.TakeDamage(mstats.attack * darkblazedamagemultiplier);
                }
                if ((gridp[0] - pk.transform.position).magnitude <= darkblazerange)
                {
                    pks.TakeDamage(mstats.attack * darkblazedamagemultiplier);
                }
                if ((gridp[0] - pp.transform.position).magnitude <= darkblazerange)
                {
                    pps.TakeDamage(mstats.attack * darkblazedamagemultiplier);
                }
                if ((gridp[0] - pm.transform.position).magnitude <= darkblazerange)
                {
                    pms.TakeDamage(mstats.attack * darkblazedamagemultiplier);
                }
                
                CurrentSkillTimes[1] = 0;
                alphablazeselected = false;
            }

            gridp.Clear();

        }
    }

    float dragonragerange = 100;
    float dragonragemultiplier = 10;
    bool dragonrageselected;
    void dragonrage()
    {
        
        
        if (Input.GetKeyUp(KeyCode.Alpha3) && dragonrageselected == false && Sliders[2].value == Sliders[2].maxValue && mstats.isDead == false)
        {
            cleanboard();
            stormselected = false;
            alphablazeselected = false;
            sootheselected = false;
            /**phoenixtearselected = false;
           blessselected = false;
           hiddenbladeselected = false;
           fullstrikeselected = false;
           focusedswordselected = false;
           enrageselected = false;
           rageselected = false;
           terrorselected = false ;**/
            dragonrageselected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            dragonrageselected = false;
        }
        if (dragonrageselected == true && mstats.isDead == false)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
            {
                for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length); z++)
                {
                    if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z])


                    {

                        gridposition = gridscript.grid[i, z].transform.position;

                    }
                }
            }
            for (int d = 0; d < Enemies.Count; d++)
            {
                if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == Enemies[d])
                {
                    gridposition = Enemies[d].transform.position;

                }
            }
            gridp.Add(gridposition);

            for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
            {
                for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
                {
                    if (b >= 5)
                    {
                        gridpositionrelativeto = gridscript.grid[c, b].transform.position;
                        if ((gridp[0] - gridpositionrelativeto).magnitude <= dragonragerange)
                        {

                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.cyan;

                        }
                        else
                        {
                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;
                        }



                    }
                }






            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && dragonrageselected == true)
            {
                if ((gridp[0] - pg.transform.position).magnitude <= dragonragerange)
                {
                    pgs.TakeDamage(mstats.attack * dragonragemultiplier);
                }
                if ((gridp[0] - pk.transform.position).magnitude <= dragonragerange)
                {
                    pks.TakeDamage(mstats.attack * dragonragemultiplier);
                }
                if ((gridp[0] - pp.transform.position).magnitude <= dragonragerange)
                {
                    pps.TakeDamage(mstats.attack * dragonragemultiplier);
                }
                if ((gridp[0] - pm.transform.position).magnitude <= dragonragerange)
                {
                    pms.TakeDamage(mstats.attack * dragonragemultiplier);
                }

                CurrentSkillTimes[2] = 0;
                dragonrageselected = false;
            }

            gridp.Clear();

        }
    }

    float sootherange = 19;
    float soothemultiplier = 3;
    bool sootheselected;
    void soothe()
    {


        if (Input.GetKeyUp(KeyCode.Alpha4) && sootheselected == false && Sliders[3].value == Sliders[3].maxValue && hstats.isDead == false)
        {
            cleanboard();
            stormselected = false;
            alphablazeselected = false;
            dragonrageselected = false;
            /**phoenixtearselected = false;
           blessselected = false;
           hiddenbladeselected = false;
           fullstrikeselected = false;
           focusedswordselected = false;
           enrageselected = false;
           rageselected = false;
           terrorselected = false ;**/
            sootheselected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            sootheselected = false;
        }
        if (sootheselected == true && hstats.isDead == false)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
            {
                for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length); z++)
                {
                    if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z])


                    {

                        gridposition = gridscript.grid[i, z].transform.position;

                    }
                }
            }
            for (int d = 0; d < Heroes.Count; d++)
            {
                if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == Heroes[d])
                {
                    gridposition = Heroes[d].transform.position;

                }
            }
            gridp.Add(gridposition);

            for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
            {
                for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
                {
                    if (b < 5)
                    {
                        gridpositionrelativeto = gridscript.grid[c, b].transform.position;
                        if ((gridp[0] - gridpositionrelativeto).magnitude <= sootherange)
                        {

                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.cyan;

                        }
                        else
                        {
                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;
                        }



                    }
                }






            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && sootheselected == true)
            {
                if ((gridp[0] - healer.transform.position).magnitude <= sootherange)
                {
                    hstats.Restore(hstats.attack * soothemultiplier);
                }
                if ((gridp[0] - cubewarrior.transform.position).magnitude <= sootherange)
                {
                    cwstats.Restore(cwstats.attack * soothemultiplier);
                }
                if ((gridp[0] - swordsman.transform.position).magnitude <= sootherange)
                {
                    smstats.Restore(smstats.attack * soothemultiplier);
                }
                if ((gridp[0] - mech.transform.position).magnitude <= sootherange)
                {
                    
                    mstats.Restore(mstats.attack * soothemultiplier);
                }


                CurrentSkillTimes[3] = 0;
                sootheselected = false;
            }

            gridp.Clear();

        }
    }




    float phoenixtearrange = 19;
    float phoenixtearmultiplier = 2;
    bool phoenixtearselected;
    bool phoenixtearbuffactive;
    bool ptbuffmech;
    bool ptbuffswordsman;
    bool ptbuffhealer;
    bool ptbuffcubewarrior;
    void PhoenixTear()
    {


        if (Input.GetKeyUp(KeyCode.Alpha5) && phoenixtearselected == false && Sliders[4].value == Sliders[4].maxValue && hstats.isDead == false)
        {
            cleanboard();
            stormselected = false;
            alphablazeselected = false;
            dragonrageselected = false;

            /**blessselected = false;
            hiddenbladeselected = false;
            fullstrikeselected = false;
            focusedswordselected = false;
            enrageselected = false;
            rageselected = false;
            terrorselected = false ;**/
            sootheselected = false;
            phoenixtearselected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            phoenixtearselected = false;
        }
        if (phoenixtearselected == true && hstats.isDead == false)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
            {
                for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length); z++)
                {
                    if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z])


                    {

                        gridposition = gridscript.grid[i, z].transform.position;

                    }
                }
            }
            for (int d = 0; d < Heroes.Count; d++)
            {
                if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == Heroes[d])
                {
                    gridposition = Heroes[d].transform.position;

                }
            }
            gridp.Add(gridposition);

            for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
            {
                for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
                {
                    if (b < 5)
                    {
                        gridpositionrelativeto = gridscript.grid[c, b].transform.position;
                        if ((gridp[0] - gridpositionrelativeto).magnitude <= sootherange)
                        {

                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.cyan;

                        }
                        else
                        {
                            gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;
                        }



                    }
                }






            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && phoenixtearselected == true)
            {
                if ((gridp[0] - healer.transform.position).magnitude <= phoenixtearrange)
                {
                    hstats.Restore(hstats.attack * phoenixtearmultiplier);
                    ptbuffhealer = true;
                }
                if ((gridp[0] - cubewarrior.transform.position).magnitude <= phoenixtearrange)
                {
                    cwstats.Restore(cwstats.attack * phoenixtearmultiplier);
                    ptbuffcubewarrior = true;
                }
                if ((gridp[0] - swordsman.transform.position).magnitude <= phoenixtearrange)
                {
                    smstats.Restore(smstats.attack * phoenixtearmultiplier);
                    ptbuffswordsman = true;
                }
                if ((gridp[0] - mech.transform.position).magnitude <= phoenixtearrange)
                {

                    mstats.Restore(mstats.attack * phoenixtearmultiplier);
                    ptbuffmech = true;
                }


                CurrentSkillTimes[4] = 0;
                phoenixtearselected = false;
                phoenixtearbuffactive = true;
            }

            gridp.Clear();

        }
    }
    bool appliedphoenixtearbuff;
    void PhoenixTearBuff()
    {
        if (ptbtimer < 10 && appliedphoenixtearbuff == false)
        {

            if (ptbuffmech == true)
            {
                mstats.defense += mdefense / 6;
            }
            if (ptbuffswordsman == true)
            {
                smstats.defense += smdefense / 6;
            }
            if (ptbuffcubewarrior == true)
            {
                cwstats.defense += cwdefense / 6;
            }
            if (ptbuffhealer == true)
            {
                hstats.defense += hdefense / 6;
            }
            appliedphoenixtearbuff = true;

        }
        else if (ptbtimer < 10)
        {

        }
        else
        {
            hstats.defense = hdefense;
            cwstats.defense = cwdefense;
            smstats.defense = smdefense;
            mstats.defense = mdefense;
            phoenixtearbuffactive = false;
            appliedphoenixtearbuff = false;
            ptbtimer = 0;

        }
    }







    int skillselectedlength;
    void cleanboard()
    {
        for (int c = 0; c < Mathf.Sqrt(gridscript.grid.Length); c++)
        {
            for (int b = 0; b < Mathf.Sqrt(gridscript.grid.Length); b++)
            {



                {
                    gridscript.grid[c, b].GetComponent<Renderer>().material.color = Color.white;

                }

                







            }
            skillselectedlength = 0;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(stormdebuffactive == true)
        {
            StormDebuff();
            speeddowntimer += Time.deltaTime;
        }
        if(phoenixtearbuffactive == true)
        {
            ptbtimer += Time.deltaTime;
            PhoenixTearBuff();
        }
        allsummoned();
        storm();
        darkblaze();
        dragonrage();
        soothe();
        PhoenixTear();
        if (Input.GetKeyUp(KeyCode.Mouse0) || alphablazeselected==false && stormselected == false && dragonrageselected == false && sootheselected == false && phoenixtearselected == false){
            cleanboard();
        }
        
    }
}
