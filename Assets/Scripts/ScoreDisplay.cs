using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private float _prevScore;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _prevScore = PlayerScore.Score;
        UpdateText();
    }


    private void Update()
    {
        if (PlayerScore.Score != _prevScore)
        {
            _prevScore = PlayerScore.Score;
            UpdateText();
        }
    }

    private void UpdateText()
        => _textMesh.text = string.Format("Score: {0}", PlayerScore.Score);
}
