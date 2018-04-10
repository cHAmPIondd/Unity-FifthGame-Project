using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowPlayerInCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Offset = new Vector3(0f, 3.5f, 3f);
    [SerializeField]
    private Sprite[] m_Sprites;
    private Transform m_PlayerTransform;
    private Transform m_CameraTransform;
    [SerializeField]
    private SpriteRenderer m_CurrentSpriteRenderer;
    [SerializeField]
    private SpriteRenderer m_NextSpriteRenderer;
    [SerializeField]
    private float m_Height=1.3f;
    [SerializeField]
    private float m_Time=5;
    private int m_CurrentIndex;
    
    void Start()
    {
        m_PlayerTransform = GameManager.s_Instance.Player;
        m_CameraTransform = Camera.main.transform; 
    }
    void LateUpdate()
    {
        transform.position = m_PlayerTransform.position + m_CameraTransform.rotation * m_Offset;
    }
    /// <summary>
    /// 转换到下一个任务点
    /// </summary>
    public void MoveNext()
    {
        m_NextSpriteRenderer.material.color = Color.white;
        m_CurrentIndex++;
        m_NextSpriteRenderer.sprite = m_Sprites[m_CurrentIndex];

        //转换
        m_CurrentSpriteRenderer.transform.DOLocalMoveY(-m_Height, m_Time / 4).SetEase(Ease.Linear);
        m_NextSpriteRenderer.transform.DOLocalMoveY(0, m_Time / 4).SetEase(Ease.Linear);
        DOTween.To(() => m_NextSpriteRenderer.material.color, x => m_NextSpriteRenderer.material.color = x, Color.white, m_Time).SetEase(Ease.Linear);
        DOTween.To(() => m_CurrentSpriteRenderer.material.color, x => m_CurrentSpriteRenderer.material.color = x, Color.clear, m_Time).SetEase(Ease.Linear)
            .onComplete = () => 
            {
                //转换完成
                m_NextSpriteRenderer.transform.localPosition = new Vector3(0, m_Height, 0);
                m_CurrentSpriteRenderer.transform.localPosition = new Vector3(0, 0, 0);
                m_CurrentSpriteRenderer.material.color = Color.white;
                m_NextSpriteRenderer.material.color = Color.clear;
                m_CurrentSpriteRenderer.sprite = m_NextSpriteRenderer.sprite;
            };
    }
}
