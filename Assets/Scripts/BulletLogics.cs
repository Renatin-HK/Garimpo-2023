using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogics : MonoBehaviour
{
    [SerializeField][Range(0.1f, 1)] float lifeTime;

    void Start()
    {
        DeleteGO();
    }

    void DeleteGO()
    {
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        Destroy(this.gameObject);

    }
}
