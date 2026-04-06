using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SendButtonHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Transform commentsContainer;
    [SerializeField] private GameObject commentPrefab;
    [SerializeField] private GameObject postPrefab;

    // Feed wale GameObject par ScrollRect hai; Content me posts spawn hoti hain.
    // Post ke andar se upar jaake wahi ScrollRect milta hai — uska .content = posts ka parent (manual assign ki zaroorat nahi).
    private RectTransform GetPostsFeedContent()
    {
        ScrollRect feedScroll = GetComponentInParent<ScrollRect>();
        return feedScroll != null ? feedScroll.content : null;
    }
    
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
        RectTransform postsFeedContent = GetPostsFeedContent();
        if (postsFeedContent != null)
            LayoutRebuilder.ForceRebuildLayoutImmediate(postsFeedContent);
    }
    


}
