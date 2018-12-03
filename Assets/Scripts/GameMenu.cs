using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public bool Visible => _retryBall.gameObject.activeInHierarchy;

    [SerializeField] private MenuBall _retryBall;
    [SerializeField] private MenuBall _quitBall;

    private bool _canClose = true;
    private List<ParticleSystem> _particles = new List<ParticleSystem>();


    private void Start()
    {
        _retryBall.Activated += (sender) =>
        {
            PlayerScore.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        };

        _quitBall.Activated += (sender) =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        };
        Hide();

        _particles.AddRange(_retryBall.GetComponentsInChildren<ParticleSystem>());
        _particles.AddRange(_quitBall.GetComponentsInChildren<ParticleSystem>());

        foreach (var ps in _particles)
        {
            var main = ps.main;
            main.useUnscaledTime = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
            Toggle();
    }

    private void Toggle()
    {
        if (Visible && !_canClose)
            return;
        SetVisibility(!Visible);
    }

    public void Show() => SetVisibility(true);
    public void Hide() => SetVisibility(false);

    private void SetVisibility(bool visible)
    {
        //Time.timeScale = visible ? 0 : 1;
        _retryBall.gameObject.SetActive(visible);
        _quitBall.gameObject.SetActive(visible);
    }
}
