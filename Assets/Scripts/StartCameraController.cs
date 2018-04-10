using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartCameraController : MonoBehaviour {

    [SerializeField]
    private Vector3[] m_Path;
    [SerializeField]
    private float m_Time = 5;
    // Use this for initialization
    void Start()
    {
        transform.DOPath(m_Path, m_Time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

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
