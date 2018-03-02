using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public GetGemmes gem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ennemi")
        {

        }
    }
}
