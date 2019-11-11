using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject playerDeathPrefab;
    public AudioClip deathClip;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {    
        if (other.transform.tag == "Player")
        {
            var audioSource = GetComponent<AudioSource>();
            if (audioSource != null && deathClip != null)
            {
                audioSource.PlayOneShot(deathClip);
            }     
            Instantiate(playerDeathPrefab, other.contacts[0].point, Quaternion.identity);
            spriteRenderer.sprite = hitSprite;
 
            Destroy(other.gameObject);

            GameManager.instance.RestartLevel(1.25f);
        }
    } 

}
