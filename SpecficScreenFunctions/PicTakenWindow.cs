using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PicTakenWindow : MonoBehaviour
{
    public static PicTakenWindow instance;

    public Transform windowTransform;

    public Image screenshotWindow;

    public Button downloadButton;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        downloadButton.onClick.AddListener(DownloadImageToNativeGallery);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWindow( )
    {
        windowTransform.gameObject.SetActive(true);
    }

    public void HideWindow( )
    {
        windowTransform.gameObject.SetActive(false);
    }

    public void TakeScreenshot(Texture rawImage)
    {
        //rawImage.mainTexture.encode
        Texture2D screenshotTexture = GetReadableTexture2d(rawImage);
        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, rawImage.width, rawImage.height), Vector2.zero);
        screenshotWindow.sprite = screenshotSprite;



    }

    public void DownloadImageToNativeGallery( )
    {
        StartCoroutine(TakeScreenshotAndSave());

    }

    public bool takingScreenshot = false;

    public void CaptureScreenshot()
    {
        
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        takingScreenshot = true;
        yield return new WaitForEndOfFrame();

        var mediaBytes = GetReadableTexture2d(screenshotWindow.mainTexture).EncodeToPNG();
        
        

        // Save the screenshot to Gallery/Photos
        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        CrackerNotification.instance.ShowCrackerMessage("Permission result: " + NativeGallery.SaveImageToGallery(mediaBytes, Application.productName + " Captures", name));
        takingScreenshot = false;
        //CrackerNotification.instance.ShowCrackerMessage("Image Saved");
    }


    private Texture2D GetReadableTexture2d(Texture texture)
    {
        var tmp = RenderTexture.GetTemporary(
            texture.width,
            texture.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear
        );
        Graphics.Blit(texture, tmp);

        var previousRenderTexture = RenderTexture.active;
        RenderTexture.active = tmp;

        var texture2d = new Texture2D(texture.width, texture.height);
        texture2d.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2d.Apply();

        RenderTexture.active = previousRenderTexture;
        RenderTexture.ReleaseTemporary(tmp);
        return texture2d;
    }
}
