using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class MissionSettings : MonoBehaviour
{
    public enum Missions 
        {
        None,
        MoveBroken,
        FixWire,
        ChangeBulb,
        MessStove
        }
    public Missions missionsType;
    //
    public bool isTrigger = false;
    private Interactable field;
    private GameObject player;

    void Start()
    {
        field = GetComponentInChildren<Interactable>();
    }

    void Update()
    {
        player = field.player;
    }

    public void MissionTrigger()
    {
        if(!isTrigger)
        {
            Debug.Log("Mission Trigger");
            isTrigger = true;
            player.GetComponent<PlayerControl>().CanMove = false;
            Mission();
        }
    }

    public void MissionExit()
    {
        if(isTrigger)
        {
            isTrigger = false;
            player.GetComponent<PlayerControl>().CanMove = true;
            Debug.Log("Mission Exit");
        }
    }

    [SerializeField] private Material defaultMat;
    public void MissionFinish()
    {
        MissionExit();
        field.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().material = defaultMat;
    }

    //--Mission--//
    void Mission()
    {
        if(missionsType == Missions.MoveBroken)
        {
            Debug.Log("Move Broken");
        }
        else if(missionsType == Missions.MessStove)
        {
            Debug.Log("Clean Stove");
        }
    }
}
