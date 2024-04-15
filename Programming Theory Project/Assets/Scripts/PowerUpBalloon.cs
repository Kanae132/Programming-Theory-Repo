using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBalloon : Balloon, IMovable
{

    [SerializeField] private float speed = 10f;

    public override void Move()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet") && enemyType == "Bomb")
        {
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
            foreach (GameObject balloon in balloons)
            {
                Balloon balloonComp = GetComponent<Balloon>();
                Bullet bulletComp = col.gameObject.GetComponent<Bullet>();
                gameManager.ScoreUpdate(balloonComp.Point);

                ParticleSystem tempPar = Instantiate(bulletComp.enePar, balloon.transform.position, Quaternion.identity);
                tempPar.Play();
                Destroy(tempPar.gameObject, tempPar.main.duration);
                Destroy(balloon);
            }
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Bullet") && enemyType == "MultiShoot")
        {
            CanonController canonController = GameObject.FindObjectOfType<CanonController>();
            if (canonController != null)
            {
                canonController.isMultiShoot = true;
            }
            Destroy(this.gameObject);
        }



        else if (col.gameObject.CompareTag("Barrier") || col.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}


