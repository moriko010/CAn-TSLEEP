using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainManager : MonoBehaviour
{
    int bedDoor;
    int bathDoor;
    int exit;

    public GameObject bedDoorObject;
    public GameObject bathDoorObject;
    public GameObject nazo3Object;
    public GameObject exitLeft;
    public GameObject exitRight;
    public GameObject particle;


    public GameObject canvas;
    public GameObject menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        BedDoor();
        BathDoor();
        Exit();

        if(PlayerPrefs.GetInt("fridgeopen") == 1)
        {
            nazo3Object.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BedDoor()
    {
        bedDoor = PlayerPrefs.GetInt("bedDoor");

        if (bedDoor == 0)
        {
            bedDoorObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (bedDoor == 1)
        {
            bedDoorObject.transform.rotation = Quaternion.Euler(0, 90, 0);


        }
    }

    public void BathDoor()
    {
        bathDoor = PlayerPrefs.GetInt("bathDoor");

        if (bathDoor == 0)
        {
            bathDoorObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (bathDoor == 1)
        {
            bathDoorObject.transform.rotation = Quaternion.Euler(0, 90, 0);


        }
    }

    public void Exit()
    {
        exit = PlayerPrefs.GetInt("exit");

        if (exit == 0)
        {
            exitLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
            exitRight.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (exit == 1)
        {
            exitLeft.transform.rotation = Quaternion.Euler(0, -90, 0);
            exitRight.transform.rotation = Quaternion.Euler(0, 90, 0);

        }
    }

    public void Particle()
    {
        particle.gameObject.SetActive(true);
    }

    public void MenuButton()
    {
        menuCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Start");
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ReturnButton()
    {
        menuCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

}
