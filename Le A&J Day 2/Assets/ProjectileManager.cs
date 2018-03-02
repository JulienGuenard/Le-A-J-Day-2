using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

    public List<GameObject> listEnemyProjectile;
    public static ProjectileManager Instance;

	// Use this for initialization
	void Awake () {
		Instance = this;

        Debug.Log("a");
        listEnemyProjectile.AddRange(GameObject.FindGameObjectsWithTag("enemyProjectile"));
	}
}
