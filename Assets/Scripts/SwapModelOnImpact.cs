using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapModelOnImpact : MonoBehaviour {
    public GameObject DestructibleModel;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().enabled = false;

        Instantiate(DestructibleModel, transform);
    }


}
