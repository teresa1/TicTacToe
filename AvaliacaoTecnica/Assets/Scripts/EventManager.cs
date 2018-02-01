using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void Instanciate();
    public static event Instanciate instanciateGrid;



    public delegate void InstanciateMarker();
    public static event Instanciate instanciateMarker;

    public void InstanciateGridEvent()
    {
        if (instanciateGrid != null)
            instanciateGrid();
    }

    public void InstanciateMarkerEvent()
    {
        if (instanciateMarker != null)
            instanciateMarker();
    }
}
