using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public GameObject player;
    public GameObject[] Rocks = new GameObject[3];
    public GameObject Treasure;
    public GameObject DepthCharge;
    public GameObject GasCan;
    public GameObject POI;
    public GameObject ChunkMarker;
    public float UnitSize = 15f;
    public Vector2 ChunkSize = new Vector2(285f, 225f);
    public int MaxRocksPerChunk = 5;
    public int DepthChargesPerChunk = 8;
    public int TreasurePerChunk = 2;
    public int POIPerChunk = 1;
    GameObject[] rocksInScene;
    GameObject[] DCInScene;
    GameObject[] TreasureInScene;
    GameObject[] POIInScene;
    GameObject[] ChunkMarkerInScene;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        //get objects
        rocksInScene = GameObject.FindGameObjectsWithTag("Rock");
        DCInScene = GameObject.FindGameObjectsWithTag("DepthCharge");
        TreasureInScene = GameObject.FindGameObjectsWithTag("Treasure");
        POIInScene = GameObject.FindGameObjectsWithTag("POI");
        ChunkMarkerInScene = GameObject.FindGameObjectsWithTag("ChunkMarker");

        //Generate
        bool IsInChunk = false;
        for (int i = 0; i < ChunkMarkerInScene.Length && !IsInChunk; i++)
        {
            Vector3 ChunkPos = ChunkMarkerInScene[i].transform.position;
            if (player.transform.position.x >= ChunkPos.x - ChunkSize.x || player.transform.position.x <= ChunkPos.x + ChunkSize.x || player.transform.position.y >= ChunkPos.y - ChunkSize.y || player.transform.position.x <= ChunkPos.x + ChunkSize.x)
            {
                IsInChunk = true;
            }
        }
        if (!IsInChunk)
        {
            Vector2 GetChunk = new Vector2(0f, 0f);
            if (player.transform.position.x > 0)
            {
                while (player.transform.position.x < GetChunk.x)
                {
                    GetChunk.x += ChunkSize.x;
                }
            }
            else
            {
                while (player.transform.position.x > GetChunk.x)
                {
                    GetChunk.x -= ChunkSize.x;
                }
            }
            if (player.transform.position.y > 0)
            {
                while (player.transform.position.y < GetChunk.y)
                {
                    GetChunk.x += ChunkSize.y;
                }
            }
            else
            {
                while (player.transform.position.y > GetChunk.y)
                {
                    GetChunk.x -= ChunkSize.y;
                }
            }
            GenerateChunk(GetChunk);
        }

    }
    float FixUnits(float value, bool Divide)
    {
        if (Divide)
        {
            return value / UnitSize;
        }
        else
        {
            return value * UnitSize;
        }
    }
    void GenerateChunk(Vector2 ChunkOrigin)
    {
        Instantiate(ChunkMarker, new Vector3(ChunkOrigin.x, ChunkOrigin.y, 0f), Quaternion.identity);
        //Rocks
        int RockNumber = Random.Range(0, MaxRocksPerChunk);
        for (int h = 0; h < RockNumber; h++)
        {
            bool Successful = false;
            for (int i = 0; i < 5 && !Successful; i++)
            {
                Vector3 RandomPos = new Vector3(FixUnits(Random.Range(FixUnits(-ChunkSize.x + ChunkOrigin.x, true), FixUnits(ChunkSize.x + ChunkOrigin.x, true)), false), FixUnits(Random.Range(FixUnits(-ChunkSize.y + ChunkOrigin.y, true), FixUnits(ChunkSize.y + ChunkOrigin.y, true)), false), 0f);
                bool Error = false;
                for (int j = 0; j < rocksInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1, false)))
                    {

                    }
                }
                Successful = !Error;
            }
            rocksInScene = GameObject.FindGameObjectsWithTag("Rock");
        }
    }
}
