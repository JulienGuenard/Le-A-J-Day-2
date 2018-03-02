using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ProjectileManager : MonoBehaviour {

    public List<GameObject> listEnemyProjectile;
    public static ProjectileManager Instance;

	// Use this for initialization
	void Awake () {
		Instance = this;

        listEnemyProjectile.AddRange(GameObject.FindGameObjectsWithTag("enemyProjecile"));
	}
}
