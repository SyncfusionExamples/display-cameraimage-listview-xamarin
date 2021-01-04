# How to display images taken from the camera on the Xamarin.Forms ListView (SfListView)? 
You can display images taken by camera in [SfListView](https://help.syncfusion.com/xamarin/listview/overview) by loading Image in the [SfListView.ItemTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.ListView.XForms.SfListView.html#Syncfusion_ListView_XForms_SfListView_ItemTemplate). 

To know more about using Media plugin for Xamarin, you can refer from the following link: https://github.com/jamesmontemagno/MediaPlugin 

Take a photo using CrossMedia plugin and convert to ImageSource. 
``` C#
namespace SfListViewSample
{
    public class ViewModel
    {
        private int count = 0;

        public Command<object> TakePhotoCommand { get; set; }

        public ViewModel()
        {
            ContactsInfo = new ObservableCollection<ListViewContactsInfo>();
            TakePhotoCommand = new Command<object>(OnTakePhotoClicked);
        }

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
    }
}
```
Display the taken image using FFImageLoading in the ItemTemplate.
``` xml
<StackLayout>
    <Button Text="Take photo" Command="{Binding TakePhotoCommand}" HeightRequest="50"/>
    <syncfusion:SfListView x:Name="listView" AutoFitMode="Height" SelectionMode="Single" ItemsSource="{Binding ContactsInfo}">
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Frame BackgroundColor="White" Padding="1" HasShadow="{OnPlatform Android=true, iOS=false, UWP=true, WPF=true}">
                    <Grid> 
                        <ffimage:CachedImage Source="{Binding ContactImage}" HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand" HeightRequest="150" WidthRequest="150" Aspect="AspectFill"/>
                        <StackLayout Grid.Column="1" Padding="10,0,0,0">
                            ...
                        </StackLayout>
                    </Grid>
                </Frame>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
</StackLayout>
```