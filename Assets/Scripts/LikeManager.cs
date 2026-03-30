using UnityEngine;
using UnityEngine.UI;
public class LikeManager : MonoBehaviour
{
    private bool liked;

    [SerializeField] private Button btn;
    [SerializeField] private Sprite likedImg;
    [SerializeField] private Sprite unlikedImg;    
    public void OnClickHandler()
    {
        if (!liked)
        {
            btn.image.sprite = likedImg;
            liked = true;
        }
        else
        {
            btn.image.sprite = unlikedImg;
            liked = false;
        }
    }
}
