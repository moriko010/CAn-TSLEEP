using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nazo2Script : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    public GameObject canvas;
    public GameObject mainManager;
    public GameObject player;
    
    MainManager Manager;

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip doorSound;
    public AudioClip returnSound;


    int number1;
    int number2;
    int number3;

    int door;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = player.gameObject.GetComponent<AudioSource>();

        canvas.gameObject.SetActive(false);

        button1Text.text = "0";
        button2Text.text = "0";
        button3Text.text = "0";

        Manager = mainManager.GetComponent<MainManager>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Button1()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (number1 < 9)
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

    public void Return()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        this.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }

    public void Enter()
    {
        if(number1 == 7 && number2 == 5 && number3 == 4)
        {
            audioSource.clip = doorSound;
            audioSource.Play();

            door = 1;
            PlayerPrefs.SetInt("bathDoor", door);

            Manager.BathDoor();
            this.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
        }
        else
        {
            door = 0;
            PlayerPrefs.SetInt("bathDoor", door);
        }
    }
}
