using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Axe X entre 5 et -5
Axe Y entre 3 et -3
Déplacement de 0.5
 */

public class PuzzleMap : MonoBehaviour
{
    
    [SerializeField] GameObject axeX;
    [SerializeField] GameObject axeY;

    bool buttonHorizontal = false;
    bool buttonVertical = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !buttonHorizontal)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x < 5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x + 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && !buttonHorizontal)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x > -5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x - 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && buttonHorizontal)
        {
            buttonHorizontal = false;
        }



        if (Input.GetAxisRaw("Vertical") > 0 && !buttonVertical)
        {
            buttonVertical = true;
            if (axeY.transform.position.y < 3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y + 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0 && !buttonVertical)
        {
            buttonVertical = true;
            if (axeY.transform.position.y > -3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y - 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && buttonVertical)
        {
            buttonVertical = false;
        }
    }
}
