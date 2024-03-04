using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int ammoAmount = 10;

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammotype;
        public int ammoAmount;
    }

    public int GetAmmo(AmmoType ammotype)
    {
        return GetAmmoSlot(ammotype).ammoAmount;
    }

    public void DecreaseAmmo(AmmoType ammotype)
    {
        GetAmmoSlot(ammotype).ammoAmount--;
    }
    public void IncreaseAmmo(AmmoType ammotype, int ammoAmount)
    {
        GetAmmoSlot(ammotype).ammoAmount += ammoAmount;
    }

    AmmoSlot GetAmmoSlot(AmmoType ammotype)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammotype == ammotype)
            {
                return slot;
            }
        }
        return null;
    }
}
