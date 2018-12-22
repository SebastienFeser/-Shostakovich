using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject exterior;

    private GameObject currentMap;

    private bool exteriorPosition = true;
    public bool ExteriorPosition => exteriorPosition;

    private static MapManager instance;
    public static MapManager Instance => instance;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMap = exterior;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionInterior(GameObject room)
    {
        wall.SetActive(false);
        exterior.SetActive(false);
        room.SetActive(true);
        exteriorPosition = false;
        currentMap = room;
    }
    public void TransitionExterior()
    {
        wall.SetActive(true);
        exterior.SetActive(true);
        currentMap.SetActive(false);
        exteriorPosition = true;
        currentMap = exterior;
    }
}
