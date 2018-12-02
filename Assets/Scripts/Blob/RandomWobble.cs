using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWobble : MonoBehaviour {
    public float WobbleFrequency = 0.01f;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    
	// Update is called once per frame
	void Update () {
		if (Random.value < WobbleFrequency)
        {
            _anim.SetTrigger("DoWobble01");
        }
	}
}
