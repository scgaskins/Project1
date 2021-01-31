using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(pos.x, transform.position.y);
        if (transform.position.x > 10)
        {
            transform.position = new Vector2(10, transform.position.y);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector2(-10, transform.position.y);
        }
    }
}
