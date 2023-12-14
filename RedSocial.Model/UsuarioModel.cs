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
        private readonly string FotoRelacion = "U";

        public List<Usuario> ListarAlAzar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var context = new RedSocialContext())
            {
                try
                {
                    usuarios = context.Usuario.
                        OrderBy(x => Guid.NewGuid()).
                        Take(10).ToList();

                    // Debemos agregar sus fotos
                    foreach (var u in usuarios)
                    {
                        // Ahora obtenemos su foto
                        u.Foto = context.Foto.Where(
                            x => x.Relacion == FotoRelacion + u.id).SingleOrDefault();

                        // Si la foto no existe le ponemos una por defecto
                        if (u.Foto == null)
                        {
                            u.Foto = new Foto();
                        }

                        // Ahora obtenemos los conocimientos de nuestro usuario
                        u.UsuarioConocimientos = context.UsuarioConocimiento
                            .Where(x => x.Usuario_id == u.id)
                            .ToList();
                    }

                }
                catch (Exception e)
                {
                    ELog.Save(this, e);
                }
            }

            return usuarios;
        }

        public Usuario Obtener(int id)
        {
            Usuario usuario = new Usuario();

            using (var context = new RedSocialContext())
            {
                try
                {
                    usuario = context.Usuario
                        .Where(x => x.id == id).Single();

                    // Damos formato a la fecha en yyyy/mm/dd
                    usuario.FechaNacimiento = ViewHelper.ConvertToDate(usuario.FechaNacimiento);

                    // Ahora obtenemos su foto
                    usuario.Foto = context.Foto
                        .Where(x => x.Relacion == FotoRelacion + usuario.id).SingleOrDefault();

                    // Si la foto no existe le ponemos una por defecto
                    if (usuario.Foto == null)
                    {
                        usuario.Foto = new Foto();
                    }

                    /*
                     * Ahora obtenemos los conocimientos de nuestro usuario, pero vamos a traerlo de la tabla conocimiento
                     * para esto haremos un LINQ INNER JOIN
                     */
                    usuario.UsuarioConocimientos = (from c in context.Conocimiento.ToList()
                                                    join cu in context.UsuarioConocimiento.ToList()
                                                    on c.id equals cu.Conocimiento_id
                                                    where cu.Usuario_id == usuario.id
                                                    orderby c.Nombre
                                                    select cu).ToList();

                    /* Como en nuestra entidad UsuarioConocimiento le hemos indicado que son llaves foraneas, el entity framework
                     * ha llegando los objetos Usuario y Conocimiento de esta clase automaticamente */

                }
                catch (Exception e)
                {
                    ELog.Save(this, e);
                }
            }

            return usuario;
        }

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
