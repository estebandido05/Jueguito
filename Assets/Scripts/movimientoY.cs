using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoY : MonoBehaviour
{
    //public float movementY;
    public float beatTempo = 120;
    public float speed;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = 95;
        transform.position = spawnPos.position;
        speed = beatTempo / 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
