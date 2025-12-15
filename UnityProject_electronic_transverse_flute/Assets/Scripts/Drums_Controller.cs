using UnityEngine;

public class Drums_Controller : MonoBehaviour
{
    //para manejar la apariencia
    public SpriteRenderer Base_Feet;
    public SpriteRenderer Snare_1;
    public SpriteRenderer Snare_2;
    public SpriteRenderer Drum_1;
    public SpriteRenderer Drum_2;
    public SpriteRenderer Drum_3;
    public SpriteRenderer Drum_4;
    public bool playAvailable = false;

    //para audios
    public AudioSource audioSource;
    public AudioClip[] beats;

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
        ColorChange();
        //audioSource.volume = Mathf.Lerp(audioSource.volume, regularVolume, Time.deltaTime * quickFadeSpeed);

    }

    public void ColorChange()
    {
        Base_Feet.color = Input.GetKey(KeyCode.Space) ? hitColor : Color.white;
        Snare_1.color = Input.GetKey(KeyCode.Q) ? hitColor : Color.white;
        Drum_1.color = Input.GetKey(KeyCode.A) ? hitColor : Color.white;
        Drum_2.color = Input.GetKey(KeyCode.W) ? hitColor : Color.white;
        Drum_3.color = Input.GetKey(KeyCode.S) ? hitColor : Color.white;
        Drum_4.color = Input.GetKey(KeyCode.D) ? hitColor : Color.white;

    }
}
