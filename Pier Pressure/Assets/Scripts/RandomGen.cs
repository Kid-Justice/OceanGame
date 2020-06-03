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
    public int GasCansPerChunk = 3;
    public int TreasurePerChunk = 2;
    public int POIPerChunk = 1;
    GameObject[] rocksInScene;
    GameObject[] DCInScene;
    GameObject[] GasCanInScene;
    GameObject[] TreasureInScene;
    GameObject[] POIInScene;
    GameObject[] ChunkMarkerInScene;
    bool GeneratedOnStart = false;

    // Start is called before the first frame update
    void Start()
    {
        rocksInScene = GameObject.FindGameObjectsWithTag("Rock");
        DCInScene = GameObject.FindGameObjectsWithTag("DepthCharge");
        GasCanInScene = GameObject.FindGameObjectsWithTag("GasCan");
        TreasureInScene = GameObject.FindGameObjectsWithTag("Treasure");
        POIInScene = GameObject.FindGameObjectsWithTag("POI");
        ChunkMarkerInScene = GameObject.FindGameObjectsWithTag("ChunkMarker");
    }

    // Update is called once per frame
    void Update()
    {
        //get objects
        rocksInScene = GameObject.FindGameObjectsWithTag("Rock");
        DCInScene = GameObject.FindGameObjectsWithTag("DepthCharge");
        GasCanInScene = GameObject.FindGameObjectsWithTag("GasCan");
        TreasureInScene = GameObject.FindGameObjectsWithTag("Treasure");
        POIInScene = GameObject.FindGameObjectsWithTag("POI");
        ChunkMarkerInScene = GameObject.FindGameObjectsWithTag("ChunkMarker");

        //Generate
        if (!GeneratedOnStart)
        {
            GenerateChunk(new Vector2(0f, 0f));
            GeneratedOnStart = true;
        }
        else
        {
            bool IsInChunk = false;
            for (int i = 0; i < ChunkMarkerInScene.Length && !IsInChunk; i++)
            {
                Vector3 ChunkPos = ChunkMarkerInScene[i].transform.position;
                if (player.transform.position.x >= ChunkPos.x - (ChunkSize.x/2) && player.transform.position.x <= ChunkPos.x + (ChunkSize.x/2) && player.transform.position.y >= ChunkPos.y - (ChunkSize.y/2) && player.transform.position.y <= ChunkPos.y + (ChunkSize.y/2))
                {
                    IsInChunk = true;
                }

            }
            Debug.Log(IsInChunk);
            if (!IsInChunk)
            {
                Vector2 GetChunk = new Vector2(0f, 0f);
                if (Mathf.Abs(player.GetComponent<Movement>().Velocity.x) > Mathf.Abs(player.GetComponent<Movement>().Velocity.y))
                {
                    if (player.transform.position.x > 0f)
                    {
                        while (player.transform.position.x > GetChunk.x)
                        {
                            GetChunk.x += ChunkSize.x * 2;
                        }
                    }
                    else
                    {
                        while (player.transform.position.x < GetChunk.x)
                        {
                            GetChunk.x -= ChunkSize.x * 2;
                            Debug.Log(GetChunk.x);
                        }
                    }
                }
                else
                {
                    if (player.transform.position.y > 0f)
                    {
                        while (player.transform.position.y > GetChunk.y)
                        {
                            GetChunk.y += ChunkSize.y * 2;
                        }
                    }
                    else
                    {
                        while (player.transform.position.y < GetChunk.y)
                        {
                            GetChunk.y -= ChunkSize.y * 2;
                        }
                    }
                }
                Debug.Log(GetChunk);
                bool ChunkExists = false;
                for (int i = 0; i < ChunkMarkerInScene.Length && !ChunkExists; i++)
                {
                    if (ChunkMarkerInScene[i].transform.position.x == GetChunk.x && ChunkMarkerInScene[i].transform.position.y == GetChunk.y)
                    {
                        ChunkExists = true;
                    }
                }
                if (!ChunkExists)
                {
                    GenerateChunk(GetChunk);
                }
            }
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
        if (GeneratedOnStart)
        {
            if (player.transform.position.x > (ChunkOrigin.x + ChunkSize.x) || player.transform.position.x < ( ChunkOrigin.x - ChunkSize.x))
            {
                Instantiate(ChunkMarker, new Vector3(player.transform.position.x, ChunkOrigin.y, 0f), Quaternion.identity);
                Debug.Log("NewChunk");
            }
            else
            {
                Instantiate(ChunkMarker, new Vector3(ChunkOrigin.x, player.transform.position.x, 0f), Quaternion.identity);
            }
        }
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
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1f, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1f, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1f, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1f, false)))
                    {
                        Error = true;
                    }
                }
                if ((RandomPos.x <= player.transform.position.x + FixUnits(3f, false) && RandomPos.x >= player.transform.position.x - FixUnits(3f, false)) && (RandomPos.y <= player.transform.position.y + FixUnits(3f, false) && RandomPos.y >= player.transform.position.y - FixUnits(3f, false)))
                {
                    Error = true;
                }
                Successful = !Error;
                if (Successful)
                {
                    Instantiate(Rocks[Random.Range(0, 3)], RandomPos, Quaternion.identity);
                }
            }
            rocksInScene = GameObject.FindGameObjectsWithTag("Rock");
        }
        //Depth Charge
        int DCNumber = Random.Range(0, DepthChargesPerChunk);
        for (int h = 0; h < RockNumber; h++)
        {
            bool Successful = false;
            for (int i = 0; i < 5 && !Successful; i++)
            {
                Vector3 RandomPos = new Vector3(FixUnits(Random.Range(FixUnits(-ChunkSize.x + ChunkOrigin.x, true), FixUnits(ChunkSize.x + ChunkOrigin.x, true)), false), FixUnits(Random.Range(FixUnits(-ChunkSize.y + ChunkOrigin.y, true), FixUnits(ChunkSize.y + ChunkOrigin.y, true)), false), 0f);
                bool Error = false;
                for (int j = 0; j < rocksInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1f, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1f, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1f, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < DCInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= DCInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= DCInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= DCInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= DCInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                if ((RandomPos.x <= player.transform.position.x + FixUnits(3f, false) && RandomPos.x >= player.transform.position.x - FixUnits(3f, false)) && (RandomPos.y <= player.transform.position.y + FixUnits(3f, false) && RandomPos.y >= player.transform.position.y - FixUnits(3f, false)))
                {
                    Error = true;
                }
                Successful = !Error;
                if (Successful)
                {
                    Instantiate(DepthCharge, RandomPos, Quaternion.identity);
                }
            }
            DCInScene = GameObject.FindGameObjectsWithTag("DepthCharge");
        }
        //Gas Can
        int GasCanNumber = Random.Range(0, GasCansPerChunk);
        for (int h = 0; h < GasCanNumber; h++)
        {
            bool Successful = false;
            for (int i = 0; i < 5 && !Successful; i++)
            {
                Vector3 RandomPos = new Vector3(FixUnits(Random.Range(FixUnits(-ChunkSize.x + ChunkOrigin.x, true), FixUnits(ChunkSize.x + ChunkOrigin.x, true)), false), FixUnits(Random.Range(FixUnits(-ChunkSize.y + ChunkOrigin.y, true), FixUnits(ChunkSize.y + ChunkOrigin.y, true)), false), 0f);
                bool Error = false;
                for (int j = 0; j < rocksInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1f, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1f, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1f, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < DCInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= DCInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= DCInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= DCInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= DCInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < GasCanInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= GasCanInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= GasCanInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= GasCanInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= GasCanInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                if ((RandomPos.x <= player.transform.position.x + FixUnits(3f, false) && RandomPos.x >= player.transform.position.x - FixUnits(3f, false)) && (RandomPos.y <= player.transform.position.y + FixUnits(3f, false) && RandomPos.y >= player.transform.position.y - FixUnits(3f, false)))
                {
                    Error = true;
                }
                Successful = !Error;
                if (Successful)
                {
                    Instantiate(GasCan, RandomPos, Quaternion.identity);
                }
            }
            GasCanInScene = GameObject.FindGameObjectsWithTag("GasCan");
        }
        //Treasure
        int TreasureNumber = Random.Range(0, TreasurePerChunk);
        for (int h = 0; h < GasCanNumber; h++)
        {
            bool Successful = false;
            for (int i = 0; i < 5 && !Successful; i++)
            {
                Vector3 RandomPos = new Vector3(FixUnits(Random.Range(FixUnits(-ChunkSize.x + ChunkOrigin.x, true), FixUnits(ChunkSize.x + ChunkOrigin.x, true)), false), FixUnits(Random.Range(FixUnits(-ChunkSize.y + ChunkOrigin.y, true), FixUnits(ChunkSize.y + ChunkOrigin.y, true)), false), 0f);
                bool Error = false;
                for (int j = 0; j < rocksInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1f, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1f, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1f, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < DCInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= DCInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= DCInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= DCInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= DCInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < GasCanInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= GasCanInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= GasCanInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= GasCanInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= GasCanInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < TreasureInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= TreasureInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= TreasureInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= TreasureInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= TreasureInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                if ((RandomPos.x <= player.transform.position.x + FixUnits(3f, false) && RandomPos.x >= player.transform.position.x - FixUnits(3f, false)) && (RandomPos.y <= player.transform.position.y + FixUnits(3f, false) && RandomPos.y >= player.transform.position.y - FixUnits(3f, false)))
                {
                    Error = true;
                }
                Successful = !Error;
                if (Successful)
                {
                    Instantiate(Treasure, RandomPos, Quaternion.identity);
                }
            }
            TreasureInScene = GameObject.FindGameObjectsWithTag("Treasure");
        }
        //POI
        int POINumber = Random.Range(0, POIPerChunk);
        for (int h = 0; h < POINumber; h++)
        {
            bool Successful = false;
            for (int i = 0; i < 5 && !Successful; i++)
            {
                Vector3 RandomPos = new Vector3(FixUnits(Random.Range(FixUnits(-ChunkSize.x + ChunkOrigin.x, true), FixUnits(ChunkSize.x + ChunkOrigin.x, true)), false), FixUnits(Random.Range(FixUnits(-ChunkSize.y + ChunkOrigin.y, true), FixUnits(ChunkSize.y + ChunkOrigin.y, true)), false), 0f);
                bool Error = false;
                for (int j = 0; j < rocksInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= rocksInScene[j].transform.position.x + FixUnits(1f, false) && RandomPos.x >= rocksInScene[j].transform.position.x - FixUnits(1f, false)) && (RandomPos.y <= rocksInScene[j].transform.position.y + FixUnits(1f, false) && RandomPos.y >= rocksInScene[j].transform.position.y - FixUnits(1f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < DCInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= DCInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= DCInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= DCInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= DCInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < GasCanInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= GasCanInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= GasCanInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= GasCanInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= GasCanInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < TreasureInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= TreasureInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= TreasureInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= TreasureInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= TreasureInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                for (int j = 0; j < POIInScene.Length && !Error; j++)
                {
                    if ((RandomPos.x <= POIInScene[j].transform.position.x + FixUnits(0.5f, false) && RandomPos.x >= POIInScene[j].transform.position.x - FixUnits(0.5f, false)) && (RandomPos.y <= POIInScene[j].transform.position.y + FixUnits(0.5f, false) && RandomPos.y >= POIInScene[j].transform.position.y - FixUnits(0.5f, false)))
                    {
                        Error = true;
                    }
                }
                if ((RandomPos.x <= player.transform.position.x + FixUnits(3f, false) && RandomPos.x >= player.transform.position.x - FixUnits(3f, false)) && (RandomPos.y <= player.transform.position.y + FixUnits(3f, false) && RandomPos.y >= player.transform.position.y - FixUnits(3f, false)))
                {
                    Error = true;
                }
                Successful = !Error;
                if (Successful)
                {
                    Instantiate(POI, RandomPos, Quaternion.identity);
                }
            }
            POIInScene = GameObject.FindGameObjectsWithTag("POI");
        }
    }
}
