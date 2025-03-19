using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    public GameObject Warn;
    private GameObject Object;
    public GameObject gameController;

    private float LeftX_SpikePos;
    private float RightX_SpikePos;
    public float YPos_UpX_SpikePos;
    public float YPos_DownX_SpikePos;

    private float UpY_SpikePos;
    private float DownY_SpikePos;
    public float XPos_LeftY_SpikePos;
    public float XPos_RightY_SpikePos;

    private float lastSpikeTime;
    private float spikeTime;
    // Start is called before the first frame update
    void Start()
    {
        spikeTime = 2;
        Object = gameObject;
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }

        YPos_UpX_SpikePos = 5.8f;
        YPos_DownX_SpikePos = -5.8f;
        LeftX_SpikePos = -7.4f;
        RightX_SpikePos = 7.4f;

        XPos_LeftY_SpikePos = -8.9f;
        XPos_RightY_SpikePos = 8.9f;
        UpY_SpikePos = 4.4f;
        DownY_SpikePos = -4.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpikeTime + spikeTime)
        {
            SpawnSpike();
            gameController.GetComponent<GameController>().IncPoint();
        }
    }
    void UpdateSpikeTime()
    {
        lastSpikeTime = Time.time;
        spikeTime = Random.Range(1, 1);
    }
    void SpawnSpike()
    {
        Instantiate(Warn, new Vector2(Random.Range(LeftX_SpikePos, RightX_SpikePos + 1), YPos_UpX_SpikePos - 1.5f), Quaternion.identity);
        Instantiate(Warn, new Vector2(Random.Range(LeftX_SpikePos, RightX_SpikePos + 1), YPos_DownX_SpikePos + 1.5f), Quaternion.identity);
        Instantiate(Warn, new Vector2(XPos_LeftY_SpikePos + 1.5f, Random.Range(DownY_SpikePos, UpY_SpikePos)), Quaternion.identity);
        Instantiate(Warn, new Vector2(XPos_RightY_SpikePos - 1.5f, Random.Range(DownY_SpikePos, UpY_SpikePos)), Quaternion.identity);

        UpdateSpikeTime();
    }
}
