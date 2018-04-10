using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_WinText;
    [SerializeField]
    private float m_WinTextWaitTime = 2;
    [SerializeField]
    private GameObject m_RankingList;
    [SerializeField]
    private Text[] m_TextArray;
    [SerializeField]
    private Text m_CurrentTimeText;
    [SerializeField]
    private GameObject m_PreviousRankingList;
    void Start()
    {
        StartCoroutine(Win());
    }
    public IEnumerator Win()
    {
        GameManager.s_Instance.Player.GetComponent<BallController>().enabled = false;
        GameManager.s_Instance.Player.GetComponent<Rigidbody>().Sleep();
        //文本You Win
        m_WinText.SetActive(true);
        yield return new WaitForSeconds(m_WinTextWaitTime);
        m_WinText.SetActive(false);
        //排行榜
        m_RankingList.SetActive(true);
        
        //查询排名并插入时间排名
        var currentTime=GameManager.s_Instance.m_Timer;
        m_CurrentTimeText.text = currentTime.ToString();
        var currentIndex = 0;
        for (int i = 1; i <= 6; i++)
        {
            var t=PlayerPrefs.GetInt("TimeScore_"+i);
            if(t==0)
            {
                t = 9999;
            }
            //如果超过排名，插入
            if(currentTime<t)
            {
                for(int j=6;j>i;j--)
                {
                    var t_j=PlayerPrefs.GetInt("TimeScore_" + (j - 1));
                    PlayerPrefs.SetInt("TimeScore_" + j, t_j);
                    if(t_j!=0)
                        m_TextArray[j-1].text = t_j.ToString();
                    else
                        m_TextArray[j - 1].text = "N/A";
                }
                PlayerPrefs.SetInt("TimeScore_" + i, currentTime);
                currentIndex = i;
                m_TextArray[i-1].text = currentTime.ToString();
                break;
            }
            if(t!=9999)
                m_TextArray[i - 1].text = t.ToString();
            else
                m_TextArray[i - 1].text = "N/A";
        }
        
    }
    public void Reload()
    {
        SceneManager.LoadScene("CosmosPark");
    }
    public void ShowRankingList()
    {
        m_PreviousRankingList.SetActive(true);
    }
}
