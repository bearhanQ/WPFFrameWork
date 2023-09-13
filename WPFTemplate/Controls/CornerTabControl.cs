﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTemplate
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFTemplate.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFTemplate.Controls;assembly=WPFTemplate.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CornerTabControl/>
    ///
    /// </summary>
    public class CornerTabControl : TabControl
    {
        static CornerTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornerTabControl), new FrameworkPropertyMetadata(typeof(CornerTabControl)));
            EventManager.RegisterClassHandler(typeof(CornerTabControl), TabItem.PreviewMouseDownEvent, new RoutedEventHandler(Delete));
        }

        private static void Delete(object sender, RoutedEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element.Name == "deleteItem")
            {
                var tabItem = (TabItem)MyVisualTreeHelper.GetParent(element, typeof(TabItem));
                var tabControl = (CornerTabControl)MyVisualTreeHelper.GetParent(element, typeof(CornerTabControl));
                tabControl.Items.Remove(tabItem);
                e.Handled = true;
            }
        }

        public TabControlType TabControlType
        {
            get { return (TabControlType)GetValue(TabControlTypeProperty); }
            set { SetValue(TabControlTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabControlType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabControlTypeProperty =
            DependencyProperty.Register("TabControlType", typeof(TabControlType), typeof(CornerTabControl), new PropertyMetadata(TabControlType.Normal));

        public Brush SelectedColor
        {
            get { return (Brush)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Brush), typeof(CornerTabControl), new PropertyMetadata(Brushes.Red));

        //public CornerRadius CornerRadius
        //{
        //    get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        //    set { SetValue(CornerRadiusProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CornerRadiusProperty =
        //    DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CornerTabControl));

        public bool ItemRemovable
        {
            get { return (bool)GetValue(ItemRemovableProperty); }
            set { SetValue(ItemRemovableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemRemovable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.Register("ItemRemovable", typeof(bool), typeof(CornerTabControl), new PropertyMetadata(false));
    }
}