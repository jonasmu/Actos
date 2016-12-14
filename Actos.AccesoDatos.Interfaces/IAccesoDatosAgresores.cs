using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos.Interfaces
{
    public interface IAccesoDatosAgresores
    {
        #region Metodos

        DataTable Agresores_DevolverTodos();

        DataTable Agresores_DevolverPorId(int id);

        int Agresores_Insertar(Agresor agresor);

        void Agresores_Modificar(Agresor agresor);


        DataTable AgresoresDirecciones_DevolverPorAgresor(Agresor agresor);

        void AgresoresDirecciones_EliminarPorAgresor(Agresor agresor);

        int AgresoresDirecciones_Insertar(Direccion direccion, Agresor agresor);


        DataTable AgresoresRedesSociales_DevolverPorAgresor(Agresor agresor);

        void AgresoresRedesSociales_EliminarPorAgresor(Agresor agresor);

        int AgresoresRedesSociales_Insertar(RedSocial redSocial, Agresor agresor);



        DataTable AgresoresTelefonos_DevolverPorAgresor(Agresor agresor);

        void AgresoresTelefonos_EliminarPorAgresor(Agresor agresor);

        int AgresoresTelefonos_Insertar(Telefono telefono, Agresor agresor);


        #endregion
    }
}
