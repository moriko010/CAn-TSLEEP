using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMark : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		float level = Mathf.Abs(Mathf.Sin(Time.time * 5));
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, level);
	}
}

