using UnityEngine;

namespace TiltBrush
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class PremultiplyAlpha : MonoBehaviour
    {
        public Shader premultipliedAlphaShader;

        private Material premultipliedAlphaMaterial;

        void Start()
        {
            if (premultipliedAlphaShader == null)
            {
                Debug.LogError("Missing shader.");
                enabled = false;
                return;
            }

            premultipliedAlphaMaterial = new Material(premultipliedAlphaShader);
        }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            if (premultipliedAlphaMaterial != null)
            {
                Graphics.Blit(src, dest, premultipliedAlphaMaterial);
            }
            else
            {
                Graphics.Blit(src, dest);
            }
        }
    }
}
