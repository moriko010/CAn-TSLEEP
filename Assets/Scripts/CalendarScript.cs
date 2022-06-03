using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalendarScript : MonoBehaviour
{
    
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Return()
    {
        this.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }

}
