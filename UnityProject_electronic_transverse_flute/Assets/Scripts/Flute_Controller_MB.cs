using UnityEngine;
using System.Collections;

public class Flute_Controller_MB : MonoBehaviour
{
    //para manejar la apariencia
    public SpriteRenderer flute; 

    //para audios
    public AudioSource audioSource; 
    public AudioClip[] notes;

    //variables
    public bool playAvailable =false;
    public float fadeOutTime = 0.5f;
    private bool isPlaying = false;

    private Coroutine fadeCoroutine;

    private AudioClip nextNote = null;
    private float regularVolume = 1f;
    private float quickFadeSpeed = 60f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playAvailable = Input.GetKey(KeyCode.Space);
        CurrentlyBlowing();

        if (nextNote != null && audioSource.volume <= 0.01f)
        {
            audioSource.clip = nextNote;
            audioSource.loop = true;
            audioSource.Play();
            regularVolume = 1f;  
            nextNote = null;
        }

        audioSource.volume = Mathf.Lerp(audioSource.volume, regularVolume, Time.deltaTime * quickFadeSpeed);
    }


    //MÉTODOS

    public void CurrentlyBlowing() //como si lo pusieras en update, pero para quitar chicha de en medio. Cambia el color del objeto si está ready to play, hace el fade y toca la nota
    {
       
        if (playAvailable)
        {
            flute.color = Color.violet;
            assignNote();
        }
        else
        {
            flute.color = Color.white;
            stopNote();
            regularVolume = 0f;
            nextNote = null;
        }
    }

    public void assignNote () //relaciona inputs con elementos de la lista de audios
    {
        bool keyPressed = false; 

        for (int i = 0; i < 8; i++)
        {
            KeyCode key = KeyCode.Alpha1 + i;
            if (Input.GetKey(key))
            {
                keyPressed = true;

                if (audioSource.clip == notes[i] && audioSource.isPlaying)
                    return;

                if (audioSource.isPlaying)
                {
                    nextNote = notes[i];
                    regularVolume = 0f;

                }
                else
                {
                    PlayNote(notes[i]);
                }
                return;
            }
        }

        if (!keyPressed)
        {
            stopNote();
            nextNote = null;
            regularVolume = 0f;
            isPlaying = false;
        }
    }

    void PlayNote(AudioClip sound)
    { 

            audioSource.clip = sound;
            audioSource.loop = true;
            audioSource.volume = 1f;
            audioSource.Play();
            isPlaying = true;
            regularVolume = 1f;
        
    }

    public void stopNote()
    {
        if (isPlaying)
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            fadeCoroutine = StartCoroutine(FadeOut(audioSource, fadeOutTime));
            isPlaying = false; 
        }
    }

    IEnumerator FadeOut(AudioSource audio, float fadeTime)
    {
        float startVolume = audio.volume;

        while (audio.volume > 0)
        {
            audio.volume -= startVolume * (Time.deltaTime / fadeTime);
            yield return null;
        }

        audio.Stop();
        audio.volume = startVolume;
    }

   
}


