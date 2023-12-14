using RedSocial.Entity;
using RedSocial.Helper;
using RedSocial.Model;
using System.Collections.Generic;

namespace RedSocial.Web.ViewModel
{
    public class LayoutViewModel
    {
        public static Usuario ObtenerUsuarioLogeado()
        {
            return new UsuarioModel().Obtener(SessionHelper.GetUser());
        }

        public static List<Usuario> ListarUsuariosAlAzar()
        {
            return new UsuarioModel().ListarAlAzar();
        }
    }
}