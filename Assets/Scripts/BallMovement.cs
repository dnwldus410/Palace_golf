using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallMovement : MonoBehaviour
{
    private Handforce Handf;
    public float speed = 0.5f;
    public float jump = 5f;
    public GameObject convers;
    private Rigidbody ballrb;
    public bool ballmove;
    private WinController Winct;



    // Start is called before the first frame update

    void Start() {
        
        if ((PlayerPrefs.HasKey("Xball")))
        {
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("Xball"), 0.5f, PlayerPrefs.GetFloat("Zball"));
            gameObject.transform.rotation= Quaternion.Euler(new Vector3(0,0,0));
        }
            Handf = FindObjectOfType<Handforce>();
        ballrb = GetComponent<Rigidbody>();
        Winct = FindObjectOfType<WinController>();
        // ballstart = (int)gameObject.transform.rotation.x;
        ballmove = false;

    }
    private void Update()
    {

        if (Handf.finish == true&&!ballmove)
        {
            if (!ballmove)
            {
                Winct.Loosing();
            }
            Handf.finish = false;
            
        }
    }
 
    public void Playball(float force)
    {
        Handf.finish = true;
        Handf.touch = true;

         ballrb.AddForce(0, force*jump, force * speed);
        //ballrb.AddForce( transform.forward * force*speed);

        convers.gameObject.SetActive(false);
    }
    /*   private IEnumerator restart()
       {

           yield return new WaitForSeconds(1.5f);
              if (!ballmove)
               {
                   Winct.StartCoroutine(Losing());
               }

       }*/
}
