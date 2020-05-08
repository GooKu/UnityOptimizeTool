using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UguiOptimizeEditor : MonoBehaviour
{
    [MenuItem("GameObject/UI/Image")]
    public static void CreatImage()
    {
        GameObject imageObj = new GameObject("Image", typeof(Image));
        imageObj.GetComponent<Image>().raycastTarget = false;
        setParent(imageObj);
    }

    [MenuItem("GameObject/UI/Text")]
    public static void CreatText()
    {
        GameObject textObj = new GameObject("Text", typeof(Text));
        Text text = textObj.GetComponent<Text>();
        text.raycastTarget = false;
        text.supportRichText = false;
        text.text = "New Text";
        text.color = Color.black;
        setParent(textObj);
    }

    private static void setParent(GameObject obj)
    {
        Transform objTransform = obj.transform;

        if (Selection.activeTransform == null || Selection.activeTransform.GetComponent<RectTransform>() == null)
        {
            Canvas canvas = (Canvas)FindObjectOfType(typeof(Canvas));
            GameObject canvasObj = null;
            if (canvas == null)
            {
                canvasObj = new GameObject("Canvas", typeof(Canvas));
                canvasObj.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                canvasObj.AddComponent<CanvasScaler>();
                canvasObj.AddComponent<GraphicRaycaster>();
                checkRootEventSystem();
            }
            else
            {
                canvasObj = canvas.gameObject;
            }

            objTransform.SetParent(canvasObj.transform);
        }
        else
        {
            objTransform.SetParent(Selection.activeTransform);
        }
        objTransform.localPosition = Vector2.zero;
        objTransform.localScale = Vector2.one;
    }

    private static void checkRootEventSystem()
    {
        GameObject[] rootObjs = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in rootObjs)
        {
            if (obj.GetComponent<EventSystem>() != null)
                return;
        }
        GameObject eventSystemObj = new GameObject("EventSystem", typeof(EventSystem));
        eventSystemObj.AddComponent<StandaloneInputModule>();
    }

}
