using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public GameObject Wincv;
    public Text wintext;
    public GameObject againcv;
    public Text againtext;
    public GameObject Overcv;
    public Text lostext;
    public bool opencv;
    public GameObject ball;
    private Handforce Handf;
    private float xball;
    private float yball;
    private float zball;
    // Start is called before the first frame update
    void Start()
    {
        Handf = FindObjectOfType<Handforce>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Handf.finish == true && Handf.touch == true)
        {
            StartCoroutine(Losing());
        }
        
         
        

    }
    void OnCollisionStay(Collision col)
    {

        if (col.collider.tag == "Ball") {
            StartCoroutine(Win());

    }
    }
    private IEnumerator Win()
    {
  
        yield return new WaitForSeconds(0.5f);
        if (!opencv)
        {
            opencv = true;
            Wincv.SetActive(true);
            wintext.text = "격방(격구게임 중 구멍에 넣는 게임) 성공!";
        }
    }
    public void Loosing()
    {
        if (ball.transform.position.z < gameObject.transform.position.z && !opencv)
        {
            if (!(PlayerPrefs.HasKey("Xball")))
            {

                xball = ball.transform.position.x;
                zball = ball.transform.position.z;
                PlayerPrefs.SetFloat("Xball", xball);
                PlayerPrefs.SetFloat("Zball", zball);
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                againcv.SetActive(true);
                againtext.text = "한번더!";
                opencv = true;
            }

        }
        if (ball.transform.position.z < gameObject.transform.position.z && !opencv)
        {
            if ((PlayerPrefs.HasKey("Xball")))
            {
               
                Overcv.SetActive(true);
                lostext.text = "실패!";
                opencv = true;
            }
        }
    }
    public IEnumerator Losing()
    {
        if (ball.transform.position.z > gameObject.transform.position.z + 1f && !opencv)
        {
          
                yield return new WaitForSeconds(0.5f);
                Overcv.SetActive(true);
                lostext.text = "실패!";
                opencv = true;
            
        }
        

        yield return new WaitForSeconds(10f);
        if (ball.transform.position.z < gameObject.transform.position.z && !opencv)
        {
            if (!(PlayerPrefs.HasKey("Xball")))
            {
              
                xball = ball.transform.position.x;
                zball = ball.transform.position.z;
                PlayerPrefs.SetFloat("Xball", xball);
                PlayerPrefs.SetFloat("Zball", zball);
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                againcv.SetActive(true);
                againtext.text = "한번더!";
                opencv = true;
            }
       
        }
        if (ball.transform.position.z < gameObject.transform.position.z && !opencv)
        { 
            if ((PlayerPrefs.HasKey("Xball")))
            {
                yield return new WaitForSeconds(0.5f);
                Overcv.SetActive(true);
                lostext.text = "실패!";
                opencv = true;
            }
        }



    }
}
