using System.Collections.Generic;
using UnityEngine.Rendering;
using System.Numerics;
using UnityEngine.UI;
using UnityEngine;
using System.IO;


public class NicknameData : MonoBehaviour
{
    public  string nickname;
    public static NicknameData Instance;
    public string bestScoreNickname;
    public int  bestScore;
    public List<Line> top;
    void Awake()
    {
        if (NicknameData.Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTop();
    }

    public void FillInNickname(string filledNickname)
    {
        nickname = filledNickname;
    }

    public void UpdateBestScore(int m_Points)
    {
        bestScore = m_Points;
        bestScoreNickname = nickname;
    }
    
    public void UpdateBestScoreText(Text bestScoreText)
    {
        bestScoreText.text = $"Best Score: {NicknameData.Instance.bestScoreNickname} :{NicknameData.Instance.bestScore}";
    }

    public void UpdateTop(int points)
    {
        if (top.Count == 0 || top[top.Count - 1].nickname != nickname)
            top.Add(new Line(nickname, points));
        else
            top[top.Count - 1].score = Mathf.Max(points, top[top.Count - 1].score);

        
        

        for (int i = 0; i < top.Count; i++)
        {
            Debug.Log(top[i].nickname + " : " + top[i].score);
        }
    }
    public void SaveTop()
    {
        SaveData data = new SaveData();
    
        data.top = top;
    
        var json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/TopData.json", json);
    }

    public void LoadTop()
    {
        var path = Application.persistentDataPath + "/TopData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data != null && data.top != null)
            {
                top = data.top;
                if (top.Count >= 1)
                {
                    Rank();
                    bestScoreNickname = top[0].nickname;
                    bestScore = top[0].score;
                }
            }
            
            else
                top = new List<Line>();
        }
    }

    public void Rank()
    { 
        top.Sort((a, b) => b.score.CompareTo(a.score));
    }
    [System.Serializable]
    public class Line
    {
        public string nickname;

        public int score;
        
        public Line(string name, int score)
        {
            this.nickname = name;
            this.score = score;
        }

    };

    [System.Serializable]
    public class SaveData
    {
        public List<Line> top;
    }
    public void DeleteAllSessions()
    {
        string folderPath = Application.persistentDataPath;

        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                File.Delete(file);
            }

        }

    }
}
