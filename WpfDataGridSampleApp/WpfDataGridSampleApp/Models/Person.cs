using Prism.Mvvm;
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
    public class Person : BindableBase, INotifyDataErrorInfo, IEditableObject
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

        private DateTime birthday;

        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.SetProperty(ref this.birthday, value); }
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

        private Person CacheData { get; set; }

        public void BeginEdit()
        {
            this.CacheData = new Person();
            this.CacheData.Name = this.Name;
            this.CacheData.Age = this.Age;
            this.CacheData.Gender = this.Gender;
            this.CacheData.Birthday = this.Birthday;
        }

        public void EndEdit()
        {
            this.CacheData = null;
        }

        public void CancelEdit()
        {
            if (this.CacheData == null) { return; }
            this.Name = this.CacheData.Name;
            this.Age = this.CacheData.Age;
            this.Gender = this.CacheData.Gender;
            this.Birthday = this.CacheData.Birthday;
            this.CacheData = null;
        }
    }
}
