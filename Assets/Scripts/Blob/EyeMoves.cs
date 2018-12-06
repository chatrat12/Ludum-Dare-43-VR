using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMoves : MonoBehaviour {
    public float EyeStateChangeFrequency = 0.002f;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if (Random.value < EyeStateChangeFrequency)
        {
            _anim.SetTrigger("DoEyeToggle");
        }
	}
}
