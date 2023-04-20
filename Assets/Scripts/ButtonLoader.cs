using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ButtonLoader : MonoBehaviour
{
    public Text text;
    
    public Image image;

    public Sprite startSprite;
    public AssetReference loadedSprite;
  
    private AsyncOperationHandle handle;
    
    public void ButtonClick()
    {
        StartCoroutine(LoadAssets());
    }

    private IEnumerator LoadAssets()
    {
        text.text += "start loading assets\n";
        
        if (handle.IsValid())
        {
            Addressables.Release(handle);
        }
        else
        {
            text.text += "smth wrong\n handle.OperationException\n";
        }

        AssetReference sprite = loadedSprite;
        handle = Addressables.LoadAssetAsync<Sprite>("name");
        yield return handle;
        
        if (handle.Status == AsyncOperationStatus.Succeeded) {
            Debug.Log("all assets finish successfully loaded\n");
            text.text += "all assets finish successfully loaded\n";
        }
        else {
            Debug.Log("level assets failed to load!");
            text.text += $"level assets failed to load! {handle.OperationException}\n";
        }
        
        
        image.sprite = handle.Result as Sprite;
    }
}

//AKIA5ISA5JZ63MFQXRML
