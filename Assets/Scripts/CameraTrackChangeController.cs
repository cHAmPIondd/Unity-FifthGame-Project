using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraTrackChangeController : MonoBehaviour {
    [SerializeField]
    private GameObject m_NextCinemachineVirtualCamera;
    private CinemachineTrackedDolly m_CinemachineTrackedDolly;
    void Start()
    {
        //获取组件
        m_CinemachineTrackedDolly = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();
    }
	
	void Update () {
        //判断此段轨道是否结束，结束则转换到下个轨道
        if (m_CinemachineTrackedDolly.m_PathPosition >= m_CinemachineTrackedDolly.m_Path.MaxPos + m_CinemachineTrackedDolly.m_AutoDolly.m_PositionOffset)
        {
            if (m_NextCinemachineVirtualCamera!=null)
                m_NextCinemachineVirtualCamera.SetActive(true);
        }
	}
}
