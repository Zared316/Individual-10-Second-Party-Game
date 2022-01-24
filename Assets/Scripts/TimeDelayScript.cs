using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDelayScript : MonoBehaviour
{
	public Text objective;



	// Use this for initialization
	void Start()
	{
		objective.text = "";
		objective.text = "Make it to the Top of the Tower And Collect the Coin in 10 Secs";
		Destroy(gameObject, 4);

	}

	// Update is called once per frame
	void Update()
	{

    }
}
