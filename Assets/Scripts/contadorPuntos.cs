using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contadorPuntos : MonoBehaviour
{
    public bool canBePressed;
    public GameObject botones;
    private KeyCode pressed;
    public int puntaje_jugador;
    // Start is called before the first frame update
    void Start()
    {
        pressed = botones.GetComponent<botonAccion>().tecla;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canBePressed)
            {
                puntaje_jugador++;
                Debug.Log(puntaje_jugador);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "trigger")
        {
            canBePressed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "trigger")
        {
            canBePressed = false;
        }
    }
}
