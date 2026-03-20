using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}