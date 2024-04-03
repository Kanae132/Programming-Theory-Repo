using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 30f;
    private float bound = 22f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
        ReturnOutOfBound();
    }

    private void BulletMove()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void ReturnOutOfBound()
    {
        if (transform.position.y > bound)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ReturnBullet(gameObject);
            }
        }
    }
}
