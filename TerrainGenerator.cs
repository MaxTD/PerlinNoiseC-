using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Terrain terrain;

    public float scale = 1f;

    public float magnitude = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if(terrain == null) 
        {
            terrain = GetComponent<Terrain>();
        }

        var terrainData = terrain.terrainData;
        var heightData = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        for (var y = 0; y < terrainData.heightmapResolution; y++)
        {
            float north = (float) y / terrainData.heightmapResolution;
            for (var x = 0; x < terrainData.heightmapResolution; x++)
            {
                float east = (float) x / terrainData.heightmapResolution;
                heightData[x, y] = magnitude * Mathf.PerlinNoise(x:east * scale, y:north * scale);
            }
        }

        terrainData.SetHeights(xBase:0, yBase:0, heightData);

        // terrainData.SetHeights(xBase 0, yBase 0, heightData);
    }
}
