﻿using System;
using System.Linq;
using Avalonia;
using Neumorphism.Avalonia.Styles.Colors.ColorManipulation;
using Neumorphism.Avalonia.Styles.Themes.Base;
using AvaloniaMedia = Avalonia.Media;

namespace Neumorphism.Avalonia.Styles.Themes
{
    public static class ThemeExtensions
    {
        public static T LocateNeumorphismTheme<T>(this Application application) where T : NeumorphismThemeBase
        {
            var theme = application.Styles.FirstOrDefault(style => style is T);
            if (theme == null)
            {
                throw new InvalidOperationException($"Cannot locate {nameof(T)} in Avalonia application styles. Be sure that you include NeumorphismTheme in your App.xaml in Application.Styles section");
            }
            
            return (T)theme;
        }

        public static IBaseTheme GetBaseTheme(this BaseThemeMode baseThemeMode) {
            return baseThemeMode switch {
                BaseThemeMode.Dark  => Theme.Dark,
                BaseThemeMode.Light => Theme.Light,
                BaseThemeMode.Inherit => Theme.GetSystemTheme() switch {
                    BaseThemeMode.Dark => Theme.Dark,
                    _                  => Theme.Light
                },
                _ => throw new InvalidOperationException()
            };
        }

        public static BaseThemeMode GetBaseTheme(this ITheme theme) {
            if (theme is null) throw new ArgumentNullException(nameof(theme));

            var foreground = theme.Background.ContrastingForegroundColor();
            return foreground == AvaloniaMedia.Colors.Black ? BaseThemeMode.Light : BaseThemeMode.Dark;
        }

        public static ITheme SetBaseTheme(this ITheme theme, IBaseTheme baseTheme) {
            if (theme is null) throw new ArgumentNullException(nameof(theme));

            theme.ValidationError = baseTheme.ValidationErrorColor;
            theme.Background = baseTheme.MaterialDesignBackground;
            theme.Paper = baseTheme.MaterialDesignPaper;
            theme.CardBackground = baseTheme.MaterialDesignCardBackground;
            theme.ToolBarBackground = baseTheme.MaterialDesignToolBarBackground;
            theme.Body = baseTheme.MaterialDesignBody;
            theme.BodyLight = baseTheme.MaterialDesignBodyLight;
            theme.ColumnHeader = baseTheme.MaterialDesignColumnHeader;
            theme.CheckBoxOff = baseTheme.MaterialDesignCheckBoxOff;
            theme.CheckBoxDisabled = baseTheme.MaterialDesignCheckBoxDisabled;
            theme.Divider = baseTheme.MaterialDesignDivider;
            theme.Selection = baseTheme.MaterialDesignSelection;
            theme.ToolForeground = baseTheme.MaterialDesignToolForeground;
            theme.ToolBackground = baseTheme.MaterialDesignToolBackground;
            theme.FlatButtonClick = baseTheme.MaterialDesignFlatButtonClick;
            theme.FlatButtonRipple = baseTheme.MaterialDesignFlatButtonRipple;
            theme.ToolTipBackground = baseTheme.MaterialDesignToolTipBackground;
            theme.ChipBackground = baseTheme.MaterialDesignChipBackground;
            theme.SnackbarBackground = baseTheme.MaterialDesignSnackbarBackground;
            theme.SnackbarMouseOver = baseTheme.MaterialDesignSnackbarMouseOver;
            theme.SnackbarRipple = baseTheme.MaterialDesignSnackbarRipple;
            theme.TextBoxBorder = baseTheme.MaterialDesignTextBoxBorder;
            theme.TextFieldBoxBackground = baseTheme.MaterialDesignTextFieldBoxBackground;
            theme.TextFieldBoxHoverBackground = baseTheme.MaterialDesignTextFieldBoxHoverBackground;
            theme.TextFieldBoxDisabledBackground = baseTheme.MaterialDesignTextFieldBoxDisabledBackground;
            theme.TextAreaBorder = baseTheme.MaterialDesignTextAreaBorder;
            theme.TextAreaInactiveBorder = baseTheme.MaterialDesignTextAreaInactiveBorder;
            theme.DataGridRowHoverBackground = baseTheme.MaterialDesignDataGridRowHoverBackground;
            theme.ShadowLightColor = baseTheme.MaterialDesignShadowLightColor;
            theme.ShadowDarkColor = baseTheme.MaterialDesignShadowDarkColor;
            theme.BorderShadowColor = baseTheme.MaterialDesignBorderShadowColor;
            theme.DisabledNoTransparencyColor = baseTheme.MaterialDesignDisabledNoTransparencyColor;

            return theme;
        }

        public static ITheme SetPrimaryColor(this ITheme theme, AvaloniaMedia.Color primaryColor) {
            if (theme is null) throw new ArgumentNullException(nameof(theme));

            theme.PrimaryLight = primaryColor.Lighten();
            theme.PrimaryMid = primaryColor;
            theme.PrimaryDark = primaryColor.Darken();

            return theme;
        }

        public static ITheme SetSecondaryColor(this ITheme theme, AvaloniaMedia.Color accentColor) {
            if (theme == null) throw new ArgumentNullException(nameof(theme));
            theme.SecondaryLight = accentColor.Lighten();
            theme.SecondaryMid = accentColor;
            theme.SecondaryDark = accentColor.Darken();

            return theme;
        }
    }
}