using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject GameUI;
    public Text BodyPartCountText;




    private void IncreaseBodyPartCounterText(int newValue)
    {
        int newCount = int.Parse(BodyPartCountText.text) + newValue;
        BodyPartCountText.text = newCount.ToString();
    }

    private void DecreaseBodyPartCounterText(int newValue)
    {
        int newCount = int.Parse(BodyPartCountText.text) - newValue;
        BodyPartCountText.text = newCount.ToString();
    }


    // Use this for initialization
    void Start ()
	{
	    GameManager.Instance.BodyPartsIncreased += IncreaseBodyPartCounterText;
	    GameManager.Instance.BodyPartsDecreased += DecreaseBodyPartCounterText;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisable()
    {
        GameManager.Instance.BodyPartsIncreased -= IncreaseBodyPartCounterText;
        GameManager.Instance.BodyPartsDecreased -= DecreaseBodyPartCounterText;
    }
}
