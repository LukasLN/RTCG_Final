using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] bool isSpawnPoint2;

    [SerializeField] Transform SpawnPoint1;

    [SerializeField] Transform SpawnPoint2;

    [SerializeField] Transform Player;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collison");
        if(other.tag == "Player")
        {
            Debug.Log("Player");
            if (isSpawnPoint2)
            {
                Player.position = SpawnPoint2.position;
            }
            else
            {
                Player.position = SpawnPoint1.position;
            }
        }
    }
}
