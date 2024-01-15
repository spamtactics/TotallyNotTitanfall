using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float[,] GenerateNoiseMap(int mapDepth, int mapWidth, float scale){
        float[,] noiseMap = new float[mapDepth, mapWidth];

        for(int i = 0; i < mapDepth; i++){
            for(int j = 0; j < mapWidth; j++){

            float sampleX = j/scale;
            float sampleY = i/scale;

            float noise = Mathf.PerlinNoise(sampleX, sampleY);
            noiseMap[i, j] = noise;

            }
        }

        return noiseMap;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
