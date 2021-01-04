using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SfListViewSample
{
    [Preserve(AllMembers = true)]
    public class ViewModel
    {
        #region Fields

        private Random random = new Random();
        private int count = 0;
        private ObservableCollection<ListViewContactsInfo> customerDetails;

        #endregion

        #region Properties
        public ObservableCollection<ListViewContactsInfo> ContactsInfo
        {
            get { return customerDetails; }
            set { this.customerDetails = value; }
        }

        public Command<object> TakePhotoCommand { get; set; }
        #endregion

        #region Constructor

        public ViewModel()
        {
            ContactsInfo = new ObservableCollection<ListViewContactsInfo>();
            TakePhotoCommand = new Command<object>(OnTakePhotoClicked);
        }
        #endregion

        #region Methods
        private async void OnTakePhotoClicked(object obj)
        {
            count += 1;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Media\\Pictures",
                Name = "Image" + count,
                SaveToAlbum = false,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                MaxWidthHeight = 2000,
            });
            var details = new ListViewContactsInfo()
            {
                ContactNumber = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString(),
                ContactName = CustomerNames[count],
            };

            if (file == null)
                return;

            details.ContactImage = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            ContactsInfo.Add(details);
        }
        #endregion

        #region Contacts Information

        string[] CustomerNames = new string[]
        {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason  ",
            "Liam   ",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Jack   ",
            "Ryan   ",
            "Connor ",
            "Michael",
            "Elijah ",
            "Brayden",
            "Benjamin",
            "Nicholas",
            "Alexander",
            "William",
            "Matthew",
            "James  ",
            "Landon ",
            "Nathan ",
            "Dylan  ",
            "Evan   ",
            "Luke   ",
            "Andrew ",
            "Gabriel",
            "Gavin  ",
            "Joshua ",
            "Owen   ",
            "Daniel ",
            "Carter ",
            "Tyler  ",
            "Cameron",
            "Christian",
            "Wyatt  ",
            "Henry  ",
            "Eli    ",
            "Joseph ",
            "Max    ",
            "Isaac  ",
            "Samuel ",
            "Anthony",
            "Grayson",
            "Zachary",
            "David  ",
            "Christopher",
            "John   ",
            "Isaiah ",
            "Levi   ",
            "Jonathan",
            "Oliver ",
            "Chase  ",
            "Cooper ",
            "Tristan",
            "Colton ",
            "Austin ",
            "Colin  ",
            "Charlie",
            "Dominic",
            "Parker ",
            "Hunter ",
            "Thomas ",
            "Alex   ",
            "Ian    ",
            "Jordan ",
            "Cole   ",
            "Julian ",
            "Aaron  ",
            "Carson ",
            "Miles  ",
            "Blake  ",
            "Brody  ",
            "Adam   ",
            "Sebastian",
            "Adrian ",
            "Nolan  ",
            "Sean   ",
            "Riley  ",
            "Bentley",
            "Xavier ",
            "Hayden ",
            "Jeremiah",
            "Jason  ",
            "Jake   ",
            "Asher  ",
            "Micah  ",
            "Jace   ",
            "Brandon",
            "Josiah ",
            "Hudson ",
            "Nathaniel",
            "Bryson ",
            "Ryder  ",
            "Justin ",
            "Bryce  ",
        };

        #endregion
    }
}
