using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public Sprite cloudSprite; 
    public Sprite waterSprite; 
    public Sprite iceSprite; 
    public ParticleSystem waterEffect;
    public ParticleSystem cloudEffect;
    SpriteRenderer m_spriteRenderer;

    void Start()
    {
        waterEffect.Play();
        cloudEffect.Stop();

        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(m_spriteRenderer.sprite == iceSprite){
            Debug.Log("Ice");
            if(waterEffect.isPlaying) waterEffect.Stop();
            if(cloudEffect.isPlaying) cloudEffect.Stop();
        }
        else if(m_spriteRenderer.sprite == waterSprite){
            Debug.Log("Water");
            if(waterEffect.isStopped) waterEffect.Play();
            if(cloudEffect.isPlaying) cloudEffect.Stop();
        }
        else if(m_spriteRenderer.sprite == cloudSprite){
            Debug.Log("Cloud");
            if(waterEffect.isPlaying) waterEffect.Stop();
            if(cloudEffect.isStopped) cloudEffect.Play();
        }
    }
}
