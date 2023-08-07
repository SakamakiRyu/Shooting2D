using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class SceneChenger
{
    public static async void LoadScene(string sceneName)
    {
        await Addressables.LoadSceneAsync($"Assets/Scenes/{sceneName}.unity");
    }
}