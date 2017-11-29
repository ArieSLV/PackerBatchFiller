using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PacketBatchFiller4
{
    /// <inheritdoc cref="Behavior{T}"/>
    /// <summary>
    /// Задает поведение <see cref="Popup"/>'а в зависимости от получения\потери фокуса на другом <see cref="Control"/>'е
    /// </summary>
    internal class ChangeIsOpenOnFocus : Behavior<Control>
    {
        #region Delegates

        /// <summary>
        /// Определяем делегаты
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += AssociatedObject_GotFocus; 
        }
        

        /// <summary>
        /// Снимаем делегаты
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }

        #endregion

        #region Methods

        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!TargetPopup.IsOpen)
            {
                TargetPopup.IsOpen = true;
                TargetPopup.MouseEnter += TargetPopup_MouseEnter;
            }
            AssociatedObject.LostFocus += CloseTargetPopup;
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }

        private void TargetPopup_MouseEnter(object sender, MouseEventArgs e)
        {
            TargetPopup.MouseEnter -= TargetPopup_MouseEnter;
            TargetPopup.MouseLeave += TargetPopup_MouseLeave;

            AssociatedObject.LostFocus -= CloseTargetPopup;
            TargetPopup.GotFocus += TargetPopup_GotFocus;
        }
        
        private void TargetPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            TargetPopup.MouseEnter += TargetPopup_MouseEnter;
            AssociatedObject.LostFocus += CloseTargetPopup;
        }
        
        private void TargetPopup_GotFocus(object sender, RoutedEventArgs e)
        {
            TargetPopup.LostFocus += CloseTargetPopup;
            TargetPopup.GotFocus -= TargetPopup_GotFocus;

            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
        }

        private void AssociatedObject_MouseEnter(object sender, MouseEventArgs e)
        {
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;

            TargetPopup.LostFocus -= CloseTargetPopup;
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;

        }

        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            TargetPopup.LostFocus += CloseTargetPopup;
        }







        /// <summary>
        /// Метод при потере фокуса у <see cref="TextBox"/>
        /// </summary>
        private void CloseTargetPopup(object sender, RoutedEventArgs routedEventArgs)
        {
            TargetPopup.IsOpen = false;
            //Устанавливаем изначальное состояние
            TargetPopup.MouseEnter -= TargetPopup_MouseEnter;
            TargetPopup.MouseLeave -= TargetPopup_MouseLeave;
            TargetPopup.GotFocus -= TargetPopup_GotFocus;
            TargetPopup.LostFocus -= CloseTargetPopup;

            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            AssociatedObject.LostFocus -= CloseTargetPopup;
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }

        #endregion

        #region Public poperties
        


        public static readonly DependencyProperty TargetPopupProperty = DependencyProperty.Register(
            "TargetPopup", typeof(Popup), typeof(ChangeIsOpenOnFocus),
            new PropertyMetadata(default(Popup)));

        /// <summary>
        /// <see cref="Popup"/> у которого меняется IsOpen в зависимости от фокуса
        /// </summary>
        public Popup TargetPopup
        {
            get => (Popup)GetValue(TargetPopupProperty);
            set => SetValue(TargetPopupProperty, value);
        }

        #endregion
    }
}