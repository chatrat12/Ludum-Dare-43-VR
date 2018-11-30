using TMPro;
using UnityEngine;

public class UIScoreDisplay : MonoBehaviour
{
    [SerializeField] private MattSaysGame _game;

    private TextMeshPro _textMesh;
    private int _prevScore = 0;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
        _prevScore = _game.Score;
        UpdateText();
    }


    private void Update()
    {
        if(_game.Score != _prevScore)
        {
            _prevScore = _game.Score;
            UpdateText();
        }
    }

    private void UpdateText()
        => _textMesh.text = string.Format("Score: {0}", _game.Score);
}
