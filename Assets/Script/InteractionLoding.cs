using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionLoding : MonoBehaviour
{
    public PlayerInput IntertionUi;
    public Slider loding;
    private float elaspedTime;
    public InteractionUI Energy;
    //private float maxTime = 3f;
    public Animator _animator;

    // 채집시 재생될 사운드
    public AudioSource _audioSource;
    // 오디오 클립
    public AudioClip _diamondSound;
    public AudioClip _woodSound;
    public AudioClip _rockSound;

    // 로딩이 완료되었을 경우 확인할 변수
    public bool isLoingComplite;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        isLoingComplite = false;
    }

    void Update()
    {
        Loding(Energy.lt);
    }


    private AudioClip SoundClips()
    {
        //채집 사운드 재생
        if (Energy.itemSoundNumber == 0)
        {
            _audioSource.clip = _diamondSound;
            return _audioSource.clip;
        }
        else if (Energy.itemSoundNumber == 1)
        {
            _audioSource.clip = _woodSound;
            return _audioSource.clip;
        }
        else if (Energy.itemSoundNumber == 2)
        {
            _audioSource.clip = _rockSound;
            return _audioSource.clip;
        }
        return null;
    }

    public void Loding(float maxTime)
    {
        if (loding.value == 0f)
        {
            _audioSource.PlayOneShot(SoundClips());
            _audioSource.loop = true;
        }

        elaspedTime += Time.deltaTime;
        loding.value = Mathf.Lerp(0f, 1f, elaspedTime / maxTime);
        _animator.SetBool("Attack", true);
        if (elaspedTime >= maxTime)
        {
            _animator.SetBool("Attack", false);
            elaspedTime = 0f;
            loding.value = 1f;
            gameObject.SetActive(false);
            invisible(Energy.Energy);
            Energy.Energy = null;
            IntertionUi.InteractionOn = false;
        }

        if (loding.value == 1f)
        {
            _audioSource.loop = false;
            _audioSource.Stop();
            LodingComplite();
            loding.value = 0f;
        }
    }

    private void LodingComplite()
    {
        isLoingComplite = true;
    }
    private void invisible(GameObject Energy)
    {
        Energy.GetComponent<MeshRenderer>().enabled = false;
        Energy.GetComponent<MeshCollider>().enabled = false;
        MeshRenderer[] childrenMeshRenderer = Energy.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < childrenMeshRenderer.Length; i++)
        {
            childrenMeshRenderer[i].enabled = false;
        }
    }
}

