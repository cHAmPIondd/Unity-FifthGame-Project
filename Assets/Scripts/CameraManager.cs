using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public static CameraManager s_Instance;
    [SerializeField]
    public GameObject[] CameraArray;
	// Use this for initialization
	void Awake () {
        s_Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
