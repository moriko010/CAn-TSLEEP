using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomDoor : MonoBehaviour
{
    int door;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        door = PlayerPrefs.GetInt("bedDoor");

        Debug.Log("Bed:" + door);
        if(door == 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(door == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
    }
}
