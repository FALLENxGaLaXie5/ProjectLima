using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBrain : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 direction;
    //Rigidbody2D rb2d;

    public float speed = 2f;
    void Start()
    {
        //rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
