using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackScript : MonoBehaviour
{
    public GameObject checkButtonB;
    public GameObject checkButtonCw;
    public GameObject checkButtonC;

    public GameObject canvas;
    public GameObject nazoBCanvas;
    public GameObject nazoCwCanvas;
    public GameObject nazoCCanvas;

    public GameObject mainCamera;
    public GameObject subCamera;

    AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip paperSound;
    public AudioClip returnSound;

    public int rack;

    // Start is called before the first frame update
    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        rack = PlayerPrefs.GetInt("rack");

        if (rack == 0)
        {
            mainCamera.gameObject.SetActive(true);
            subCamera.gameObject.SetActive(false);

            checkButtonB.gameObject.SetActive(true);
            checkButtonCw.gameObject.SetActive(true);
            checkButtonC.gameObject.SetActive(false);
        }
        else if (rack == 1)
        {
            mainCamera.gameObject.SetActive(false);
            subCamera.gameObject.SetActive(true);

            checkButtonB.gameObject.SetActive(false);
            checkButtonCw.gameObject.SetActive(false);
            checkButtonC.gameObject.SetActive(true);
        }

    }
    public void CheckButtonB()
    {
        audioSource.clip = paperSound;
        audioSource.Play();

        nazoBCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void CheckButtonCw()
    {
        audioSource.clip = paperSound;
        audioSource.Play();

        nazoCwCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void CheckButtonC()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();

        nazoCCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }


    public void ReturnButtonB()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoBCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    public void ReturnButtonCw()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoCwCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    public void ReturnButtonC()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoCCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    

}
