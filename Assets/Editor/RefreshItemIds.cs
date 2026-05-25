#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class RefreshItemIds
{
    [MenuItem("Tools/Refresh Item IDs")]
    public static void Refresh()
    {
        string[] guids = AssetDatabase.FindAssets("t:ItemSO");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemSO item = AssetDatabase.LoadAssetAtPath<ItemSO>(path);

            EditorUtility.SetDirty(item);
        }

        AssetDatabase.SaveAssets();
        Debug.Log($"Refreshed {guids.Length} ItemSOs");
    }
}
#endif