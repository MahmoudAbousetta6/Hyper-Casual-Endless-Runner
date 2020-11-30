using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstecaleDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
            Destroy(other.gameObject);
    }

}
