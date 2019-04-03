using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SummonCharacter : MonoBehaviour {
    GameObject summonholder;
    GameObject summon;
    public GameObject mg;
    NewGridTest gridscript;
    GameObject grid;
    Color summonholdercolor;
    Vector3 gridposition;
    public bool mechselected;
    public bool mechcanmove;
    private int summonselected = 0;
    public int mholdergone;
    public bool everyonesummoned;
    Vector3 centermechongrid = new Vector3(2, 0, 0);

    CubeWarriorSummon cws;
    GameObject cubewarrior;

    swordsmansummoning swordsmansummonscript;
    GameObject smsummon;

    HealerSummon healersummonscript;
    GameObject healer;

    public float speed = 10;
    public float defense = 12;
    public float attack = 10;

    // Use this for initialization
    void Awake () {
        summonholder = GameObject.Find("summonholder");
        summon = GameObject.Find("mech");
        mg = GameObject.Find("MechGlow");
        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        summonholdercolor = summonholder.GetComponent<Renderer>().material.color;
        summon.SetActive(false);
        mechselected = false;
        mg.SetActive(false);
        cubewarrior = GameObject.Find("CubeWarriorSummoning");
        cws = cubewarrior.GetComponent<CubeWarriorSummon>();

        smsummon = GameObject.Find("SummonSwordsman");
        swordsmansummonscript = smsummon.GetComponent<swordsmansummoning>();

        healer = GameObject.Find("SummonHealer");
        healersummonscript = healer.GetComponent<HealerSummon>();

    }



    void allsummoned()
    {
        if (swordsmansummonscript.smholdergone != 1 || cws.cwholdergone != 1 || healersummonscript.hholdergone != 1)
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
        if (healersummonscript.healerselected == true || swordsmansummonscript.swordsmanselected == true || cws.warriorselected == true)
        {

            
            mechselected = false;
            mg.SetActive(false);
        }
    }

    void warriorselect()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == summon && Input.GetMouseButtonUp(0) && mechselected == false)
        {
            
            mechselected = true;
            mg.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == summon && Input.GetMouseButtonUp(0) && mechselected == true)
        {

            mechselected = false;
            
            mg.SetActive(false);
        }
    }

    void changelocation()
    {
        if (mechcanmove == true && summon.transform.position != gridposition)
        {

            summon.transform.position = Vector3.MoveTowards(summon.transform.position, gridposition, .4f);
        }
        else
        {
            mechcanmove = false;
        }
    }

    void movetoclick()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
        {
            for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length)/2; z++)
            {
                if (summon && Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z] && Input.GetMouseButton(0) && mechselected == true)

            
            {

                    gridposition = gridscript.grid[i, z].transform.position + centermechongrid;
                    mechcanmove = true;
                //summon.transform.position = Vector3.MoveTowards(summon.transform.position, gridscript.grid[i, z].transform.position+centermechongrid, .4f);
                // gridscript.grid[1, 1].SetActive(false);
                }
        }
    }
            
    }
    void SelectSummon()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (summonselected == 1 && Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "CombatZone" && Input.GetMouseButtonUp(0))
        {
          
            summon.SetActive(true);
            
            summon.transform.position = hit.collider.gameObject.transform.position+centermechongrid;
            

            summonselected = 0;
            summonholder.SetActive(false);
            mholdergone = 1;
        }
        else if (summonselected == 1 && Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "CombatZone" && Input.GetMouseButtonUp(0))
        {
            summonselected = 0;
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "summonholder" && Input.GetMouseButtonUp(0))
        {
            summonholder.GetComponent<Renderer>().material.color = Color.cyan;
            summonselected = 1;
           
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "summonholder")
        {
            
            summonholder.GetComponent<Renderer>().material.color = Color.cyan;
            //gameObject.GetComponent<Renderer>().material.color = Color.white;


        }



        else if (summonselected == 1)
        {

        }
        else
        {
            summonholder.GetComponent<Renderer>().material.color = summonholdercolor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkotherselected();
        allsummoned();
        warriorselect();
        SelectSummon();
        

    }
}
