using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguingod : MonoBehaviour
{

    
    
    
    
    NewGridTest gridscript;
    GameObject grid;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
    GameObject pgod;
    GameObject pgbody;
    bool penguinset = true;
    // Use this for initialization



    void Awake()
    {
        pgod = GameObject.Find("PenguinGod");
        pgbody = GameObject.Find("PenguinGodBody");



        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();

        
    }

 



    private void pgstartposition()
    {


        gridposition = gridscript.grid[5, 7].transform.position;
        pgod.transform.position = gridposition;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (penguinset == true)
        {
            pgstartposition();
            penguinset = false;
        }
    }
}
