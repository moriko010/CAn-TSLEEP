using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        page1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Page1()
    {
        audioSource.Play();

        page1.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);

    }
    public void Page2()
    {
        audioSource.Play();

        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(true);
        page3.gameObject.SetActive(false);
    }
    public void Page3()
    {
        audioSource.Play();

        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(true);
        page4.gameObject.SetActive(false);

    }
    public void Page4()
    {
        audioSource.Play();

        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(true);
    }
}
