using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager s_Instance;

    public Transform Player;
    public FollowPlayerInCamera FollowTask;
    [SerializeField]
    private GameObject m_StartGraph;
    [SerializeField]
    private GameObject m_StartUI;
    [SerializeField]
    private BeginController m_BeginController;
    [SerializeField]
    private GameObject m_WinController;
    [SerializeField]
    private Text m_TimeText;
    [SerializeField]
    private GameObject m_PauseUI;
    [SerializeField]
    private AudioSource m_BGM;

    public int CameraIndex { get; set; }
    public Vector3 SavePosition { get; set; }
    public bool IsBegin { private get; set; }
    public bool IsWin { private get; set; }
    public bool IsPause { private get; set; }

    public int m_Timer { get; set; }
    // Use this for initialization
    void Awake()
    {
        s_Instance = this;
        CameraIndex = 0;
        SavePosition = Player.position;
        StartCoroutine(Begin());
    }
    void Update()
    {
        if (IsBegin && !IsWin)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !IsPause)
            {
                IsPause = true;
                m_PauseUI.SetActive(true);
                m_BGM.Pause();
                Time.timeScale = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && IsPause)
            {
                IsPause = false;
                m_PauseUI.SetActive(false);
                m_BGM.UnPause();
                Time.timeScale = 1;
            }
        }
    }
    IEnumerator Begin()
    {
        //判断是否开始游戏
        while (true)
        {
            if (Input.anyKey)
            {
                m_StartGraph.SetActive(false);
                m_StartUI.SetActive(false);
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(2f);
        //开始游戏
        yield return StartCoroutine(m_BeginController.Begin());
        
        //判断是否胜利
        m_Timer = 0;
        IsBegin = true;
        while (!IsWin)
        {
            m_Timer += 1;
            m_TimeText.text = m_Timer.ToString();
            yield return new WaitForSeconds(1);
        }
        //胜利
        m_WinController.SetActive(true);
    }
}
