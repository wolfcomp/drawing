﻿/* Una.Drawing                                                 ____ ___
 *   A declarative drawing library for FFXIV.                 |    |   \____ _____        ____                _
 *                                                            |    |   /    \\__  \      |    \ ___ ___ _ _ _|_|___ ___
 * By Una. Licensed under AGPL-3.                             |    |  |   |  \/ __ \_    |  |  |  _| .'| | | | |   | . |
 * https://github.com/una-xiv/drawing                         |______/|___|  (____  / [] |____/|_| |__,|_____|_|_|_|_  |
 * ----------------------------------------------------------------------- \/ --- \/ ----------------------------- |__*/

using System;
using SkiaSharp;

namespace Una.Drawing.Generator;

internal class GradientGenerator : IGenerator
{
    public int RenderOrder => 1;

    public void Generate(SKCanvas canvas, Node node)
    {
        ComputedStyle style = node.ComputedStyle;
        Size          size  = node.Bounds.PaddingSize;

        if (null == style.BackgroundGradient || style.BackgroundGradient.IsEmpty) return;

        int inset = style.BackgroundGradient.Inset;

        using var paint = new SKPaint();
        SKRect    rect  = new(inset, inset, size.Width - inset, size.Height - inset);

        paint.IsAntialias = true;
        paint.Style       = SKPaintStyle.Fill;
        paint.Shader      = CreateShader(size, style.BackgroundGradient);

        if (style.BorderRadius == 0) {
            canvas.DrawRect(rect, paint);
            return;
        }

        var radius = (float)style.BorderRadius;

        RoundedCorners corners     = style.RoundedCorners;
        SKPoint        topLeft     = corners.HasFlag(RoundedCorners.TopLeft) ? new(radius, radius) : new(0, 0);
        SKPoint        topRight    = corners.HasFlag(RoundedCorners.TopRight) ? new(radius, radius) : new(0, 0);
        SKPoint        bottomRight = corners.HasFlag(RoundedCorners.BottomRight) ? new(radius, radius) : new(0, 0);
        SKPoint        bottomLeft  = corners.HasFlag(RoundedCorners.BottomLeft) ? new(radius, radius) : new(0, 0);
        SKRoundRect    roundRect   = new SKRoundRect(rect, radius, radius);

        roundRect.SetRectRadii(rect, [topLeft, topRight, bottomRight, bottomLeft]);
        canvas.DrawRoundRect(roundRect, paint);
    }

    private static SKShader CreateShader(Size size, GradientColor gradientColor)
    {
        return gradientColor.Type switch {
            GradientType.Horizontal => SKShader.CreateLinearGradient(
                new(gradientColor.Inset, gradientColor.Inset),
                new(size.Width - gradientColor.Inset, gradientColor.Inset),
                new[] { Color.ToSkColor(gradientColor.Color1), Color.ToSkColor(gradientColor.Color2) },
                null,
                SKShaderTileMode.Clamp
            ),
            GradientType.Vertical => SKShader.CreateLinearGradient(
                new(gradientColor.Inset, gradientColor.Inset),
                new(gradientColor.Inset, size.Height - gradientColor.Inset),
                new[] { Color.ToSkColor(gradientColor.Color1), Color.ToSkColor(gradientColor.Color2) },
                null,
                SKShaderTileMode.Clamp
            ),
            GradientType.Radial => SKShader.CreateRadialGradient(
                new(size.Width / 2, size.Height / 2),
                (size.Width - gradientColor.Inset) / 2,
                new[] { Color.ToSkColor(gradientColor.Color1), Color.ToSkColor(gradientColor.Color2) },
                null,
                SKShaderTileMode.Clamp
            ),
            _ => throw new InvalidOperationException(nameof(gradientColor.Type))
        };
    }
}
