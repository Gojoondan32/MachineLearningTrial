using UnityEngine;

public enum AnimalAge{child, adult}

public struct AnimalStats{
    
    private AnimalAge _age;
    private float _size;
    private float _speed;
    private float _maxHunger;

    public AnimalStats(float size, float speed, float maxHunger){
        _size = size;
        _speed = speed;
        _maxHunger = maxHunger;

        _age = AnimalAge.child;
    }

    public float GetSpeed() => _speed;
    public void IncreaseSpeed(float speedAmount) => _speed += speedAmount;
    public Vector3 GetCurrentSize() => new Vector3(_size, _size, _size);
    public void GrowUp(Transform animal){
        _age = AnimalAge.adult;
        _size = 0.5f;
        animal.localScale = GetCurrentSize();
    }
    public void IncreaseSize(float size) => _size += size;

}
