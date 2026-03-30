using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostUI : MonoBehaviour
{
    public Image profileImage;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI placeText;
    public Image postImage;
    public TextMeshProUGUI tagsText;
    public TextMeshProUGUI captionText;
    public TextMeshProUGUI contentText;

    public void SetData(PostData data)
    {
        usernameText.text = data.username;
        placeText.text = data.place;

        // Load Profile Pic
        Sprite profSprite = Resources.Load<Sprite>("Images/" + data.profilePic);
        if (profSprite != null)
            profileImage.sprite = profSprite;

        // Load Post Image
        Sprite sprite = Resources.Load<Sprite>("Images/" + data.image);
        if (sprite != null)
            postImage.sprite = sprite;

        tagsText.text = string.Join(", ", data.tags);
        captionText.text = data.caption;
        contentText.text = data.content;
    }
}