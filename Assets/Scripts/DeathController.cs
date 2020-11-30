using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Speed = 0;
            GameManager.instance.DeathMenuPanel.SetActive(true);
        }
    }
   
}
