using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void Move();
}

public class Balloon : MonoBehaviour, IMovable
{
    public GameManager gameManager;
    public string enemyType; // Loại kẻ địch
    private float _speed;
    private float _point;

    public float Speed
    {
        get { return _speed; }
    }

    public float Point
    {
        get { return _point; }
    }

    public void setValues()
    {

        if (enemyType == "Red")
        {
            _speed = 5.0f;
            _point = 5f;

        }
        else if (enemyType == "Blue")
        {
            _speed = 3.0f;
            _point = 3f;
        }
        else if (enemyType == "Purple")
        {
            _speed = 7.0f;
            _point = 7f;
        }
        else if (enemyType == "Bomb" || enemyType == "MultiShoot"){
            _point = 10f;
        }
       

    }

    void Start()
    {
        setValues();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += new Vector3(0, -Speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            gameManager.ScoreUpdate(Point);
        }
    }
}
