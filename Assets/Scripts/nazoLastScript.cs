using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class nazoLastScript : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;
    public Text button5Text;

    public GameObject canvas;

    string letter1;
    string letter2;
    string letter3;
    string letter4;
    string letter5;

    string[] str = { "A", "C", "D", "E", "H", "M", "N", "P", "R", "U"};

    int i, j, k, l,m;
    int exit;

    public GameObject mainManager;

    MainManager manager;

    public GameObject player;

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip doorSound;
    public AudioClip returnSound;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = player.gameObject.GetComponent<AudioSource>();

        canvas.gameObject.SetActive(false);

        letter1 = str[0];
        letter2 = str[0];
        letter3 = str[0];
        letter4 = str[0];

        manager = mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Button1()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (i < 10)
        {
            i++;
            if (i == 10)
            {
                i = 0;
            }

            letter1 = str[i];
            button1Text.text = letter1.ToString();
        }
    }
    public void Button2()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (j < 10)
        {
            j++;
            if (j == 10)
            {
                j = 0;
            }

            letter2 = str[j];
            button2Text.text = letter2.ToString();
        }
    }
    public void Button3()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (k < 10)
        {
            k++;
            if (k == 10)
            {
                k = 0;
            }

            letter3 = str[k];
            button3Text.text = letter3.ToString();
        }
    }
    public void Button4()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (l < 10)
        {
            l++;
            if (l == 10)
            {
                l = 0;
            }

            letter4 = str[l];
            button4Text.text = letter4.ToString();
        }
    }

    public void Button5()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (m < 10)
        {
            m++;
            if (m == 10)
            {
                m = 0;
            }

            letter5 = str[m];
            button5Text.text = letter5.ToString();
        }
    }

    public void Enter()
    {

        if (letter1 == "D" && letter2 == "R" && letter3 == "E" && letter4 == "A" && letter5 == "M")
        {
            audioSource.clip = doorSound;
            audioSource.Play();

            exit = 1;
            PlayerPrefs.SetInt("exit", exit);

            this.gameObject.SetActive(false);

            canvas.gameObject.SetActive(true);

            manager.Exit();

        }
        else
        {
            exit = 0;
        }
    }

    public void Return()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        this.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }


}
