using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayerControle : MonoBehaviour
{
    public GameObject Joueur;
    public bool running;
    public float horizontalmove;
    public float verticalmove;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && running)
        {
            Joueur.GetCompoent<Animation>().Play("Run");
            horizontalmove = Input.GetAxis("Horizontal") * Time.deltaTime * 100;
            verticalmove= Input.GetAxis("Vertical") * Time.deltaTime * 100;
            transform.Rotate(0,horizontalmove,0);
            transform.Translate(0,0,verticalmove);
        }
        else   
        
        {
            if (!running)
            {
                Joueur.GetCompoent<Animation>().Play("Walk");
                horizontalmove = Input.GetAxis("Horizontal") * Time.deltaTime * 100;
                verticalmove= Input.GetAxis("Vertical") * Time.deltaTime * 100;
            }
            Joueur.GetCompoent<Animation>().Play("Idle");
            running= false;
          
        } 
        
    }
}
