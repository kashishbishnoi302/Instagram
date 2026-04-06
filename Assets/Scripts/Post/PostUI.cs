using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class PostUI : MonoBehaviour
{
    [SerializeField] private Image profileImage;
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI placeText;
    [SerializeField] private Image postImage;
    [SerializeField] private TextMeshProUGUI tagsText;
    [SerializeField] private TextMeshProUGUI captionText;
    [SerializeField] private TextMeshProUGUI contentText;
    
    
    public void SetData(PostData data)
    {
        usernameText.text = data.username;
        placeText.text = data.place;

        // Sprite profSprite = Resources.Load<Sprite>("Images/" + data.profilePic);
        // if (profSprite != null)
        //     profileImage.sprite = profSprite;

        Addressables.LoadAssetAsync<Sprite>(data.profilePic).Completed += profilePicHandle =>
        {
            if (profilePicHandle.Status == AsyncOperationStatus.Succeeded)
            {
                profileImage.sprite = profilePicHandle.Result;
            }
            else
            {
                Debug.Log("Failed to load the profile pic " +  data.profilePic);
            }
        };

        Addressables.LoadAssetAsync<Sprite>(data.image).Completed += imageHandle =>
        {
            if (imageHandle.Status == AsyncOperationStatus.Succeeded)
            {
                postImage.sprite = imageHandle.Result;
            }
            else
            {
                Debug.Log("Failed to load the image pic " + data.image);
            }
        };

        // Sprite sprite = Resources.Load<Sprite>("Images/" + data.image);
        // if (sprite != null)
        //     postImage.sprite = sprite;

        tagsText.text = string.Join(", ", data.tags);
        captionText.text = data.caption;
        contentText.text = data.content;
    }
}
