using CommunityToolkit.Maui.Markup;
using System.Text;

namespace Ahorcado;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		var ahorcado = new Ahorcado();
        BindingContext = ahorcado;

        //var l = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal);

        Content = new VerticalStackLayout
        {
            Children =
            {

                //Palabra
                new CollectionView()
                {
                    ItemsLayout = LinearItemsLayout.Horizontal,
                    ItemTemplate = new DataTemplate(() =>
                        new Label{
                            FontSize = 18,
                            Text = "_",
                            Padding = 8
                        }
                        .Bind(Label.TextProperty)

                    )

                }
                .Bind(CollectionView.ItemsSourceProperty, nameof(Ahorcado.PalabraMostrar)),

                
  
                // Entrada Texto 
                new Entry{
                    //MaxLength = 1,
                }.Invoke((keyEntry) =>{
                    keyEntry.Loaded += (sender, args) =>
                        keyEntry.Focus();

                    keyEntry.TextChanged += (sender,args) =>{
                        new Timer((s) =>
                            keyEntry.Dispatcher.Dispatch(()=>
                                keyEntry.Text = String.Empty)

                            ,null,500,0 );
                    };


                })
                .Bind(Entry.TextProperty, nameof(Ahorcado.KeyEntry), BindingMode.TwoWay)
                .BindCommand(nameof(Ahorcado.returnCommand))
                .Size(50),

                // Falladas
                new Label().Bind(Label.TextProperty,nameof(Ahorcado.LetrasFalladas))




            }
		}
        .Center();



        

    }


}


