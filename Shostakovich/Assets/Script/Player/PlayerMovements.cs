using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField] float movementDistance = 1f;   //The player will walk tile by tile
    [SerializeField] float playerSpeed = 1f;        


    bool isMoving = false;


    enum PlayerLookPosition         //To switch the position where the player is looking and
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }

    PlayerLookPosition playerLookPosition;

    void Start()
    {
        playerLookPosition = PlayerLookPosition.SOUTH;
    }

    void Update()
    {
        switch (playerLookPosition)
        {
            case PlayerLookPosition.NORTH:
                PlayerLookNorth();
                break;
            case PlayerLookPosition.SOUTH:
                PlayerLookSouth();
                break;
            case PlayerLookPosition.EAST:
                PlayerLookEast();
                break;
            case PlayerLookPosition.WEST:
                PlayerLookWest();
                break;
        }
    }

    void PlayerLookNorth()
    {
        //Change player Rotation
        //Change player Sprite
    }

    void PlayerLookSouth()
    {

    }

    void PlayerLookEast()
    {

    }

    void PlayerLookWest()
    {

    }
}
