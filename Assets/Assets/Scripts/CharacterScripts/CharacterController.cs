using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            this.gameObject.transform.position += new Vector3(0, 0.01f);
        }

        if (Input.GetKey("down"))
        {
            this.gameObject.transform.position += new Vector3(0, -0.01f);
        }

        if (Input.GetKey("left"))
        {
            this.gameObject.transform.position += new Vector3(-0.01f, 0);
        }

        if (Input.GetKey("right"))
        {
            this.gameObject.transform.position += new Vector3(0.01f, 0);
        }
    }
}
