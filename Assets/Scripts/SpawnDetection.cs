using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetection : MonoBehaviour
{
    public bool pointReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GroundSpawn.instance.Spawn();
            pointReached = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GroundSpawn.instance.DeSpawn();
            pointReached = false;
        }
    }

}
