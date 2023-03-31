using UnityEngine;
using UnityEngine.UI;

public class CustomRenderer : MonoBehaviour
{
    private Texture2D _result;

    [SerializeField]
    private RenderTexture enemyLights;

    [SerializeField]
    private RenderTexture playerLights;

    [SerializeField]
    private RawImage target;

    private void Awake()
    {
        _result = new Texture2D(enemyLights.width, enemyLights.height, TextureFormat.RGBA32, false);
        _result.filterMode = enemyLights.filterMode;
    }

    private void LateUpdate()
    {
        Texture2D playerTex = playerLights.ToTexture();
        Texture2D enemyTex = enemyLights.ToTexture();

        Color[] playerArray = playerTex.GetPixels();
        Color[] enemyArray = enemyTex.GetPixels();

        for (int i = 0; i < playerArray.Length; i++)
        {
            Color playerColor = playerArray[i];
            Color enemyColor = enemyArray[i];

            int x = i % playerTex.width, y = i / playerTex.width;

            if (playerColor != Color.black && playerColor.a != 0)
                _result.SetPixel(x, y, playerColor + enemyColor);
            else
                _result.SetPixel(x, y, Color.clear);
        }

        Destroy(playerTex);
        Destroy(enemyTex);

        _result.Apply();
        target.texture = _result;
    }

    private void OnDestroy()
    {
        Destroy(_result);
    }
}
