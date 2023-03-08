using TMPro;
using UnityEngine;

public class BaseViewBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Transform _bar;
    
    public void UpdateText(float time)
    {
        _textMesh.text = time.ToString("0.00");
    }

    public void UpdateBar(float lerp)
    {
        _bar.localScale = new Vector3(1 - lerp, 1f, 1f);
    }
}
