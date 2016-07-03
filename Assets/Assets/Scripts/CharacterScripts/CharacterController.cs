using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    private float speed_max = 0.01f;
    public Animator Ani;

    private GenerateGrass GrassGenerator;
    // Use this for initialization
    void Start() {
        GrassGenerator = GameObject.FindGameObjectWithTag("TerrainGenerator").GetComponent<GenerateGrass>();
        GrassGenerator.generateGrassTile(0, 0);
        GrassGenerator.GenerateField(0, 0);
        Ani.Play("StandingDown");
    }

    // Update is called once per frame
    void FixedUpdate() {
        int gridX = (int)Mathf.Round(this.gameObject.transform.position.x);
        int gridY = (int)Mathf.Round(this.gameObject.transform.position.z);
        string animation = "";
        int dirX = 0, dirY = 0;
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            animation = "MovingUp";
            dirY += 1;
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            animation = "MovingDown";
            dirY -= 1;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            animation = "MovingLeft";
            dirX -= 1;
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            animation = "MovingRight";
            dirX += 1;
        }
        float velX = 0, velY = 0;

        float v = Mathf.Sqrt(dirX * dirX + dirY * dirY);
        if (v != 0)
        {
            float s = 1 / v;
            velX = dirX * s * speed_max;
            velY = dirY * s * speed_max;
            Ani.SetBool("Stopped", false);
            this.gameObject.transform.position += new Vector3(velX, 0, velY);
            Ani.Play(animation);
        } else
        {
            Ani.SetBool("Stopped", true);
        }

        int newGridX = (int)Mathf.Round(this.gameObject.transform.position.x);
        int newGridY = (int)Mathf.Round(this.gameObject.transform.position.z);
        if (gridX != newGridX || gridY != newGridY)
        {
            GrassGenerator.GenerateField(newGridX, newGridY);
        }
    }
}
