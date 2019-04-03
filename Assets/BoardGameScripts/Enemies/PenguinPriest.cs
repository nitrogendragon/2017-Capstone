using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPriest : MonoBehaviour
{

    
    
    
    
    NewGridTest gridscript;
    GameObject grid;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
   
    GameObject ppriest;
    GameObject ppbody;
    bool penguinset = true;
    // Use this for initialization



    void Awake()
    {
        ppriest = GameObject.Find("PenguinPriest");
        ppbody = GameObject.Find("PenguinPriestBody");



        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        

    }





    private void ppstartposition()
    {


        gridposition = gridscript.grid[2, 9].transform.position;
        ppriest.transform.position = gridposition;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (penguinset == true)
        {
            ppstartposition();
            penguinset = false;
        }
       
    }
}
