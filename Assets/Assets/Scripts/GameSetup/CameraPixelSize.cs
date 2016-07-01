using UnityEngine;
using System.Collections;
 
public class CameraPixelSize : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = Screen.height / 2;
    }
}
