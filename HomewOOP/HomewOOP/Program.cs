//* Создать класс Figure для работы с геометрическими фигурами. В качестве полей класса задаются цвет
//фигуры, состояние «видимое/невидимое». Реализовать операции: передвижение геометрической фигуры по
//горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый). Метод вывода на экран
//должен выводить состояние всех полей объекта. Создать класс Point (точка) как потомок геометрической
//фигуры. Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который
//вычисляет площадь окружности. Создать класс Rectangle (прямоугольник) как потомок точки, реализовать
//метод вычисления площади прямоугольника. Точка, окружность, прямоугольник должны поддерживать методы
//передвижения по горизонтали и вертикали, изменения цвета.

class Rectangle: Point
{
    
}

class Circle: Point
{

}

class Point: Figure
{

}

abstract class Figure
{
    private string color;
    private bool visible;

    public Figure(string _color, bool _visible)
    {
        this.color = _color;
        this.visible = _visible;
    }
    /// <summary>
    /// Передвижение по оси Х
    /// </summary>
    abstract public void MovementX();
    /// <summary>
    /// Передвижение по оси Y
    /// </summary>
    abstract public void MovementY();
    /// <summary>
    /// Вычисление площади
    /// </summary>
    /// <returns></returns>
    abstract public double GetArea();
    /// <summary>
    /// Изменение цвета
    /// </summary>
    abstract public void ColorShift();
    /// <summary>
    /// Изменение цвета
    /// </summary>
    abstract public bool VisibleShift();
}