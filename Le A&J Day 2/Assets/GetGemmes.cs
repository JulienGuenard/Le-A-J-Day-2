using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGemmes : MonoBehaviour {

    public int Gemmes;
    public string gemmesLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.transform.gameObject.layer) == gemmesLayer)
        {
            Gemmes++;
            Destroy(other.transform.gameObject);
        }
    }

    void LoseGems()
    {
        Gemmes = 0;
    }

    void AddGems(int i)
    {
        Gemmes += i;
    }
}
