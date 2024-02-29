using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSpot : MonoBehaviour
{
    public GameObject boton;
    public float dist_entre_objts;
    public GameObject Boton_presionado;
    // Start is called before the first frame update
    void Start()
    {
        //boton = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dist_entre_objts = collision.transform.position.y - boton.transform.position.y;
    }
}
