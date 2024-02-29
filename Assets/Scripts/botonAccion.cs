using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class botonAccion : MonoBehaviour
{
    public KeyCode tecla;
    public BoxCollider2D tigger;
    public float tecla_presionada = 0.1f;
    public float currentTime;
    public float distanciaEntreObjs;
    bool hitSmth;
    public GameObject good, perfect, nearMissed, missed;
    public scoreManager puntitos;
    public AK.Wwise.Switch _perfect, _good, _nearMissed, _missed;
    public AK.Wwise.Event Play_Timings;

    IEnumerator MensajesEstado(GameObject x)
    {
        x.SetActive(true);
        yield return new WaitForSeconds(2f);
        x.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        tigger = GetComponent<BoxCollider2D>();
        currentTime = tecla_presionada;
        tigger.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
            //boton_presionado(tecla, tigger, currentTime);
        if (Input.GetKeyDown(tecla))
        {
            tigger.enabled = true;
            currentTime = 0;
        }

        if (!tigger.enabled) return;

        currentTime += Time.deltaTime;
        if (currentTime >= tecla_presionada)
        {
            tigger.enabled = false;
            if (hitSmth) hitSmth = false;
            else
            {
                //Debug.Log("Missed");
                puntitos.resetCombo();
                puntitos.addFailure();
                _missed.SetValue(this.gameObject);
               StartCoroutine(MensajesEstado(missed));
                Play_Timings.Post(this.gameObject);
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!tigger.enabled) return;

        distanciaEntreObjs = collision.gameObject.transform.position.y - this.gameObject.transform.position.y;
        
        if (distanciaEntreObjs < 0.3f)
        {
            //Debug.Log("PERFECT!!");
            puntitos.resetFailure();
            puntitos.addScore(100);
            _perfect.SetValue(this.gameObject);
            Play_Timings.Post(this.gameObject);
            
            StartCoroutine(MensajesEstado(perfect));

        }
        else if (distanciaEntreObjs <= 0.6f)
        {
            //Debug.Log("GOOD");
            puntitos.resetFailure();
            puntitos.addScore(50);
            _good.SetValue(this.gameObject);
            StartCoroutine(MensajesEstado(good));
            Play_Timings.Post(this.gameObject);

        }
        else if (distanciaEntreObjs <= 1)
        {
            //Debug.Log("Near Miss");
            puntitos.resetFailure();
            puntitos.addScore(10);
            _nearMissed.SetValue(this.gameObject);
            StartCoroutine(MensajesEstado(nearMissed));
            Play_Timings.Post(this.gameObject);
        }
        hitSmth = true;
        collision.gameObject.GetComponent<spawnerArrows>().Respawn();
        //Debug.Log(collision.gameObject.name);
        
    }

}

