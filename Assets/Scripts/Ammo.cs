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

    public int GetAmmo()
    {
        return ammoAmount;
    }

    public void DecreaseAmmo()
    {
        ammoAmount--;
    }
}
