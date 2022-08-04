using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 200;
    public int numberOfTiles = 3;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
		{
            if (i == 0)
			{
                if (tilePrefabs[0].name != "Tile0"){
                    GameObject go = Instantiate(tilePrefabs[0], transform.forward * 90, transform.rotation);
                    activeTiles.Add(go);
                    zSpawn += tileLength;
                }
                else {
                    SpawnTile(0);
                }
			}
            else
			{
                SpawnTile(Random.Range(1, tilePrefabs.Length));
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 200 > zSpawn - (numberOfTiles * tileLength))
		{
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
	{
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
	}

    private void DeleteTile()
	{
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
	}
}
