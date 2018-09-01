using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPMovement : MonoBehaviour
{
    public string vipTeamColor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Accessors

    public string VIPTeam
    {
        get
        {
            return vipTeamColor;
        }

        set
        {
            vipTeamColor = value;
        }
    }

    #endregion
}
