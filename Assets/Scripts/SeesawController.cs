using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeesawController : MonoBehaviour {

    [SerializeField]
    private Vector3 m_Target = new Vector3(0, -90f, 0);
    [SerializeField]
    private float m_Time = 5;
    private AudioSource m_AudioSource;
    // Use this for initialization
    void Start()
    {
        m_AudioSource=GetComponent<AudioSource>();
        transform.DORotate(m_Target, m_Time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).onStepComplete = () => { m_AudioSource.Play(); };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
