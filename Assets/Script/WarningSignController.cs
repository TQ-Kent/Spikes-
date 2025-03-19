using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignController : MonoBehaviour
{
    private GameObject spikeSpawn;
    private GameObject Object;
    public GameObject Spike;

    // Start is called before the first frame update
    void Start()
    {
        Object = gameObject;
        spikeSpawn = GameObject.FindGameObjectWithTag("SpikeSpawn");
        if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos + 1.5f || Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_RightY_SpikePos - 1.5f)
        {
            if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos + 1.5f)
            {
                Object.transform.rotation = Quaternion.Euler(Vector3.forward * 270);
            }
            else
            {
                Object.transform.rotation = Quaternion.Euler(Vector3.forward * 90);            }
        }
        else if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos - 1.5f|| Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_DownX_SpikePos + 1.5f)
        {
            if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos - 1.5f)
            {
                Object.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
            }
        }
        Destroy(Object, 1);
    }
    private void OnDestroy()
    {
        if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos + 1.5f|| Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_RightY_SpikePos - 1.5f)
        {
            if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos + 1.5f)
            {
                Instantiate(Spike, new Vector2(spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos, Object.transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(Spike, new Vector2(spikeSpawn.GetComponent<SpikeSpawn>().XPos_RightY_SpikePos, Object.transform.position.y), Quaternion.identity);
            }
        }
        else if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos - 1.5f|| Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_DownX_SpikePos + 1.5f)
        {
            if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos - 1.5f)
            {
                Instantiate(Spike, new Vector2(Object.transform.position.x, spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos), Quaternion.identity);
            }
            else
            {
                Instantiate(Spike, new Vector2(Object.transform.position.x, spikeSpawn.GetComponent<SpikeSpawn>().YPos_DownX_SpikePos), Quaternion.identity);
            }
        }
    }
}
