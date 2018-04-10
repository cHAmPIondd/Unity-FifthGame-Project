using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrigger : MonoBehaviour {
    [SerializeField]
    private FlyingUmbrellaController m_FlyingUmbrella;
    [SerializeField]
    private GameObject m_Effect;
    void OnTriggerEnter(Collider other)
    {
        m_FlyingUmbrella.Carrier = other.transform;
        m_FlyingUmbrella.Begin();
        GetComponent<Collider>().enabled = false;
        m_Effect.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
