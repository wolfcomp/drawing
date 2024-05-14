﻿/* Una.Drawing                                                 ____ ___
 *   A declarative drawing library for FFXIV.                 |    |   \____ _____        ____                _
 *                                                            |    |   /    \\__  \      |    \ ___ ___ _ _ _|_|___ ___
 * By Una. Licensed under AGPL-3.                             |    |  |   |  \/ __ \_    |  |  |  _| .'| | | | |   | . |
 * https://github.com/una-xiv/drawing                         |______/|___|  (____  / [] |____/|_| |__,|_____|_|_|_|_  |
 * ----------------------------------------------------------------------- \/ --- \/ ----------------------------- |__*/

using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Una.Drawing;

internal class ComputedStyle
{
    /// <summary>
    /// Invoked when a property that affects the layout has changed.
    /// </summary>
    internal Action? OnLayoutPropertyChanged;

    /// <summary>
    /// Invoked when a property that affects the graphical aspects of the node
    /// have been changed.
    /// </summary>
    internal Action? OnPaintPropertyChanged;

    internal ComputedStyle()
    {
        Reset();
    }

    /// <inheritdoc cref="Style.IsVisible"/>
    internal bool IsVisible { get; set; } = true;

    /// <inheritdoc cref="Style.Anchor"/>
    internal Anchor Anchor { get; set; } = Anchor.TopLeft;

    /// <inheritdoc cref="Style.Size"/>
    internal Size Size { get; set; } = new();

    /// <inheritdoc cref="Style.Flow"/>
    internal Flow Flow { get; set; } = Flow.Horizontal;

    /// <inheritdoc cref="Style.Gap"/>
    internal int Gap { get; set; }

    /// <inheritdoc cref="Style.Padding"/>
    internal EdgeSize Padding { get; set; } = new();

    /// <inheritdoc cref="Style.Margin"/>
    internal EdgeSize Margin { get; set; } = new();

    internal bool Stretch { get; set; }

    /// <inheritdoc cref="Style.Color"/>
    internal Color Color { get; set; } = new(0xFFC0C0C0);

    /// <inheritdoc cref="Style.Font"/>
    internal uint Font { get; set; }

    /// <inheritdoc cref="Style.FontSize"/>
    internal int FontSize { get; set; }

    /// <inheritdoc cref="Style.LineHeight"/>
    internal float LineHeight { get; set; }

    /// <inheritdoc cref="Style.WordWrap"/>
    internal bool WordWrap { get; set; }

    /// <inheritdoc cref="Style.TextAlign"/>
    internal Anchor TextAlign { get; set; } = Anchor.TopLeft;

    /// <inheritdoc cref="Style.OutlineSize"/>
    internal float OutlineSize { get; set; }

    /// <inheritdoc cref="Style.TextOffset"/>
    internal Vector2 TextOffset { get; set; }

    /// <inheritdoc cref="Style.BackgroundColor"/>
    internal Color? BackgroundColor { get; set; }

    /// <inheritdoc cref="Style.BorderColor"/>
    internal BorderColor? BorderColor { get; set; }

    /// <inheritdoc cref="Style.BorderInset"/>
    internal float BorderInset { get; set; }

    /// <inheritdoc cref="Style.BorderRadius"/>
    internal int BorderRadius { get; set; }

    /// <inheritdoc cref="Style.BorderWidth"/>
    internal EdgeSize BorderWidth { get; set; } = new();

    /// <inheritdoc cref="Style.StrokeColor"/>
    internal Color? StrokeColor { get; set; }

    /// <inheritdoc cref="Style.StrokeWidth"/>
    internal int StrokeWidth { get; set; }

    /// <inheritdoc cref="Style.StrokeInset"/>
    internal float StrokeInset { get; set; }

    /// <inheritdoc cref="Style.RoundedCorners"/>
    internal RoundedCorners RoundedCorners { get; set; }

    /// <inheritdoc cref="Style.BackgroundGradient"/>
    internal GradientColor? BackgroundGradient { get; set; }

    /// <inheritdoc cref="Style.OutlineColor"/>
    internal Color? OutlineColor { get; set; }

    /// <inheritdoc cref="Style.TextShadowSize"/>
    internal float TextShadowSize { get; set; }

    /// <inheritdoc cref="Style.TextShadowColor"/>
    internal Color? TextShadowColor { get; set; }

    /// <inheritdoc cref="Style.IconId"/>
    internal uint? IconId { get; set; }

    /// <inheritdoc cref="Style.IconInset"/>
    internal EdgeSize? IconInset { get; set; }

    /// <inheritdoc cref="Style.IconOffset"/>
    internal Vector2? IconOffset { get; set; }

    /// <inheritdoc cref="Style.IconRounding"/>
    internal float IconRounding { get; set; }

    /// <inheritdoc cref="Style.IconGrayscale"/>
    internal bool IconGrayscale { get; set; }

    /// <inheritdoc cref="Style.IconContrast"/>
    internal float IconContrast { get; set; }

    /// <inheritdoc cref="Style.Opacity"/>
    internal float Opacity { get; set; }

    /// <inheritdoc cref="Style.ShadowSize"/>
    internal EdgeSize ShadowSize { get; set; } = new();

    /// <inheritdoc cref="Style.ShadowInset"/>
    internal int ShadowInset { get; set; }

    /// <inheritdoc cref="Style.ShadowOffset"/>
    internal Vector2 ShadowOffset { get; set; }

    /// <inheritdoc cref="Style.IsAntialiased"/>
    internal bool IsAntialiased { get; set; }

    internal void Apply(Style style)
    {
        IsVisible          = style.IsVisible ?? IsVisible;
        Anchor             = style.Anchor ?? Anchor;
        Size               = style.Size ?? Size;
        Flow               = style.Flow ?? Flow;
        Gap                = style.Gap ?? Gap;
        Stretch            = style.Stretch ?? Stretch;
        Padding            = style.Padding ?? Padding;
        Margin             = style.Margin ?? Margin;
        Color              = style.Color ?? Color;
        Font               = style.Font ?? Font;
        FontSize           = style.FontSize ?? FontSize;
        LineHeight         = style.LineHeight ?? LineHeight;
        WordWrap           = style.WordWrap ?? WordWrap;
        TextAlign          = style.TextAlign ?? TextAlign;
        OutlineSize        = style.OutlineSize ?? OutlineSize;
        TextOffset         = style.TextOffset ?? TextOffset;
        BackgroundColor    = style.BackgroundColor ?? BackgroundColor;
        BorderColor        = style.BorderColor ?? BorderColor;
        BorderInset        = style.BorderInset ?? BorderInset;
        BorderRadius       = style.BorderRadius ?? BorderRadius;
        BorderWidth        = style.BorderWidth ?? BorderWidth;
        StrokeColor        = style.StrokeColor ?? StrokeColor;
        StrokeWidth        = style.StrokeWidth ?? StrokeWidth;
        StrokeInset        = style.StrokeInset ?? StrokeInset;
        RoundedCorners     = style.RoundedCorners ?? RoundedCorners;
        BackgroundGradient = style.BackgroundGradient ?? BackgroundGradient;
        OutlineColor       = style.OutlineColor ?? OutlineColor;
        TextShadowSize     = style.TextShadowSize ?? TextShadowSize;
        TextShadowColor    = style.TextShadowColor ?? TextShadowColor;
        IconId             = style.IconId ?? IconId;
        IconInset          = style.IconInset ?? IconInset;
        IconOffset         = style.IconOffset ?? IconOffset;
        IconRounding       = style.IconRounding ?? IconRounding;
        IconGrayscale      = style.IconGrayscale ?? IconGrayscale;
        IconContrast       = style.IconContrast ?? IconContrast;
        Opacity            = style.Opacity ?? Opacity;
        ShadowSize         = style.ShadowSize ?? ShadowSize;
        ShadowInset        = style.ShadowInset ?? ShadowInset;
        ShadowOffset       = style.ShadowOffset ?? ShadowOffset;
        IsAntialiased      = style.IsAntialiased ?? IsAntialiased;
    }

    internal void Reset()
    {
        IsVisible          = true;
        Anchor             = Anchor.TopLeft;
        Size               = new();
        Flow               = Flow.Horizontal;
        Gap                = 0;
        Stretch            = false;
        Padding            = new();
        Margin             = new();
        Color              = new(0xFFC0C0C0);
        Font               = 0;
        FontSize           = 12;
        LineHeight         = 1.2f;
        WordWrap           = false;
        TextAlign          = Anchor.TopLeft;
        OutlineSize        = 0;
        TextOffset         = Vector2.Zero;
        BackgroundColor    = null;
        BorderColor        = null;
        BorderInset        = 0;
        BorderRadius       = 0;
        BorderWidth        = new();
        StrokeColor        = null;
        StrokeWidth        = 0;
        StrokeInset        = 0;
        RoundedCorners     = RoundedCorners.All;
        BackgroundGradient = null;
        OutlineColor       = null;
        TextShadowSize     = 0;
        TextShadowColor    = null;
        IconId             = null;
        IconInset          = null;
        IconOffset         = null;
        IconRounding       = 0;
        IconGrayscale      = false;
        IconContrast       = 0;
        Opacity            = 1;
        ShadowSize         = new();
        ShadowInset        = 0;
        ShadowOffset       = Vector2.Zero;
        IsAntialiased      = true;
    }

    internal LayoutStyle CommittedLayoutStyle;
    internal PaintStyle  CommittedPaintStyle;

    internal int Commit()
    {
        LayoutStyle ls = new() {
            Anchor        = Anchor.Point,
            IsVisible     = IsVisible,
            Width         = Size.Width,
            Height        = Size.Height,
            Flow          = Flow,
            Gap           = Gap,
            Stretch       = Stretch,
            PaddingTop    = Padding.Top,
            PaddingRight  = Padding.Right,
            PaddingBottom = Padding.Bottom,
            PaddingLeft   = Padding.Left,
            MarginTop     = Margin.Top,
            MarginRight   = Margin.Right,
            MarginBottom  = Margin.Bottom,
            MarginLeft    = Margin.Left,
            WordWrap      = WordWrap,
            Font          = Font,
            FontSize      = FontSize,
            LineHeight    = LineHeight
        };

        PaintStyle ps = new() {
            Color                   = Color.ToUInt(),
            TextAlign               = TextAlign.Point,
            OutlineSize             = OutlineSize,
            TextOffset              = TextOffset,
            BackgroundColor         = BackgroundColor?.ToUInt(),
            BorderTopColor          = BorderColor?.Top?.ToUInt(),
            BorderRightColor        = BorderColor?.Right?.ToUInt(),
            BorderBottomColor       = BorderColor?.Bottom?.ToUInt(),
            BorderLeftColor         = BorderColor?.Left?.ToUInt(),
            BorderInset             = BorderInset,
            BorderRadius            = BorderRadius,
            BorderTopWidth          = BorderWidth.Top,
            BorderRightWidth        = BorderWidth.Right,
            BorderBottomWidth       = BorderWidth.Bottom,
            BorderLeftWidth         = BorderWidth.Left,
            StrokeColor             = StrokeColor?.ToUInt(),
            StrokeWidth             = StrokeWidth,
            StrokeInset             = StrokeInset,
            BackgroundGradient1     = BackgroundGradient?.Color1?.ToUInt(),
            BackgroundGradient2     = BackgroundGradient?.Color2?.ToUInt(),
            BackgroundGradientInset = BackgroundGradient?.Inset,
            OutlineColor            = OutlineColor?.ToUInt(),
            TextShadowSize          = TextShadowSize,
            TextShadowColor         = TextShadowColor?.ToUInt(),
            IconId                  = IconId,
            IconInsetTop            = IconInset?.Top,
            IconInsetRight          = IconInset?.Right,
            IconInsetBottom         = IconInset?.Bottom,
            IconInsetLeft           = IconInset?.Left,
            IconOffsetX             = IconOffset?.X,
            IconOffsetY             = IconOffset?.Y,
            IconRounding            = IconRounding,
            IconGrayscale           = IconGrayscale,
            IconContrast            = IconContrast,
            IsAntialiased           = IsAntialiased
        };

        var result = 0;

        if (AreStructsEqual(ref CommittedLayoutStyle, ref ls) is false) {
            CommittedLayoutStyle = ls;
            OnLayoutPropertyChanged?.Invoke();
            result = 1;
        }

        if (AreStructsEqual(ref CommittedPaintStyle, ref ps) is false) {
            CommittedPaintStyle = ps;
            OnPaintPropertyChanged?.Invoke();
            result += 2;
        }

        return result;
    }

    private static bool AreStructsEqual<T>(ref readonly T a, ref readonly T b) where T : unmanaged
    {
        return MemoryMarshal
            .AsBytes(new ReadOnlySpan<T>(in a))
            .SequenceEqual(MemoryMarshal.AsBytes(new ReadOnlySpan<T>(in b)));
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct LayoutStyle
{
    internal Anchor.AnchorPoint Anchor;
    internal bool               IsVisible;
    internal int                Width;
    internal int                Height;
    internal Flow               Flow;
    internal int                Gap;
    internal bool               Stretch;
    internal int                PaddingTop;
    internal int                PaddingRight;
    internal int                PaddingBottom;
    internal int                PaddingLeft;
    internal int                MarginTop;
    internal int                MarginRight;
    internal int                MarginBottom;
    internal int                MarginLeft;
    internal bool               WordWrap;
    internal uint               Font;
    internal int                FontSize;
    internal float              LineHeight;
}

[StructLayout(LayoutKind.Sequential)]
internal struct PaintStyle
{
    internal Anchor.AnchorPoint TextAlign;
    internal float              OutlineSize;
    internal Vector2            TextOffset;
    internal uint               Color;
    internal uint?              BackgroundColor;
    internal uint?              BorderTopColor;
    internal uint?              BorderRightColor;
    internal uint?              BorderBottomColor;
    internal uint?              BorderLeftColor;
    internal float              BorderInset;
    internal int                BorderRadius;
    internal int                BorderTopWidth;
    internal int                BorderRightWidth;
    internal int                BorderBottomWidth;
    internal int                BorderLeftWidth;
    internal uint?              StrokeColor;
    internal int                StrokeWidth;
    internal float              StrokeInset;
    internal RoundedCorners?    RoundedCorners;
    internal uint?              BackgroundGradient1;
    internal uint?              BackgroundGradient2;
    internal int?               BackgroundGradientInset;
    internal uint?              OutlineColor;
    internal float              TextShadowSize;
    internal uint?              TextShadowColor;
    internal uint?              IconId;
    internal int?               IconInsetTop;
    internal int?               IconInsetRight;
    internal int?               IconInsetBottom;
    internal int?               IconInsetLeft;
    internal float?             IconOffsetX;
    internal float?             IconOffsetY;
    internal float?             IconRounding;
    internal bool?              IconGrayscale;
    internal float?             IconContrast;
    internal bool               IsAntialiased;
}
