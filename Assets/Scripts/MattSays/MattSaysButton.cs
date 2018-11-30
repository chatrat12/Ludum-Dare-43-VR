using UnityEngine;

// Messy game jam code xD
[RequireComponent(typeof(ButtonInput))]
public class MattSaysButton : MonoBehaviour
{
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }
    public bool Lit
    {
        get { return _lit; }
        set { _lit = value; }
    }
    public TonePlayer TonePlayer => _tonePlayer;
    public ButtonInput Input => _input;

    [SerializeField] private Color _color = Color.white;
    [SerializeField] private bool  _lit   = false;

    private Light      _light;
    private Material   _material;
    private TonePlayer _tonePlayer;
    private ButtonInput _input;

    private void Awake()
    {
        _material   = GetComponentInChildren<Renderer>().material;
        _light      = GetComponentInChildren<Light>();
        _tonePlayer = GetComponentInChildren<TonePlayer>();
        _input      = GetComponent<ButtonInput>();
    }

    private void Update()
    {
        UpdateProperties();
    }

    private void UpdateProperties()
    {
        _material.color = _color * 0.5f;
        _light.color = _color;
        _light.enabled = _lit;
        _material.SetColor("_EmissionColor", _color.gamma);
        if(_lit)
           _material.EnableKeyword("_EMISSION");
        else
            _material.DisableKeyword("_EMISSION");
        _tonePlayer.Playing = _lit;
    }
}
