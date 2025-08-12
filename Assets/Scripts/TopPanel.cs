using UnityEngine;

public class TopPanel : MonoBehaviour
{
    public GameObject linePrefab;
    void Awake()
    {
        MakeRankList();
    }

    private void MakeRankList()
    {
        NicknameData.Instance.Rank();
        foreach (var rankLine in NicknameData.Instance.top)
        {
            var line = Instantiate(linePrefab, gameObject.transform);

            line.GetComponent<RankLine>().FillInLine(rankLine.nickname, rankLine.score);
        }
    }
}
