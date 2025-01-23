using UnityEngine;
using UnityEngine.EventSystems;
public class S1Button : MonoBehaviour {
    public void ResetButton() {
        EventSystem.current.SetSelectedGameObject(null);
    }
}