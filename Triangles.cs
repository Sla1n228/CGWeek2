namespace CGP;

public partial class Triangles : Form
{
    public Triangles()
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;

        InitializeComponent();
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Color.Black, 2);

        Point[] trianglePoints =
        {
            new Point(100,100),
            new Point(500,100),
            new Point(300,446)
        };
        
        g.DrawPolygon(pen, trianglePoints);

        int[] sideLengths;
        do
        {
            trianglePoints = getChildTrianglePoints(trianglePoints);
            sideLengths =
            [
                (int)MathF.Sqrt((trianglePoints[0].X - trianglePoints[1].X) * (trianglePoints[0].X - trianglePoints[1].X)) + (trianglePoints[0].Y - trianglePoints[1].Y) * (trianglePoints[0].Y - trianglePoints[1].Y),
                (int)MathF.Sqrt((trianglePoints[1].X - trianglePoints[2].X) * (trianglePoints[1].X - trianglePoints[2].X)) + (trianglePoints[1].Y - trianglePoints[2].Y) * (trianglePoints[1].Y - trianglePoints[2].Y),
                (int)MathF.Sqrt((trianglePoints[0].X - trianglePoints[2].X) * (trianglePoints[0].X - trianglePoints[2].X)) + (trianglePoints[0].Y - trianglePoints[2].Y) * (trianglePoints[0].Y - trianglePoints[2].Y)
            ];
            g.DrawPolygon(pen, trianglePoints);
        } while (sideLengths[0] >= 1 &&  sideLengths[1] >= 1 && sideLengths[2] >= 1);
    }

    private static Point[] getChildTrianglePoints(Point[] trianglePoints)
    {
        return new Point[]
        {
            new Point((trianglePoints[0].X + trianglePoints[1].X)/2, (trianglePoints[0].Y + trianglePoints[1].Y)/2),
            new Point((trianglePoints[1].X + trianglePoints[2].X)/2, (trianglePoints[1].Y + trianglePoints[2].Y)/2),
            new Point((trianglePoints[0].X + trianglePoints[2].X)/2, (trianglePoints[0].Y + trianglePoints[2].Y)/2)
        };
    }
}