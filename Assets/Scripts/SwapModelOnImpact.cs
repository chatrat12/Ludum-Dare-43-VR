using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapModelOnImpact : MonoBehaviour
{
    public GameObject WholeModel;
    public GameObject DestructibleModel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTriggerEnter(new Collider());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;

        WholeModel.GetComponent<MeshRenderer>().enabled = false;
        
        var destructible = Instantiate(DestructibleModel);
        destructible.transform.position = WholeModel.transform.position;
        //destructible.transform.rotation = WholeModel.transform.rotation;
        //destructible.transform.localScale = WholeModel.transform.localScale;
    }


}
