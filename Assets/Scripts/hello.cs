using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hello : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPos;
    public float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        //player.transform.position = new Vector2(5, 2);
        player.transform.position = spawnPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
        /*if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }*/
    }

    private void FixedUpdate()
    {
        //Debug.Log("Ilan senpaiiiiiiii");
    }
}
