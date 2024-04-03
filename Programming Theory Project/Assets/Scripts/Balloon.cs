using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void Move();
}

public class Balloon : MonoBehaviour, IMovable
{
    public string enemyType; // Loại kẻ địch
    private float _speed;

    public float Speed
    {
        get { return _speed; }
        private set
        {
            if (enemyType == "Red")
            {
                _speed = 5.0f;
            }
            else if (enemyType == "Blue")
            {
                _speed = 3.0f;
            }
            else if (enemyType == "Purple")
            {
                _speed = 7.0f;
            }
        }
    }

    void Start()
    {
        Speed = _speed;
    }

    void Update()
    {
        Move();
    }

   public virtual void Move()
    {
        transform.position += new Vector3(0, -Speed * Time.deltaTime, 0);
    }
}
