using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Generation generation;

    [SerializeField]
    private MeshRenderer tileRenderer;

    [SerializeField]
    private MeshFilter meshFilter;

    [SerializeField]
    private MeshCollider meshCollider;

    [SerializeField]
    private float mapScale;

    [SerializeField]
    private float heightMultiplier;


    void Start()
    {
        generateTile();
    }

    private void updateVertices(float[,] heightMap, float heightMultiplier){

        int width = heightMap.GetLength(0);
        int depth = heightMap.GetLength(1);

        int vertex = 0;
        for(int i = 0; i < width;i++){
            for(int j = 0;j < depth; j++){
                float height = heightMap[i, j];

                Vector3 vertex = 


            }
        }

    }

    void generateTile(){
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
        int tileWidth = tileDepth;

        float [,] heightMap = generation.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale);

        Texture2D tileTexture = BuildTexture(heightMap);
        this.tileRenderer.material.mainTexture = tileTexture;
    }

    private Texture2D BuildTexture(float[,] heightMap){

        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Color[] colourMap = new Color[tileWidth*tileDepth];

        for(int i = 0; i < tileDepth; i++){
            for(int j = 0; j < tileWidth; j++){
                int colourIndex = i*tileWidth + j;
                float height = heightMap[i, j];

                colourMap[colourIndex] = Color.Lerp(Color.black, Color.white, height);

            }
        }

        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colourMap);
        tileTexture.Apply();
        return tileTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
