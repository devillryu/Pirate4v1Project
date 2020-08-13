using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleDisplay : MonoBehaviour
{
    public GameObject roledisplayasSurvival;
    public GameObject roledisplayasHunter;
    void Start()
    {
        ChangeDisplay();
    }
    public void Swaproleforplay()
    {
        if (Swaprole.chooserole.Role == "Survival")
            Swaprole.chooserole.Role = "Hunter";
        else
            Swaprole.chooserole.Role = "Survival";
        ChangeDisplay();
    }
    public void ChangeDisplay()
    {
        if (Swaprole.chooserole.Role == "Survival")
        {
            roledisplayasSurvival.SetActive(true);
            roledisplayasHunter.SetActive(false);
        }
        else
        {
            roledisplayasHunter.SetActive(true);
            roledisplayasSurvival.SetActive(false);
        }
    }
}
