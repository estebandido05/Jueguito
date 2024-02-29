using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptTimer : MonoBehaviour
{
    public int counter;
    public float segundos, minutos;
    public TextMeshProUGUI cronometro;

    // Start is called before the first frame update
    void Start()
    {
        counter = 60;
        segundos = 0;
        minutos = 0;
    }

    // Update is called once per frame  
    void Update()
    {
        segundos += Time.deltaTime;

        if (segundos >= 60)
        {
            segundos -= 60;
            minutos++;
        }
        cronometro.text = $"{minutos} : {segundos.ToString("0")}";
       // Debug.Log(minutos);
    }
}
