using System;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using TravellerMapSystem.Worlds;

namespace TravellerMapSystem.Tools
{
    internal class DrawSubsector
    {
        //Dotnet Framework stuff

        private static readonly int xSize = 1050;
        private static readonly int ySize = 1500;
        private static readonly int HEIGHT = 140;
        private static readonly float WIDTH = HexWidth(HEIGHT);
        private static readonly Image GRID = CreateGrid();

        private readonly KnownUniverseSubsector _knownUniverseSubsectorToDraw;

        public DrawSubsector(KnownUniverseSubsector knownUniverseSubsectorToDraw)
        {
            _knownUniverseSubsectorToDraw = knownUniverseSubsectorToDraw;
        }

        public Image GenerateSubSectorImage()
        {
            Image subsector = GRID.CloneAs<Rgb24>();
            DrawWorlds(subsector);

            return subsector;
        }

        private void DrawWorlds(Image subsector)
        {
            var fontSize = 16;

            var brush = new SolidBrush(Color.Black);
            var fontWorld = SystemFonts.CreateFont("High Versian", fontSize);
            var fontRest = SystemFonts.CreateFont("Arial", fontSize+2);

            for (var row = 0; row < _knownUniverseSubsectorToDraw.Systems.GetLength(0); row++)
            for (var col = 0; col < _knownUniverseSubsectorToDraw.Systems.GetLength(1); col++)
                //Get HexCoords

                if (_knownUniverseSubsectorToDraw.Systems[row, col].HasWorld)
                {
                    var world =
                        _knownUniverseSubsectorToDraw.Systems[row, col].PrimaryWorld as TravellerWorld;
                    DrawSystemName(row, col, fontSize, HEIGHT, WIDTH, fontWorld, subsector, brush);
                    DrawUniversalWorldProfile(HEIGHT, row, col, WIDTH, fontRest, subsector, brush, world);

                    DrawSystemStation(subsector, row, col, fontSize, world, fontRest, brush);
                }
        }

        private static void DrawSystemStation(Image subsector, int row, int col, int fontSize, TravellerWorld? world,
            Font? Font, SolidBrush? brush)
        {
            //Get Text Coords
            var y = (float)(HEIGHT / 2) + row * HEIGHT;
            if (col % 2 == 1) y += HEIGHT / 2;
            y += fontSize * 1.5f;

            var text = $"{world.Stations}".ToUpper();

            var x = col * (WIDTH * 0.75f);
            x += WIDTH / 2 - text.Length * Font.Size / 2.8f;
            x += Font.Size;

            subsector.Mutate(ctx => ctx.DrawText(text, Font, brush, new PointF(x, y)));
        }

        private void DrawSystemName(int row, int col, int fontSize, int height, float width, Font Font, Image graphics,
            SolidBrush brush)
        {
            var text = $"{_knownUniverseSubsectorToDraw.Systems[row, col].Name}";

            if (text.Length > 10) text = text.Substring(0, 10);

            var y = fontSize * 2 + row * height;
            if (col % 2 == 1) y += height / 2;

            var x = col * (width * 0.75f);
            x += width / 2 - text.Length * Font.Size / 4.5f;

            graphics.Mutate(ctx => ctx.DrawText(text, Font, brush, new PointF(x, y)));
        }

        private static void DrawLocationText(int row, int col, int fontSize, int height, float width, Font Font,
            Image graphics, SolidBrush brush)
        {
            var text = $"{col + 1} {row + 1}";

            var y = fontSize + row * height;
            if (col % 2 == 1) y += height / 2;

            var x = col * (width * 0.75f);
            x += width / 2 - text.Length * Font.Size / 4.0f;

            graphics.Mutate(ctx => ctx.DrawText(text, Font, brush, new PointF(x, y - fontSize)));
        }

        private static void DrawUniversalWorldProfile(int height, int row, int col, float width, Font Font,
            Image graphics,
            SolidBrush brush, TravellerWorld travellerWorld)
        {
            //Get Text Coords
            var y = height / 2 + row * height;
            if (col % 2 == 1) y += height / 2;

            var text = $"{travellerWorld.UWP}".ToUpper();

            var x = col * (width * 0.75f);
            x += width / 2 - text.Length * Font.Size / 2.5f;
            x += Font.Size;

            graphics.Mutate(ctx => ctx.DrawText(text, Font, brush, new PointF(x, y)));
        }

        private static PointF[] HexToPoints(float height, int row, int Col)
        {
            var width = HexWidth(height);
            var y = height / 2;
            float x = 0;

            y += row * height;
            if (Col % 2 == 1) y += height / 2;

            x += Col * (width * 0.75f);

            return new[]
            {
                new(x, y),
                new PointF(x + width * 0.25f, y - height / 2),
                new PointF(x + width * 0.75f, y - height / 2),
                new PointF(x + width, y),
                new PointF(x + width * 0.75f, y + height / 2),
                new PointF(x + width * 0.25f, y + height / 2)
            };
        }

        private static float HexWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        }

        private static Image CreateGrid()
        {
            Image retImage = null;
            var fontSize = 18;
            using (var grid = new Image<Rgb24>(xSize, ySize))
            {
                var brush = new SolidBrush(Color.White);
                var BlackBrush = new SolidBrush(Color.Black);
                var font = SystemFonts.CreateFont("Arial", fontSize);
                grid.Mutate(x => x.Fill(brush, new Rectangle(0, 0, xSize, ySize)));

                for (var row = 0; row < 10; row++)
                for (var col = 0; col < 8; col++)
                {
                    var points = HexToPoints(HEIGHT, row, col);
                    grid.Mutate(x => x.DrawPolygon(Color.Black, 2, points));


                    DrawLocationText(row, col, fontSize, HEIGHT, WIDTH, font, grid, BlackBrush);
                }

                retImage = grid.Clone();
            }


            return retImage;
        }
    }
}