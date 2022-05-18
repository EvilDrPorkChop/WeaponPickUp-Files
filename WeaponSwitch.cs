using System.Collections;
using System.Collections.Generic; using UnityEngine;

public class WeaponSwitch : MonoBehaviour 
{ 

public static int selectedWeapon = 0;
private WeaponPickUp weaponPickUp;
// Start is called before the first frame update
void Start()
{
    SelectWeapon();
}

// Update is called once per frame
void Update()
{
    int previousthing = selectedWeapon;
    if (Input.GetAxis("Mouse ScrollWheel") > 0f)
    {
        if (selectedWeapon >= transform.childCount - 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;
    }
    if (Input.GetAxis("Mouse ScrollWheel") < 0f)
    {
        if (selectedWeapon <= 0)
            selectedWeapon = transform.childCount - 1;
        else
            selectedWeapon--;
    }
    if (previousthing != selectedWeapon)
    {
        SelectWeapon();
    }
}

    public void SelectWeapon()
{
    int i = 0;
    if (transform.childCount > 0)
    {
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                var weaponObject = weapon.gameObject;
                weaponObject.GetComponentInChildren<WeaponPickUp>().primaryWeapon = true;
                weaponObject.SetActive(true);
            }
            else
            {
                var weaponObject = weapon.gameObject;
                weaponObject.GetComponentInChildren<WeaponPickUp>().primaryWeapon = false;
                weaponObject.SetActive(false);
            }
            i++;
        }
    }
}

public void SetWeaponPickedUpAsPrimary(int newWeaponIndex)
{
    selectedWeapon = newWeaponIndex;
    SelectWeapon();
}
}