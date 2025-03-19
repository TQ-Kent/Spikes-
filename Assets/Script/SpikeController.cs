using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private GameObject Object;
    private GameObject spikeSpawn;
    public GameObject warning;


    private Vector2 Flip;
    private Vector2 target;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1;
        spikeSpawn = GameObject.FindGameObjectWithTag("SpikeSpawn");
        Object = gameObject;
        Destroy(Object, 4);
        if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos || Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_RightY_SpikePos)
        {
            if (Object.transform.position.x == spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos)
            {
                Flip = Object.transform.localScale;
                Flip.x *= -1;
                Object.transform.localScale = Flip;
                target.y = Object.transform.position.y;
                target.x = spikeSpawn.GetComponent<SpikeSpawn>().XPos_RightY_SpikePos;
            }
            else
            { 
                target.y = Object.transform.position.y;
                target.x = spikeSpawn.GetComponent<SpikeSpawn>().XPos_LeftY_SpikePos;
            }
        }
        else if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos || Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_DownX_SpikePos)
        {
            if (Object.transform.position.y == spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos)
            {
                Object.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                target.y = spikeSpawn.GetComponent<SpikeSpawn>().YPos_DownX_SpikePos;
                target.x = Object.transform.position.x;
            }
            else
            {
                Object.transform.rotation = Quaternion.Euler(Vector3.forward * 270);
                target.y = spikeSpawn.GetComponent<SpikeSpawn>().YPos_UpX_SpikePos;
                target.x = Object.transform.position.x;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Object.transform.position = Vector2.Lerp(Object.transform.position, target, moveSpeed * Time.deltaTime);
    }
}
