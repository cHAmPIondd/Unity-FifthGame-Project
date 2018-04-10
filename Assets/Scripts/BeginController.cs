using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginController : MonoBehaviour {
    [SerializeField]
    private float m_WaitTime=0.5f;
    [SerializeField]
    private Sprite[] m_Sprites;
    [SerializeField]
    private Animator m_BeginAnimator;
    [SerializeField]
    private AudioSource m_AudioSource_321;
    [SerializeField]
    private AudioSource m_AudioSource_Go;
    private Image m_Image;
	// Use this for initialization
	void Start () {
	}

    public IEnumerator Begin()
    {
        //开始倒计时
        m_Image = GetComponent<Image>();
        gameObject.SetActive(true);
        m_Image.sprite = m_Sprites[0];
        m_AudioSource_321.Play();
        yield return new WaitForSeconds(m_WaitTime);
        m_Image.sprite = m_Sprites[1];
        m_AudioSource_321.Play();
        yield return new WaitForSeconds(m_WaitTime);
        m_Image.sprite = m_Sprites[2];
        m_AudioSource_321.Play();
        yield return new WaitForSeconds(m_WaitTime);
        m_AudioSource_Go.Play();
        m_Image.sprite = m_Sprites[3];
        //开门
        m_BeginAnimator.SetTrigger("Open");
        //开跑
        GameManager.s_Instance.Player.GetComponent<BallController>().enabled = true;
        yield return new WaitForSeconds(m_WaitTime/2);
        //关闭提示
        gameObject.SetActive(false);
    }
}
