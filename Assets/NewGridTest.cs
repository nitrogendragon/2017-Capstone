using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGridTest : MonoBehaviour
{
    Renderer rend;
    //public Material enemyboardside;
    public Material playerboardside;
    public GameObject plane;
    GameObject tilepiece;
    public int width = 10;
    public int height = 10;
  // public Camera camera;
   public GameObject[,] grid = new GameObject[10, 10];// creates the grid and makes it into a game object of an array size of 10 by 10 
                                                // Use this for initialization
   public void Awake()
    {
        tilepiece = GameObject.Find("tilepiece");
        //makes the grid before the scene is loaded hopefully
        for (int x = 0; x < width; x++)
        {
            
            for (int z = 0; z < height; z++)
            {
               
                  
                    
                        rend = tilepiece.GetComponent<Renderer>();
                        rend.material = playerboardside;
                    

                GameObject gridplane = Instantiate(plane); //as GameObject;//instantiates the plane as gridplane
                                                            gridplane.transform.parent = transform;
                                                            gridplane.transform.localPosition = new Vector3(x, 0, z);
               // gridplane.transform.position = new Vector3(gridplane.transform.position.x + x, gridplane.transform.position.y, gridplane.transform.position.z + z);//sets the positions of the planes as the for loops are iterated through.
                grid[x, z] = gridplane;
                
            }
        }
        
        tilepiece.SetActive(false);

    }
      
}
