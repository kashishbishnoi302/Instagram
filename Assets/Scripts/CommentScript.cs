using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CommentScript : MonoBehaviour
{
    [SerializeField] private TMP_Text content;
    public void SetText(string text)
    {
        content.text = text;
    }
}
