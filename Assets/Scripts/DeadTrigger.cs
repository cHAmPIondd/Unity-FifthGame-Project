using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour {
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(enabled&&other.tag=="Player")
        {
            StartCoroutine(other.GetComponent<BallController>().Dead());
            var d=GetComponent<destroyMe>();
            if (d!=null)
                d.enabled=false;
        }
    }
}
