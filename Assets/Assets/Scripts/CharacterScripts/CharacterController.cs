using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += new Vector3(0, 0, 0.01f);
        }

        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -0.01f);
        }

        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += new Vector3(-0.01f, 0, 0);
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += new Vector3(0.01f, 0, 0);
        }
    }
}
