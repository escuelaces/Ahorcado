using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using System.Text;
using System.Windows.Input;

namespace Ahorcado
{
    public partial class Ahorcado : BindableObject
    {

        String[] Diccionario =
        {
            "COSMOVISION",
            "FANTASIA",
            "PAPANATAS",
            "MACEDONIA",
            "TITIRITERO"
        };


        Random aleatorio = new Random();
        public ICommand returnCommand { get; set; }

        

            

        [Bindable(true)]
        public String LetrasFalladas
        {
            get => (String)GetValue(Ahorcado.LetrasFalladasProperty);
            set => SetValue(LetrasFalladasProperty, value);
        }


        // Palabra a Mostrar ____A___A
        public ObservableCollection<Char> PalabraMostrar
        {
            get => (ObservableCollection<Char>)GetValue(Ahorcado.PalabraMostrarProperty);
            set => SetValue(PalabraMostrarProperty, value);
        }



        public String Palabra
        {
            get => (String)GetValue(Ahorcado.PalabraProperty);
            set => SetValue(PalabraProperty, value);
        }


        //Entrada tecla
        public String KeyEntry
        {
            get => (String)GetValue(Ahorcado.KeyEntryProperty);
            set => SetValue(KeyEntryProperty, value);
        }


        public Ahorcado()
        {
            returnCommand = new Command(() => Console.WriteLine());

            NewGame();
        }


        public static void onKeyEntryChanged(BindableObject sender, object oldValue,object  newValue)
        {
            if ((newValue as String) == String.Empty) return;

            var ahorcado = sender as Ahorcado;
            var key = (newValue as String).ToUpper().First();

            // Si la palabra no contiene la letras añadirlo a letras falladas
            if (!ahorcado.Palabra.Contains(key)){
                ahorcado.LetrasFalladas += key;
                return;
            }

            for(var n=0; n<ahorcado.Palabra.Length; n++)
            {
                if (ahorcado.Palabra[n] == key){
                    ahorcado.PalabraMostrar[n] = key;
                }
            }


        }

        
 
        public void NewGame()
        {
            Palabra = Diccionario[aleatorio.Next(Diccionario.Count())];
            PalabraMostrar =  new(new String('_', Palabra.Count()));
            LetrasFalladas = "";
        }

    }
}

