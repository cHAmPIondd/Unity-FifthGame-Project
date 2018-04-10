using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour {
    [SerializeField]
    private int m_CameraIndex;
    [SerializeField]
    private Behaviour[] m_OpenBehaviour;
    [SerializeField]
    private Collider[] m_CloseCollider;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.s_Instance.CameraIndex = m_CameraIndex;
            GameManager.s_Instance.SavePosition = transform.position;
            GetComponent<AudioSource>().Play();
            GameManager.s_Instance.FollowTask.MoveNext();
            foreach (var o in m_OpenBehaviour)
            {
                o.enabled = true;
            }
            foreach (var o in m_CloseCollider)
            {
                o.enabled = false;
            }
            GetComponent<Collider>().enabled = false;
        }
    }
}
