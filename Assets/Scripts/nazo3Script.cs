using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class nazo3Script : MonoBehaviour
{
    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;
    public Text button5Text;

    public GameObject canvas;

    public GameObject player;

    string letter1;
    string letter2;
    string letter3;
    string letter4;
    string letter5;

    string[] str = { "A", "D", "E", "I", "M", "R", "S", "U", "Y"};

    int i, j, k, l, m;
    int fridgeopen;

    public GameObject nazo3;
    public GameObject fridgecheck1;
    public GameObject fridgecheck2;

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
        letter5 = str[0];

        fridgeopen = PlayerPrefs.GetInt("fridgeopen");

        FridgeOpen();
    }

    // Update is called once per frame
    void Update()
    {
        FridgeOpen();
    }

    public void Button1()
    {
        audioSource.clip = dialSound;
        audioSource.Play();

        if (i < 9)
        {
            i++;
            if (i == 9)
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

        if (j < 9)
        {
            j++;
            if (j == 9)
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

        if (k < 9)
        {
            k++;
            if (k == 9)
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

        if (l < 9)
        {
            l++;
            if (l == 9)
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

        if (m < 9)
        {
            m++;
            if (m == 9)
            {
                m = 0;
            }

            letter5 = str[m];
            button5Text.text = letter5.ToString();
        }
    }

    public void Enter()
    {
        audioSource.clip = enterSound;
        audioSource.Play();

        if (letter1 == "A" && letter2 == "R" && letter3 == "I" && letter4 == "S" && letter5 == "A")
        {
            fridgeopen = 1;
            PlayerPrefs.SetInt("fridgeopen", fridgeopen);

            canvas.gameObject.SetActive(true);
            nazo3.gameObject.SetActive(false);

            FridgeOpen();
            this.gameObject.SetActive(false);
        }
        else
        {
            fridgeopen = 0;

            FridgeOpen();
        }
    }

    public void Return()
    {
        audioSource.clip = returnSound;
        audioSource.Play();

        canvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void FridgeOpen()
    {
        if(fridgeopen == 0)
        {
            nazo3.gameObject.SetActive(true);
            fridgecheck1.gameObject.SetActive(false);
            fridgecheck2.gameObject.SetActive(false);
        }
        else if(fridgeopen == 1)
        {
            nazo3.gameObject.SetActive(false);
            fridgecheck1.gameObject.SetActive(true);
            fridgecheck2.gameObject.SetActive(true);

        }
    }

}
