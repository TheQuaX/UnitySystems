using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CleanerProjects : EditorWindow
{
    #region Variables
    int gameType = 2;
    private string root = @"Assets\";
    private bool warned = false;
    private bool showWarning = false;


    #endregion

    [MenuItem("Window/CleanerProjects")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CleanerProjects));
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        gameType = EditorGUILayout.IntSlider("2D or 3D Project?", gameType, 2, 3);
        EditorGUILayout.Space(20f);
        if (GUILayout.Button("Generate"))
        {
            Generate();
        }
        EditorGUILayout.Space(20f);

        if (!showWarning)
        {
            if (GUILayout.Button("Clean Project"))
            {
                showWarning = true;
            }
        }

        if (showWarning)
        {
            GUILayout.Label("Warning:", EditorStyles.boldLabel);
            GUILayout.Label("Preferences in Prefabs could be lost! Continue?");
            if (GUILayout.Button("YES"))
            {
                warned = true;
                showWarning = false;
                CleanProject();
            }
            if (GUILayout.Button("NO"))
            {
                showWarning = false;
            }

        }
    }
    [MenuItem("Clean Project/Create 2D Game Directories")]
    static void Create2DFolders()
    {
        if (!AssetDatabase.IsValidFolder(@"Assets\Animations")) { AssetDatabase.CreateFolder("Assets", "Animations"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Materials")) { AssetDatabase.CreateFolder("Assets", "Materials"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Particles")) { AssetDatabase.CreateFolder("Assets", "Particles"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Physics2D")) { AssetDatabase.CreateFolder("Assets", "Physics2D"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Prefabs")) { AssetDatabase.CreateFolder("Assets", "Prefabs"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Scripts")) { AssetDatabase.CreateFolder("Assets", "Scripts"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Shader")) { AssetDatabase.CreateFolder("Assets", "Shader"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Sounds")) { AssetDatabase.CreateFolder("Assets", "Sounds"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Sprites")) { AssetDatabase.CreateFolder("Assets", "Sprites"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\UI")) { AssetDatabase.CreateFolder("Assets", "UI"); }
    }

    [MenuItem("Clean Project/Create 3D Game Directories")]
    static void Create3DFolders()
    {
        if (!AssetDatabase.IsValidFolder(@"Assets\Animations")) { AssetDatabase.CreateFolder("Assets", "Animations"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Materials")) { AssetDatabase.CreateFolder("Assets", "Materials"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Particles")) { AssetDatabase.CreateFolder("Assets", "Particles"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Physics")) { AssetDatabase.CreateFolder("Assets", "Physics"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Prefabs")) { AssetDatabase.CreateFolder("Assets", "Prefabs"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Scripts")) { AssetDatabase.CreateFolder("Assets", "Scripts"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Shader")) { AssetDatabase.CreateFolder("Assets", "Shader"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Sounds")) { AssetDatabase.CreateFolder("Assets", "Sounds"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Textures")) { AssetDatabase.CreateFolder("Assets", "Textures"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\Models")) { AssetDatabase.CreateFolder("Assets", "Models"); }
        if (!AssetDatabase.IsValidFolder(@"Assets\UI")) { AssetDatabase.CreateFolder("Assets", "UI"); }
    }



    void Generate()
    {
        if (gameType == 2)
        {

            if (!Directory.Exists(root))
            {
                //does not exist
                Debug.Log("CleanProject: [ASSETS] Folder doesnt exist!");
            }
            //2D
            else
            {
                if (!AssetDatabase.IsValidFolder(@"Assets\Animations")) { AssetDatabase.CreateFolder("Assets", "Animations"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Materials")) { AssetDatabase.CreateFolder("Assets", "Materials"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Physics2D")) { AssetDatabase.CreateFolder("Assets", "Physics2D"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Prefabs")) { AssetDatabase.CreateFolder("Assets", "Prefabs"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Scripts")) { AssetDatabase.CreateFolder("Assets", "Scripts"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Shader")) { AssetDatabase.CreateFolder("Assets", "Shader"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Sounds")) { AssetDatabase.CreateFolder("Assets", "Sounds"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Sprites")) { AssetDatabase.CreateFolder("Assets", "Sprites"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\UI")) { AssetDatabase.CreateFolder("Assets", "UI"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Particles")) { AssetDatabase.CreateFolder("Assets", "Particles"); }
                AssetDatabase.Refresh();
                Debug.Log("[CleanProject] generated directories for 2D");
            }
        }
        //3D
        else
        {
            string root = @"Assets\";
            if (!Directory.Exists(root))
            {
                //does not exist
                Debug.Log("CleanProject: [ASSETS] Folder doesnt exist!");
            }
            else
            {
                if (!AssetDatabase.IsValidFolder(@"Assets\Animations")) { AssetDatabase.CreateFolder("Assets", "Animations"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Materials")) { AssetDatabase.CreateFolder("Assets", "Materials"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Particles")) { AssetDatabase.CreateFolder("Assets", "Particles"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Physics")) { AssetDatabase.CreateFolder("Assets", "Physics"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Prefabs")) { AssetDatabase.CreateFolder("Assets", "Prefabs"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Scripts")) { AssetDatabase.CreateFolder("Assets", "Scripts"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Shader")) { AssetDatabase.CreateFolder("Assets", "Shader"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Sounds")) { AssetDatabase.CreateFolder("Assets", "Sounds"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Textures")) { AssetDatabase.CreateFolder("Assets", "Textures"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\Models")) { AssetDatabase.CreateFolder("Assets", "Models"); }
                if (!AssetDatabase.IsValidFolder(@"Assets\UI")) { AssetDatabase.CreateFolder("Assets", "UI"); }
                AssetDatabase.Refresh();
                Debug.Log("[CleanProject] generated directories for 3D");
            }
        }
    }

    void CleanProject()
    {
        if (warned)
        {
            Cleaner();
            Debug.Log("CLEANED PROJECT!");
        }
        warned = false;
    }

    [MenuItem("Clean Project/Tidyup! [experimental]")]
    static void Cleaner()
    {
        if (AssetDatabase.IsValidFolder(@"Assets\Animations")) {
            /*Get Animations and Animators*/
            int c = 0;
            string[] guids;
            // search for a Animations called Animations
            guids = AssetDatabase.FindAssets("t:Animation", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Animations\"+n);
                c++;
            }
            Debug.Log("Moved " + c + " Animation(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Materials")) {
            int c = 0;
            string[] guids;
            // search for a Material called Material
            guids = AssetDatabase.FindAssets("t:Material", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Materials\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Material(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Physics2D")) {
            /*Get physics*/
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:physicsMaterial2D", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Physics2D\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Physics2D(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Prefabs")) {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:prefab", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Prefabs\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Prefabs(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Scripts")) {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:Script", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Scripts\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Script(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Shader")) {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:Shader", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Shader\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Shader(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Sounds")) {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:AudioClip", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Sounds\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Sound(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Sprites")) {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:sprite", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Sprites\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Sprite(s)!");
        }
        if (AssetDatabase.IsValidFolder(@"Assets\Textures"))
        {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:texture2D", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Textures\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Texture(s)!");
        }
        /*if (AssetDatabase.IsValidFolder(@"Assets\Models"))
        {
            int c = 0;
            string[] guids;
            guids = AssetDatabase.FindAssets("t:object", new[] { "Assets" });
            foreach (string guid in guids)
            {
                string n = AssetDatabase.GUIDToAssetPath(guid).Replace("Assets/", "");
                AssetDatabase.MoveAsset(AssetDatabase.GUIDToAssetPath(guid), @"Assets\Models\" + n);
                c++;
            }
            Debug.Log("Moved " + c + " Model(s)!");
        }
        Debug.Log("Tidyed up!");*/
    }
}
