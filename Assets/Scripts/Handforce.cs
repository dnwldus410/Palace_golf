using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class Handforce : MonoBehaviour
{
    public Slider forceSlider;
    public LineRenderer ballLine;
    private float nowforce;
    protected float Minforce = 10f;
    protected float Maxforce = 100f;
    public bool touch;
    public bool finish;
    Vector3 s_rotation;
    protected HammerController Hammerct;
    public GameObject stick;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()

    {
      Hammerct = FindObjectOfType<HammerController>();
        s_rotation = stick.transform.eulerAngles;
        
        touch = false;
        finish = false;
      
        forceSlider.gameObject.SetActive(true);
        forceSlider.maxValue = Maxforce;
        //forceSlider.value = Maxforce;

        ballLine.positionCount = 2;
        ballLine.enabled = false;
        

    }

    void Update()
    {
   
      
        
    }
    private void OnMouseDrag()
    {
       
        if (!touch)
        {
            ballLine.enabled = true;
            ballLine.SetPosition(0, ball.transform.position);
            if (Minforce <= Maxforce)
            {
                
                Minforce += Minforce * Time.deltaTime;
            forceSlider.value = Minforce;
               

                //  stick.transform.Rotate(Minforce * Time.deltaTime, 0, 0);
                stick.transform.rotation = new Quaternion();
                s_rotation += new Vector3(Minforce * Time.deltaTime, 0, 0);
                stick.transform.rotation = Quaternion.Euler(s_rotation);
                nowforce = Minforce;
                Hammerct.ballready(Minforce);

            }
            ballLine.SetPosition(1, new Vector3(0,0,Minforce*0.4f));
        }
    }
    private void OnMouseUp()
    {
        if (!touch)
        {
            ballLine.enabled = false;
            StartCoroutine(Hammermove());
        }

    }

        private IEnumerator Hammermove()
        {



        
            while (nowforce >= 0.1)
            {
                stick.transform.rotation = new Quaternion();
                s_rotation += new Vector3(-nowforce * Time.deltaTime, 0, 0);
                stick.transform.rotation = Quaternion.Euler(s_rotation);
                nowforce -= 10f * Time.deltaTime;
            yield return new WaitForSeconds(0.003f);
           
            }
        
        
            finish = true;

        }
        
    }

