using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Actos.Modelo.Entidades;
using Actos.Modelo.Entidades.Tipos;
using Actos.Repositorios;
using System.ServiceModel;
using Actos.ServicioWeb.Interfaces;

namespace Actos.ServicioWeb
{
    public partial class Servicio : IServicio
    {
        #region Propiedades

        private RepositorioAgresores RepositorioAgresores
        {
            get { return new RepositorioAgresores(); }
        }

        private RepositorioAntecedentes RepositorioAntecedentes
        {
            get { return new RepositorioAntecedentes(); }
        }

        private RepositorioEstados RepositorioEstados
        {
            get { return new RepositorioEstados(); }
        }

        private RepositorioLocalidades RepositorioLocalidades
        {
            get { return new RepositorioLocalidades(); }
        }

        private RepositorioVictimas RepositorioVictimas
        {
            get { return new RepositorioVictimas(); }
        }

        private RepositorioTiposDirecciones RepositorioTiposDirecciones
        {
            get { return new RepositorioTiposDirecciones(); }
        }

        private RepositorioTiposRedesSociales RepositorioTiposRedesSociales
        {
            get { return new RepositorioTiposRedesSociales(); }
        }

        private RepositorioTiposTelefonos RepositorioTiposTelefonos
        {
            get { return new RepositorioTiposTelefonos(); }
        }

        #endregion
    }
}