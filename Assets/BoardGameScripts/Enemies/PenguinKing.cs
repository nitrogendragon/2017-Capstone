using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinKing : MonoBehaviour
{
    
    
    
    
    NewGridTest gridscript;
    GameObject grid;
    Vector3 gridposition;
    Vector3 adjust = new Vector3(0, 1, 0);
    GameObject pking;
    GameObject pkbody;
    bool penguinset =true;
   
    // Use this for initialization

   

    void Awake()
    {
        pking = GameObject.Find("PenguinKing");
        pkbody = GameObject.Find("PenguinKingBody");
        
       
        
        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
       
        
    }


  
  
   
    private void pkstartposition()
    {


        gridposition = gridscript.grid[5, 9].transform.position;
        pking.transform.position = gridposition;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (penguinset == true)
        {
            pkstartposition();
            penguinset = false;
        }
    }
}
