using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private float speed_max = 0.01f;
    public Animator HeadAnimationControl;
    public Animator ChestAnimationControl;
    public Animator LegsAnimationControl;
    
    private GenerateGrass GrassGenerator;

    private string AniHead, AniChest, AniLegs = "";
    // Use this for initialization
    void Start() {
        GrassGenerator = GameObject.FindGameObjectWithTag("TerrainGenerator").GetComponent<GenerateGrass>();
        GrassGenerator.generateGrassTile(0, 0);
        GrassGenerator.GenerateField(0, 0);
        HeadAnimationControl.Play("Head_Down");
        ChestAnimationControl.Play("Chest_Left");
    }

    // Update is called once per frame
    void FixedUpdate() {
        int gridX = (int)Mathf.Round(this.gameObject.transform.position.x);
        int gridY = (int)Mathf.Round(this.gameObject.transform.position.z);
        int dirX = 0, dirY = 0;
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            AniHead = "Head_Up";
            AniChest = "Chest_Right";
            dirY += 1;
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            AniHead = "Head_Down";
            AniChest = "Chest_Left";
            dirY -= 1;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            AniHead = "Head_Left";
            AniChest = "Chest_Left";
            dirX -= 1;
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            AniHead = "Head_Right";
            AniChest = "Chest_Right";
            dirX += 1;
        }
        float velX = 0, velY = 0;

        float v = Mathf.Sqrt(dirX * dirX + dirY * dirY);
        if (v != 0)
        {
            float s = 1 / v;
            velX = dirX * s * speed_max;
            velY = dirY * s * speed_max;
            LegsAnimationControl.SetBool("Stopped", false);
            this.gameObject.transform.position += new Vector3(velX, 0, velY);

            HeadAnimationControl.Play(AniHead);
            ChestAnimationControl.Play(AniChest);
        }
        else
        {
            LegsAnimationControl.SetBool("Stopped", true);
        }
        

        int newGridX = (int)Mathf.Round(this.gameObject.transform.position.x);
        int newGridY = (int)Mathf.Round(this.gameObject.transform.position.z);
        if (gridX != newGridX || gridY != newGridY)
        {
            GrassGenerator.GenerateField(newGridX, newGridY);
        }
    }
}
