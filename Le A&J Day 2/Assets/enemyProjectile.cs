using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enemyProjectile : MonoBehaviour {

public float speed;
public float destroyTime;
public bool isActive = false;

  Rigidbody2D rb2D;

void Awake ()
{
      rb2D = GetComponent<Rigidbody2D>();
}

void Update ()
{
if (isActive)
{
   Move();
   }
}

	void OnTriggerStay2D (Collider2D col)
    {
       if (col.tag == "Player")
       {
          transform.position = new Vector2(999,999);
          ProjectileManager.Instance.listEnemyProjectile.Add(gameObject);
          isActive = false;
       }
    }

    void Move ()
    {
      rb2D.velocity = transform.right * -speed;
    }

    public IEnumerator AutoDisapear ()
    {
       yield return new WaitForSeconds(destroyTime);
      transform.position = new Vector2(999,999);
      ProjectileManager.Instance.listEnemyProjectile.Add(gameObject);
       isActive = false;

    }
}
