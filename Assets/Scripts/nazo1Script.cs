using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nazo1Script : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public GameObject canvas;
    public GameObject bedDoor;
    public GameObject mainManager;
    public GameObject player;
    
    MainManager Manager;

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip doorSound;

    int number1;
    int number2;
    int number3;
    int number4;

    int door;


    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);

        button1Text.text = "0";
        button2Text.text = "0";
        button3Text.text = "0";
        button4Text.text = "0";

        Manager = mainManager.GetComponent<MainManager>();

        audioSource = player.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("nazo1:" + door);


    }

    public void Button1()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if(number1 < 9)
        {
            number1++;
            button1Text.text = number1.ToString();

        }
        else
        {
            number1 = 0;
            button1Text.text = number1.ToString();

        }
    }
    public void Button2()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (number2 < 9)
        {
            number2++;
            button2Text.text = number2.ToString();

        }
        else
        {
            number2 = 0;
            button2Text.text = number2.ToString();

        }
    }
    public void Button3()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (number3 < 9)
        {
            number3++;
            button3Text.text = number3.ToString();

        }
        else
        {
            number3 = 0;
            button3Text.text = number3.ToString();

        }
    }
    public void Button4()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (number4 < 9)
        {
            number4++;
            button4Text.text = number4.ToString();

        }
        else
        {
            number4 = 0;
            button4Text.text = number4.ToString();

        }
    }

    public void Return()
    {
        this.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }

    public void Enter()
    {
        if(number1 == 3 && number2 == 5 && number3 == 6 && number4 == 4)
        {
            door = 1;
            PlayerPrefs.SetInt("bedDoor", door);

            audioSource.clip = doorSound;
            audioSource.Play();

            Manager.BedDoor();

            this.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
        }
        else
        {
            door = 0;
            PlayerPrefs.SetInt("bedDoor", door);

            audioSource.clip = dialSound;
            audioSource.Play();
        }
    }
}
