using UnityEngine;
using System.Collections;

public class TeleportBlink : MonoBehaviour
{
    public Vector2 teleportPosition;
    public int blinkCount = 3;
    public float blinkSpeed = 0.1f;
    public float walkDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport player
            other.transform.position = teleportPosition;

            // Stop player movement temporarily
            PlayerControl pc = other.GetComponent<PlayerControl>();
            if (pc != null)
            {
                pc.DisableMovement(walkDelay + blinkCount * blinkSpeed * 2);
            }

            // Blink effect
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                StartCoroutine(BlinkPlayer(sr));
            }
        }
    }

    private IEnumerator BlinkPlayer(SpriteRenderer sr)
    {
        for (int i = 0; i < blinkCount * 2; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        sr.enabled = true;
    }
}
