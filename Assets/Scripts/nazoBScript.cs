using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class nazoBScript : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;
    public Text button5Text;

    public GameObject canvas;
    public GameObject door5;
    public GameObject mainCamera;
    public GameObject door5Camera;

    public GameObject nazoBansButton;
    public GameObject return5Button;

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip enterSound;
    public AudioClip returnSound;

    string letter1;
    string letter2;
    string letter3;
    string letter4;
    string letter5;

    string[] str = { "A", "B", "C", "E", "H", "N", "P", "U" };

    int i, j, k, l, m;
    int ball2;

    public GameObject ball;

    BallScript BallScript;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        return5Button.gameObject.SetActive(false);
        nazoBansButton.gameObject.SetActive(false);

        letter1 = str[0];
        letter2 = str[0];
        letter3 = str[0];
        letter4 = str[0];
        letter5 = str[0];

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

        if (l < 7)
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
    public void Button5()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (m < 8)
        {
            m++;
            if (m == 8)
            {
                m = 0;
            }

            letter5 = str[m];
            button5Text.text = letter5.ToString();
        }
    }

    public void Enter()
    {

        if (letter1 == "P" && letter2 == "E" && letter3 == "A" && letter4 == "C" && letter5 == "E")
        {
            audioSource.clip = enterSound;
            audioSource.Play();

            ball2 = 1;
            PlayerPrefs.SetInt("ball2", ball2);

            this.gameObject.SetActive(false);
            door5.transform.rotation = Quaternion.Euler(0, 90, 0);

            canvas.gameObject.SetActive(true);

            mainCamera.gameObject.SetActive(true);
            door5Camera.gameObject.SetActive(false);

            BallScript.Ball2();

        }
        else
        {
            ball2 = 0;
        }
    }

    public void Return()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        this.gameObject.SetActive(false);

        return5Button.gameObject.SetActive(true);
        nazoBansButton.gameObject.SetActive(true);
    }


}
