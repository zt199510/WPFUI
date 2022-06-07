using System;
using System.Collections.Generic;
using System.Text;

namespace Zt.UI.Silver.Global
{
    #region Button
    public enum ButtonStyle
    {
        Standard,
        Hollow,
        Outline,
        Link,
    }

    public enum ClickStyle
    {
        None,
        Sink,
    }
    #endregion

    #region Loading
    public enum LoadingStyle
    {
        Standard,
        Wave,
        Ring,
        Ring2,
        Classic
    }
    #endregion

    #region CheckBox
    public enum CheckBoxStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion


    #region RadioButton
    public enum RadioButtonStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion


    #region DateTimePickerMode
    public enum DateTimePickerMode
    {
        DateTime,
        Date,
        Time,
    }
    #endregion


    #region Calendar
    public enum CalendarMode
    {
        Date,
        YearMonth,
        Year,
    }
    #endregion

    #region ProgressBarStyle 进度条样式
    public enum ProgressBarStyle
    {
        Standard,
        Ring
    }
    #endregion

    #region TabControlStyle
    public enum TabControlStyle
    {
        Standard,
        Classic,
        Card,
    }

    public enum ItemsAlignment
    {
        LeftOrTop,
        Center,
    }
    #endregion

    #region RepeatButton
    public enum RepeatButtonStyle
    {
        Standard,
        Hollow,
        Outline,
        Link,
    }
    #endregion


    #region TreeView
    public enum TreeViewStyle
    {
        Standard,
        Classic,
        Modern,
        Chain,
    }

    public enum SelectMode
    {
        Any,
        ChildOnly,
        Disabled
    }

    public enum ExpandMode
    {
        DoubleClick,
        SingleClick
    }

    public enum ExpandBehaviour
    {
        Any,
        OnlyOne,
    }
    #endregion
}
