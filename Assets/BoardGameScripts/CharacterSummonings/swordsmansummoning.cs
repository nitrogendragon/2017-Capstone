using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class swordsmansummoning : MonoBehaviour
{
    GameObject pg;
    GameObject pp;
    GameObject pm;
    GameObject pk;

    Penguingodstats pgs;
    PenguinKingStats pks;
    PenguinMasterStats pms;
    PenguinPriestStats pps;

    public GameObject swordsmanholder;
    GameObject swordsman;
    GameObject swordsmanbody;
    public GameObject sg;
    NewGridTest gridscript;
    GameObject grid;
    Color swordsmanholdercolor;
    Vector3 gridposition;
    public bool swordsmanselected;
    public bool swordsmancanmove;
    private int sms = 0;
    public int smholdergone;
    public bool everyonesummoned = false;
    public bool battlestart;
    CubeWarriorSummon cws;
    GameObject cubewarrior;
    GameObject summoning;
    SummonCharacter sc;
    HealerSummon healersummonscript;
    GameObject healersummon;
    public float speed = 20;
    public float defense = 3;
    public float attack = 14;
    float regatktimer;
    // Use this for initialization
    void Awake()
    {
        swordsmanholder = GameObject.Find("SwordsmanHolder");
        swordsman = GameObject.Find("Swordsman");
        swordsmanbody = GameObject.Find("SwordsmanBody");
        sg = GameObject.Find("SwordsmanGlow");
        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        swordsmanholdercolor = swordsmanholder.GetComponent<Renderer>().material.color;
        swordsman.SetActive(false);
        swordsmanselected = false;
        sg.SetActive(false);
        cubewarrior = GameObject.Find("CubeWarriorSummoning");
        cws = cubewarrior.GetComponent<CubeWarriorSummon>();

        summoning = GameObject.Find("Summoning");
        sc = summoning.GetComponent<SummonCharacter>();

        healersummon = GameObject.Find("SummonHealer");
        healersummonscript = healersummon.GetComponent<HealerSummon>();


        pg = GameObject.Find("PenguinGod");
        pm = GameObject.Find("PenguinMaster");
        pp = GameObject.Find("PenguinPriest");
        pk = GameObject.Find("PenguinKing");

        pgs = pg.GetComponent<Penguingodstats>();
        pms = pm.GetComponent<PenguinMasterStats>();
        pps = pp.GetComponent<PenguinPriestStats>();
        pks = pk.GetComponent<PenguinKingStats>();
    }
    void Startbattle()
    {
        if(everyonesummoned == true)
        {
            if (Input.GetKeyUp(KeyCode.M))
            {
                battlestart = true;
            }
        }
    }
    public void allsummoned()
    {
        if (healersummonscript.hholdergone != 1 || cws.cwholdergone != 1 || sc.mholdergone != 1 || sms!=0)
        {
            
        }
        else
        {
            everyonesummoned = true;
            movetoclick();
            changelocation();
            
        }

    }

    void checkotherselected()
    {
        if (healersummonscript.healerselected || sc.mechselected == true || cws.warriorselected == true)
        {


            swordsmanselected = false;
            sg.SetActive(false);
        }
    }
    void ensurenowarp()
    {
        if (swordsmanselected == false && swordsman.transform.position == gridposition)
        {
            swordsmancanmove = false;
        }
    }
    void warriorselect()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == swordsman && Input.GetMouseButtonUp(0) && swordsmanselected == true)
        {

            swordsmanselected = false;
            sg.SetActive(false);
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == swordsman && Input.GetMouseButtonUp(0) && swordsmanselected == false)
        {

            swordsmanselected = true;

            sg.SetActive(true);
        }
    }

    void changelocation()
    {
        if (swordsmancanmove == true && swordsman.transform.position != gridposition)
        {

            swordsman.transform.position = Vector3.MoveTowards(swordsman.transform.position, gridposition, .4f);
        }
        else
        {
            swordsmancanmove = false;
        }
    }
    private void movetoclick()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
        {
            for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length) / 2; z++)
            {
                if (swordsman && Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z] && Input.GetMouseButton(0) && swordsmanselected == true)


                {

                    gridposition = gridscript.grid[i, z].transform.position;
                    swordsmancanmove = true;

                    //Vector3 adjust = new Vector3(0, 1, 0);
                    //cw.transform.position = Vector3.MoveTowards(cw.transform.position, gridscript.grid[i, z].transform.position+adjust, .4f);


                    // gridscript.grid[1, 1].SetActive(false);
                }
            }
        }

    }
    void SelectSwordsman()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if ( sms == 1 && Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "CombatZone" && Input.GetMouseButtonUp(0))
        {

            swordsman.SetActive(true);

            swordsman.transform.position = hit.collider.gameObject.transform.position;


            sms = 0;
            swordsmanholder.SetActive(false);
            smholdergone = 1;
        }
      
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "swordsmanholder" && Input.GetMouseButtonUp(0))
        {
            swordsmanholder.GetComponent<Renderer>().material.color = Color.cyan;
            sms = 1;

        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "swordsmanholder")
        {

            swordsmanholder.GetComponent<Renderer>().material.color = Color.cyan;
            //gameObject.GetComponent<Renderer>().material.color = Color.white;


        }



        else if (sms == 1)
        {

        }
        else
        {
            swordsmanholder.GetComponent<Renderer>().material.color = swordsmanholdercolor;
        }
    }


    
   
   

    // Update is called once per frame
    void Update()
    {
        checkotherselected();
        allsummoned();
        warriorselect();
        SelectSwordsman();
        Startbattle();
       
        
    }
}
