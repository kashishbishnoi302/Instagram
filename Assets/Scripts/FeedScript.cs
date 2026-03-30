using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FeedScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject postPrefab;
    public Transform contentParent;

    [SerializeField] private GameObject content;
    
    void Start()
    {
        LoadFromJson();
    }

    private void LoadFromJson()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        
        TextAsset jsonFile = Resources.Load<TextAsset>("posts"); // TextAsset -> unity me ek class hai -> which is used to store text files like .json, .csv etc
        // loads posts.json ka data as plain text into jsonFile (TextAsset)
        PostList postList = JsonUtility.FromJson<PostList>(jsonFile.text);
        // JsonUtility -> a built-in json parser -> convert json into a postList object 
        // looks at the jsonFile.text -> it is an array of posts -> maps that array to the List<PostData> now -> it checks 
        // each post -> which can be mapped to PostData objects -> creates real PostData objects and store them in the List
        
        foreach (PostData data in postList.posts)
        {
            GameObject post = Instantiate(postPrefab, contentParent);
            // postPrefab -> used as a blueprint to create new gameobjects
            // contentParent -> decides the hierarchy of the object in scene
            post.GetComponent<PostUI>().SetData(data);
            // each newly created gameobject calls its own PostUI script and sets data to the references
        }
        
        
        
        
        
       
    }
}
