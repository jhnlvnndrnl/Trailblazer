using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public GameObject Mud;
    public GameObject Tower;
    public GameObject StartCoin;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log("Trigger hit by: " + other.name);
    if (triggered) return;

    if (other.CompareTag("Player"))
    {
        triggered = true;

        if (Mud != null)
            Destroy(Mud);

        if (Tower != null)
            Destroy(Tower);

        if (StartCoin != null)
            Destroy(StartCoin);
    }
}


}
