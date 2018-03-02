﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;

public class enemyEagle : MonoBehaviour {

  Rigidbody2D rb2D;
public float speed;

  public float projRot;
  public float projSpeed;
  public float projDestroyTime;

  public bool isAttacking = false;

  GameObject playerAim;

void Awake ()
{
      rb2D = GetComponent<Rigidbody2D>();
}

	void Update () 
    {
    if (!isAttacking)
		Move();

      if (!isAttacking)
        CheckAttack();
      
      if (isAttacking)
        rb2D.velocity = Vector2.zero;


    

    }

    void Move ()
    {
    if (
      rb2D.velocity = transform.right * -speed;
    }

    void CheckAttack ()
    {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2 (-transform.right.x,-1) * 10);
        if (hit.collider != null) {
          Debug.DrawRay(transform.position, hit.collider.offset - (new Vector2 (-transform.right.x,-1) * hit.collider.transform.position.y), Color.red, 0.1f);
          if (hit.collider.gameObject.tag == "Player")
          {
              StartCoroutine(Attack(hit.collider.gameObject));
          }
    }else
    {
          Debug.DrawRay(transform.position, new Vector2 (-transform.right.x,-1) * 10, Color.red, 0.1f);
    }
    }

    IEnumerator Attack (GameObject player)
    {
    isAttacking = true;
    yield return new WaitForSeconds(1f);
      GameObject newProj = ProjectileManager.Instance.listEnemyProjectile[0];
      newProj.transform.position = transform.position;
      ProjectileManager.Instance.listEnemyProjectile.Remove(newProj);
      newProj.GetComponent<enemyProjectile>().isActive = true;
      newProj.transform.rotation = Quaternion.Euler(0,0,Vector3.Angle(transform.position, player.transform.position));
      newProj.GetComponent<enemyProjectile>().speed = projSpeed;
      newProj.GetComponent<enemyProjectile>().destroyTime = projDestroyTime;
      StartCoroutine(newProj.GetComponent<enemyProjectile>().AutoDisapear());
      yield return new WaitForSeconds(1f);
      isAttacking = false;
    }
}
