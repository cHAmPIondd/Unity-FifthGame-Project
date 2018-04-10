using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateFloorController : MonoBehaviour {

    [SerializeField]
    private Vector3 m_Target = new Vector3(0, -90f, 0);
    [SerializeField]
    private float m_Time = 5;
    // Use this for initialization
    void Start()
    {
        transform.DORotate(m_Target, m_Time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
