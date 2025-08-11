using UnityEngine;
using UnityEngine.EventSystems;
public class DeselectOnClick : MonoBehaviour
{
    public void OnClick()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
