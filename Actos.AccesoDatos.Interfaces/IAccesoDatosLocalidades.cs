using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos.Interfaces
{
    public interface IAccesoDatosLocalidades
    {
        #region Metodos

        DataTable Localidades_DevolverPorId(int id);

        DataTable Localidades_DevolverTodos();

        int Localidades_Insertar(Localidad localidad);

        void Localidades_Modificar(Localidad localidad);

        void Localidades_Eliminar(Localidad localidad);

        #endregion
    }
}
