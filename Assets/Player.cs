using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	    public float movementSpeed = 40;
	    public float turningSpeed = 80;
    public float boost = 130;
    public float jumpPower = 200;
    public GameObject player;
    public int strength;
    
    public Quaternion originalRotationValue; // declare this as a Quaternion
    public float rotationResetSpeed = 10.0f;
    
    private Vector3 newPosition;
    
    void Start()
    {
        originalRotationValue = GameObject.Find("Player").transform.rotation; // save the initial rotation
    }
    void Update() {
		        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		        transform.Rotate(0, horizontal, 0);
		         
		        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		        transform.Translate(0, 0, vertical);
        Jumper();
        Safetynet();
        FixOrientation();
        SetToGrid();
		    }
    public void Jumper()
    {




        if (Input.GetKey(KeyCode.V) == true)
        {
        
            player.GetComponent<Rigidbody>().AddForce(transform.up * jumpPower );
            player.GetComponent<Rigidbody>().AddForce(transform.forward * boost);

        }
        if (Input.GetKey(KeyCode.B) == true)
        {

            player.GetComponent<Rigidbody>().AddForce(-transform.up * jumpPower);
            player.GetComponent<Rigidbody>().AddForce(transform.forward * boost);

        }
    }
    public void Safetynet()
    {
        if(GameObject.Find("Player").transform.position.y < -5)
        {
            Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y+10, player.transform.position.z);
            transform.position = newPos;
        }
    }
    public void FixOrientation()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            
            GameObject.Find("Player").transform.rotation = originalRotationValue ;
            
        }

    }
    public void SetToGrid()
    {



        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
            if (hit.collider.gameObject.CompareTag("grid2"))
            //if (Input.GetKeyDown(KeyCode.H))
            
                {

                  


                    newPosition.x = hit.collider.gameObject.transform.position.x;
                    newPosition.y = hit.collider.gameObject.transform.position.y + gameObject.GetComponent<Renderer>().bounds.size.x / 2;
                    newPosition.z = hit.collider.gameObject.transform.position.z;



                   
                    //   GameObject.Find("Player").transform.position = Vector3.MoveTowards(GameObject.Find("Player").transform.position, hit.collider.gameObject.transform.position, 5000);
                    GameObject.Find("Player").transform.position = Vector3.MoveTowards(GameObject.Find("Player").transform.position, newPosition, 5000);

                }
            }

        }
    }

    public void StrengthStat()
    {
        strength = 10;
    }
    }

