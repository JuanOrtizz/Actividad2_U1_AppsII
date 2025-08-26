using Ortiz_J_Act2_U1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ortiz_J_Act2_U1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Objeto alumno del modelo
        private AlumnoModel _alumno = new AlumnoModel();

        //Propiedades del modelo usadas en el ViewModel para el Binding
        public string Name
        {
            get => _alumno.Name;

            set
            {
                if (_alumno.Name != value)
                {
                    _alumno.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get => _alumno.Age;

            set
            {
                if (_alumno.Age != value)
                {
                    _alumno.Age = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _alumno.Description;

            set
            {
                if (_alumno.Description != value)
                {
                    _alumno.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command SaveDataCommand { get; }

        public MainViewModel()
        {
            //Inicializo el comando
            SaveDataCommand = new Command(() =>
                {
                    // Hago las valdiaciones para ver si estan vacios
                    if (string.IsNullOrEmpty(Name) || Age == 0 || string.IsNullOrEmpty(Description))
                    {
                        // Si estan vacios muestro una alerta
                        Application.Current.MainPage.DisplayAlert("Hay campos vacios", "Completa todos los campos para recien guardar", "OK");
                    }
                    else
                    {
                        //Sino, actualizo los valores del objeto alumno
                        _alumno.Name = this.Name;
                        _alumno.Age = this.Age;
                        _alumno.Description = this.Description;
                        //Muestro una alerta indicando que se guardaron los datos
                        Application.Current.MainPage.DisplayAlert("Datos guardados", "", "OK");
                    }
                        
                }
            );
        }

        // Evento para la interfaz
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
