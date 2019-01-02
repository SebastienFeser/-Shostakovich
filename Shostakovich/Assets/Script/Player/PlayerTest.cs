using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public enum Orientation
    {
        NORTH,
        SOUTH,
        RIGHT,
        LEFT
    }


    [SerializeField] private float speed;

    private Orientation currentOrientation;
    public Orientation CurrentOrientation => currentOrientation;

    [SerializeField] private Detector detector;

    [SerializeField] private bool key;
    public bool Key
    {
        get { return key; }
        set { key = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        detector.GetComponentInChildren<Detector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            currentOrientation = Orientation.NORTH;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!detector.DetectWall())
            transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + 1), speed);
        }
        else if (Input.GetButtonDown("Down"))
        {
            currentOrientation = Orientation.SOUTH;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y - 1), speed);
        }
        else if (Input.GetButtonDown("Right"))
        {
            currentOrientation = Orientation.RIGHT;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x + 1, transform.position.y), speed);
        }
        else if (Input.GetButtonDown("Left"))
        {
            currentOrientation = Orientation.LEFT;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            if (!detector.DetectWall())
                transform.position = Vector3.Lerp(transform.position, new Vector2(transform.position.x - 1, transform.position.y), speed);
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (detector.DetectInteract())
            {
                detector.DetectInteract().Interaction();
            }
        }
        
    }
}
