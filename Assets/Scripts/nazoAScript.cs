using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class nazoAScript : MonoBehaviour
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

    string[] str = { "A", "D", "I", "M", "R", "S", "T", "Y" };

    AudioSource audioSource;

    public AudioClip dialSound;
    public AudioClip enterSound;

    public int i;
    int j, k, l, m;
    int ball1;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        letter1 = str[0];
        letter2 = str[0];
        letter3 = str[0];
        letter4 = str[0];
        letter5 = str[0];
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
            if(i == 8)
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

        if (letter1 == "S" && letter2 == "M" && letter3 == "A" && letter4 == "R" && letter5 == "T")
        {
            audioSource.clip = enterSound;
            audioSource.Play();

            ball1 = 1;
            PlayerPrefs.SetInt("ball1", ball1);

            SceneManager.LoadScene("Main1");

        }
        else
        {
            ball1 = 0;
       }
    }

}
