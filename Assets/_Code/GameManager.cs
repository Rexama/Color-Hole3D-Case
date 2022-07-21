using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EZCameraShake;
using Lean.Touch;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public ParticleSystem confetti;
    public LeanManualTranslate move;

    public void OnLevelEnd()
    {
        confetti.Play();
        move.Multiplier = 0;

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(2f).OnComplete(() =>
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // Debug.Log(currentSceneIndex);
            // Debug.Log(SceneManager.sceneCount - 1);
            // if (currentSceneIndex < SceneManager.sceneCount - 1)
            // {
            //     Debug.Log("x");
            //     SceneManager.LoadScene(currentSceneIndex + 1);
            // }
            // else
            // {
            //     Debug.Log("y");
            //     SceneManager.LoadScene(0);
            // }
            SceneManager.LoadScene((currentSceneIndex + 1)%5);
        });
    }

    public void OnLevelFail()
    {
        move.Multiplier = 0;
        CameraShaker.Instance.ShakeOnce(0.3f, 10, 0.1f, 2f);

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(2f).OnComplete(() =>
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        });
    }
}