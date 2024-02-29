using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AK.Wwise.RTPC estadoPublico;
    public float estadoAnimo;

    //public AK.Wwise.Event Drms;
    // Start is called before the first frame update
    void Start()
    {
        estadoPublico.SetGlobalValue(60f);
        AkSoundEngine.PostEvent("Play_Publico", this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
