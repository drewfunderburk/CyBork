using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTiler : MonoBehaviour
{
    [SerializeField, AssetsOnly]
    private GameObject[] _images;

    [SerializeField]
    private bool _stitchPerfectly = true;

    [SerializeField, MinMaxSlider(0, 5, true), HideIf("_stitchPerfectly")]
    private Vector2 _spawnDelayRange;

    [SerializeField]
    private float _imageSpeed = 1f;

    private GameObject _currentImage;
    private GameObject _nextImage;
    private List<GameObject> _spawnedImages;

    private float _timer;
    private float _distance;

    private void Start()
    {
        foreach (GameObject obj in _images)
            if(!obj.TryGetComponent(out SpriteRenderer sprite))
                Debug.LogWarning(obj.ToString() + " has no sprite renderer");
    }

    private void Update()
    {
        HandleSpawning();
        UpdateSpawnedImages();
    }

    private GameObject GetRandomImage()=> _images[Random.Range(0, _images.Length)];

    private void UpdateSpawnedImages()
    {
        throw new System.NotImplementedException();
    }

    private void HandleSpawning()
    {
        if (_stitchPerfectly)
        {
            if (_currentImage == null)
            {
                _currentImage = GetRandomImage();
                _spawnedImages.Add(Instantiate(_currentImage, transform));
            }
            if (_nextImage == null)
            {
                _nextImage = GetRandomImage();
                GameObject image = Instantiate(_nextImage, transform);
                
            }
        }
        else
        {

        }
    }
}
