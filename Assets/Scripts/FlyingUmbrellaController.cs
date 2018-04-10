using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlyingUmbrellaController : MonoBehaviour {
    public Transform Carrier { private get; set; }
    [SerializeField]
    private Vector3 m_Offset;
    [SerializeField]
    private Vector3[] m_Path;
    [SerializeField]
    private float m_Time=5;
	// Use this for initialization
    public void Begin()
    {
        Carrier.GetComponent<Rigidbody>().isKinematic = true;
        Carrier.GetComponent<Collider>().enabled = false;
        Carrier.GetComponent<BallController>().enabled = false;
        Carrier.parent = transform;
        Carrier.localPosition = m_Offset;
        transform.position = m_Path[0];
        transform.DOPath(m_Path, m_Time).SetEase(Ease.Linear).onComplete = () => { Over(); };
    }
    public void Over()
    {
        Carrier.GetComponent<Rigidbody>().isKinematic = false;
        Carrier.GetComponent<Collider>().enabled = true;
        Carrier.GetComponent<BallController>().enabled = true;
        Carrier.parent = null;
        Destroy(gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + m_Offset,1);
        Gizmos.color = Color.blue;
        foreach(var v in m_Path)
        {
             Gizmos.DrawSphere(v,0.3f);
        }
    }
}
