using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NazoCanvasScript : MonoBehaviour
{
    
    public GameObject canvas;

    //AudioSource audioSource;

    //public AudioClip returnSound;


    // Start is called before the first frame update
    void Start()
    {
        //audioSource = this.gameObject.GetComponent<AudioSource>();

        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Return()
    {
        //audioSource.clip = returnSound;
        //audioSource.Play();

        this.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }

}
