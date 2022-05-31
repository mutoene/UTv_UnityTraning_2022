using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10;
    
    void Start()
    {
        StartCoroutine(DestroyAfterSomeMin());
    }

    // 一定時間後に除去
    IEnumerator DestroyAfterSomeMin()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(this.gameObject);
    }
}
