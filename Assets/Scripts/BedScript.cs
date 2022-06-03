using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public GameObject nazoCCanvas;
    public GameObject nazoACanvas;

    public GameObject manager;
    AudioSource audioSource;

    public AudioClip paperSound;
    public AudioClip returnSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = manager.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckButtonC()
    {
        nazoCCanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

        audioSource.clip = paperSound;
        audioSource.Play();
    }

    public void CheckButtonA()
    {
        nazoACanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

        audioSource.clip = paperSound;
        audioSource.Play();
    }

    public void ReturnButtonC()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoCCanvas.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void ReturnButtonA()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoACanvas.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }


}
