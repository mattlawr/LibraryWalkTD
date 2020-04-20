/**
 * Entity.cs
 * Written by Matthew Lawrence
 * Superclass of Enemy and Bullet
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles universal events for gameplay objects.
/// </summary>
public class Entity : MonoBehaviour
{
    public AudioSource audioPrefab;

    [Header("Events")]
    [Space]

    public UnityEvent OnDeath;

    protected virtual void Die(float time = 0f)
    {
        if(time == 0f)
            OnDeath.Invoke();

        Destroy(gameObject, time);
    }

    public void DropObject(GameObject go)
    {
        GameObject g = Instantiate(go, transform.position, transform.rotation);
        Destroy(g, 1f);
    }

    public void PlaySound(AudioClip clip)
    {
        if (!audioPrefab)
            return;

        AudioSource gaudio = Instantiate(audioPrefab, transform.position, transform.rotation);

        gaudio.clip = clip;
        gaudio.Play();

        Destroy(gaudio.gameObject, 1f);
    }
}
