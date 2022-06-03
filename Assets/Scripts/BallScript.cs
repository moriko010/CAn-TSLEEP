using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallScript : MonoBehaviour
{
    int b1;
    int b2;
    int b3;
    int b4;

    int i;
    public int lastbox;

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;

    public Text pickUpButton1Text;
    public Text pickUpButton2Text;
    public Text pickUpButton3Text;
    public Text pickUpButton4Text;

    public GameObject nazoBoxD;
    public GameObject nazoLastBox;
    public GameObject nazoLastCol;

    public GameObject nazoLastBoxButton;

    public GameObject player;

    Vector3 tmp1;
    Vector3 tmp2;
    Vector3 tmp3;
    Vector3 tmp4;


    // Start is called before the first frame update
    void Start()
    {
        lastbox = PlayerPrefs.GetInt("lastbox");

        if(lastbox == 4)
        {
            nazoLastBox.gameObject.SetActive(false);
            nazoLastCol.gameObject.SetActive(true);

        }

        // ball active -----------------------------------------------------

        b1 = PlayerPrefs.GetInt("ball1");
        b2 = PlayerPrefs.GetInt("ball2");
        b3 = PlayerPrefs.GetInt("ball3");
        b4 = PlayerPrefs.GetInt("ball4");

        if(b1 == 1)
        {
            ball1.gameObject.SetActive(true);
        }
        else
        {
            ball1.gameObject.SetActive(false);
        }

        if(b2 == 1)
        {
            ball2.gameObject.SetActive(true);
        }
        else
        {
            ball2.gameObject.SetActive(false);
        }

        if(b3 == 1)
        {
            ball3.gameObject.SetActive(true);
        }
        else
        {
            ball3.gameObject.SetActive(false);
        }

        if(b4 == 1)
        {
            ball4.gameObject.SetActive(true);
        }
        else
        {
            ball4.gameObject.SetActive(false);
        }




        //  ball position------------------------------------------------------

        if (PlayerPrefs.HasKey("ball1x") == false)
        {
            ball1.transform.position = new Vector3(2.3f, -1.13f, 1.8f);
        }
        else
        {
            tmp1.x = PlayerPrefs.GetFloat("ball1x");
            tmp1.y = PlayerPrefs.GetFloat("ball1y");
            tmp1.z = PlayerPrefs.GetFloat("ball1z");
            ball1.transform.position = tmp1;
        }

        if (PlayerPrefs.HasKey("ball2x") == false)
        {
            ball2.transform.position = new Vector3(-6.2f, -1.13f, 21);
        }
        else
        {
            tmp2.x = PlayerPrefs.GetFloat("ball2x");
            tmp2.y = PlayerPrefs.GetFloat("ball2y");
            tmp2.z = PlayerPrefs.GetFloat("ball2z");
            ball2.transform.position = tmp2;
        }

        if (PlayerPrefs.HasKey("ball3x") == false)
        {
            ball3.transform.position = new Vector3(-8, -1.13f, 23.5f);
        }
        else
        {
            tmp3.x = PlayerPrefs.GetFloat("ball3x");
            tmp3.y = PlayerPrefs.GetFloat("ball3y");
            tmp3.z = PlayerPrefs.GetFloat("ball3z");
            ball3.transform.position = tmp3;
        }

        if (PlayerPrefs.HasKey("ball4x") == false)
        {
            ball4.transform.position = new Vector3(-8, -1.13f, 1.7f);
        }
        else
        {
            tmp4.x = PlayerPrefs.GetFloat("ball4x");
            tmp4.y = PlayerPrefs.GetFloat("ball4y");
            tmp4.z = PlayerPrefs.GetFloat("ball4z");
            ball4.transform.position = tmp4;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ball2()
    {
        b2 = PlayerPrefs.GetInt("ball2");

        if (b2 == 1)
        {
            ball2.gameObject.SetActive(true);
        }
        else
        {
            ball2.gameObject.SetActive(false);
        }
    }

    public void Ball4()
    {
        b4 = PlayerPrefs.GetInt("ball4");

        if (b4 == 1)
        {
            ball4.gameObject.SetActive(true);
            nazoBoxD.gameObject.SetActive(false);
        }
        else
        {
            ball4.gameObject.SetActive(false);
        }
    }



    public void PickUpBall1()
    {
        if(i == 0)
        {
            ball1.gameObject.transform.parent = player.gameObject.transform;
            ball1.gameObject.transform.localPosition = new Vector3(0, 2.1f, 2.5f);
            pickUpButton1Text.text = "DROP";

            i = 1;
        }
        else
        {
            ball1.gameObject.transform.parent = this.gameObject.transform;
            tmp1 = ball1.transform.position;
            tmp1.y = -1.13f;
            ball1.transform.position = tmp1;

            tmp1 = ball1.transform.position;
            PlayerPrefs.SetFloat("ball1x", tmp1.x);
            PlayerPrefs.SetFloat("ball1y", tmp1.y);
            PlayerPrefs.SetFloat("ball1z", tmp1.z);
            pickUpButton1Text.text = "PICK UP";

            i = 0;
        }

    }

    public void PickUpBall2()
    {
        if (i == 0)
        {
            ball2.gameObject.transform.parent = player.gameObject.transform;
            ball2.gameObject.transform.localPosition = new Vector3(0, 2.1f, 2.5f);
            pickUpButton2Text.text = "DROP";

            i = 1;
        }
        else
        {
            ball2.transform.parent = this.gameObject.transform;
            tmp2 = ball2.gameObject.transform.position;
            tmp2.y = -1.13f;
            ball2.gameObject.transform.position = tmp2;

            tmp2 = ball2.gameObject.transform.position;
            PlayerPrefs.SetFloat("ball2x", tmp2.x);
            PlayerPrefs.SetFloat("ball2y", tmp2.y);
            PlayerPrefs.SetFloat("ball2z", tmp2.z);

            pickUpButton2Text.text = "PICK UP";

            i = 0;
        }

    }

    public void PickUpBall3()
    {
        if (i == 0)
        {
            ball3.gameObject.transform.parent = player.gameObject.transform;
            ball3.gameObject.transform.localPosition = new Vector3(0, 2.1f, 2.5f);
            pickUpButton3Text.text = "DROP";

            i = 1;
        }
        else
        {
            ball3.gameObject.transform.parent = this.gameObject.transform;
            tmp3 = ball3.transform.position;
            tmp3.y = -1.13f;
            ball3.gameObject.transform.position = tmp3;

            tmp3 = ball3.transform.position;
            PlayerPrefs.SetFloat("ball3x", tmp3.x);
            PlayerPrefs.SetFloat("ball3y", tmp3.y);
            PlayerPrefs.SetFloat("ball3z", tmp3.z);

            pickUpButton3Text.text = "PICK UP";

            i = 0;
        }

    }

    public void PickUpBall4()
    {
        if (i == 0)
        {
            ball4.gameObject.transform.parent = player.gameObject.transform;
            ball4.gameObject.transform.localPosition = new Vector3(0, 2.1f, 2.5f);
            pickUpButton4Text.text = "DROP";

            i = 1;
        }
        else
        {
            ball4.gameObject.transform.parent = this.gameObject.transform;
            tmp4 = ball4.transform.position;
            tmp4.y = -1.13f;
            ball4.gameObject.transform.position = tmp4;

            tmp4 = ball4.transform.position;
            PlayerPrefs.SetFloat("ball4x", tmp4.x);
            PlayerPrefs.SetFloat("ball4y", tmp4.y);
            PlayerPrefs.SetFloat("ball4z", tmp4.z);

            pickUpButton4Text.text = "PICK UP";

            i = 0;
        }
    }

    public void InBox1()
    {
        ball1.gameObject.transform.parent = nazoLastBox.gameObject.transform;
        ball1.gameObject.transform.localPosition = new Vector3(-0.2f, 0.3f, 0.2f);
        lastbox ++;
        PlayerPrefs.SetInt("lastbox", lastbox);

        tmp1 = ball1.transform.position;
        PlayerPrefs.SetFloat("ball1x", tmp1.x);
        PlayerPrefs.SetFloat("ball1y", tmp1.y);
        PlayerPrefs.SetFloat("ball1z", tmp1.z);

        if (lastbox == 4)
        {
            nazoLastBox.gameObject.SetActive(false);
            nazoLastCol.gameObject.SetActive(true);
            nazoLastBoxButton.gameObject.SetActive(false);

        }

    }

    public void InBox2()
    {
        ball2.gameObject.transform.parent = nazoLastBox.gameObject.transform;
        ball2.gameObject.transform.localPosition = new Vector3(0.2f, 0.3f, 0.2f);
        lastbox ++;
        PlayerPrefs.SetInt("lastbox", lastbox);

        tmp2 = ball2.transform.position;
        PlayerPrefs.SetFloat("ball2x", tmp2.x);
        PlayerPrefs.SetFloat("ball2y", tmp2.y);
        PlayerPrefs.SetFloat("ball2z", tmp2.z);

        if (lastbox == 4)
        {
            nazoLastBox.gameObject.SetActive(false);
            nazoLastCol.gameObject.SetActive(true);
            nazoLastBoxButton.gameObject.SetActive(false);

        }

    }

    public void InBox3()
    {
        ball3.gameObject.transform.parent = nazoLastBox.gameObject.transform;
        ball3.gameObject.transform.localPosition = new Vector3(-0.2f, 0.3f, -0.2f);
        lastbox ++;
        PlayerPrefs.SetInt("lastbox", lastbox);

        tmp3 = ball3.transform.position;
        PlayerPrefs.SetFloat("ball3x", tmp3.x);
        PlayerPrefs.SetFloat("ball3y", tmp3.y);
        PlayerPrefs.SetFloat("ball3z", tmp3.z);

        if (lastbox == 4)
        {
            nazoLastBox.gameObject.SetActive(false);
            nazoLastCol.gameObject.SetActive(true);
            nazoLastBoxButton.gameObject.SetActive(false);

        }

    }

    public void InBox4()
    {
        ball4.gameObject.transform.parent = nazoLastBox.gameObject.transform;
        ball4.gameObject.transform.localPosition = new Vector3(0.2f, 0.3f, -0.2f);
        lastbox ++;
        PlayerPrefs.SetInt("lastbox", lastbox);

        tmp4 = ball4.transform.position;
        PlayerPrefs.SetFloat("ball4x", tmp4.x);
        PlayerPrefs.SetFloat("ball4y", tmp4.y);
        PlayerPrefs.SetFloat("ball4z", tmp4.z);

        if (lastbox == 4)
        {
            nazoLastBox.gameObject.SetActive(false);
            nazoLastCol.gameObject.SetActive(true);
            nazoLastBoxButton.gameObject.SetActive(false);

        }

    }

}
