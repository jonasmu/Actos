using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos.Interfaces
{
    public interface IAccesoDatosVictimas
    {
        DataTable Victimas_DevolverTodos();

        DataTable Victimas_DevolverPorId(int id);

        int Victimas_Insertar(Victima victima);

        void Victimas_Modificar(Victima victima);
    }
}
