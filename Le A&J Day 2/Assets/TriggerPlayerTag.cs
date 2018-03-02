using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TriggerPlayerTag : MonoBehaviour {

    public string oldPlayerLayer;
    public string newPlayerLayer;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (LayerMask.LayerToName(other.transform.gameObject.layer) == oldPlayerLayer)
        {
            other.transform.gameObject.layer = LayerMask.NameToLayer(newPlayerLayer);
        }
    }

}
