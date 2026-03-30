using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SendButtonHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public Transform commentsContainer;
    [SerializeField] private GameObject commentPrefab;
    [SerializeField] private GameObject postPrefab;
    
    public void OnClickHandler()
    {
        string text = inputField.text;
        if (string.IsNullOrEmpty(text)) return;

        GameObject newComment = Instantiate(commentPrefab, commentsContainer);
        CommentScript script = newComment.GetComponent<CommentScript>();
        script.SetText(text);
        
        inputField.text = "";
        commentsContainer.gameObject.SetActive(true);
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(commentPrefab.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(postPrefab.GetComponent<RectTransform>());
    }
    


}
