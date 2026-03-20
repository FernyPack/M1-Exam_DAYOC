using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;

    public float launchForce = 8f;
    public float controlForce = 5f;
    bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !launched)
        {
            Vector2 dir = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            );

            rb.AddForce(dir.normalized * launchForce, ForceMode2D.Impulse);
            launched = true;
        }
        if (launched)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(h, v);
            rb.AddForce(move * controlForce);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            GameManager.instance.LoseLife();
        }
    }
}