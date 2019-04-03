

 using UnityEngine;
 using System.Collections;
 
 public class gridtest : MonoBehaviour
{

    public GameObject block1;
    public GameObject block2;
    
    public int worldWidth = 20;
    public int worldHeight = 20;
    public int worldcounter = 0;


    public float spawnSpeed = 0;

    void Awake()
    {
        StartCoroutine(CreateWorld());
      
        
    }
   
    IEnumerator CreateWorld()
    {
        if (worldcounter < worldHeight * worldWidth)
        {
            Debug.Log(worldcounter);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);

           

              
                for (int x = 0; x < worldWidth; x++)
                {
                    worldcounter++;

                    yield return new WaitForSeconds(spawnSpeed);

                    if (worldcounter == worldHeight * worldWidth)
                    {
                        Debug.Log("should be working");
                        // AudioSource audio = GetComponent<AudioSource>();
                        audio.Stop();
                    }
                if (worldcounter > worldHeight * worldWidth)

                {

                    audio.Play();
                }
                for (int z = 0; z < worldHeight; z++)
                    {
                    worldcounter++;   
                        yield return new WaitForSeconds(spawnSpeed);
                    
                        if (worldcounter >= worldHeight * worldWidth)
                        {
                            
                            // AudioSource audio = GetComponent<AudioSource>();
                            audio.Stop();
                        }
                    if (worldcounter > worldHeight * worldWidth)

                    {

                        audio.Play();
                    }
                    if (z % 2 == 0 && x % 2 == 0)
                        {

                            GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                            block.transform.parent = transform;
                            block.transform.localPosition = new Vector3(x, 0, z);

                        }
                        else if (z % 2 != 0 && x % 2 != 0)
                        {
                            GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                            block.transform.parent = transform;
                            block.transform.localPosition = new Vector3(x, 0, z);
                        }
                        else if (z % 2 != 0 && x % 2 == 0)
                        {
                            GameObject block = Instantiate(block2, Vector3.zero, block2.transform.rotation) as GameObject;
                            block.transform.parent = transform;
                            block.transform.localPosition = new Vector3(x, 0, z);
                        }
                        else if (z % 2 == 0 && x % 2 != 0)
                        {
                            GameObject block = Instantiate(block2, Vector3.zero, block2.transform.rotation) as GameObject;
                            block.transform.parent = transform;
                            block.transform.localPosition = new Vector3(x, 0, z);
                        }
                    }
                }
            
        }
    }
   
    
}
