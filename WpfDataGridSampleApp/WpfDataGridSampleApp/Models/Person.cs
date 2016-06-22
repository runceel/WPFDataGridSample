using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace WpfDataGridSampleApp.Models
{
    public class Person : BindableBase, INotifyDataErrorInfo
    {
        private ErrorsContainer<string> ErrorsContainer { get; }

        private string name;

        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        private string age;

        [Required(ErrorMessage = "Age is required")]
        [RegularExpression("[0-9]+", ErrorMessage = "Age is number")]
        public string Age
        {
            get { return this.age; }
            set { this.SetProperty(ref this.age, value); }
        }

        private Gender gender;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public Gender Gender
        {
            get { return this.gender; }
            set { this.SetProperty(ref this.gender, value); }
        }

        public bool HasErrors => this.ErrorsContainer.HasErrors;

        public Person()
        {
            this.ErrorsContainer = new ErrorsContainer<string>(x => this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(x)));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return this.ErrorsContainer.GetErrors(propertyName);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            var p = this.GetType().GetProperty(propertyName);
            var value = p.GetValue(this);
            var errors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = propertyName }, errors))
            {
                this.ErrorsContainer.SetErrors(propertyName, errors.Select(x => x.ErrorMessage));
            }
            else
            {
                this.ErrorsContainer.ClearErrors(propertyName);
            }
        }
    }
}
