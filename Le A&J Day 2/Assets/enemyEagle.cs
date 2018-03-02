using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;

public class enemyEagle : MonoBehaviour {

Rigidbody2D rigidbody;
public float speed;

  public float projRot;
  public float projSpeed;
  public float projDestroyTime;

  Ray ray;

void Awake ()
{
     rigidbody = GetComponent<Rigidbody2D>();
}

	void Update () 
    {
		Move();

      RaycastHit hitPoint;
      ray.origin = transform.position + new Vector3 (0,0,0);
      ray.direction = transform.position - new Vector3 (50,50,0);
      Debug.DrawRay(new Vector3 (0,0,0), -new Vector3 (50,50,0), Color.green);
         if(Physics.Raycast(ray, out hitPoint, Mathf.Infinity))
         {
 
             if(Physics.Raycast(ray, out hitPoint, Mathf.Infinity) == GameObject.FindGameObjectWithTag("Player"))
             {
                 Debug.Log("Hit ground"); 
             }
             
             if(Physics.Raycast(ray, out hitPoint, Mathf.Infinity) == GameObject.FindGameObjectWithTag("ground"))
             {
                 Debug.Log("Hit object"); 
             }
         }
         else
         {
             Debug.Log ("No collider hit"); 
         }
	}

    void Move ()
    {
        rigidbody.velocity = new Vector2 (-speed, 0);
    }

    void Attack ()
    {
      GameObject newProj = ProjectileManager.Instance.listEnemyProjectile[0];
      ProjectileManager.Instance.listEnemyProjectile.Remove(newProj);
      newProj.GetComponent<enemyProjectile>().isActive = true;
      newProj.transform.rotation = Quaternion.Euler(0,0,projRot);
      newProj.GetComponent<enemyProjectile>().speed = projSpeed;
      newProj.GetComponent<enemyProjectile>().destroyTime = projDestroyTime;
    }
}
