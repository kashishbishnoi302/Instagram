using UnityEngine;
using System.Collections.Generic;

// AddressableAssets : class used to dynamically load/unload 
using UnityEngine.AddressableAssets; 

// used to track the status of data which is being loaded
using UnityEngine.ResourceManagement.AsyncOperations;

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
        if (postPrefab == null || contentParent == null)
        {
            Debug.LogError("FeedScript: assign Post Prefab and Content Parent in the Inspector.");
            return;
        }

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // TextAsset jsonFile = Resources.Load<TextAsset>("posts"); // TextAsset -> unity me ek class hai -> which is used to store text files like .json, .csv etc
        // // loads posts.json ka data as plain text into jsonFile (TextAsset)
        

        // loads data parallely -> posts_data is the address of posts.json -> .Completed -> when the loading is completed -> run this code
        // handle -> is a result box -> stores the result

        // AsyncOperation -> used to track the status 
        Addressables.LoadAssetAsync<TextAsset>("posts_data").Completed += jsonHandle =>
        {
            // jsonHandle is a box -> has the result (file) and status (failor success)
            if (jsonHandle.Status == AsyncOperationStatus.Succeeded)
            {
                string json = jsonHandle.Result.text;

                List<PostData> postList = PostDataJson.LoadPostsFromJson(json);
                if (postList == null || postList.Count == 0)
                {
                    Debug.LogWarning("No posts parsed from JSON");
                    return;
                }

                foreach (PostData data in postList)
                {

                    Addressables.InstantiateAsync("post_prefab", contentParent).Completed += prefabHandle =>
                    {
                        if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
                        {
                            GameObject post = prefabHandle.Result;
                            post.GetComponent<PostUI>().SetData(data);
                        }
                    };
                }

            }
        };


        // foreach (PostData data in postList)
        // {
        //     GameObject post = Instantiate(postPrefab, contentParent);
        //     // postPrefab -> used as a blueprint to create new gameobjects
        //     // contentParent -> decides the hierarchy of the object in scene
        //     post.GetComponent<PostUI>().SetData(data);
        //     // each newly created gameobject calls its own PostUI script and sets data to the references
        // }
        //

    }


}



// Addressables -> basically ek unity package hai -> for memory management -> bhut baar game me asa hoga ki ham assets ko 
// dynamically load aur unload krwa rahe honge -> so if we don't want an asset later -> we can unload it -> remove it from the
// memory 

// destroy() do the same thing -> but addressables do one more thing -> keeps reference count -> like there's an image which is being used by 
// 5 game objects -> it'll keep this count saved, now this image will be loaded once, sabhi gameobjects me uska reference hoga
// now when these game objects get destroyed in runtime -> the count keeps decreasing, as the count becomes 0, this image will be
// removed from the memory..

// when we mark anything as Addressable -> they are added to Local Default Group


// Addressable as the name suggests -> uses address to load the assets when needed.
// Addressables.LoadAssetAsync -> game freeze nahi hota, bg me load hota hai

// instantiate normally jab krte hain tab assets Start me hi memory me load ho jate hain -> addressables make sure ki on-demand
// memory me load ho



