using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
    public GameObject enterNicknameWarning;
    
    public void StartGame()
    {
        if (NicknameData.Instance.nickname != "")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            enterNicknameWarning.SetActive(true);
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR        
            EditorApplication.ExitPlaymode();
        #else 
            Application.Quit();
        #endif
    }
}
