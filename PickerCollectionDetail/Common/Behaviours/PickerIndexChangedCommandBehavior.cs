using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickerCollectionDetail.Common.Behaviours
{
    public class PickerIndexChangedCommandBehavior : Behavior<Picker>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", 
                typeof(ICommand), 
                typeof(PickerIndexChangedCommandBehavior), 
                null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        void Bindable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!(sender is Picker bindable))
                return;

            if (Command?.CanExecute(bindable) ?? true)
            {
                Command?.Execute(bindable);
            }
        }

        protected override void OnAttachedTo(Picker bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable.BindingContext != null)
                BindingContext = bindable.BindingContext;

            bindable.BindingContextChanged += Bindable_BindingContextChanged;

            bindable.SelectedIndexChanged += Bindable_SelectedIndexChanged;
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= Bindable_BindingContextChanged;

            bindable.SelectedIndexChanged -= Bindable_SelectedIndexChanged;
        }

        void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();

            if (!(sender is BindableObject bindable))
                return;

            BindingContext = bindable.BindingContext;
        }
    }
}
