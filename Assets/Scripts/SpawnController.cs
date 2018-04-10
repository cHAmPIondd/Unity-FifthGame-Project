using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField]
    private GameObject m_Prefab;
    [SerializeField]
    private float m_Time;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_Time);
            Instantiate(m_Prefab, transform);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
