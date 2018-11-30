using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TonePlayer : MonoBehaviour
{
    private const float SAMPLE_RATE            = 44100;
    private const float WAVE_LENGTH_IN_SECONDS = 2;

    public float Frequency
    {
        get { return _frequency; }
        set { _frequency = value; }
    }

    [SerializeField] private float _frequency = 400;

    AudioSource _source;
    int _timeIndex = 0;

    public bool Playing
    {
        get { return _playing; }
        set
        {
            _playing = value;
            if (_source.isPlaying && !value)
                _source.Stop();
            else if (!_source.isPlaying && value)
            {
                _timeIndex = 0;
                _source.Play();
            }
        }
    }

    private bool _playing = false;

    private void Awake()
    {
        _source = gameObject.AddComponent<AudioSource>();
        _source.playOnAwake = false;
        _source.Stop();
    }


    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(_timeIndex, _frequency, SAMPLE_RATE);

            if (channels == 2)
                data[i + 1] = CreateSine(_timeIndex, _frequency, SAMPLE_RATE);

            _timeIndex++;

            //if timeIndex gets too big, reset it to 0
            if (_timeIndex >= (SAMPLE_RATE * WAVE_LENGTH_IN_SECONDS))
                _timeIndex = 0;
        }
    }

    public float CreateSine(int timeIndex, float frequency, float sampleRate)
        => Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
}
