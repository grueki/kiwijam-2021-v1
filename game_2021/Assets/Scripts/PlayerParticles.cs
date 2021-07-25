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
            if(waterEffect.isPlaying) waterEffect.Stop();
            if(cloudEffect.isPlaying) cloudEffect.Stop();
        }
        else if(m_spriteRenderer.sprite == waterSprite){
            if(waterEffect.isStopped) waterEffect.Play();
            if(cloudEffect.isPlaying) cloudEffect.Stop();
        }
        else if(m_spriteRenderer.sprite == cloudSprite){
            if(waterEffect.isPlaying) waterEffect.Stop();
            if(cloudEffect.isStopped) cloudEffect.Play();
        }
    }
}
