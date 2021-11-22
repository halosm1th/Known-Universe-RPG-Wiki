using System;
using System.Drawing;
using TravellerMapSystem.Worlds;

namespace TravellerMapSystem.Tools
{
    class DrawSubsector
    {
         //Dotnet Framework stuff
        
                private static readonly int xSize = 1050;
                private static readonly int ySize = 1500;
                private static readonly int HEIGHT = 140;
                private static readonly float WIDTH = HexWidth(HEIGHT);
                private static readonly Image GRID = CreateGrid();

                private KnownUniverseSubsector _knownUniverseSubsectorToDraw;
                
                public DrawSubsector(KnownUniverseSubsector knownUniverseSubsectorToDraw)
                {
                    _knownUniverseSubsectorToDraw = knownUniverseSubsectorToDraw;
                }
                
                public Bitmap GenerateSubSectorImage()
                {
                    var subsector = new Bitmap(GRID);
        
                    DrawWorlds(subsector);
        
                    return subsector;
                }
        
                private void DrawWorlds(Bitmap subsector)
                {
                    var fontSize = 18;
        
                    var graphics = Graphics.FromImage(subsector);
                    var brush = new SolidBrush(Color.Black);
                    var Font = new Font("Ariel", fontSize);
        
                    for (int row = 0; row < _knownUniverseSubsectorToDraw.Systems.GetLength(0); row++)
                    {
                        for (int col = 0; col < _knownUniverseSubsectorToDraw.Systems.GetLength(1); col++)
                        {
                            //Get HexCoords
        
                            DrawLocationText(row, col, fontSize, HEIGHT, WIDTH, Font, graphics, brush);
        
                            if ( _knownUniverseSubsectorToDraw.Systems[row, col].HasWorld)
                            {
                                var world = _knownUniverseSubsectorToDraw.Systems[row, col].PrimaryWorld as TravellerWorld;
                                DrawSystemName(row, col, fontSize, HEIGHT, WIDTH, Font, graphics, brush);
                                DrawUniversalWorldProfile(HEIGHT, row, col, WIDTH, Font, graphics, brush, world);
        
        
                                //Get Text Coords
                                var y = (float)(HEIGHT / 2) + (row * HEIGHT);
                                if (col % 2 == 1) y += HEIGHT / 2;
                                y += fontSize * 1.5f;
        
                                var text = $"{ world.Stations}".ToUpper();
        
                                var x = col * (WIDTH * 0.75f);
                                x += (WIDTH / 2) - (text.Length * Font.SizeInPoints) / 2.0f;
                                x += Font.Size;
        
                                graphics.DrawString(text, Font, brush, x, y);
                            }
                        }
                    }
                }
        
                private void DrawSystemName(int row, int col, int fontSize, int height, float width, Font Font, Graphics graphics,
                    SolidBrush brush)
                {
                    var text = $"{ _knownUniverseSubsectorToDraw.Systems[row, col].Name}";
        
                    if (text.Length > 10)
                    {
                        text = text.Substring(0, 10);
                    }
        
                    var y = (fontSize * 2) + (row * height);
                    if (col % 2 == 1) y += height / 2;
        
                    var x = col * (width * 0.75f);
                    x += (width / 2) - (text.Length * Font.Size) / 2.8f;
        
                    graphics.DrawString(text, Font, brush, x, y);
                }
        
                private static void DrawLocationText(int row, int col, int fontSize, int height, float width, Font Font,
                    Graphics graphics, SolidBrush brush)
                {
                    var text = $"{col + 1} {row + 1}";
        
                    var y = (fontSize) + (row * height);
                    if (col % 2 == 1) y += height / 2;
        
                    var x = col * (width * 0.75f);
                    x += (width / 2) - (text.Length * Font.SizeInPoints) / 2.0f;
        
                    graphics.DrawString(text, Font, brush, x, y - fontSize);
                }
        
                private static void DrawUniversalWorldProfile(int height, int row, int col, float width, Font Font, Graphics graphics,
                    SolidBrush brush, TravellerWorld travellerWorld)
                {
                    //Get Text Coords
                    var y = (height / 2) + (row * height);
                    if (col % 2 == 1) y += height / 2;
        
                    var text = $"{travellerWorld.UWP}".ToUpper();
        
                    var x = col * (width * 0.75f);
                    x += (width / 2) - (text.Length * Font.SizeInPoints) / 2.0f;
                    x += Font.Size;
        
                    graphics.DrawString(text, Font, brush, x, y);
                }
        
                private static PointF[] HexToPoints(float height, int row, int Col)
                {
                    float width = HexWidth(height);
                    float y = height / 2;
                    float x = 0;
        
                    y += row * height;
                    if (Col % 2 == 1) y += height / 2;
        
                    x += Col * (width * 0.75f);
        
                    return new PointF[]
                    {
                        new PointF(x,y),
                        new PointF(x + width * 0.25f,y - height/2),
                        new PointF(x + width * 0.75f, y - height / 2),
                        new PointF(x + width, y),
                        new PointF(x + width * 0.75f, y + height / 2),
                        new PointF(x + width * 0.25f, y + height / 2),
                    };
                }
        
                private static float HexWidth(float height)
                {
                    return (float)(4 * (height / 2 / Math.Sqrt(3)));
                }
        
                private static Image CreateGrid()
                {
                    var grid =new Bitmap(xSize, ySize);
                    var graphics = Graphics.FromImage(grid);
                    var brush = new SolidBrush(Color.White);
                    graphics.FillRectangle(brush,new Rectangle(0,0,xSize,ySize));
                    var pen = new Pen(Color.Black);
        
                    for (int row = 0; row < 10; row++)
                    {
                        for (int col = 0; col < 8; col++)
                        {
                            var points = HexToPoints(HEIGHT, row, col);
                            graphics.DrawPolygon(pen, points);
                        }
                    }
        
        
                    return grid as Image;
                }

    }
}