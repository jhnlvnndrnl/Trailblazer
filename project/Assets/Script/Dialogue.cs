using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.05f;

    [Header("Audio")]
    public AudioSource typingAudioSource;

    [Header("Player")]
    public PlayerControl player; // Reference your PlayerControl

    private int index = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void OnEnable()
    {
        // Disable player movement when dialogue starts
        if (player != null) player.canMove = false;

        textComponent.text = string.Empty;
        StartNextLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                // Finish current line instantly
                StopTypingSound();
                if (typingCoroutine != null)
                    StopCoroutine(typingCoroutine);

                textComponent.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartNextLine()
    {
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        // Play typing sound
        PlayTypingSound();

        foreach (char c in lines[index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Stop audio at the end
        StopTypingSound();

        isTyping = false;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartNextLine();
        }
        else
        {
            // Dialogue finished
            StopTypingSound();

            // Restore player movement
            if (player != null) player.canMove = true;

            // Destroy dialogue box
            Destroy(gameObject);
        }
    }

    void PlayTypingSound()
    {
        if (typingAudioSource != null)
        {
            typingAudioSource.loop = true;
            typingAudioSource.Play();
        }
    }

    void StopTypingSound()
    {
        if (typingAudioSource != null && typingAudioSource.isPlaying)
            typingAudioSource.Stop();
    }

    public void StartTypingAudio()
    {
        if (typingAudioSource != null)
        {
            typingAudioSource.loop = true;
            typingAudioSource.Play();
        }
    }

}