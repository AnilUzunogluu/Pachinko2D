using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsBall : MonoBehaviour
{
    public float movementSpeed;
    bool isBallFalling = false;
    Rigidbody2D ball;
    public Vector3 ballStartLocation;

    private void Awake()
    {
        ball = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        BallStart();
        StartAgain();
    }

    private void Controls()
    {
        if (!isBallFalling)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
        }
    }

    private void BallStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBallFalling = true;
            ball.constraints = RigidbodyConstraints2D.None;
        }
    }
    private void StartAgain()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            transform.localPosition = ballStartLocation;
            ball.constraints = RigidbodyConstraints2D.FreezeAll;
            isBallFalling = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
