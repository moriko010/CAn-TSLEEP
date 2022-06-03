using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NazoLastBoxCanvasScript : MonoBehaviour
{
    
    public GameObject canvas;

    public GameObject mainCamera;
    public GameObject nazoLastBoxCamera;

    public GameObject nazoLastBoxButton;
    public GameObject nazoLastBoxHint;



    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NazoLastBox()
    {
        nazoLastBoxHint.gameObject.SetActive(true);
        nazoLastBoxButton.gameObject.SetActive(false);
    }


    public void Return()
    {
        nazoLastBoxCamera.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
    }

}
