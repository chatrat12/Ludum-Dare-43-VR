using TMPro;
using UnityEngine;

public class CasualtiesDisplay : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private float _prevCasualties;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _prevCasualties = PlayerScore.Score;
        UpdateText();
    }


    private void Update()
    {
        if (PlayerScore.Score != _prevCasualties)
        {
            _prevCasualties = PlayerScore.Casualties;
            UpdateText();
        }
    }

    private void UpdateText()
        => _textMesh.text = string.Format("Casualties: {0}", PlayerScore.Casualties);
}
