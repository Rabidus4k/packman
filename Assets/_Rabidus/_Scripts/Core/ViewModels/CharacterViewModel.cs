public abstract class CharacterViewModel
{
    protected ICharacterModel _model;

    public CharacterViewModel(ICharacterModel model)
    {
        _model = model;
    }
}
