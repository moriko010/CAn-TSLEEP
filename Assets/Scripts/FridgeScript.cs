using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject nazoCCanvas;
    public GameObject nazoBCanvas;

    public GameObject checkButtonC;
    public GameObject checkButtonB;

    public GameObject mainCamera;
    public GameObject subCamera;

    public int fridge;

    AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip returnSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //fridge =  PlayerPrefs.GetInt("fridge");

        if (fridge == 0)
        {
            mainCamera.gameObject.SetActive(true);
            subCamera.gameObject.SetActive(false);

            checkButtonC.gameObject.SetActive(true);
            checkButtonB.gameObject.SetActive(false);
        }
        else if(fridge == 1)
        {
            mainCamera.gameObject.SetActive(false);
            subCamera.gameObject.SetActive(true);

            checkButtonC.gameObject.SetActive(false);
            checkButtonB.gameObject.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckButtonC()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();

        nazoCCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void CheckButtonB()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();

        nazoBCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void ReturnButtonC()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoCCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    public void ReturnButtonB()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazoBCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }


}
