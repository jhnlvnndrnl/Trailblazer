using UnityEngine;

public class LastTrigger : MonoBehaviour
{
    public GameObject Bases;
    public GameObject SecondBases;

    public GameObject StartBase;
    public GameObject StartCoin; 
    public GameObject  FirstCoin;
    public GameObject StartTrigger;


    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Destroy the first bases
            if (Bases != null)
                Destroy(Bases);

            // Enable second bases
            if (SecondBases != null)
                SecondBases.SetActive(true);

            if (StartBase != null)
                Destroy(StartBase);

            if (StartCoin != null)
                StartCoin.SetActive(true);

            if (StartTrigger != null)
                StartTrigger.SetActive(true);

            if (FirstCoin != null)
                Destroy(FirstCoin);
        }
    }
}
