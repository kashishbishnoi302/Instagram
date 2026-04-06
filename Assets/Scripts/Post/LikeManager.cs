using UnityEngine;
using UnityEngine.UI;
using Insta;
public class LikeManager : MonoBehaviour
{
    private bool _liked;
    
    [SerializeField] private Button btn;
    [SerializeField] private Sprite likedImg;
    [SerializeField] private Sprite unlikedImg;    
    public void OnClickHandler()
    {
        if (!_liked)
        {
            btn.image.sprite = likedImg;
            _liked = true;
            LikeLogger.OnLikePressed();
        }
        else
        {
            btn.image.sprite = unlikedImg;
            _liked = false;
        }
    }
}
