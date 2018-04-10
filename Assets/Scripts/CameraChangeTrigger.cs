using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraChangeTrigger : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera m_CinemachineVirtualCamera;
    [SerializeField]
    private float m_PositionOffset;
    [SerializeField]
    private float m_Time=3f;
    private CinemachineTrackedDolly m_CinemachineTrackedDolly;
    void Start()
    {
        m_CinemachineTrackedDolly = m_CinemachineVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            DOTween.To(()=>m_CinemachineTrackedDolly.m_AutoDolly.m_PositionOffset, x => m_CinemachineTrackedDolly.m_AutoDolly.m_PositionOffset = x, m_PositionOffset, m_Time);
        }
    }
}
