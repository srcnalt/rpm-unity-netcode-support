using UnityEditor;
using UnityEngine;

namespace ReadyPlayerMe.PhotonSupport.Editor
{
    public static class TransferPrefab
    {
        [MenuItem("Ready Player Me/Transfer Netcode Prefab")]
        public static void Transfer()
        {
            string[] guids = AssetDatabase.FindAssets("t:prefab RPM_Netcode_Character");

            if (guids.Length == 0)
            {
                Debug.Log("RPM_Netcode_Character prefab not found. Please reimport Netcode Support package.");
            }
            else
            {
                if (AssetDatabase.LoadAssetAtPath("Assets/Ready Player Me/Resources/RPM_Character.prefab", typeof(GameObject)))
                {
                    if (!EditorUtility.DisplayDialog("Warning", "RPM_Character prefab already exists. Do you want to overwrite it?", "Yes", "No"))
                    {
                        return;
                    }
                }

                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                AssetDatabase.CopyAsset(path, "Assets/Ready Player Me/Resources/RPM_Character.prefab");
                Selection.activeObject = AssetDatabase.LoadAssetAtPath("Assets/Ready Player Me/Resources/RPM_Character.prefab", typeof(GameObject));
                Debug.Log("Netcode prefab transferred to Assets/Ready Player Me/Resources/RPM_Character.prefab");
            }
        }
    }
}
