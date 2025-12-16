using UnityEngine;

public class Drums_Controller : MonoBehaviour
{
    //para manejar la apariencia
    public SpriteRenderer Base_Feet;
    public SpriteRenderer Snare_1;
    public SpriteRenderer Snare_2;
    public SpriteRenderer Hit_hat;
    public SpriteRenderer Drum_1;
    public SpriteRenderer Drum_2;
    public SpriteRenderer Drum_3;
    public SpriteRenderer Drum_4;

    //para audios
    public AudioSource AS_snare1;
    public AudioSource AS_snare2;
    public AudioSource AS_hithat;
    public AudioSource AS_drum1;
    public AudioSource AS_drum2;
    public AudioSource AS_drum3;
    public AudioSource AS_drum4;
    public AudioSource AS_basefeet;

    public AudioClip Base_Feet_Clip;
    public AudioClip Snare1_Clip;
    public AudioClip Snare2_Clip;
    public AudioClip HitHat_Clip;
    public AudioClip Drum1_Clip;
    public AudioClip Drum2_Clip;
    public AudioClip Drum3_Clip;
    public AudioClip Drum4_Clip;

    private Color hitColor = Color.violet;
    //variables

    //private float regularVolume = 1f;
    //private float quickFadeSpeed = 60f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        //audioSource.volume = Mathf.Lerp(audioSource.volume, regularVolume, Time.deltaTime * quickFadeSpeed);
        HandleDrum(Base_Feet, AS_basefeet, Base_Feet_Clip, KeyCode.Space);
        HandleDrum(Snare_1, AS_snare1, Snare1_Clip, KeyCode.E);
        HandleDrum(Snare_2, AS_snare2, Snare2_Clip, KeyCode.Alpha1);
        HandleDrum(Hit_hat, AS_hithat, HitHat_Clip, KeyCode.Q);
        HandleDrum(Drum_1, AS_drum1, Drum1_Clip, KeyCode.LeftArrow);
        HandleDrum(Drum_2, AS_drum2, Drum2_Clip, KeyCode.UpArrow);
        HandleDrum(Drum_3, AS_drum3, Drum3_Clip, KeyCode.DownArrow);
        HandleDrum(Drum_4, AS_drum4, Drum4_Clip, KeyCode.RightArrow);
    }

    void HandleDrum(SpriteRenderer sprite, AudioSource audio, AudioClip clip, KeyCode key)
    {
        // Color mientras se pulsa
        sprite.color = Input.GetKey(key) ? hitColor : Color.white;

        // Golpe de sonido
        if (Input.GetKeyDown(key) && audio != null && clip != null)
        {
            audio.PlayOneShot(clip);
        }
    }
}
