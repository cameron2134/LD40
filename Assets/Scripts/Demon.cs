using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Creature {

    private const int DEMON_LIFESPAN = 10;
    private string[] directions = new string[] { "Left", "Right" };
    private string directionToFly;


	void Start ()
	{
	    //directionToFly = directions[Random.Range(0, directions.Length-1)];

	    
	}

    void OnEnable()
    {
        StartCoroutine(Expire());
        InvokeRepeating("DropBodyParts", Random.Range(1, 3), Random.Range(1, 4));
    }

    void OnDisable()
    {
        CancelInvoke("DropBodyParts");
    }
	

	void Update ()
	{
	    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), moveSpeed * Time.deltaTime);

        //switch (directionToFly)
        //{
        //    case "Right":
        //        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), moveSpeed * Time.deltaTime);
        //        break;
        //    case "Left":
        //        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), moveSpeed * Time.deltaTime);
        //        break;
        //}
    }


    private void DropBodyParts()
    {
        GameObject bodyPart = GameManager.Instance.GetGameObj("BodyPart");
        bodyPart.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        bodyPart.SetActive(true);
    }


    IEnumerator Expire()
    {
        yield return new WaitForSeconds(DEMON_LIFESPAN);
        CancelInvoke("DropBodyParts");
        GameManager.Instance.DestroyObj(gameObject);
    }
}
