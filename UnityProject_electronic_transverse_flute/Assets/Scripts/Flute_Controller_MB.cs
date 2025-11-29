using UnityEngine;

public class Flute_Controller_MB : MonoBehaviour
{
    public SpriteRenderer flute;

    public AudioSource audioSource;
    public AudioClip[] notes;

    public bool playAvailable;
    public float fadeOutTime = 0.5f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentlyBlowing();
       
    }

    public void CurrentlyBlowing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playAvailable = true;
        }
        else
        {
            playAvailable = false;
        }
        if (playAvailable == true)
        {
            flute.color = Color.violet;
        }
        else
        {
            flute.color = Color.white;
        }
    }

    public void notePlaying ()
    {
        if (playAvailable == true)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {

            }
        }
    }
}

