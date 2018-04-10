using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveFloorController : MonoBehaviour {
    [SerializeField]
    private Vector3[] m_Path;
    [SerializeField]
    private float m_Time=5;
    private AudioSource m_AudioSource;
	// Use this for initialization
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play(); 
        transform.DOPath(m_Path, m_Time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).onStepComplete = () => { m_AudioSource.Play(); }; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        foreach (var v in m_Path)
        {
            Gizmos.DrawSphere(v, 0.3f);
        }
    }
}
