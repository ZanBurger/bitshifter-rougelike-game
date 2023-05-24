using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class IncreasedFirerate : MonoBehaviour
    {
        public float baseFirerate = 0.25f;
        public float firerateMultiplier = 5f;
        public int durationSeconds = 10;
        private Weapon weapon;

        public void Initialize(Weapon playerWeapon)
        {
            weapon = playerWeapon;
            StartCoroutine(IncreaseFirerate());
        }

        IEnumerator IncreaseFirerate()
        {
            weapon.SetCurrentFirerate(baseFirerate / firerateMultiplier);
            yield return new WaitForSeconds(durationSeconds);
            weapon.SetCurrentFirerate(baseFirerate);
            PickUp.isPickedRate = false;
            Destroy(this);
        }
    }
}