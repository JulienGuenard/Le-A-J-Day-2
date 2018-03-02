using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRb : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public float runSpeed = 0.01f;
    public float speedLimit = 150f;
    public List<string> groundLayers = new List<string>();
    public float distToGround;
    public float jumpForce;

    public bool canRun;
    public bool hasJumped;

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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2D.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb2D.velocity.magnitude > speedLimit)
        {
            rb2D.velocity = rb2D.velocity.normalized * speedLimit;
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        foreach (string layer in groundLayers)
        {
            if (LayerMask.LayerToName(coll.gameObject.layer) == layer)
                canRun = true;
        }
        if(coll.gameObject.tag == "Ennemi" && !hasJumped)
        {
            gameObject.SendMessage("LoseGems");
        }
        else if(coll.gameObject.tag == "Ennemi" && hasJumped)
        {
            Destroy(coll.gameObject);
            gameObject.SendMessage("AddGems", 1);
        }
    }

    bool IsGrounded()
    {
        hasJumped = false;
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround);
    }

}
