using UnityEditor;
using UnityEngine;

public class TextureImportSettings : AssetPostprocessor
{
    // This method runs before a texture is imported or re-imported
    void OnPreprocessTexture()
    {
        // Check if the imported file is a PNG
        if (assetPath.EndsWith(".png") || assetPath.EndsWith(".jpg") )
            {
                // Get the TextureImporter instance
                TextureImporter textureImporter = (TextureImporter)assetImporter;

                // Check if the current texture already has the "Uncompressed" compression
                if (textureImporter.textureCompression != TextureImporterCompression.Uncompressed )
                    {
                        // Only modify settings if the compression is not already "Uncompressed"
                        textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
                        // Apply the changes
                        AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                    }
            }
    }
}
