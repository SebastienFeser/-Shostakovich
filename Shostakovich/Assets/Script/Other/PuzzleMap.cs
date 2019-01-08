using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
Axe X entre 5 et -5
Axe Y entre 3 et -3
Déplacement de 0.5
 */

public class PuzzleMap : MonoBehaviour
{

    [SerializeField] GameObject axeX;
    [SerializeField] GameObject axeY;
    [SerializeField] float xWinPosition = -4.5f;
    [SerializeField] float yWinPosition = 0f;
    [SerializeField] TextMeshProUGUI victoryText;

    bool buttonHorizontal = false;
    bool buttonVertical = false;
    bool canMove = true;
    bool endstarted = false;

    [SerializeField] private string rewardObject;
    [SerializeField] AudioSource boxSource;
    [SerializeField] AudioClip lockerClip;

    // Start is called before the first frame update
    void Start()
    {
        victoryText.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //Tile movement X
        if (Input.GetAxisRaw("Horizontal") > 0 && !buttonHorizontal && canMove)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x < 4.5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x + 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && !buttonHorizontal && canMove)
        {
            buttonHorizontal = true;
            if (axeX.transform.position.x > -4.5)
            {
                axeX.transform.position = new Vector2(axeX.transform.position.x - 0.5f, axeX.transform.position.y);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && buttonHorizontal && canMove)
        {
            buttonHorizontal = false;
        }


        //Tile movement Y
        if (Input.GetAxisRaw("Vertical") > 0 && !buttonVertical && canMove)
        {
            buttonVertical = true;
            if (axeY.transform.position.y < 3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y + 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0 && !buttonVertical && canMove)
        {
            buttonVertical = true;
            if (axeY.transform.position.y > -3)
            {
                axeY.transform.position = new Vector2(axeY.transform.position.x, axeY.transform.position.y - 0.5f);
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && buttonVertical && canMove)
        {
            buttonVertical = false;
        }

        if (axeX.transform.position.x == xWinPosition && axeY.transform.position.y == yWinPosition && !endstarted)
        {
            //play unlock sound
            boxSource.clip = lockerClip;
            boxSource.Play();
            canMove = false;
            StartCoroutine(WinText());
            endstarted = true;
            if (!GameManager.Instance.SaveDataInstance.inventory.Contains(rewardObject))
            {
                GameManager.Instance.SaveDataInstance.inventory.Add(rewardObject);
            }
            else
            {
                Debug.Log("error object already exist");
            }

        }


    }

    IEnumerator WinText()
    {
        for (float i = 0; i < 1; i += 0.02f)
        {
            victoryText.color = new Color(1, 1, 1, 0 + i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Luca");
    }
}
