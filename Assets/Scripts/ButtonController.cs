using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject stick;
    public GameObject ball;
    private float movement=0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OkBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
        
    }
    public void StartBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
        
    }
    public void AgainBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void DownBtn()
    {
        if (stick.transform.position.z > -3)
        {
            stick.transform.Translate(0, 0, -movement);
        }
    }
    public void UpBtn()
    {
        if (stick.transform.position.z < ball.transform.position.z-1.5f)
        {
            stick.transform.Translate(0, 0, movement);
        }
    }
    public void LeftBtn()
    {
        if (stick.transform.position.x > -5)
        {
            stick.transform.Translate(-movement, 0, 0);
        }
    }
    public void RightBtn()
    {
        if (stick.transform.position.x < 5)
        {
            stick.transform.Translate(movement, 0, 0);
        }
    }
}
