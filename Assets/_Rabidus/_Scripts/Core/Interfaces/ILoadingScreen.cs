using Cysharp.Threading.Tasks;
using System.Threading;

public interface ILoadingScreen
{
    void Show();
    void Hide();
    void SetProgress(float value);
}
