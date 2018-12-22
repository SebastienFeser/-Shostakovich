using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector2(transform.position.x, transform.position.y + 1), speed);
            Debug.Log("Up");
        }
        else if (Input.GetButtonDown("Down"))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector2(transform.position.x, transform.position.y - 1), speed);

            Debug.Log("Down");

        }
        else if (Input.GetButtonDown("Right"))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector2(transform.position.x + 1, transform.position.y), speed);
            Debug.Log("Right");

        }
        else if (Input.GetButtonDown("Left"))
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector2(transform.position.x - 1, transform.position.y), speed);
            Debug.Log("Left");

        }
    }
}
