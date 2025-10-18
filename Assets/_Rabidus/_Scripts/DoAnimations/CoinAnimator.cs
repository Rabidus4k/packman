using DG.Tweening;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Collider _collider;

    [Header("Idle")]
    [SerializeField] private float bobAmplitude = 0.15f;
    [SerializeField] private float bobDuration = 0.8f;
    [SerializeField] private float rotationSpeed = 360f;

    [Header("OnCollect")]
    [SerializeField] private float collectScaleUpMultiplier = 1.2f;
    [SerializeField] private float collectUpTime = 0.12f;
    [SerializeField] private float collectDownTime = 0.18f;
    [SerializeField] private bool destroyOnComplete = true;

    private Sequence _idleSeq;
    private Vector3 _startScale;
    private Vector3 _startLocalPos;

    private void Awake()
    {
        _startScale = transform.localScale;
        _startLocalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        PlayIdle();
    }

    private void OnDisable()
    {
        KillAllTweens();
    }

    private void PlayIdle()
    {
        KillAllTweens();

        _idleSeq = DOTween.Sequence();

        Tween bob = transform
            .DOLocalMoveY(_startLocalPos.y + bobAmplitude, bobDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);

        float rotationDuration = 360f / Mathf.Max(1f, rotationSpeed); // один оборот в секундах
        Tween spin = transform
            .DOLocalRotate(new Vector3(0f, 360f, 0f), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

        _idleSeq.Join(bob).Join(spin);
        _idleSeq.Play();
    }

    private void KillAllTweens()
    {
        _idleSeq?.Kill();
        _idleSeq = null;
        transform.DOKill();
    }

    public void OnCollect()
    {
        _collider.enabled = false;
        KillAllTweens();

        Sequence collectSeq = DOTween.Sequence();
        collectSeq.Append(
            transform.DOScale(_startScale * collectScaleUpMultiplier, collectUpTime)
                     .SetEase(Ease.OutBack)
        );
        collectSeq.Append(
            transform.DOScale(Vector3.zero, collectDownTime)
                     .SetEase(Ease.InBack)
        );

        if (destroyOnComplete)
        {
            collectSeq.OnComplete(() => Destroy(_root));
        }
        else
        {
            collectSeq.OnComplete(() =>
            {
                _root.SetActive(false);
            });
        }
    }

    public void RestartIdle()
    {
        transform.localScale = _startScale;
        transform.localPosition = _startLocalPos;
        PlayIdle();
    }
}