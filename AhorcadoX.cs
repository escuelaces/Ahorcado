using System;
using System.Collections.ObjectModel;

namespace Ahorcado
{
    public partial class Ahorcado
    {

        public static readonly BindableProperty LetrasFalladasProperty =
           BindableProperty.Create(nameof(LetrasFalladas), typeof(String), typeof(Ahorcado), "");


        public static readonly BindableProperty PalabraMostrarProperty =
           BindableProperty.Create(nameof(PalabraMostrar), typeof(ObservableCollection<Char>), typeof(Ahorcado), new ObservableCollection<Char>());


        // Palabra a adivinar
        public static readonly BindableProperty PalabraProperty =
            BindableProperty.Create(nameof(Palabra), typeof(String), typeof(Ahorcado), "");

        //Entrada tecla
        public static readonly BindableProperty KeyEntryProperty =
            BindableProperty.Create(nameof(KeyEntry), typeof(String), typeof(Ahorcado), "",
                 propertyChanged: onKeyEntryChanged);
           
    }
}

