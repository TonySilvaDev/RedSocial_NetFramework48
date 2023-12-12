using RedSocial.Entity;
using RedSocial.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Model
{
    public class UsuarioModel
    {
        private ResponseModel rm = new ResponseModel();

        public ResponseModel RegistroDeLogin(Usuario usuario)
        {
            using (var context = new RedSocialContext())
            {
                try
                {
                    // Guardamos la clave en formato MD5
                    usuario.Contrasena = HashHelper.MD5(usuario.Contrasena);

                    // Ignoramos la validacion para que la contraseña pase
                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.Usuario.Add(usuario);
                    context.SaveChanges();

                    context.Database.ExecuteSqlCommand("UPDATE Usuario SET Url = @url WHERE id = @id",
                        new SqlParameter("url", ViewHelper.ConvertNameToUrl(usuario.Nombre, usuario.Apellido, usuario.id.ToString())),
                        new SqlParameter("id", usuario.id));

                    // Guardamos en session al usuario actual, solo necesitamos guardar su ID
                    SessionHelper.AddUserToSession(usuario.id.ToString());

                    rm.SetResponse(true);
                    rm.href = "inicio";
                }
                catch (Exception e)
                {
                    ELog.Save(this, e);
                }
            }

            return rm;
        }

        public ResponseModel Acceder(Usuario usuario)
        {
            using (var context = new RedSocialContext())
            {
                try
                {
                    // Encriptamos la contraseña para comparar
                    usuario.Contrasena = HashHelper.MD5(usuario.Contrasena);

                    var _usuario = context.Usuario
                                .Where(x =>
                                x.Contrasena == usuario.Contrasena &&
                                x.Correo == usuario.Correo
                                ).SingleOrDefault();

                    if (_usuario != null)
                    {
                        SessionHelper.AddUserToSession(_usuario.id.ToString());

                        rm.SetResponse(true);
                        rm.href = "Inicio";
                    }
                    else
                    {
                        rm.SetResponse(false, "El usuario ingresado no existe");
                    }
                }
                catch (Exception e)
                {
                    ELog.Save(this, e);
                }
            }

            return rm;
        }
    }
}
