using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRb : MonoBehaviour {

    public Rigidbody2D rb2D;
    public float runSpeed = 0.01f;
    public List<string> groundLayers = new List<string>();

    public bool canRun;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (canRun == false)
            return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddRelativeForce(Vector2.right * runSpeed, ForceMode2D.Impulse);
            canRun = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddRelativeForce(Vector2.left * runSpeed, ForceMode2D.Impulse);
            canRun = false;
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        foreach (string layer in groundLayers)
        {
            if (LayerMask.LayerToName(coll.gameObject.layer) == layer)
                canRun = true;
        }
    }

}
