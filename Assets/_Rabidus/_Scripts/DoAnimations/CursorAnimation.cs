using UnityEngine;
using DG.Tweening;

public class CursorAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _duration = 0.4f;

    private void Start()
    {
        _rectTransform.DOAnchorPos(_endPosition, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
