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

        Vector3[] meshVertices = this.meshFilter.mesh.vertices;

        int vertexIndex = 0;
        for(int i = 0; i < width;i++){
            for(int j = 0;j < depth; j++){

                float height = heightMap[j, i];
                
                Vector3 vertex = meshVertices [vertexIndex];
                // change the vertex Y coordinate, proportional to the height value
                meshVertices[vertexIndex] = new Vector3(vertex.x, height * this.heightMultiplier, vertex.z);
                vertexIndex++;
            }
        }

        this.meshFilter.mesh.vertices = meshVertices;
        this.meshFilter.mesh.RecalculateBounds ();
        this.meshFilter.mesh.RecalculateNormals ();
        // update the mesh collider
        this.meshCollider.sharedMesh = this.meshFilter.mesh;

    }

    void generateTile(){
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt (meshVertices.Length);
        int tileWidth = tileDepth;
        // calculate the offsets based on the tile position
        float offsetX = -this.gameObject.transform.position.x;
        float offsetZ = -this.gameObject.transform.position.z;
        // generate a heightMap using noise
        float[,] heightMap = this.generation.GenerateNoiseMap (tileDepth, tileWidth, this.mapScale, offsetX, offsetZ);
        // build a Texture2D from the height map
        Texture2D tileTexture = BuildTexture (heightMap);
        this.tileRenderer.material.mainTexture = tileTexture;
        // update the tile mesh vertices according to the height map
        updateVertices(heightMap, this.heightMultiplier);
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
