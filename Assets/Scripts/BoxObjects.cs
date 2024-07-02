using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BoxObjects : MonoBehaviour
{
    public SettingSO settings;
    public Side Selection;
    public VoidEventSO ScoreUpdate;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    //private void OnCollisionEnter(Collision other)
    //{

    //    Debug.LogWarning("Entered Collision with the Box");
    //    if (other.gameObject.CompareTag("hands"))
    //    {
    //        if (Selection == Side.RIGHT)
    //        {
    //            if (settings.RightHand)
    //            {
    //                meshRenderer.enabled = false;
    //                Instantiate(settings.boxEffects[Random.Range(0, settings.boxEffects.Count)], transform.position + new Vector3(0f, 0f, -0.1f), Quaternion.identity);
    //                settings.PlayBoxSound(audioSource);
    //                ScoreUpdate.RaiseEvent();
    //                settings.Score += settings.ScoreFactor;
    //                //  Invoke(nameof(CheckState), 2f);
    //                Destroy(this, 5f);
    //            }
    //        }

    //        if (Selection == Side.LEFT)
    //        {
    //            if (settings.LeftHand)
    //            {
    //                Instantiate(settings.boxEffects[Random.Range(0, settings.boxEffects.Count)], transform.position + new Vector3(0f, 0f, -0.1f), Quaternion.identity);
    //                meshRenderer.enabled = false;
    //                settings.PlayBoxSound(audioSource);
    //                settings.Score += settings.ScoreFactor;
    //                ScoreUpdate.RaiseEvent();
    //                // Invoke(nameof(CheckState), 2f);
    //                Destroy(this, 5f);
    //            }
    //        }

    //    }
    //}

    public void Update()
    {
        transform.position += -Vector3.forward * Time.deltaTime * settings.BoxSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hands"))
        {
            if (Selection == Side.RIGHT)
            {
                if (settings.RightHand)
                {
                    meshRenderer.enabled = false;
                    Instantiate(settings.boxEffects[Random.Range(0, settings.boxEffects.Count)], transform.position + new Vector3(0f, 0f, -0.1f), Quaternion.identity);
                    settings.PlayBoxSound(audioSource);
                    ScoreUpdate.RaiseEvent();
                    settings.Score += settings.ScoreFactor;
                    //  Invoke(nameof(CheckState), 2f);
                    Destroy(this, 5f);
                }
            }

            if (Selection == Side.LEFT)
            {
                if (settings.LeftHand)
                {
                    Instantiate(settings.boxEffects[Random.Range(0, settings.boxEffects.Count)], transform.position + new Vector3(0f, 0f, -0.1f), Quaternion.identity);
                    meshRenderer.enabled = false;
                    settings.PlayBoxSound(audioSource);
                    settings.Score += settings.ScoreFactor;
                    ScoreUpdate.RaiseEvent();
                    // Invoke(nameof(CheckState), 2f);
                    Destroy(this, 5f);
                }
            }

        }
    }

    private void CheckState()
    {
        if (meshRenderer.enabled)
        {
            settings.FailCount += 1;
        }
    }
}
