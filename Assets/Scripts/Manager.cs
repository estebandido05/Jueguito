using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public float numeroCuentaRegresiva;
    public GameObject mensaje;
    public TextMeshProUGUI mensajeCuenta;
    private bool _seguro;

    // Start is called before the first frame update
    void Start()
    {
        _seguro = false;
        numeroCuentaRegresiva = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (numeroCuentaRegresiva > 0)
        {
            numeroCuentaRegresiva = numeroCuentaRegresiva - Time.deltaTime;
            mensajeCuenta.text = $"{numeroCuentaRegresiva.ToString("0")}";
        }
        else if (!_seguro)
        {
            mensajeCuenta.text = "START!!";
            _seguro = true;
            Invoke("DisableText", 1);
        }
    }

    void DisableText()
    {
        mensaje.SetActive(false);
    }
}
