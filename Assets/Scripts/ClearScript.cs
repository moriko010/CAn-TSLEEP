using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearScript : MonoBehaviour
{

    public GameObject character;
    public GameObject mainCamera;
    public GameObject panel;
    public GameObject clearCanvas;

    float fadeSpeed = 0.02f;
    float alpha;
    float red, green, blue;

    Image fadeImage;

    public Vector3 _center;
    public Vector3 _axis;
    public float _period = 10;

    float time;

    bool timebool = false;
    bool cameraRotate = false;
    bool clear = false;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        character.transform.position = new Vector3(7.1f, 0, 0.8f);
        character.transform.rotation = Quaternion.Euler(-90, -90, 0);

        mainCamera.transform.position = new Vector3(9.8f, 0, 0.8f);
        mainCamera.transform.rotation = Quaternion.Euler(-90, -90, 0);

        animator = character.gameObject.GetComponent<Animator>();


        fadeImage = panel.GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha >= 0)
        {
            alpha -= fadeSpeed;
            fadeImage.color = new Color(red, green, blue, alpha);
        }
        else
        {
            cameraRotate = true;
        }

        if(timebool == true)
        {
            time += Time.deltaTime;

        }


        if (time >= 2.2f)
        {

            cameraRotate = false;
            clear = true;
        }

        if(cameraRotate == true)
        {
            timebool = true;
            mainCamera.transform.RotateAround(_center, _axis, 360 / _period * Time.deltaTime);
        }
        else
        {
            timebool = false;
        }


        if(clear == true)
        {
            Invoke("ClearCamera", 2.0f);
        }
    }
    
    void ClearCamera()
    {
        character.transform.position = new Vector3(8.5f, -1.2f, 2.6f);
        character.transform.rotation = Quaternion.Euler(0, 0, 0);

        mainCamera.transform.position = new Vector3(6.3f, 2, 5.1f);
        mainCamera.transform.rotation = Quaternion.Euler(10, 150, 0);

        animator.SetBool("StandUp", true);

        Invoke("ClearCanvas",4.0f);
    }
    
    void ClearCanvas()
    {
        clearCanvas.SetActive(true);
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
}
