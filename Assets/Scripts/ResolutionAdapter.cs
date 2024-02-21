using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform))]
public class ResolutionAdapter : MonoBehaviour
{
    private Image targetImage;
    private RectTransform imageRect;
    private Vector2 screenSize;

    private void Awake()
    {
        screenSize = new Vector2(1170, 2532); //Default screen size (iphone12)
       
        imageRect = GetComponent<RectTransform>();
        if (screenSize.x != Screen.width || screenSize.y != Screen.height)
        {
            ResizeImage();
            screenSize = new Vector2(Screen.width, Screen.height);
        }
    }

    public void ResizeImage()
    {
        Vector2 imagePos = imageRect.anchoredPosition;

        float imageW = imageRect.rect.width;
        float imageH = imageRect.rect.height;

        float rap = imageW / imageH;

        float imageWPercent = imageW / screenSize.x;
        float imageHPercent = imageH / screenSize.y;

        float newWidth = Screen.width * imageWPercent;
        float newHeight = Screen.height * imageHPercent;

        float min = Mathf.Min(newWidth, newHeight);

        if (min == newWidth) {
            newHeight = (1 / rap) * newWidth;
        } else {
            newWidth = rap * newHeight;
        }

        float percentX = imagePos.x / screenSize.x;
        float percentY = imagePos.y / screenSize.y;

        float posX = Screen.width * percentX;
        float posY = Screen.height * percentY;

        imageRect.sizeDelta = new Vector2(newWidth, newHeight);
        imageRect.anchoredPosition = new Vector2(posX, posY);
    }
}