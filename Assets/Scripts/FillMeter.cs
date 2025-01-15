using UnityEngine;
using UnityEngine.UI;

public class FillMeter : MonoBehaviour {
    private Image img;
    public void SetFillAmount(float fill_amount) {
        img.fillAmount = fill_amount;
    }
    void Start() {
        img = GetComponent<Image>();
    }
}