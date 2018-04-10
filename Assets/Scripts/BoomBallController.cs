using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBallController : MonoBehaviour {
    [SerializeField]
    private float m_Force=10;
    [SerializeField]
    private GameObject m_BoomPrefab;
    [SerializeField]
    private float m_BoomTime = 2f;
    // Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * m_Force);
        StartCoroutine(Boom());
	}
	IEnumerator Boom()
    {
        yield return new WaitForSeconds(m_BoomTime);
        Instantiate(m_BoomPrefab).transform.position=transform.position;
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
