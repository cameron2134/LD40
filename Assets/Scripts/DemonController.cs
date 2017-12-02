using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{

    public GameObject[] demonSpawnPoints;


    // spawn at edge of map

	// Use this for initialization
	void Start ()
	{
	    InvokeRepeating("SpawnDemon", 0, 8);
	}


    private void SpawnDemon()
    {
        Transform spawnPoint = demonSpawnPoints[Random.Range(0, demonSpawnPoints.Length - 1)].transform;
        GameObject demon = GameManager.Instance.GetGameObj("Demon");
        demon.transform.position = spawnPoint.position;
        demon.SetActive(true);
    }

}
