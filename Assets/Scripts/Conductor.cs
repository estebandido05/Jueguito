using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Conductor : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private Intervals[] _intervals;
   [SerializeField] AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Intervals interval in _intervals)
        {
            float sampleTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLenght(bpm)));
            interval.CheckForNewInterval(sampleTime);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;

    public float GetIntervalLenght(float bpm) // Nos da cuentos segundos estan
    {
        return 60 / (bpm * steps); 
    }

    public void CheckForNewInterval (float interval)
    {
        if(Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }   
    }
}