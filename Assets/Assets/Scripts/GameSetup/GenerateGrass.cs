using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GenerateGrass : MonoBehaviour
{
    public GameObject Grass;
    public GameObject Water;

    public int Height, Width;

    private GameObject _player;

    Dictionary<int, Dictionary<int, Tile>> tiles = new Dictionary<int, Dictionary<int, Tile>>();

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        generateTile((int)_player.transform.position.x, (int)_player.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void generateTile(int x, int y)
    {
        Tile tile = new Tile(Grass, x, y);
        Dictionary<int, Tile> ymap;
        if (!tiles.TryGetValue(x, out ymap))
        {
            ymap = new Dictionary<int, Tile>();
            tiles.Add(x, ymap);
        }
        if (!ymap.ContainsKey(y))
        {
            ymap.Add(y, tile);
            GameObject landscape;

            if (UnityEngine.Random.Range(0.0f, 10.0f) < 1.0f)
            {
                landscape = Instantiate(Water);
            }
            else
            {
                landscape = Instantiate(Grass);
            }
            landscape.transform.position = new Vector3(x, 0, y);
            landscape.transform.parent = this.transform;
        }
    }

    public void generateGrassTile(int x, int y)
    {
        Tile tile = new Tile(Grass, x, y);
        Dictionary<int, Tile> ymap;
        if (!tiles.TryGetValue(x, out ymap))
        {
            ymap = new Dictionary<int, Tile>();
            tiles.Add(x, ymap);
        }
        if (!ymap.ContainsKey(y))
        {
            ymap.Add(y, tile);
            GameObject landscape;

            landscape = Instantiate(Grass);
            landscape.transform.position = new Vector3(x, 0, y);
            landscape.transform.parent = this.transform;
        }
    }

    public void GenerateField(int newGridX, int newGridY)
    {
        for (int x = -2; x <= 2; x++)
        {
            for (int y = -2; y <= 2; y++)
            {
                generateTile(newGridX + x, newGridY + y);
            }
        }
    }
}
