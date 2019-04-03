using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectwithmouseandmove : MonoBehaviour {
    public static float selected = 0;
    public GameObject target1;
 
    private Vector3 newPosition;


 
    // Use this for initialization
    void OnMouseOver()
    {
        if (selected == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
           /** if (Input.GetMouseButtonUp(0))
        {
            if (selected != 1)
            {
                selected += 1;
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                selected = 0;
            }
           // gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        //gameObject.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;**/
    }
    void OnMouseExit()
    {
        if (selected == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            Debug.Log(selected);
        }

        else
        {
            Debug.Log(selected);
        }
        
    }
    void Start () {
        newPosition = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (selected == 0 && gameObject.GetComponent<Renderer>().material.color != Color.blue && gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        /**
        if (gameObject.GetComponent<Renderer>().material.color == Color.blue && Input.GetKeyUp(KeyCode.H))
        {
           


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                target1.transform.position = newPosition;
            }
        }
            **/


        
    }
        
        
    
}
