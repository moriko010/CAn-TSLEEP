using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(0, 1.5f, -0.66f);
        this.transform.localRotation = Quaternion.Euler(10, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
