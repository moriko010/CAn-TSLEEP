using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CharacterScript : MonoBehaviour
{
    public FloatingJoystick joy; //左画面JoyStick
    public FloatingJoystick joyRotate; //右画面JoyStick

    public GameObject jumpButton;
    public GameObject pushButton;
    public GameObject canvas;
    public GameObject menuCanvas;
    public GameObject mainCamera;


    public GameObject exitButton;
    public GameObject doorButton;
    public GameObject bedButton;
    //public GameObject pickUpButton;

    public GameObject swipe;
    public GameObject right;
    public GameObject left;
    public GameObject tap;
    public GameObject doorMark;
    public GameObject bedMark;

    //public GameObject rack;
    public GameObject exitRight;
    public GameObject exitLeft;
    public GameObject door;
    public GameObject doorcol;

    float dx;
    float dy;
    float rad;
    float deg;


    int jumpCount;

    float moveSpeed = 3.0f; //移動する速度
    float rotateSpeed = 8.0f;  //回転する速度
    float xPosition;
    float yPosition;
    float zPosition;
    float timer = 0.0f;
    float degStop;
    float jumpPower = 9.5f;

    Rigidbody rb;
    Rigidbody rigidy;

    Vector3 tmp;

    bool timebool = true;
    bool buttonDownFlag = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        swipe.gameObject.SetActive(true);

        exitLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
        exitRight.transform.rotation = Quaternion.Euler(0, 0, 0);
        door.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timebool)
        {
            timer += Time.deltaTime;
        }
        if(timer > 0.01f)
        {

            this.transform.position = new Vector3(-2.5f, -1.25f, 34);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);


            timebool = false;
            timer = 0.0f;
        }

        Joystick();
    }


    void Joystick()
    {
        dx = joy.Horizontal; //joystickの水平方向の動きの値、-1~1の値をとります
        dy = joy.Vertical; //joystickの垂直方向の動きの値、-1~1の値をとります

        rad = Mathf.Atan2(dx - 0, dy - 0); //　 原点(0,0)と点（dx,dy)の距離から角度をとってくれる便利な関数

        deg = rad * Mathf.Rad2Deg; //radianからdegreenに変換します

        transform.Rotate(new Vector3(0, rotateSpeed * joyRotate.Horizontal, 0));

        if (deg != 0) //joystickの原点と(dx,dy)の２点がなす角度が０ではないとき = joystickを動かしている時
        {
            animator.SetBool("CharaWalk", true); 
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime; //正面方向へプレイヤーを移動させ続ける

            degStop = deg; //停止前のプレイヤーの向きを保存

            swipe.gameObject.SetActive(false);
        }
        else //joystickの原点と(dx,dy)の２点がなす角度が０の時 = joystickが止まっている時
        {
            animator.SetBool("CharaWalk", false); 
        }

    }





    // collision -------------------------------------

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "xtag")
        {
            tmp = this.transform.position;
            xPosition = tmp.x;
        }

        if (col.gameObject.tag == "ytag")
        {
            tmp = this.transform.position;
            yPosition = tmp.y;
        }

        if (col.gameObject.tag == "ztag")
        {
            tmp = this.transform.position;
            zPosition = tmp.z;
        }

    }
    private void OnTriggerStay(Collider col)
    {
        // すり抜け防止
        if (col.gameObject.tag == "xtag")
        {
            //Debug.Log("xtag");
            tmp.x = xPosition;
            this.transform.position = tmp;
        }

        if (col.gameObject.tag == "ytag")
        {
            //Debug.Log("ytag");
            tmp.y = yPosition;
            this.transform.position = tmp;
        }

        if (col.gameObject.tag == "ztag")
        {
            //Debug.Log("ztag");
            tmp.z = zPosition;
            this.transform.position = tmp;
        }



        // button ----------------------------------------------


        if (col.gameObject.tag == "clear")
        {
            exitButton.gameObject.SetActive(true);
            tap.gameObject.SetActive(true);
        }


        if (col.gameObject.tag == "check")
        {
            joyRotate.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            Invoke("RightLeft", 3.0f);
            doorMark.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "door2")
        {
            doorButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "bed")
        {
            bedButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "atari")
        {
            jumpButton.gameObject.SetActive(true);
        }

    }

    void RightLeft()
    {
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);

    }


    // ボタンの消失
    private void OnTriggerExit(Collider col)
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ytag")　　//jumpの回数制限をつけます
        {
            jumpCount = 0;
            animator.SetBool("CharaJump", false);

        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "push")
        {
            pushButton.gameObject.SetActive(false);
        }
    }  


    
    // box --------------------------------------------------
    void OnCollisionStay(Collision col)
    {
        /*if(col.gameObject.tag == "push")
        {
            pushButton.gameObject.SetActive(true);
            if(buttonDownFlag)
            {
                rigidy = col.gameObject.GetComponent<Rigidbody>();
                rigidy.constraints = RigidbodyConstraints.None;
                rigidy.freezeRotation = true;

                rack.GetComponent<BoxScript>().BoxPositionSave();
            }
        }*/
    }

    public void OnButtonDown()
    {
        moveSpeed = 1.0f;
        buttonDownFlag = true;
    }
    public void OnButtonUp()
    {
        moveSpeed = 3.0f;
        rigidy.constraints = RigidbodyConstraints.FreezePosition;
        buttonDownFlag = false;
    }
   
    

    // button -------------------------------------------------

        // Jump-------------
    public void Jump()
    {

        if (jumpCount == 0)
        {

            rb.velocity = new Vector3(0, jumpPower, 0);
            jumpCount = 1;
            animator.SetBool("CharaJump", true);

            Invoke("JumpFalse", 1.8f);
        }
    }
    void JumpFalse()
    {
        if(jumpCount != 0)
        {
            jumpCount = 0;
            animator.SetBool("CharaJump", false);
        }
    }

    // ------------------------- 

    public void Exit()
    {
        exitLeft.transform.rotation = Quaternion.Euler(0, -90, 0);
        exitRight.transform.rotation = Quaternion.Euler(0, 90, 0);

        exitButton.gameObject.SetActive(false);
        tap.gameObject.SetActive(false);

    }

    public void Door()
    {
        door.transform.rotation = Quaternion.Euler(0, 90, 0);
        Debug.Log("door");

        doorButton.gameObject.SetActive(false);
        doorMark.gameObject.SetActive(false);
        doorcol.gameObject.SetActive(false);
        bedMark.gameObject.SetActive(true);

    }

    public void Bed()
    {
        this.transform.position = new Vector3(7, -0.15f, 0.7f);
        this.transform.rotation = Quaternion.Euler(-90, -90, 0);
        mainCamera.transform.localPosition = new Vector3(0.9f, 0.6f, 0.7f);
        mainCamera.transform.localRotation = Quaternion.Euler(-28.5f, -112.4f, -81.6f);

        bedButton.gameObject.SetActive(false);
        bedMark.gameObject.SetActive(false);

        Invoke("Fademanager", 2.5f);

    }

    // ---------------------------------------


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




    void Fademanager()
    {
        FadeManager.Instance.LoadScene("Main1", 2.0f);
    }
}
