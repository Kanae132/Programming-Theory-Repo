using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem enePar;
    public ParticleSystem powerPar;
    public AudioClip desAudio;
    private AudioSource audioSource;
    private float bulletSpeed = 30f;
    private float bound = 22f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    void OnCollisionEnter(Collision col)
    {

        GameObject temp = new GameObject("Temp");
        AudioSource tempAudio = temp.AddComponent<AudioSource>();
        tempAudio.clip = desAudio;

        if (col.gameObject.CompareTag("Balloon"))
        {
            ParticleSystem tempPar = Instantiate(enePar, transform.position, Quaternion.identity, temp.transform);
            tempPar.Play();
            tempAudio.PlayOneShot(desAudio);

            Destroy(this.gameObject);
            Destroy(temp, desAudio.length);
        }
        else if (col.gameObject.CompareTag("PowerUp"))
        {
            ParticleSystem powerTempPar = Instantiate(powerPar, transform.position, Quaternion.identity, temp.transform);
            powerTempPar.Play();
            Destroy(temp, desAudio.length);
            tempAudio.PlayOneShot(desAudio);
        }

    }
}
