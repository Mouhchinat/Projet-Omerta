using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;
public class PlayerControle : MonoBehaviour
{
    public GameObject Joueur;
    public bool running;
    public float horizontalmove;
    public float verticalmove;
    // Update is called once per frame


 

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") )
        {
            Joueur.GetComponent<Animation>().Play("Run");
            horizontalmove = Input.GetAxis("Horizontal") * Time.deltaTime * 100;
            verticalmove= Input.GetAxis("Vertical") * Time.deltaTime * 8;
            running = true;
            transform.Rotate(0,horizontalmove,0);
            transform.Translate(0,0,verticalmove);
        }
        else

        {
            Joueur.GetComponent<Animation>().Play("Idle");
            running= false;
          
        } 
        
    }
}
