using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour {

  public List<GameObject> listGem;
    public static GemManager Instance;

    // Use this for initialization
    void Awake () {
        Instance = this;

        listGem.AddRange(GameObject.FindGameObjectsWithTag("gem"));
    }
}
