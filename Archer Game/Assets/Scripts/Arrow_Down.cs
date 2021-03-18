using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Down : MonoBehaviour
{
    public Rigidbody2D rb;
    public int arrowCount = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            if (collision.gameObject.CompareTag("XWall"))
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.left);
                float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
                rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            }
            else
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.down);
                float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
                rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            }
            arrowCount--;
            if (arrowCount <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
