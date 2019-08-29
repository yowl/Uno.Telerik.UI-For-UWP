﻿using Telerik.UI.Xaml.Controls.Data.DataForm;
using Telerik.UI.Xaml.Controls.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Telerik.UI.Xaml.Controls.Data
{
    /// <summary>
    /// Represents an AutoCompleteEditor control.
    /// </summary>
    public class AutoCompleteEditor : RadAutoCompleteBox, ITypeEditor, IEditor
    {
        /// <summary>
        /// Identifies the <see cref="LabelIconStyle"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty LabelIconStyleProperty =
            DependencyProperty.Register(nameof(LabelIconStyle), typeof(Style), typeof(AutoCompleteEditor), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="ErrorIconStyle"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty ErrorIconStyleProperty =
            DependencyProperty.Register(nameof(ErrorIconStyle), typeof(Style), typeof(AutoCompleteEditor), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="HasErrors"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty HasErrorsProperty =
            DependencyProperty.Register(nameof(HasErrors), typeof(bool), typeof(AutoCompleteEditor), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the <see cref="IconDisplayMode"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty IconDisplayModeProperty =
            DependencyProperty.Register(nameof(IconDisplayMode), typeof(EditorIconDisplayMode), typeof(AutoCompleteEditor), new PropertyMetadata(EditorIconDisplayMode.None));

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteEditor"/> class.
        /// </summary>
        public AutoCompleteEditor()
        {
            this.DefaultStyleKey = typeof(AutoCompleteEditor);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control has errors.
        /// </summary>
        public bool HasErrors
        {
            get { return (bool)GetValue(HasErrorsProperty); }
            set { this.SetValue(HasErrorsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the style for the error icon of the editor.
        /// </summary>
        public Style ErrorIconStyle
        {
            get { return (Style)GetValue(ErrorIconStyleProperty); }
            set { this.SetValue(ErrorIconStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the style for the label icon of the editor.
        /// </summary>
        public Style LabelIconStyle
        {
            get { return (Style)GetValue(LabelIconStyleProperty); }
            set { this.SetValue(LabelIconStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the display mode of the icon for the editor.
        /// </summary>
        public EditorIconDisplayMode IconDisplayMode
        {
            get { return (EditorIconDisplayMode)GetValue(IconDisplayModeProperty); }
            set { this.SetValue(IconDisplayModeProperty, value); }
        }

        object IEditor.GetCurrentValue()
        {
            return this.Text;
        }

        /// <summary>
        /// Method used for generating bindings for the <see cref="ITypeEditor"/> properties.
        /// </summary>
        public void BindEditor()
        {
            Binding b = new Binding() { Mode = BindingMode.TwoWay };
            b.Path = new PropertyPath("PropertyValue");
            this.SetBinding(AutoCompleteEditor.TextProperty, b);

            Binding b1 = new Binding();
            b1.Path = new PropertyPath("Errors.Count");
            b1.Converter = new EditorIconVisibilityConverter();
            b1.ConverterParameter = "HasErrors";
            this.SetBinding(AutoCompleteEditor.HasErrorsProperty, b1);

            Binding b2 = new Binding();
            b2.Path = new PropertyPath("Watermark");
            this.SetBinding(AutoCompleteEditor.WatermarkProperty, b2);

            Binding b3 = new Binding();
            b3.Converter = new IsEnabledEditorConvetrer();
            b3.Path = new PropertyPath(string.Empty);
            this.SetBinding(AutoCompleteEditor.IsEnabledProperty, b3);

            Binding b4 = new Binding();
            b4.Path = new PropertyPath("ValueOptions");
            this.SetBinding(AutoCompleteEditor.ItemsSourceProperty, b4);
        }
    }
}