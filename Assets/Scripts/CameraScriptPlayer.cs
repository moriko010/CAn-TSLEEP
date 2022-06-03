using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptPlayer : MonoBehaviour
{
    public GameObject subCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0, 2.3f, -4);

    }
    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "xtag" || col.gameObject.tag == "ytag" || col.gameObject.tag == "ztag")
        {
            //this.gameObject.SetActive(false);
            subCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "xtag" || col.gameObject.tag == "ytag" || col.gameObject.tag == "ztag")
        {
            subCamera.gameObject.SetActive(false);
        }
    }*/
}
