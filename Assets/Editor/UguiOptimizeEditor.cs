using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UguiOptimizeEditor : Editor {
	[MenuItem("GameObject/UI/Image")]
	public static void CreatImage() {
        GameObject image = new GameObject("Image", typeof(Image));
        image.GetComponent<Image>().raycastTarget = false;

        if (Selection.activeTransform == null || Selection.activeTransform.GetComponent<RectTransform>() == null) {
            GameObject go = new GameObject("Canvas", typeof(Canvas));
            image.transform.SetParent(go.transform);
        } else {
            image.transform.SetParent(Selection.activeTransform);
        }
	}

    [MenuItem("GameObject/UI/Text")]
    public static void CreatText() {
        GameObject textObj = new GameObject("Text", typeof(Text));
        Text text = textObj.GetComponent<Text>();
        text.raycastTarget = false;
        text.supportRichText = false;
        text.text = "New Text";
        text.color = Color.black;

        if (Selection.activeTransform == null || Selection.activeTransform.GetComponent<RectTransform>() == null) {
            GameObject go = new GameObject("Canvas", typeof(Canvas));
            textObj.transform.SetParent(go.transform);
        } else {
            textObj.transform.SetParent(Selection.activeTransform);
        }
    }

}
