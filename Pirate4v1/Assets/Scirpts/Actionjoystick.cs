using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game4v1
{
public class Actionjoystick : MonoBehaviour
{
    public GameObject SitButton; 
    // Start is called before the first frame update
    void Start()
    {
        if(Swaprole.chooserole.Role == "Hunter")
        Destroy(SitButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Action()
    {
        if (Swaprole.chooserole.Role == "Survival")
        {
            if(playerscript.CanInvest == true)
            Debug.Log("Invest");
            if(playerscript.canOpenChest == true)
            Box.isOpen = true;
            if(playerscript.Trapped == true)
            playerscript.TrapPress--;
        }
        else
        {
            Debug.Log("Attack");
        }
    }
    public void SkillandUseItem()
    {
        if (Swaprole.chooserole.Role == "Survival")
        {
            
            Debug.Log("Useitem");
        }
        else
        {
            Debug.Log("Skill");
        }
    }
    public void Sit()
    {
        if(Swaprole.chooserole.Role == "Survival")
        {
            if(playerscript.Sit == false)
            playerscript.Sit = true;
            else
            playerscript.Sit = false;
        }
    }
}
}
