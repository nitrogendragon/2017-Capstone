using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinmaster : MonoBehaviour {





    NewGridTest gridscript;
    GameObject grid;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
    GameObject pmaster;
    GameObject pmbody;
    bool penguinset = true;
    // Use this for initialization



    void Awake()
    {
        pmaster = GameObject.Find("PenguinMaster");
        pmbody = GameObject.Find("PenguinMasterBody");



        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();


    }





    private void pmstartposition()
    {


        gridposition = gridscript.grid[5, 5].transform.position;
        pmaster.transform.position = gridposition;


    }

    // Update is called once per frame
    void Update()
    {
        if (penguinset == true)
        {
            pmstartposition();
            penguinset = false;
        }
    }
}
