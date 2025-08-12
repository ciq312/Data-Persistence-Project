using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankLine : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text nick;

    public void FillInLine(string nick, int score)
    {
        this.score.text = score.ToString();
        
        this.nick.text = nick;
    }
}
