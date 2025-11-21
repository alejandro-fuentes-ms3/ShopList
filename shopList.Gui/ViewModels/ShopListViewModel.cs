using shopList.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace shopList.Gui.ViewModels
{
    public class ShopListViewModel:INotifyPropertyChanged
    {
        private string nombredelarticulo = "matequilla";
        private int _cantidadAcompra = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<item> Items { get; }
        public string NombreDelArticulo
        {
            get => nombredelarticulo;
            set
            {
                if(value != nombredelarticulo)
                {
                    nombredelarticulo=value;
                    OnPropertyChanged(nameof(nombredelarticulo));
                }
            }

        }
        public int cantidadacomprar
        {
            get => cantidadacomprar;
            set
            {
                if (value != cantidadacomprar)
                {
                    cantidadacomprar = value;
                    OnPropertyChanged(nameof(cantidadacomprar));
                }
            }
        }
        public ICommand AgregarshoplistiteamCommand { get; private set; }
        

        public ShopListViewModel()
        {
            Items = new ObservableCollection<item>();
            CargarDatos();
            AgregarshoplistiteamCommand = new Command(Agregashoplistiteam);
        }
        public void Agregashoplistiteam()
        {
            if (string.IsNullOrEmpty(nombredelarticulo) || cantidadacomprar >= 0)
            {
                return;
            }
            Random generador= new Random();

            var item = new item()
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = cantidadacomprar,
                comprado = false,
            };
        }

        private void CargarDatos()
        {

            Items.Add(new item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                comprado = false,
            });

            Items.Add(new item()
            {
                Id = 2,
                Nombre = "Pan de caja",
                Cantidad = 1,
                comprado = false,
            });

            Items.Add(new item()
            {
                Id = 3,
                Nombre = "Jamón",
                Cantidad = 500,
                comprado = false,
            });
            
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
