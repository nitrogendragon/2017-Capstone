using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemehere : MonoBehaviour {
    private Vector3 newPosition;
    //private float newpositionx;
    //private float newpositiony;
    //private float newpositionz;
    void Start()
    {
        newPosition = transform.position;
    }
    void Update()
    {

        SettoMouseLocation();
       
    }
    public void SettoMouseLocation()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 4000))
            {
                newPosition.x = hit.point.x;
                newPosition.y = hit.point.y + gameObject.GetComponent<Renderer>().bounds.size.x / 2;
                newPosition.z = hit.point.z;
                transform.position = newPosition;
            }
        }
    }
}

