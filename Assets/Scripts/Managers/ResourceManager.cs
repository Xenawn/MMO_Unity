
using UnityEngine;


public class ResourceManager
{
    public T Load<T>(string path) where T: Object
    {
        return Resources.Load<T>(path);
    }
 
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //1. original 이미 들고 있으면 바로 사용
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{path}");
        if(prefab== null)
        {
            Debug.Log($"Failed to load prefab:{path}");
            return null;
        }

        // 2. 혹시 풀링된 애가 있으면 사용
        GameObject go = Object.Instantiate(prefab, parent);
        int index =go.name.IndexOf("(Clone)");
        if(index>0)
            go.name = go.name.Substring(0,index);
        return go;
    }

    public void Destory(GameObject gameObject)
    {
        if (gameObject == null)
            return;

        // 만약에 풀링이 필요하다면 -> 풀링 매니저한테 위탁
        Object.Destroy(gameObject);
    }
}
