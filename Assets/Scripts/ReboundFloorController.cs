using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ReboundFloorController : MonoBehaviour {
    [SerializeField]
    private float m_OffsetY = -1f;
    [SerializeField]
    private float m_Time = 1f;
    private AudioSource m_AudioSource;
    private float m_InitialY;
    void Start()
    {
        m_AudioSource=GetComponent<AudioSource>();
        m_InitialY = transform.position.y;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_AudioSource.Play();
            transform.DOMoveY(m_InitialY + m_OffsetY, m_Time).SetEase(Ease.OutBounce);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.DOMoveY(m_InitialY, m_Time).SetEase(Ease.OutBounce);
        }
    }
}