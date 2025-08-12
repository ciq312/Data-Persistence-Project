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
            SceneManager.LoadScene(2);
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

    public void GoToTop()
    {
        SceneManager.LoadScene(1);
    }
}
