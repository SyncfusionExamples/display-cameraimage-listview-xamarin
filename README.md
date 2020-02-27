# How to display images taken from the camera on the Xamarin.Forms ListView (SfListView)? 
You can display images taken by camera using Xam.Plugin.Media nuget in SfListView by loading Image in listview ItemTemplate. 

To know more about using Media plugin for Xamarin, you can refer from the following link: https://github.com/jamesmontemagno/MediaPlugin 

Taking a photo using CrossMedia plugin and convert to ImageSource 
``` C#
namespace SfListViewSample
{
    public class ListViewContactsInfoRepository
    {
        public async void GetContactDetails(int count)
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

                Directory = "Media\\Pictures",
                Name = "Image",
                SaveToAlbum = false,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                MaxWidthHeight = 2000,
            });
            details = new ListViewContactsInfo()
            {
                ContactType = contactType[random.Next(0, 5)],
                ContactNumber = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString(),
                ContactName = CustomerNames[i],
                ContactImage = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                }),
}

            };
            customerDetails.Add(details);
        }
}
```
Displaying taken image in Xamarin.Forms Image using ListView ItemTemplate.
``` xml
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.Content>
        <syncfusion:SfListView x:Name="listView"
                                   BackgroundColor="AliceBlue"
                                   ItemSize="500"
                                   SelectionMode="Single" SelectionChanged="ListView_SelectionChanged"
                                   ItemsSource="{Binding ContactsInfo}">
            <syncfusion:SfListView.ItemTemplate>
                <DataTemplate>
                    <Image Source="{Binding ContactImage, Mode=TwoWay}"
                               Aspect="AspectFill" BackgroundColor="Blue" 
                               HeightRequest="500" WidthRequest="500"/>
                </DataTemplate>
            </syncfusion:SfListView.ItemTemplate>
        </syncfusion:SfListView>
    </ContentPage.Content>
</ContentPage>
```
