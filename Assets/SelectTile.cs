using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour
{

    int selected = 0;
    void Awake()
    {
        //tile = GameObject.Find("GridPlaceHolder");
        // newgridtest = tile.GetComponent<NewGridTest>();

    }

    void OnMouseOver()
    {
        if (selected == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

    }
    void OnMouseExit()
    {
        if (selected == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }

        else
        {
            
        }

    }
}
