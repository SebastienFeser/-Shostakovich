﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : FixObject
{
    [SerializeField] private int room;
    [SerializeField] private string keyName;
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

            other.GetComponent<PlayerTest>().TimeMove = 2;
            switch (other.GetComponent<PlayerTest>().CurrentOrientation)
            {
                case PlayerTest.Orientation.NORTH:
                {
                    other.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                    break;
                }
                case PlayerTest.Orientation.EAST:
                {
                    other.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                    break;
                }
                case PlayerTest.Orientation.SOUTH:
                {
                    other.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                    break;
                }
                case PlayerTest.Orientation.WEST:
                {
                    other.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                    break;
                }
            }
        }
    }

    public override void Interaction()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(keyName))
        {
            Dialog.ShowAlternativeDialog();
            Interactive = false;
            Wall = false;
        }
        else
        {
            Dialog.ShowDialog();
        }
    }
}
