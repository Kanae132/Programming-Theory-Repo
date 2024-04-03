using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameManager gameManager;

    void Start()
    {
       
    }

    void Update()
    {
        Rotate();
        Shoot();
    }

    void Rotate()
    {
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float currentZRotation = transform.eulerAngles.z > 180 ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
        float newRotation = Mathf.Clamp(currentZRotation + rotation, -60, 60);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = gameManager.GetBullet();
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;
            newBullet.SetActive(true);
        }
    }
}
