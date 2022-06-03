using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    float timer = 0.0f;

    bool timebool = true;

    Vector3 tmp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timebool)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.01f)
        {
            if (PlayerPrefs.HasKey("boxX") == false)
            {
                this.transform.position = new Vector3(0, -1, 20);

            }
            else
            {
                tmp.x = PlayerPrefs.GetFloat("boxX");
                tmp.y = PlayerPrefs.GetFloat("boxY");
                tmp.z = PlayerPrefs.GetFloat("boxZ");
                this.transform.position = tmp;
            }
            timebool = false;
            timer = 0.0f;


        }

        
    }
    public void BoxPositionSave()
    {
        tmp = this.transform.position;
        PlayerPrefs.SetFloat("boxX", tmp.x);
        PlayerPrefs.SetFloat("boxY", tmp.y);
        PlayerPrefs.SetFloat("boxZ", tmp.z);
    }

}
