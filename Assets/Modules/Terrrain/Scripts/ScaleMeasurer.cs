using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ScaleMeasurer : MonoBehaviour
{
    // Start is called before the first frame update
    Terrain terrain;
    TerrainData terrainData;
    float[,] heightMap;
    [SerializeField]
    public float height = 0;
    public float highest = 0f;
    public float lowest = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = (gameObject.transform.position - terrain.transform.position)*513/1000;
        //Vector2 index = new Vector2((int)relativePos.x * 513 / 500, (int)relativePos.z * 513 / 500);
        //height = heightMap[(int)index.x, (int)index.y];

        height = heightMap[(int)Mathf.Clamp(relativePos.x,0, terrainData.heightmapResolution-1), 
                           (int)Mathf.Clamp(relativePos.z,0, terrainData.heightmapResolution - 1)];


        for (int i = 0; i < terrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < terrainData.heightmapResolution; j++)
            {
                highest = Mathf.Max(highest, heightMap[i, j]);
                lowest = Mathf.Min(lowest, heightMap[i, j]);
            }
        }
        //height = heightMap[(int) Mathf.Clamp(relativePos.x, 0 , 512), Mathf.Clamp((int)relativePos.y, 0, 512)];
    }

    void OnEnable()
    {
        UnityEngine.Debug.Log("Initialising Terrain Data");
        terrain = FindObjectOfType<Terrain>();
        terrainData = Terrain.activeTerrain.terrainData;
        heightMap = terrainData.GetHeights(0, 0, terrainData.heightmapResolution,
                                                terrainData.heightmapResolution);
    }
}
