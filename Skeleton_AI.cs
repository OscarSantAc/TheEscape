using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_AI : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    private int layer_mask;
    public float distance = 2f;
    private bool first = true;
    private bool frozen;

    private void Start()
    {
        layer_mask = LayerMask.GetMask("Platform");
    }

    void Update()
    {
        frozen = GlobalVariables.getFrozenTime();
        if (!frozen)
        {
            if (first)
            {
                Invoke("delay", 1.5f);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
                if (!groundInfo.collider)
                {
                    if (movingRight)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                    }
                    else
                    {

                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }

                    movingRight = !movingRight;
                }
            }
        }
    }

    void delay()
    {
        first = false;
    }
}