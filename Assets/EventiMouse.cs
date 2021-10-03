using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventiMouse : MonoBehaviour {

    void Start(){ }
    void Update() { }
    /*    // Al passaggio del mouse rendo l'oggetto trasparente
    void OnMouseOver() {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 1F;
        GetComponent<Renderer>().material.color = color;
    }
    void OnMouseExit() {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 0.5F;
        GetComponent<Renderer>().material.color = color;
    }*/

    [SerializeField] private Animator myAnimationController;

    
    void OnMouseDown() {

    	bool attuale = myAnimationController.GetBool("PlaySpostamento");
    	attuale = !attuale;
    	myAnimationController.SetBool("PlaySpostamento", attuale);


    	// Al click del mouse cambio il colore
        /*Color color = GetComponent<Renderer>().material.color;
        color.r = Random.value;
        color.g = Random.value;
        color.b = Random.value;
        color.a = 1f;
        GetComponent<Renderer>().material.color = color;*/
    }

}
