using System;
using System.Collections.Specialized;
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
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }
       
        /// <summary>
        /// Снимаем делегаты
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }

        #endregion

        #region Methods


        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TargetListBox.Items.Count > 1)
            {
                //Открываем Popup
                TargetPopup.StaysOpen = true;
                TargetPopup.IsOpen = true;

                //Если потеряет фокус - убрать флаг StayOpen
                AssociatedObject.LostFocus += SetStayOpenFalse;

                //Подчищаем лишние делегаты
                TargetPopup.Closed += TargetPopup_Closed;

                //Начинаем отслеживать клавиатуру для навигации по элементам ListBox'а
                TargetListBox.PreviewKeyDown += TargetListBox_PreviewKeyDown;
                ((INotifyCollectionChanged) TargetListBox.Items).CollectionChanged +=
                    ChangeIsOpenOnFocus_CollectionChanged;
            }

        }

        private void ChangeIsOpenOnFocus_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (TargetListBox.Items.Count <= 1)
            {
                TargetPopup.StaysOpen = false;
                TargetPopup.IsOpen = false;
            }
            else
            {
                
            }
                
        }

        private void TargetPopup_Closed(object sender, EventArgs e)
        {
            //Popup закрыт - наводим чистоту
            AssociatedObject.LostFocus -= SetStayOpenFalse;
        }

        private void SetStayOpenFalse(object sender, RoutedEventArgs routedEventArgs)
        {
            //Если Popup потеряет фокус - нужно его закрыть
            TargetPopup.StaysOpen = false;
        }


        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Tab:
                    TargetPopup.IsOpen = false;
                    break;
                case Key.Down:
                    if (TargetListBox.Items.Count > 0)
                    {
                        TargetListBox.Focus();
                        var listBoxItemToFocus =
                            (ListBoxItem) TargetListBox
                                .ItemContainerGenerator
                                .ContainerFromItem(TargetListBox.Items[0]);
                        listBoxItemToFocus.Focus();
                    }
                    e.Handled = true;
                    break;
                    default:
                        
                    break;

            }
        }

        private void TargetListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (Equals(TargetListBox.Items[0], TargetListBox.SelectedItem)) AssociatedObject.Focus();
                    break;
                case Key.Enter:
                case Key.Space:
                    ((TextBox) AssociatedObject).Text = TargetListBox.SelectedItem.ToString();
                    AssociatedObject.Focus();
                    ((TextBox) AssociatedObject).CaretIndex = ((TextBox) AssociatedObject).Text.Length;
                    break;
                    
            }
        }

        

        #endregion

        #region Public dependency poperties

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

        public static readonly DependencyProperty TargetListBoxProperty = DependencyProperty.Register(
            "TargetListBox", typeof(ListBox), typeof(ChangeIsOpenOnFocus), new PropertyMetadata(default(ListBox)));

        /// <summary>
        /// <see cref="ListBox"/> у которого работаем с выбранными элементами клавиатурой 
        /// </summary>
        public ListBox TargetListBox
        {
            get => (ListBox) GetValue(TargetListBoxProperty);
            set => SetValue(TargetListBoxProperty, value);
        }

        #endregion
    }
}