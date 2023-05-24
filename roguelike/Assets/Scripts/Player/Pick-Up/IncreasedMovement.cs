using System.Collections;
using UnityEngine;

namespace Player
{
    public class IncreasedMovement : MonoBehaviour
    {
        public int durationSeconds = 10; // How long the effect lasts.
        public float speedMultiplier = 1.5f; // How much faster the player moves.
        public PlayerController playerController;

        private bool isMovementIncreased;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(IncreaseMovement());
        }
        IEnumerator IncreaseMovement()
        {
            isMovementIncreased = true;
            yield return new WaitForSeconds(durationSeconds);
            isMovementIncreased = false;
            PickUp.isPickedMovement = false;
            Destroy(this);
        }
        
        public float GetCurrentSpeed()
        {
            return isMovementIncreased ? playerController.moveSpeed * speedMultiplier : playerController.moveSpeed;
        }
    }
}