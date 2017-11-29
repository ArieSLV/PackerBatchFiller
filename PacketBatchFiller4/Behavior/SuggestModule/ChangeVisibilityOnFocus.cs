using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace PacketBatchFiller4
{
    /// <inheritdoc cref="Behavior{T}"/>
    /// <summary>
    /// Задает поведение одного <see cref="Control"/>'а в зависимости от получения\потери фокуса на другом <see cref="Control"/>'е
    /// </summary>
    internal class ChangeVisibilityOnFocus : Behavior<Control>
    {
        #region Delegates

        /// <summary>
        /// Определяем делегаты
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += AssociatedObjectOnGotFocus;
            AssociatedObject.LostFocus += AssociatedObjectOnLostFocus;
        }

        /// <summary>
        /// Снимаем делегаты
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObjectOnGotFocus;
            AssociatedObject.LostFocus -= AssociatedObjectOnLostFocus;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод при получении фокуса на <see cref="TextBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void AssociatedObjectOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            ControlToChangeVisibility.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод при потере фокуса у <see cref="TextBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        private void AssociatedObjectOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            ControlToChangeVisibility.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Public poperties

        
        public static readonly DependencyProperty ControlToChangeVisibilityProperty = DependencyProperty.Register(
            "ControlToChangeVisibility", typeof(UIElement), typeof(ChangeVisibilityOnFocus),
            new PropertyMetadata(default(UIElement)));
        
        /// <summary>
        /// <see cref="UIElement"/> у которого меняется <see cref="Visibility"/> в зависимости от фокуса
        /// </summary>
        public UIElement ControlToChangeVisibility
        {
            get => (UIElement) GetValue(ControlToChangeVisibilityProperty);
            set => SetValue(ControlToChangeVisibilityProperty, value);
        }

        #endregion
    }
}
