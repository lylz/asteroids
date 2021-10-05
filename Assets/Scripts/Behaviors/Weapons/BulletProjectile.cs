using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public float Speed;
    public float Lifetime;
    public Vector3 Direction;

    private void Start()
    {
        StartCoroutine("DestroyAfterLifetimeEnds");
    }

    private void FixedUpdate()
    {
        transform.position += Direction * Speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterLifetimeEnds()
    {
        yield return new WaitForSeconds(Lifetime);

        Destroy(gameObject);
    }
}
