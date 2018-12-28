using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerTest>())
        {
            if (MapManager.Instance.ExteriorPosition)
            {
                MapManager.Instance.TransitionInterior(room);

            }
            else
            {
                MapManager.Instance.TransitionExterior();

            }

            switch (other.GetComponent<PlayerTest>().CurrentOrientation)
            {
                case PlayerTest.Orientation.NORTH:
                {
                    other.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                    break;
                }
                case PlayerTest.Orientation.RIGHT:
                {
                    other.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                    break;
                }
                case PlayerTest.Orientation.SOUTH:
                {
                    other.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                    break;
                }
                case PlayerTest.Orientation.LEFT:
                {
                    other.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                    break;
                }
            }
        }
    }
}
