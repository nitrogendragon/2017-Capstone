using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSummon : MonoBehaviour
{

    GameObject healer;//cubewarrior
    GameObject hb;// cube warrior body
    public GameObject hh;
    public GameObject hg;
    NewGridTest gridscript;
    GameObject grid;
    public bool healerselected;
    public bool healercanmove;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
    Color hshc;// cubewarriorsummoningholdercolor
    private int hs = 0;// short for cube warrior selected
    // Use this for initialization
    public int hholdergone;

    GameObject summoning;
    SummonCharacter sc;

    swordsmansummoning swordsmansummonscript;
    GameObject smsummon;

    CubeWarriorSummon cws;
    GameObject cubewarrior;
    public float speed = 15;
    public float defense = 5;
    public float attack = 7;
    public bool everyonesummoned;

    void Awake()
    {
        hg = GameObject.Find("HealerGlow");
        hh = GameObject.Find("HealerHolder");

        healer = GameObject.Find("Healer");
        hb = GameObject.Find("HealerBody");
        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        hshc = hh.GetComponent<Renderer>().material.color;

        summoning = GameObject.Find("Summoning");
        sc = summoning.GetComponent<SummonCharacter>();

        smsummon = GameObject.Find("SummonSwordsman");
        swordsmansummonscript = smsummon.GetComponent<swordsmansummoning>();

        cubewarrior = GameObject.Find("CubeWarriorSummoning");
        cws = cubewarrior.GetComponent<CubeWarriorSummon>();

        healer.SetActive(false);
        hg.SetActive(false);
        healerselected = false;
    }
    public void allsummoned()
    {
        if(swordsmansummonscript.smholdergone !=1 || cws.cwholdergone !=1 || sc.mholdergone != 1)
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
        if (cws.warriorselected == true || swordsmansummonscript.swordsmanselected == true || sc.mechselected == true)
        {


            healerselected = false;
            hg.SetActive(false);
        }
    }
    void warriorselect()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == healer && Input.GetMouseButtonUp(0) && healerselected == false)
        {

            healerselected = true;
            hg.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == healer && Input.GetMouseButtonUp(0) && healerselected == true)
        {

            healerselected = false;
            hg.SetActive(false);
        }

    }
    void changelocation()
    {
        if (healercanmove == true && healer.transform.position != gridposition)
        {

            healer.transform.position = Vector3.MoveTowards(healer.transform.position, gridposition, .4f);
        }
        else
        {
            
            healercanmove = false;
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
                if (healer && Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z] && Input.GetMouseButton(0) && healerselected == true)


                {

                    gridposition = gridscript.grid[i, z].transform.position;
                  
                    healercanmove = true;

                    //Vector3 adjust = new Vector3(0, 1, 0);
                    //cw.transform.position = Vector3.MoveTowards(cw.transform.position, gridscript.grid[i, z].transform.position+adjust, .4f);


                    // gridscript.grid[1, 1].SetActive(false);
                }
            }
        }

    }
    void SelectWarrior()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (hs == 1 && Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "CombatZone" && Input.GetMouseButtonUp(0))
        {

            healer.SetActive(true);

            healer.transform.position = hit.collider.gameObject.transform.position;


            hs = 0;
            hh.SetActive(false);
            hholdergone = 1;

        }


        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "healerholder" && Input.GetMouseButtonUp(0))
        {
            hh.GetComponent<Renderer>().material.color = Color.cyan;
            hs = 1;

        }


        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "healerholder")
        {

            hh.GetComponent<Renderer>().material.color = Color.cyan;
            //gameObject.GetComponent<Renderer>().material.color = Color.white;


        }



        else if (hs == 1)
        {

        }
        else
        {
            hh.GetComponent<Renderer>().material.color = hshc;

        }
    }

    // Update is called once per frame
    void Update()
    {
        checkotherselected();
        allsummoned();
        warriorselect();
        SelectWarrior();
    }
}

