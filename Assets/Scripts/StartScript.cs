using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main1");
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Main1");
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }


}
