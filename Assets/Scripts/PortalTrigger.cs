using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {
    [SerializeField]
    private Vector3 m_ExitPosition;
    [SerializeField]
    private float m_Time=2f;
    private AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource=GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transfer(other.gameObject));
    }
    IEnumerator Transfer(GameObject go)
    {
        m_AudioSource.Play();
        go.GetComponent<BallController>().SetActiveFalse();
        yield return new WaitForSeconds(m_Time);
        go.transform.position = m_ExitPosition;
        go.GetComponent<BallController>().SetActiveTrue();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(m_ExitPosition, 1);
    }
}
