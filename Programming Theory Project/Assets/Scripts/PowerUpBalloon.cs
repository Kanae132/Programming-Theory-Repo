using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBalloon : Balloon, IMovable
{

    [SerializeField]private Vector3 direction;
    private float speed = 5f;
     
    public override void Move(){
        int randomDirection = Random.Range(0,2);
        if(randomDirection == 0){
            direction = Vector3.left;
        }else{
            direction = Vector3.right;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
   
}
