using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Spawner : MonoBehaviourPunCallbacks
{
    public static Spawner inst;

    [SerializeField] private GameObject playerPrefab;    
    [SerializeField] private GameObject[] spawnPoints;

    [HideInInspector]
    public GameObject playerClone;
 

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        OnSpawn();
    }

  
    public void OnSpawn()
    {
    
        {
           
            playerClone = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
            if (PhotonNetwork.IsMasterClient)
            {
                playerClone.transform.position = spawnPoints[0].transform.position;
            }
            else
            {
                playerClone.transform.position = spawnPoints[1].transform.position;
            }
        }

        Debug.Log("Players Spawned");
    }

}
