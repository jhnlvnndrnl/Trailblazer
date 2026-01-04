using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject dialogueBox; // Disabled DialogueBox prefab

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            // Enable the dialogue box
            dialogueBox.SetActive(true);

            // Start the typing audio immediately
            Dialogue dialogueScript = dialogueBox.GetComponent<Dialogue>();
            if (dialogueScript != null)
            {
                dialogueScript.StartTypingAudio();
            }
        }
    }
}
