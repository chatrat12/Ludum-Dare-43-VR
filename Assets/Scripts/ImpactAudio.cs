using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ImpactAudio : MonoBehaviour
{
    [SerializeField] private float _threshold;
    [SerializeField] private AudioClip[] _clips;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > _threshold)
            PlayRandomClip();
    }

    private void PlayRandomClip()
    {
        if (_clips.Length > 0)
        {
            _source.clip = _clips[Random.Range(0, _clips.Length)];
            _source.Play();
        }
    }
}
