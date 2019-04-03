using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWarriorSummon : MonoBehaviour {
    public GameObject cwsh;//cubewarriorsummoningholder
    GameObject cw;//cubewarrior
    GameObject cwb;// cube warrior body
    public GameObject cwh;
    public GameObject cwg;
    NewGridTest gridscript;
    GameObject grid;
    public bool warriorselected;
    public bool warriorcanmove;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
    Color cwshc;// cubewarriorsummoningholdercolor
    private int cws = 0;// short for cube warrior selected
    // Use this for initialization
    public int cwholdergone;
    GameObject summoning;
    SummonCharacter sc;
    public float speed = 13;
    public float defense = 6;
    public float attack = 9;
    swordsmansummoning swordsmansummonscript;
    GameObject smsummon;

    HealerSummon healersummonscript;
    GameObject healersummon;

    void Awake () {
        cwg = GameObject.Find("CubeWarriorGlow");
        cwh = GameObject.Find("CubeWarriorHolder");
        cwsh = GameObject.Find("CubeWarriorHolderBorder");
        cw = GameObject.Find("CubeWarrior");
        cwb = GameObject.Find("CubeWarriorBody");
        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        cwshc = cwsh.GetComponent<Renderer>().material.color;

        summoning = GameObject.Find("Summoning");
        sc = summoning.GetComponent<SummonCharacter>();

        smsummon = GameObject.Find("SummonSwordsman");
        swordsmansummonscript = smsummon.GetComponent<swordsmansummoning>();

        healersummon = GameObject.Find("SummonHealer");
        healersummonscript = healersummon.GetComponent<HealerSummon>();

        cw.SetActive(false);
        cwg.SetActive(false);
        warriorselected = false;
          
}

    void allsummoned()
    {
        if (swordsmansummonscript.smholdergone != 1 || healersummonscript.hholdergone != 1 || sc.mholdergone != 1)
        {

        }
        else
        {

            movetoclick();
            changelocation();
        }

    }

    void checkotherselected()
    {
        if (healersummonscript.healerselected == true || swordsmansummonscript.swordsmanselected == true || sc.mechselected == true)
        {

            
            warriorselected = false;
            cwg.SetActive(false);
        }
    }
    void warriorselect()
    {
       RaycastHit hit;
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if ( Physics.Raycast(ray, out hit) && hit.collider.gameObject == cwb && Input.GetMouseButtonUp(0) && warriorselected == false)
        {
            
             warriorselected = true;
            cwg.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == cwb && Input.GetMouseButtonUp(0) && warriorselected == true)
        {
            
            warriorselected = false;
            cwg.SetActive(false);
        }

    }
    void changelocation()
    {
        if(warriorcanmove == true && cw.transform.position!= gridposition)
        {
            
            cw.transform.position = Vector3.MoveTowards(cw.transform.position, gridposition, .4f);
        }
        else
        {
            warriorcanmove = false;
        }
    }
   private void movetoclick()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < Mathf.Sqrt(gridscript.grid.Length); i++)
        {
            for (int z = 0; z < Mathf.Sqrt(gridscript.grid.Length)/2; z++)
            {
                if (cw && Physics.Raycast(ray, out hit, 4000) && hit.collider.gameObject == gridscript.grid[i, z] && Input.GetMouseButton(0) && warriorselected == true)


                {
                    
                    gridposition = gridscript.grid[i, z].transform.position+adjust;
                    warriorcanmove = true;
                    
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
        if (cws == 1 && Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "CombatZone" && Input.GetMouseButtonUp(0))
        {
           
            cw.SetActive(true);
           
            cw.transform.position = hit.collider.gameObject.transform.position + adjust;
            

            cws = 0;
            cwh.SetActive(false);
            cwsh.SetActive(false);
            cwholdergone = 1;
        }
         
        
          else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag == "cubewarriorholder" && Input.GetMouseButtonUp(0))
        {
            cwsh.GetComponent<Renderer>().material.color = Color.cyan;
            cws = 1;
         
        }
            
        
        else if (Physics.Raycast(ray, out hit, 4000) && hit.collider.tag =="cubewarriorholder")
        {
            
            cwsh.GetComponent<Renderer>().material.color = Color.cyan;
            //gameObject.GetComponent<Renderer>().material.color = Color.white;


        }



        else if (cws == 1)
        {
           
        }
        else
        {
            cwsh.GetComponent<Renderer>().material.color = cwshc;
            
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
