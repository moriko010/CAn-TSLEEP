using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerScript : MonoBehaviour
{
    public FloatingJoystick joy; //左画面JoyStick
    public FloatingJoystick joyRotate; //右画面JoyStick

    public GameObject pushButton;
    public GameObject canvas;
    public GameObject mainCamera;
    public GameObject subCamera;
    public GameObject nazoLastBoxCamera;

// Scene Button
    public GameObject cabinetButton;
    public GameObject bookButton;
    public GameObject fridge1Button;
    public GameObject fridge2Button;
    public GameObject bedButton;
    public GameObject rackButton;

// nazo Button
    public GameObject nazo1Button;
    public GameObject nazo2Button;
    public GameObject nazo3Button;
    public GameObject nazoBButton;
    public GameObject nazoB2Button;
    public GameObject nazoBansButton;
    public GameObject nazoCdButton;
    public GameObject nazoCoButton;
    public GameObject nazodButton;
    public GameObject nazoDButton;
    public GameObject nazoDansButton;
    public GameObject nazoLastBoxCameraButton;
    public GameObject nazoLastBoxButton;
    public GameObject nazoLastButton;
    public GameObject nazoLastAnsButton;

    public GameObject calendarButton;
    public GameObject plantButton;

// nazo Canvas
    public GameObject nazo1;
    public GameObject nazo2;
    public GameObject nazo3;
    public GameObject nazoB;
    public GameObject nazoB2;
    public GameObject nazoBans;
    public GameObject nazoCd;
    public GameObject nazoCo;
    public GameObject nazod;
    public GameObject nazoD;
    public GameObject nazoDans;
    public GameObject nazoLastBox;
    public GameObject nazoLastBoxHint;
    public GameObject nazoLast;
    public GameObject nazoLastAns;
    public GameObject calendar;

// Kitchen Doors
    public GameObject door2Button;
    public GameObject door3Button;
    public GameObject door4Button;
    public GameObject door5Button;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject return2Button;
    public GameObject return3Button;
    public GameObject return4Button;
    public GameObject return5Button;
    public GameObject door2Camera;
    public GameObject door3Camera;
    public GameObject door4Camera;
    public GameObject door5Camera;

// Balls
    public GameObject pickUpButton1;
    public GameObject pickUpButton2;
    public GameObject pickUpButton3;
    public GameObject pickUpButton4;

// Sounds
    public AudioClip jumpSound;
    //public AudioClip walkSound;
    public AudioClip ballSound;
    public AudioClip buttonSound;
    public AudioClip sceneSound;
    public AudioClip paperSound;
    public AudioClip returnSound;

    AudioSource audioSource;

    public GameObject box;
    public GameObject plant;

    public GameObject particle;

    float dx;
    float dy;
    float rad;
    float deg;


    int jumpCount;
    int fridge;
    int rack;
    int drop;
    int lastbox;

// Move
    float moveSpeed = 2.0f; //移動する速度
    float rotateSpeed = 8.0f;  //回転する速度
    float timer = 0.0f;
    float clearTimer = 0.0f;
    float degStop;
    //float thrust = 500.0f;
    float jumpPower = 9.5f;
    bool isGrounded;

    Rigidbody playerRb;
    Rigidbody colRb;

    Vector3 tmp;
    Vector3 force;

    bool timebool = true;
    //bool ispush = false;
    bool buttonDownFlag = false;
    bool clearBool = false;
    //bool isWalk = false;

    Animator animator;

    public GameObject ball;
    BallScript BallScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        BallScript = ball.GetComponent<BallScript>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

        force = new Vector3(0, 0, 300.0f);

        if (PlayerPrefs.HasKey("xPosition"))
        {
            tmp.x = PlayerPrefs.GetFloat("xPosition");
            tmp.y = PlayerPrefs.GetFloat("yPosition");
            tmp.z = PlayerPrefs.GetFloat("zPosition");
            this.transform.position = tmp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(timebool)
        {
            timer += Time.deltaTime;
        }
        if(timer > 0.01f)
        {
            //this.transform.position = new Vector3(9, 2, 5);

            if (PlayerPrefs.HasKey("xPosition"))
            {
                tmp.x = PlayerPrefs.GetFloat("xPosition");
                tmp.y = PlayerPrefs.GetFloat("yPosition");
                tmp.z = PlayerPrefs.GetFloat("zPosition");
                this.transform.position = tmp;
            } 
            timebool = false;
            timer = 0.0f;
        }*/

        if(clearBool)
        {
            clearTimer += Time.deltaTime;
            moveSpeed = 0;
            animator.SetBool("SlowWalk", true);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.position += this.transform.forward * 0.5f * Time.deltaTime;
            canvas.gameObject.SetActive(false);

            if (clearTimer > 2.0f)
            {
                particle.gameObject.SetActive(true);
                FadeManager.Instance.LoadScene("Clear", 4.0f);
            }
        }
        //playerRb.velocity = Vector3.zero;
        //playerRb.AddForce(force);

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
            animator.SetBool("Walk", true);
            //this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime; //正面方向へプレイヤーを移動させ続ける
            if(isGrounded == true)
            {
                playerRb.velocity = Vector3.zero;
            }
            //playerRb.AddRelativeForce(force);
            playerRb.AddForce(transform.forward * 100.0f);

            // isWalk = true;

            degStop = deg; //停止前のプレイヤーの向きを保存
        }
        else //joystickの原点と(dx,dy)の２点がなす角度が０の時 = joystickが止まっている時
        {
            animator.SetBool("Walk", false);
            //isWalk = false;
        }

    }

    /*void WalkSound()
    {
        if(isWalk)
        {
            audioSource.clip = walkSound;
            audioSource.Play();
        }
    }*/



    // collision -------------------------------------

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "clear")
        {
            clearBool = true;
            subCamera.gameObject.SetActive(false);

        }

    }
    private void OnTriggerStay(Collider col)
    {
        // ボタンの出現
        if (col.gameObject.tag == "cabinet")
        {
            tmp = this.transform.position;
            PlayerPrefs.SetFloat("xPosition", tmp.x);
            PlayerPrefs.SetFloat("yPosition", tmp.y);
            PlayerPrefs.SetFloat("zPosition", tmp.z);

            cabinetButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "book")
        {
            tmp = this.transform.position;
            PlayerPrefs.SetFloat("xPosition", tmp.x);
            PlayerPrefs.SetFloat("yPosition", tmp.y);
            PlayerPrefs.SetFloat("zPosition", tmp.z);

            bookButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "fridge")
        {
            if(PlayerPrefs.GetInt("fridgeopen") == 1)
            {
                tmp = this.transform.position;
                PlayerPrefs.SetFloat("xPosition", tmp.x);
                PlayerPrefs.SetFloat("yPosition", tmp.y);
                PlayerPrefs.SetFloat("zPosition", tmp.z);

                fridge = 0;
                PlayerPrefs.SetInt("fridge", fridge);

                fridge1Button.gameObject.SetActive(true);
            }
        }

        if (col.gameObject.tag == "fridge2")
        {
            if (PlayerPrefs.GetInt("fridgeopen") == 1)
            {
                tmp = this.transform.position;
                PlayerPrefs.SetFloat("xPosition", tmp.x);
                PlayerPrefs.SetFloat("yPosition", tmp.y);
                PlayerPrefs.SetFloat("zPosition", tmp.z);

                fridge = 1;
                PlayerPrefs.SetInt("fridge", fridge);
            
                fridge2Button.gameObject.SetActive(true);
            }

        }
        
        if (col.gameObject.tag == "bed")
        {
            tmp = this.transform.position;
            PlayerPrefs.SetFloat("xPosition", tmp.x);
            PlayerPrefs.SetFloat("yPosition", tmp.y);
            PlayerPrefs.SetFloat("zPosition", tmp.z);

            bedButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "rack")
        {
            tmp = this.transform.position;
            PlayerPrefs.SetFloat("xPosition", tmp.x);
            PlayerPrefs.SetFloat("yPosition", tmp.y);
            PlayerPrefs.SetFloat("zPosition", tmp.z);

            rack = 0;
            PlayerPrefs.SetInt("rack", rack);

            rackButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "rack2")
        {
            tmp = this.transform.position;
            PlayerPrefs.SetFloat("xPosition", tmp.x);
            PlayerPrefs.SetFloat("yPosition", tmp.y);
            PlayerPrefs.SetFloat("zPosition", tmp.z);

            rack = 1;
            PlayerPrefs.SetInt("rack", rack);

            rackButton.gameObject.SetActive(true);
        }



        if (col.gameObject.tag == "nazo1")
        {
            nazo1Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazo2")
        {
            nazo2Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazo3")
        {
            if (PlayerPrefs.GetInt("fridgeopen") == 0)
            {
                nazo3Button.gameObject.SetActive(true);
            }
        }



        if (col.gameObject.tag == "nazoB")
        {
            nazoBButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoB2")
        {
            nazoB2Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "basket")
        {
            nazoCdButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoC-o")
        {
            nazoCoButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoD")
        {
            nazoDButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoDans")
        {
            nazoDansButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoLastBox")
        {
            nazoLastBoxCameraButton.gameObject.SetActive(true);
            drop = 1;
        }

        if (col.gameObject.tag == "nazolastcol")
        {
            nazoLastButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "nazoLast")
        {
            nazoLastButton.gameObject.SetActive(false);
            nazoLastAnsButton.gameObject.SetActive(true);
        }



        if (col.gameObject.tag == "calendar")
        {
            calendarButton.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "plant")
        {
            plantButton.gameObject.SetActive(true);
        }

        // ball -------------------------------------

        if (col.gameObject.tag == "ball1")
        {
            pickUpButton1.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "ball2")
        {
            pickUpButton2.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "ball3")
        {
            pickUpButton3.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "ball4")
        {
            pickUpButton4.gameObject.SetActive(true);
        }


        // ---------------------------------------------


        if (col.gameObject.tag == "door2")
        {
            door2Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "door3")
        {
            door3Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "door4")
        {
            door4Button.gameObject.SetActive(true);
        }

        if (col.gameObject.tag == "door5")
        {
            door5Button.gameObject.SetActive(true);
        }


    }


    // ボタンの消失
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "cabinet")
        {
            cabinetButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "book")
        {
            bookButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "fridge")
        {
            fridge1Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "fridge2")
        {
            fridge2Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "bed")
        {
            bedButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "rack")
        {
            rackButton.gameObject.SetActive(false);
        }



        if (col.gameObject.tag == "nazo1")
        {
            nazo1Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazo2")
        {
            nazo2Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazo3")
        {
            nazo3Button.gameObject.SetActive(false);
        }



        if (col.gameObject.tag == "nazoB")
        {
            nazoBButton.gameObject.SetActive(false);
        }
        
        if (col.gameObject.tag == "nazoB2")
        {
            nazoB2Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "basket")
        {
            nazoCdButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazoC-o")
        {
            nazoCoButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazoD")
        {
            nazoDButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazoDans")
        {
            nazoDansButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazoLastBox")
        {
            nazoLastBoxCameraButton.gameObject.SetActive(false);
            drop = 0;
        }

        if (col.gameObject.tag == "nazoLastCol")
        {
            nazoLastButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "nazoLast")
        {
            nazoLastAnsButton.gameObject.SetActive(false);
        }



        if (col.gameObject.tag == "calendar")
        {
            calendarButton.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "plant")
        {
            plantButton.gameObject.SetActive(false);
        }

        // ball --------------------------------------

        if (col.gameObject.tag == "ball1")
        {
            pickUpButton1.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "ball2")
        {
            pickUpButton2.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "ball3")
        {
            pickUpButton3.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "ball4")
        {
            pickUpButton4.gameObject.SetActive(false);
        }



        // ---------------------------------------------


        if (col.gameObject.tag == "door2")
        {
            door2Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "door3")
        {
            door3Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "door4")
        {
            door4Button.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "door5")
        {
            door5Button.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ytag")　　//jumpの回数制限をつけます
        {
            jumpCount = 0;
            animator.SetBool("Jump", false);

            isGrounded = true;
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
        if(col.gameObject.tag == "push")
        {
            pushButton.gameObject.SetActive(true);
            if(buttonDownFlag)
            {
                colRb = col.gameObject.GetComponent<Rigidbody>();
                colRb.constraints = RigidbodyConstraints.None;
                colRb.freezeRotation = true;

                box.GetComponent<BoxScript>().BoxPositionSave();
            }
        }
    }

    public void OnButtonDown()
    {
        moveSpeed = 1.0f;
        buttonDownFlag = true;
    }
    public void OnButtonUp()
    {
        moveSpeed = 3.0f;
        colRb.constraints = RigidbodyConstraints.FreezePosition;
        buttonDownFlag = false;
    }
   
    

    // button -------------------------------------------------

        // Jump-------------
    public void Jump()
    {
        if (jumpCount == 0)
        {
            audioSource.clip = jumpSound;
            audioSource.Play();

            playerRb.velocity = new Vector3(0, jumpPower, 0);
            //rb.AddForce(transform.forward * thrust);
            jumpCount = 1;
            animator.SetBool("Jump", true);

            isGrounded = false;
            Invoke("JumpFalse", 1.8f);
        }
    }
    void JumpFalse()
    {
        if(jumpCount != 0)
        {
            jumpCount = 0;
            animator.SetBool("Jump", false);

            isGrounded = false;
        }
    }

    // ------------------------- 

    public void Push()
    {
    }

    public void Nazo1()
    {
        nazo1.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();
    }

    public void Nazo2()
    {
        nazo2.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();
    }

    public void Nazo3()
    {
        nazo3.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();
    }



    public void NazoB()
    {
        nazoB.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();
    }

    public void NazoB2()
    {
        nazoB2.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }

    public void NazoBans()
    {
        nazoBans.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();
    }


    public void NazoCd()
    {
        nazoCd.gameObject.SetActive(true);
        audioSource.clip = paperSound;
        audioSource.Play();

    }

    public void NazoCo()
    {
        nazoCo.gameObject.SetActive(true);
        audioSource.clip = paperSound;
        audioSource.Play();

    }

    public void Nazod()
    {
        nazod.gameObject.SetActive(true);
        audioSource.clip = paperSound;
        audioSource.Play();

    }

    public void NazoD()
    {
        nazoD.gameObject.SetActive(true);
        audioSource.clip = paperSound;
        audioSource.Play();


    }

    public void NazoDans()
    {
        nazoDans.gameObject.SetActive(true);
        nazoDansButton.gameObject.SetActive(false);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }

    public void NazoLastBoxCamera()
    {
        nazoLastBoxCamera.gameObject.SetActive(true);
        nazoLastBox.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        subCamera.gameObject.SetActive(false);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }

    public void NazoLast()
    {
        nazoLast.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }

    public void NazoLastAns()
    {
        nazoLastAns.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }



    public void Calendar()
    {
        calendar.gameObject.SetActive(true);
        audioSource.clip = buttonSound;
        audioSource.Play();

    }

    public void Plant()
    {
        plant.transform.position = new Vector3(7, -1, 27.7f);
        plant.transform.rotation = Quaternion.Euler(0, 0, 95);
        this.transform.position = new Vector3(6, -1.2f, 25);
    }


    public void PickUp1()
    {
        audioSource.clip = ballSound;
        audioSource.Play();


        if (drop == 0)
        {
            BallScript.PickUpBall1();
        }
        else
        {
            BallScript.InBox1();
            pickUpButton1.gameObject.SetActive(false);
        }
    }

    public void PickUp2()
    {
        audioSource.clip = ballSound;
        audioSource.Play();

        if (drop == 0)
        {
            BallScript.PickUpBall2();
        }
        else
        {
            BallScript.InBox2();
            pickUpButton2.gameObject.SetActive(false);
        }
    }

    public void PickUp3()
    {
        audioSource.clip = ballSound;
        audioSource.Play();

        if (drop == 0)
        {
            BallScript.PickUpBall3();
        }
        else
        {
            BallScript.InBox3();
            pickUpButton3.gameObject.SetActive(false);
        }
    }

    public void PickUp4()
    {
        audioSource.clip = ballSound;
        audioSource.Play();

        if (drop == 0)
        {
            BallScript.PickUpBall4();
        }
        else
        {
            BallScript.InBox4();
            pickUpButton4.gameObject.SetActive(false);
        }
    }


    // kitchen door-------------------------------------------

    public void Door2()
    {
        door2.transform.rotation = Quaternion.Euler(0, 0, 0);

        mainCamera.gameObject.SetActive(false);
        subCamera.gameObject.SetActive(false);
        door2Camera.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);

        return2Button.gameObject.SetActive(true);
        nazodButton.gameObject.SetActive(true);
    }

    public void Door3()
    {
        door3.transform.rotation = Quaternion.Euler(0, 0, 0);

        mainCamera.gameObject.SetActive(false);
        subCamera.gameObject.SetActive(false);
        door3Camera.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);

        return3Button.gameObject.SetActive(true);
    }

    public void Door4()
    {
        door4.transform.rotation = Quaternion.Euler(0, 0, 0);

        mainCamera.gameObject.SetActive(false);
        door4Camera.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);

        return4Button.gameObject.SetActive(true);
    }

    public void Door5()
    {
        door5.transform.rotation = Quaternion.Euler(0, 0, 0);

        mainCamera.gameObject.SetActive(false);
        subCamera.gameObject.SetActive(false);
        door5Camera.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);

        return5Button.gameObject.SetActive(true);
        nazoBansButton.gameObject.SetActive(true);
    }



    public void Return2()
    {

        door2.transform.rotation = Quaternion.Euler(0, 90, 0);

        audioSource.clip = returnSound;
        audioSource.Play();

        return2Button.gameObject.SetActive(false);
        nazodButton.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        mainCamera.gameObject.SetActive(true);
        subCamera.gameObject.SetActive(true);
        door2Camera.gameObject.SetActive(false);
    }

    public void Return3()
    {
        door3.transform.rotation = Quaternion.Euler(0, 90, 0);

        audioSource.clip = returnSound;
        audioSource.Play();

        return3Button.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        mainCamera.gameObject.SetActive(true);
        subCamera.gameObject.SetActive(true);
        door3Camera.gameObject.SetActive(false);
    }

    public void Return4()
    {
        door4.transform.rotation = Quaternion.Euler(0, 90, 0);

        audioSource.clip = returnSound;
        audioSource.Play();

        return4Button.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        mainCamera.gameObject.SetActive(true);
        subCamera.gameObject.SetActive(true);
        door4Camera.gameObject.SetActive(false);
    }

    public void Return5()
    {
        door5.transform.rotation = Quaternion.Euler(0, 90, 0);

        audioSource.clip = returnSound;
        audioSource.Play();

        return5Button.gameObject.SetActive(false);
        nazoBansButton.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        mainCamera.gameObject.SetActive(true);
        subCamera.gameObject.SetActive(true);
        door5Camera.gameObject.SetActive(false);
    }

    // ------------------------------------------










    // Scene移動 ----------------

    public void CabinetButton()
    {
        SceneManager.LoadScene("Cabinet");
        audioSource.clip = sceneSound;
        audioSource.Play();
    }

    public void BookButton()
    {
        SceneManager.LoadScene("Book");
        audioSource.clip = sceneSound;
        audioSource.Play();
    }

    public void FridgeButton()
    {
        SceneManager.LoadScene("Fridge");
        audioSource.clip = sceneSound;
        audioSource.Play();
    }
    public void BedButton()
    {
        SceneManager.LoadScene("Bed");
        audioSource.clip = sceneSound;
        audioSource.Play();
    }

    public void RackButton()
    {
        SceneManager.LoadScene("Rack");
        audioSource.clip = sceneSound;
        audioSource.Play();
    }




}
