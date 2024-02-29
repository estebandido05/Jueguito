using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerArrows : MonoBehaviour
{
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn() {
        transform.position = spawnPos.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Fondo")) return;
            transform.position = spawnPos.position;

    }
}

