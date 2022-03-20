using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Neumorphism.Dialog.Interfaces;
using Neumorphism.Dialog.ViewModels;

namespace Neumorphism.Dialog.Views
{
    public class DatePickerDialog : Window, IDialogWindowResult<DateTimePickerDialogResult>, IHasNegativeResult
    {
        private DatePickerDialogViewModel viewModel;

        public DateTimePickerDialogResult Result { get; set; }

        public DatePickerDialog()
        {
            Result = new DateTimePickerDialogResult();

            InitializeComponent();
        }

        public void AttachViewModel(DatePickerDialogViewModel vm)
        {
            DataContext = vm;
            viewModel = vm;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
        }

        public DateTimePickerDialogResult GetResult()
        {
            return Result;
        }

        public void SetNegativeResult(DialogResult result)
        {
            Result.Result = result.GetResult;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}