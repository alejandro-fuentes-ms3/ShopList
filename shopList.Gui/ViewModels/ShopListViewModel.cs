using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using shopList.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Input;

namespace shopList.Gui.ViewModels
{
    public partial class ShopListViewModels : ObservableObject

    {
        [ObservableProperty]
        private Item? itemSeleccionado;
        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;

        //   public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item> Items { get; }

        //public string NombreDelArticulo
        //{
        //    get => _nombreDelArticulo;
        //    set
        //    {
        //        if (value != _nombreDelArticulo)
        //        {
        //            _nombreDelArticulo = value;
        //            OnPropertyChanged(nameof(NombreDelArticulo));
        //        }
        //    }
        //}
        //public int CantidadAComprar
        //{
        //    get => _cantidadAComprar;
        //    set
        //    {
        //        if (value != _cantidadAComprar)
        //        {
        //            _cantidadAComprar = value;
        //            OnPropertyChanged(nameof(CantidadAComprar));
        //        }
        //    }
        //}

        //public ICommand AgregarShopListItemCommand {  get; private set; }


        public ShopListViewModels()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            // AgregarShopListItemCommand = new Command(AgregarShopListItem);
            if (Items.Count > 0)
            {
                ItemSeleccionado = Items.First();
            }
            else
            {
                ItemSeleccionado = null;
            }

        }
        [RelayCommand]
        public void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(_nombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }
            Random generador = new Random();
            var item = new Item
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false
            };
            Items.Add(item);
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
            

        }
        [RelayCommand]
        public void EliminarShopListItem()
        {
            if (ItemSeleccionado == null)
            {
                return;
            }

            var index = Items.IndexOf(ItemSeleccionado);

            Item? nuevoSeleccionado = null;

            if (Items.Count > 1)
            {
                // Si NO es el último elemento
                if (index < Items.Count - 1)
                {
                    nuevoSeleccionado = Items[index + 1];   // Selecciona el siguiente
                }
                else
                {
                    nuevoSeleccionado = Items[index - 1];   // Selecciona el anterior
                }
            }

            Items.Remove(ItemSeleccionado);

            //Si no hay nada q seleccionar
            ItemSeleccionado = nuevoSeleccionado;
        }
        private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado = false
            });
            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Cereal de caja",
                Cantidad = 1,
                Comprado = false

            });
            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamon",
                Cantidad = 500,
                Comprado = true

            });
        }
        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}

