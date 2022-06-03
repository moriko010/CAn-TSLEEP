using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CabinetScript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject canvas;

    public GameObject nazo1HintCanvas;
    public GameObject nazoACanvas;

    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject checkButton1;
    public GameObject checkButton2;

    AudioSource audioSource;

    public AudioClip buttonSound;
    public AudioClip paperSound;
    public AudioClip returnSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RightButton()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();

        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(false);
        checkButton1.gameObject.SetActive(false);
        checkButton2.gameObject.SetActive(true);

    }
    public void LeftButton()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();

        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(true);
        checkButton1.gameObject.SetActive(true);
        checkButton2.gameObject.SetActive(false);
    }
    public void CheckButton1()
    {
        audioSource.clip = paperSound;
        audioSource.Play();

        nazo1HintCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void CheckButton2()
    {
        audioSource.clip = paperSound;
        audioSource.Play();

        nazoACanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void ReturnButton()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        nazo1HintCanvas.gameObject.SetActive(false);
        nazoACanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }


}
