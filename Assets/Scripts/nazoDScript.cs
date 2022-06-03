using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class nazoDScript : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public GameObject canvas;

    public GameObject player;

    string letter1;
    string letter2;
    string letter3;
    string letter4;

    string[] str = { "A", "C", "D", "E", "J", "K", "N", "S"};

    int i, j, k, l;
    int ball4;

    public GameObject ball;

    BallScript BallScript;

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip enterSound;
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

        BallScript = ball.GetComponent<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Button1()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (i < 8)
        {
            i++;
            if (i == 8)
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

        if (j < 8)
        {
            j++;
            if (j == 8)
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

        if (k < 8)
        {
            k++;
            if (k == 8)
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

        if (l < 8)
        {
            l++;
            if (l == 8)
            {
                l = 0;
            }

            letter4 = str[l];
            button4Text.text = letter4.ToString();
        }
    }

    public void Enter()
    {

        if (letter1 == "E" && letter2 == "D" && letter3 == "E" && letter4 == "N")
        {
            audioSource.clip = enterSound;
            audioSource.Play();

            ball4 = 1;
            PlayerPrefs.SetInt("ball4", ball4);

            this.gameObject.SetActive(false);

            canvas.gameObject.SetActive(true);

            BallScript.Ball4();

        }
        else
        {
            ball4 = 0;
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
