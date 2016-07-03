using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Debug.Log("entered");
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
