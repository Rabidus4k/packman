using System;
using UnityEngine;
using Zenject;

public class CharacterInputView : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;

    private ICharacterInputViewModel _viewModel;
    private Vector3 _desiredMovement;
    private float _rotationSpeed = 180f;

    [Inject]
    private void Construct(ICharacterInputViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Movement.OnChanged += SetMovement;
        _viewModel.RotationSpeed.OnChanged += SetRotationSpeed;
    }

    private void SetRotationSpeed(float value)
    {
        _rotationSpeed = value;
    }

    private void OnDisable()
    {
        _viewModel.Movement.OnChanged -= SetMovement;
        _viewModel.RotationSpeed.OnChanged -= SetRotationSpeed;
    }

    private void Update()
    {
        var horizontal = _joystick.Horizontal;
        var vertical = _joystick.Vertical;

        _viewModel.HandleInput(horizontal, vertical);
        _viewModel.SetPosition(transform.position);
    }

    private void SetMovement(Vector3 movement)
    {
        _desiredMovement = movement;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_desiredMovement.x, 0, _desiredMovement.y);

        ApplyMovement(movement);
        ApplyRotation(movement);
        ApplyAnimation(movement);
    }

    private void ApplyMovement(Vector3 movement)
    {
        _controller.Move(movement * Time.deltaTime);
    }

    private void ApplyRotation(Vector3 movement)
    {
        if (movement.sqrMagnitude > 0.0001f)
        {
            Quaternion target = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = target;
        }
    }

    private void ApplyAnimation(Vector3 movement)
    {
        _animator.SetFloat(AnimationHashContainer.Speed, movement.normalized.magnitude);
    }
}
