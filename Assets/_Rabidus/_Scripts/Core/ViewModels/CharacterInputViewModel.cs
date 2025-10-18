using UnityEngine;

public class CharacterInputViewModel : ICharacterInputViewModel
{
    public ReactiveProperty<Vector3> Movement { get; private set; } = new ReactiveProperty<Vector3>();

    public ReactiveProperty<float> RotationSpeed { get; private set;} = new ReactiveProperty<float>();

    protected ICharacterInputModel _model;

    public CharacterInputViewModel(ICharacterInputModel model)
    {
        _model = model;
        Movement.Value = model.Movement;
        RotationSpeed.Value = model.Config.RotationSpeed;
    }

    public void HandleInput(float horizontal, float vertical)
    {
        _model.HandleInput(horizontal, vertical);
        Movement.Value = _model.Movement;
    }
}
