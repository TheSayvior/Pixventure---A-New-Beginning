using UnityEngine;
using System.Collections;

public class GenerateGrass : MonoBehaviour {

    public GameObject Grass;

    public int Height, Width;
    
	// Use this for initialization
	void Start () {
	for(int h = -Height / 2; h<Height/2; h++)
        {
            for (int w = -Width / 2; w < Width/2; w++)
            {
                GameObject grass = Instantiate(Grass);
                grass.transform.position = new Vector3(w, 0, h);
                grass.name = "Grass("+w+","+h+")";
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
