//* Создать класс Figure для работы с геометрическими фигурами. В качестве полей класса задаются цвет
//фигуры, состояние «видимое/невидимое». Реализовать операции: передвижение геометрической фигуры по
//горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый). Метод вывода на экран
//должен выводить состояние всех полей объекта. Создать класс Point (точка) как потомок геометрической
//фигуры. Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который
//вычисляет площадь окружности. Создать класс Rectangle (прямоугольник) как потомок точки, реализовать
//метод вычисления площади прямоугольника. Точка, окружность, прямоугольник должны поддерживать методы
//передвижения по горизонтали и вертикали, изменения цвета.

double area;

Circle circle = new Circle(5, 4, 2, "blue", true);
circle.ColorShift("white");
area = circle.GetArea();
Console.WriteLine(area);

Rectangle rectangle = new Rectangle(5, 2, 3, 3, "red", true);
area = rectangle.GetArea();
Console.WriteLine(area);
int[] pointsRect = rectangle.MovementX(1);
foreach(int point in pointsRect)
{
    Console.Write($"{point}\t");
}

sealed class Rectangle: Point, IGetArea
{
    int point2X, point2Y, point3X, point3Y, point4X, point4Y;
    int rectangleLength, rectangleWidth;

    public Rectangle(int rL, int rW, int pointX, int pointY, string _color, bool _visible):
        base(pointX, pointY, _color, _visible)
    {
        rectangleLength = rL;
        rectangleWidth = rW;
        point2X = pointX + rL;
        point2Y = pointY;
        point3X = point2X;
        point3Y = point2Y + rW;
        point4X = pointX;
        point4Y = point3Y;
    }
    new public int[] MovementX(int step)
    {
        int[] result = new int[4]; 
        result[0] = base.positionX += step;
        result[1] = point2X += step;
        result[2] = point3X += step;
        result[3] = point4X += step;
        return result;
    }
    new public int[] MovementY(int step)
    {
        int[] result = new int[4];
        result[0] = base.positionY += step;
        result[1] = point2Y += step;
        result[2] = point3Y += step;
        result[3] = point4Y += step;
        return result;
    }
    public double GetArea()
    {
        return rectangleLength * rectangleWidth;
    }
}

sealed class Circle: Point, IGetArea
{
    private int radius;

    public Circle(int radius, int pX, int pY, string _color, bool _visible): 
        base (pX, pY, _color, _visible)
    {
        this.radius = radius;
    }
    public double GetArea()
    {
        return 3.14 * (radius * radius);
    }
}

class Point: Figure
{
    private protected int positionX;
    private protected int positionY;

    public Point(int pX, int pY, string _color, bool _visible):
        base(_color, _visible)
    {
        this.positionX = pX;
        this.positionY = pY;
    }

    public override int MovementX(int step)
    {
        return positionX += step;
    }
    public override int MovementY(int step)
    {
        return positionY += step;
    }
    public override string ColorShift(string newColor)
    {
        return color = newColor;
    }
    public override bool VisibleShift(bool newVisible)
    {
        return visible = newVisible;
    }
}

abstract class Figure
{
    private protected string color;
    private protected bool visible;

    public Figure(string _color, bool _visible)
    {
        this.color = _color;
        this.visible = _visible;
    }

    /// <summary>
    /// Передвижение по оси Х
    /// </summary>
    abstract public int MovementX(int step);
    /// <summary>
    /// Передвижение по оси Y
    /// </summary>
    abstract public int MovementY(int step);
    /// <summary>
    /// Изменение цвета
    /// </summary>
    abstract public string ColorShift(string newColor);
    /// <summary>
    /// Опрос состояния
    /// </summary>
    abstract public bool VisibleShift(bool newVisible);
}

interface IGetArea{
    /// <summary>
    /// Вычисление площади
    /// </summary>
    /// <returns></returns>
    public double GetArea();
}