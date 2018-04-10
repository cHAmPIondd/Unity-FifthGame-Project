using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour {
    private Animator m_Animator;
    [SerializeField]
    private GameObject[] m_CloseObject;
    private AudioSource m_AudioSource;
    void Start()
    {
        m_Animator=GetComponent<Animator>();
        m_AudioSource=GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        m_Animator.SetTrigger("Open");
        m_AudioSource.Play();
        foreach (var e in m_CloseObject)
        {
            e.SetActive(false);
        }
        GetComponent<Collider>().enabled=false;
    }
}
