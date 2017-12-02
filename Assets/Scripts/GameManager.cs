using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;


    public GameObject inactiveObjectFolder;
    public GameObject activeObjectFolder;

    private List<GameObject> objectPool;



    private string[] bodyParts = new string[] { "Leg", "Arm", "Face", "Torso", "Foot", "Hand" };



    public string GetBodyPart()
    {
        return bodyParts[Random.Range(0, bodyParts.Length-1)];
    }




    // events etc

    public delegate void BodyPartChangeHandler(int numChanged);

    public event BodyPartChangeHandler BodyPartsIncreased;
    public event BodyPartChangeHandler BodyPartsDecreased;

    public void OnBodyPartsIncreased(int numChanged)
    {
        if (BodyPartsIncreased != null)
            BodyPartsIncreased(numChanged);
        else
            Debug.Log("No subscribers to BodyPartsIncreased");
    }

    public void OnBodyPartsDecreased(int numChanged)
    {
        if (BodyPartsDecreased != null)
            BodyPartsDecreased(numChanged);
        else
            Debug.Log("No subscribers to BodyPartsDecreased");
    }







    public void DestroyObj(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(inactiveObjectFolder.transform);
        objectPool.Add(obj);
    }



    /// <summary>
    /// Searches for the specified game object as a string and retrieves it from the pool.
    /// </summary>
    /// <param name="obj">The game object to retrieve.</param>
    /// <returns>The specified game object.</returns>
    public GameObject GetGameObj(string obj)
    {

        GameObject returnObj;


        if (objectPool.Count > 0)
        {

            if (obj.Contains("(Clone)"))
                returnObj = objectPool.Find(o => o.name == obj);


            else
                returnObj = objectPool.Find(o => o.name == (obj + "(Clone)"));

            returnObj.transform.SetParent(activeObjectFolder.transform);
            objectPool.Remove(returnObj);

            return returnObj;
        }

        return null;
    }




    /// <summary>
    /// Loads all of the game objects and disable them.
    /// </summary>
    public void LoadGameData()
    {

        for (int i = 0; i < 20; i++)
        {

            Load("BodyPart");
            Load("EnemySkeleton");

        }

        Debug.Log("Loading completed! " + objectPool.Count + " game objects loaded.");

    }



    private void Load(string path)
    {

        GameObject objToLoad;

        objToLoad = (GameObject)Instantiate(Resources.Load(path));

        objToLoad.transform.SetParent(inactiveObjectFolder.transform);
        objectPool.Add(objToLoad);

        objToLoad.SetActive(false);

    }



    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    // Use this for initialization
    void Start ()
	{
        

	    objectPool = new List<GameObject>();
        LoadGameData();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
