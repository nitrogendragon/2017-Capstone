 var goPrefab : GameObject;
 var cubeEdge = 6;  // number of cubes on an edge
 var v3Center = Vector3.zero;
 
 private var argo : GameObject[,,] = new GameObject[cubeEdge, cubeEdge, cubeEdge];
 
 function Start() {
     for (var i = 0; i < cubeEdge; i++) {
         for (var j = 0; j < cubeEdge; j++) {
             for (var k = 0; k < cubeEdge; k++) {
                 var x = v3Center.x - cubeEdge / 2.0 + i;
                 var y = v3Center.y + cubeEdge / 2.0 - j;
                 var z = v3Center.z - cubeEdge / 2.0 + k;
                 
                 argo[i,j,k] = Instantiate(goPrefab, Vector3(x,y,z), Quaternion.identity,Color.Random);
             }
         }
     }
 }
 
 function Update()
 {
   if (Input.GetMouseButtonDown(0)) {
       var go : GameObject = argo[Random.Range(0, cubeEdge), Random.Range(0, cubeEdge), Random.Range(0, cubeEdge)];
       go.GetComponent.<Renderer>().enabled = !go.GetComponent.<Renderer>().enabled;
   }
 }
//i love this project//