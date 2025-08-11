using UnityEngine;

public class NicknameData : MonoBehaviour
{
    public  string nickname;
    public static NicknameData Instance;
    public string bestScoreNickname;
    public int  bestScore;
    void Awake()
    {
        if (NicknameData.Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FillInNickname(string filledNickname)
    {
        nickname = filledNickname;
    }

    public void UpdateBestScore(int m_Points)
    {
        bestScore = m_Points;
        bestScoreNickname = nickname;
        Debug.Log(bestScoreNickname + " : " + nickname);
    }
}
