using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TODOOFERTAS.Persistencia;

namespace TODOOFERTAS.Dominio
{
    public class Controladora
    {
        public List<Promocion> listaPromocion()
        {
            return pPromocion.ListaPromocion();
        }

        public Promocion buscarPromocion(string pIdPromocion)
        {
            return pPromocion.BuscarPromocion(pIdPromocion);
        }

        public bool insertTablaPromocion(Promocion promocion)
        {
            return pPromocion.InsertTablaPromocion(promocion);
        }

        public bool eliminarPromocion(string pIdPromocion)
        {
            return pPromocion.EliminarPromocion(pIdPromocion);
        }

        public bool modificarPromocion(Promocion promocion)
        {
            return pPromocion.ModificarPromocion(promocion);
        }

        public bool intentosAdmin(int pCedula)
        {
            return pAdministrador.SumarIntentos(pCedula);
        }
        public bool ResetAdmin(int pCedula)
        {
            return pAdministrador.Reset(pCedula);
        }
        public bool ResetUser(int pCedula)
        {
            return pUsuario.Reset(pCedula);
        }
        public bool intentosUsuario(int pCedula)
        {
            return pUsuario.SumarIntentos(pCedula);
        }


        #region Audith
        public bool AltaAudith(Audith audith) 
        {
            return pAudith.AltaAudith(audith);
        }

        #endregion

        #region Administrador
        public List<Administrador> ListaAdmin()
        {
            return pAdministrador.ListaAdmin();
        }

        public Administrador BuscarAdmin(int pCedula, string pPassword)
        {
            return pAdministrador.BuscarAdmin(pCedula, pPassword);
        }
       
        public Administrador BuscarAdminCi(int pCedula)
        {
            return pAdministrador.BuscarAdminCi(pCedula);
        }

        public bool AltaAdmin(Administrador pAdmin)
        {
            return pAdministrador.AltaAdmin(pAdmin);
        }
        #endregion

        #region Usuario
        public List<Usuario> ListaUsuario()
        {
            return pUsuario.ListaUsuario();
        }

        public Usuario BuscarUsuario(int pCedula, string pPassword)
        {
            return pUsuario.BuscarUsuario(pCedula, pPassword);
        }

        public Usuario BuscarUsuarioCi(int pCedula)
        {
            return pUsuario.BuscarUsuarioCi(pCedula);
        }

        public bool AltaUsuario(Usuario pUser)
        {
            return pUsuario.AltaUsuario(pUser);
        }
        #endregion

        #region Venta
        public List<Venta> ListaVenta()
        {
            return pVenta.ListaVenta();
        }

        public Venta BuscarVenta(int pId)
        {
            return pVenta.BuscarVenta(pId);
        }

        public bool AltaVenta(Venta venta)
        {
            return pVenta.AltaVenta(venta);
        }
        #endregion
    }
}