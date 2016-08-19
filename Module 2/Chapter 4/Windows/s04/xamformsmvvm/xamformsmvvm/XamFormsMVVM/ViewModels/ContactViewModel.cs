using XamFormsMVVM.Models;
using XLabs.Forms.Mvvm;

namespace XamFormsMVVM.ViewModels
{
    public class ContactViewModel : ViewModel
    {
        private readonly Contact _contact;

        public string Profession
        {
            get { return _contact.Profession; }
            set
            {
                if (_contact.Profession != value)
                {
                    _contact.Profession = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", _contact.FirstName, _contact.LastName); }
        }

        public ContactViewModel(Contact contact)
        {
            _contact = contact;
        }
    }
}
