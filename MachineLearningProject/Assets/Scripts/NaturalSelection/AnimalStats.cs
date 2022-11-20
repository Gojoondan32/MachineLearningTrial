public enum AnimalAge{child, adult}

public struct AnimalStats{
    
    private AnimalAge _age;
    private float _size;
    private float _speed;

    public AnimalStats(AnimalAge age, float size, float speed){
        _age = age;
        _size = size;
        _speed = speed;
    }

    public void IncreaseSpeed(float speedAmount) => _speed += speedAmount;
    public void IncreaseSize(float size) => _size += size;

}
