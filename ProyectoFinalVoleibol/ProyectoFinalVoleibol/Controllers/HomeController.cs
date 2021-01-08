using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ProyectoFinalVoleibol.Models;
using ProyectoFinalVoleibol.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ProyectoFinalVoleibol.Helpers;
using ProyectoFinalVoleibol.Models.ViewModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalVoleibol.Controllers
{
    public class HomeController : Controller
    {

        public IWebHostEnvironment Environment { get; set; }

        public HomeController(IWebHostEnvironment env)
        {
            Environment = env;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Registrar()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Registrar(Usuario u, string contraseña1, string contraseña2)
        {
            bdvoleibolContext Context = new bdvoleibolContext();
            try
            {
                if (Context.Usuario.Any(x => x.Correo == u.Correo))
                {
                    ModelState.AddModelError("", "Ya existe una cuenta registrada con este correo");
                    return View(u);
                }
                else
                {
                    if (contraseña1 == contraseña2)
                    {
                        Repository<Usuario> repos = new Repository<Usuario>(Context);
                        u.Contraseña = HashHelper.GetHash(contraseña1);
                        u.Codigo = CodeHelper.GetCodigo();
                        u.Activo = 0;
                        repos.Insert(u);


                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("sistemascomputacionales7g@gmail.com ", "Voley4All");
                        message.To.Add(u.Correo);
                        message.Subject = "Confirma tu correo";


                        string mensaje = System.IO.File.ReadAllText(Environment.WebRootPath + "/Correo.html");
                        message.IsBodyHtml = true;
                        message.Body = mensaje.Replace("{##Codigo##}", u.Codigo.ToString());

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("sistemascomputacionales7g@gmail.com", "sistemas7g");
                        client.Send(message);


                        List<Claim> informacion = new List<Claim>();
                        informacion.Clear();
                        informacion.Add(new Claim("CorreoActivar", u.Correo));

                        return RedirectToAction("ActivarCuenta");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Las contraseñas no coinciden");
                        return View(u);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(u);
            }

        }

        [AllowAnonymous]
        public IActionResult ActivarCuenta()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ActivarCuenta(int codigo)
        {
            bdvoleibolContext Context = new bdvoleibolContext();
            UsuarioRepository repos = new UsuarioRepository(Context);
            var user = Context.Usuario.FirstOrDefault(x => x.Codigo == codigo);

            if (user != null && user.Activo == 0)
            {
                var cod = user.Codigo;

                if (codigo == cod)
                {
                    user.Activo = 1;
                    repos.Update(user);

                    return RedirectToAction("IniciarSesion");
                }
                else
                {
                    ModelState.AddModelError("", "El codigo no coincide");
                    return View((object)codigo);
                }
            }
            else
            {
                ModelState.AddModelError("", "No se encontro el usuario");
                return View((object)codigo);
            }
        }

        [AllowAnonymous]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(Usuario u, bool persistant)
        {
            bdvoleibolContext Context = new bdvoleibolContext();

            UsuarioRepository repos = new UsuarioRepository(Context);

            var usuario = repos.GetUsuarioByCorreo(u.Correo);

            if (usuario != null && HashHelper.GetHash(u.Contraseña) == usuario.Contraseña)
            {
                if (usuario.Activo == 1)
                {
                    List<Claim> informacion = new List<Claim>();

                    informacion.Add(new Claim(ClaimTypes.Name, "Usuario" + usuario.NomUser));
                    informacion.Add(new Claim("Correo electronico", usuario.Correo));
                    informacion.Add(new Claim("Nombre Completo", usuario.NomUser));
                    informacion.Add(new Claim("Fecha Ingreso", DateTime.Now.ToString()));


                    var claimsIdentity = new ClaimsIdentity(informacion, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    if (persistant == true)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                        new AuthenticationProperties { IsPersistent = true });
                    }
                    else
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                        new AuthenticationProperties { IsPersistent = false });
                    }

                    return RedirectToAction("Entrada");
                }
                else
                {
                    ModelState.AddModelError("", "La cuenta registrada con este correo electronico no esta activa");
                    return View(u);
                }

            }
            else
            {
                ModelState.AddModelError("", "El usuario o la contraseña son incorrectas");
                return View(u);
            }



        }

        [Authorize]
        public IActionResult CambiarContraseña()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CambiarContraseña(string contraseñaNueva1, string correo, string contraseñaNueva2)
        {
            bdvoleibolContext Context = new bdvoleibolContext();
            UsuarioRepository repos = new UsuarioRepository(Context);


            var user = repos.GetUsuarioByCorreo(correo);
            try
            {
                if (contraseñaNueva1 == contraseñaNueva2)
                {
                    user.Contraseña = HashHelper.GetHash(contraseñaNueva1);
                    if (user.Contraseña == contraseñaNueva1)
                    {
                        ModelState.AddModelError("", "La nueva contraseña no puede ser igual a la ya registrada");
                        return View(contraseñaNueva1);
                    }
                    else
                    {
                        repos.Update(user);

                        return RedirectToAction("Entrada");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Las contraseñas no coinciden");
                    return View();

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(contraseñaNueva1, contraseñaNueva2);
            }

        }

        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult RecuperarContraseña()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecuperarContraseña(string correo)
        {
            try
            {
                bdvoleibolContext Context = new bdvoleibolContext();
                UsuarioRepository repos = new UsuarioRepository(Context);


                var user = repos.GetUsuarioByCorreo(correo);

                if (user != null)
                {

                    var contraseñaTemporal = CodeHelper.GetCodigo();

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("sistemascomputacionales7g@gmail.com", "Voley4All");
                    message.To.Add(correo);
                    message.Subject = "Recupera tu contraseña";

                    message.Body = $"Utiliza esta contraseña temporal para ingresar a tu cuenta, recuerda que una vez que ingreses deberas cambiarla: {contraseñaTemporal} ";

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("sistemascomputacionales7g@gmail.com", "sistemas7g");
                    client.Send(message);

                    user.Contraseña = HashHelper.GetHash(contraseñaTemporal.ToString());
                    repos.Update(user);
                    return RedirectToAction("IniciarSesion");
                }
                else
                {
                    ModelState.AddModelError("", "El correo no esta registrado");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View((object)correo);
            }

        }

        [Authorize]
        public IActionResult Entrada()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(string correo)
        {
            bdvoleibolContext Context = new bdvoleibolContext();

            UsuarioRepository repos = new UsuarioRepository(Context);
            var user = repos.GetUsuarioByCorreo(correo);

            if (user != null)
            {
                repos.Delete(user);
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un error");
                return View("Entrada");
            }
            return RedirectToAction("Index");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(Roles = "DirectorTecnico, Administrador")]

        public IActionResult IndexAdminDt()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult DtInicioSesion()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DtInicioSesion(Directortecnico dt)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var DirT = repository.ObtenerDtPorClave(dt.Clave);
            try
            {
                if (DirT != null && DirT.Contrasena == HashHelper.GetHash(dt.Contrasena))
                {
                    if (DirT.Activo == 1)
                    {
                        List<Claim> info = new List<Claim>();
                        info.Add(new Claim(ClaimTypes.Name, "Usuario" + DirT.Nombre));
                        info.Add(new Claim(ClaimTypes.Role, "DirectorTecnico"));
                        info.Add(new Claim("Nombre", DirT.Nombre));
                        info.Add(new Claim("Id", DirT.Id.ToString()));

                        var claimsidentity = new ClaimsIdentity(info, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsprincipal = new ClaimsPrincipal(claimsidentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsprincipal,
                            new AuthenticationProperties { IsPersistent = true });
                        return RedirectToAction("IndexAdminDt", DirT.Clave);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Su cuenta no esta activa.");
                        return View(dt);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Clave de director tecnico o contraseña estan incorrectas.");
                    return View(dt);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dt);
            }
        }

        [AllowAnonymous]
        public IActionResult AdminIS()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> AdminIS(Administrador d)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            RolesRepository<Administrador> repository = new RolesRepository<Administrador>(context);
            var administrador = context.Administrador.FirstOrDefault(x => x.Clave == d.Clave);
            try
            {
                if (administrador != null && administrador.Contrasena == HashHelper.GetHash(d.Contrasena))
                {
                    List<Claim> info = new List<Claim>();
                    info.Add(new Claim(ClaimTypes.Name, "Usuario" + administrador.Nombre));
                    info.Add(new Claim(ClaimTypes.Role, "Administrador"));
                    info.Add(new Claim("clave", administrador.Nombre.ToString()));
                    info.Add(new Claim("Nombre", administrador.Nombre));

                    var claimsidentity = new ClaimsIdentity(info, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsprincipal = new ClaimsPrincipal(claimsidentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsprincipal,
                        new AuthenticationProperties { IsPersistent = true });
                    return RedirectToAction("IndexAdminDt");
                }
                else
                {
                    ModelState.AddModelError("", "El número de control o la contraseña del director son incorrectas.");
                    return View(d);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(d);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesionAdminDir()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult ListaDeDt()
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var DirectoresTecnicos = repository.ObtenerTodo();
            return View(DirectoresTecnicos);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult AltaDirTecnicos()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult AltaDirTecnicos(Directortecnico dt)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);

            try
            {
                var directortecnico = repository.ObtenerDtPorClave(dt.Clave);
                if (directortecnico == null)
                {
                    dt.Activo = 1;
                    dt.Contrasena = HashHelper.GetHash(dt.Contrasena);
                    repository.Insertar(dt);
                    return RedirectToAction("ListaDeDt");
                }
                else
                {
                    ModelState.AddModelError("", "La clave que ingresó no es valida.");
                    return View(dt);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dt);

            }

        }



        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult EstadoDirTecnico(Directortecnico dt)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerPorId(dt.Id);
            if (directortecnico != null && directortecnico.Activo == 0)
            {
                directortecnico.Activo = 1;
                repository.EditarI(directortecnico);
            }
            else
            {
                directortecnico.Activo = 0;
                repository.EditarI(directortecnico);
            }
            return RedirectToAction("ListaDeDt");
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult EditarDt(int id)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerPorId(id);
            if (directortecnico != null)
            {
                return View(directortecnico);
            }
            return RedirectToAction("ListaDeDt");
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult EditarDt(Directortecnico dt)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerPorId(dt.Id);
            try
            {
                if (directortecnico != null)
                {
                    directortecnico.Nombre = dt.Nombre;
                    directortecnico.Equipo = dt.Equipo;
                    directortecnico.NacionalesGanados = dt.NacionalesGanados;
                    directortecnico.NacionalesPerdidos = dt.NacionalesPerdidos;
                    directortecnico.InternacionalesGanados = dt.InternacionalesGanados;
                    directortecnico.InternacionalesPerdidos = dt.InternacionalesPerdidos;
                    directortecnico.Seleccion = dt.Seleccion;
                    directortecnico.Tipo = dt.Tipo;
                    repository.EditarI(directortecnico);
                }
                return RedirectToAction("ListaDeDt");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(directortecnico);
            }
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult CambiarClaveDt(int id)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerPorId(id);
            if (directortecnico == null)
            {
                return RedirectToAction("ListaDeDt");
            }
            return View(directortecnico);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CambiarClaveDt(Directortecnico m, string nuevaContra, string nuevaContraConfirm)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerPorId(m.Id);
            try
            {

                if (directortecnico != null)
                {
                    if (nuevaContra != nuevaContraConfirm)
                    {
                        ModelState.AddModelError("", "Las contraseñas no coinciden.");
                        return View(directortecnico);
                    }
                    else if (directortecnico.Contrasena == HashHelper.GetHash(nuevaContra))
                    {
                        ModelState.AddModelError("", "La nueva contraseña no puede ser igual a la que desea cambiar.");
                        return View(directortecnico);
                    }
                    else
                    {
                        directortecnico.Contrasena = HashHelper.GetHash(nuevaContra);
                        repository.EditarI(directortecnico);
                        return RedirectToAction("ListaDeDt");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El director tecnico a editar no existe.");
                    return View(directortecnico);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(directortecnico);
            }
        }

        [Authorize(Roles = "DirectorTecnico, Administrador")]
        public IActionResult ListaDeIntegrantes(int id)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            var directortecnico = repository.ObtenerIntegrantesPorDt(id);
            if (directortecnico != null)
            {
                if (User.IsInRole("DirectorTecnico"))
                {
                    if (User.Claims.FirstOrDefault(x => x.Type == "Id").Value == directortecnico.Id.ToString())
                    {
                        return View(directortecnico);
                    }
                    else
                    {
                        return RedirectToAction("Denegado");
                    }
                }
                else
                {
                    return View(directortecnico);
                }
            }
            else
            {
                return RedirectToAction("ListaDeIntegrantes");
            }
        }

        //[Authorize(Roles = "DirectorTecnico, Administrador")]


        //public IActionResult AgregarIntegrante(int id)
        //{
        //    bdvoleibolContext context = new bdvoleibolContext();
        //    DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
        //    IntegrantesVM viewModel = new IntegrantesVM();
        //    viewModel.Directortecnico = repository.ObtenerPorId(id);

        //    if (viewModel.Directortecnico != null)
        //    {
        //        if (User.IsInRole("DirectorTecnico"))
        //        {
        //            if (User.Claims.FirstOrDefault(x => x.Type == "Id").Value == viewModel.Directortecnico.Id.ToString())
        //            {
        //                return View(viewModel);

        //            }
        //            else
        //            {
        //                return RedirectToAction("Denegado");
        //            }
        //        }
        //        else
        //        {
        //            return View(viewModel);

        //        }
        //    }
        //    return View(viewModel);

        //}

        //[Authorize(Roles = "DirectorTecnico, Administrador")]
        //[HttpPost]


        //public IActionResult AgregarIntegrante(IntegrantesVM viewModel)
        //{
        //    bdvoleibolContext context = new bdvoleibolContext();
        //    DirectorTecnicoRepository directorTecnicoRepository = new DirectorTecnicoRepository(context);
        //    IntegrantesRepository integrantesRepository = new IntegrantesRepository(context);
        //    if (viewModel.Archivo.ContentType != "image/jpeg" || viewModel.Archivo.Length > 1024 * 1024 * 2)

        //    {
        //        ModelState.AddModelError("", "Debe seleccionar un archivo jpeg de almenos de 2mb.");
        //        return View(viewModel);

        //    }
        //    try
        //    {

        //        var IdDt = directorTecnicoRepository.ObtenerDtPorClave(viewModel.Directortecnico.Clave).Id;
        //        viewModel.Integrantes.IdDt = IdDt;
        //        integrantesRepository.Insertar(viewModel.Integrantes);
        //        FileStream fs = new FileStream(Environment.WebRootPath + "/images/" + viewModel.Integrantes.Id + ".jpg", FileMode.Create);
        //        viewModel.Archivo.CopyTo(fs);
        //        fs.Close();
        //        return RedirectToAction("ListaDeIntegrantes");

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View(viewModel);

        //    }
        //}



        //[Authorize(Roles = "DirectorTecnico, Administrador")]

        //public IActionResult EditarIntegrante(int id)
        //{
        //    bdvoleibolContext context = new bdvoleibolContext();
        //    IntegrantesVM vm = new IntegrantesVM();
        //    DirectorTecnicoRepository directorTecnicoRepository = new DirectorTecnicoRepository(context);

        //    IntegrantesRepository pr = new IntegrantesRepository(context);
        //    vm.Integrantes = pr.ObtenerPorId(id);

        //    if (vm.Integrantes == null)
        //    {
        //        vm.Directortecnico = directorTecnicoRepository.ObtenerPorId(vm.Integrantes.IdDt);
        //        if (User.IsInRole("DirectorTecnico"))
        //        {
        //            vm.Directortecnico = directorTecnicoRepository.ObtenerPorId(vm.Integrantes.IdDt);
        //            if (User.Claims.FirstOrDefault(x => x.Type == "Id").Value == vm.Directortecnico.Clave.ToString())
        //            {

        //                return View(vm);
        //            }
        //        }
        //        return View(vm);
        //    }
        //    else return RedirectToAction("Index");

        //    //DirectorTecnicoRepository cr = new DirectorTecnicoRepository(context);
        //    vm.directortecnicos = directorTecnicoRepository.ObtenerTodo();
        //    if (System.IO.File.Exists(Environment.WebRootPath + $"/images/{vm.Integrantes.Id}.jpg"))
        //    {
        //        vm.Imagen = vm.Integrantes.Id + ".jpg";
        //    }
        //    else
        //    {
        //        vm.Imagen = "no-disponible.png";
        //    }
        //    //return View(vm);
        //    return RedirectToAction("ListaDeIntegrantes");

        //}


        //[Authorize(Roles = "DirectorTecnico, Administrador")]
        //[HttpPost]
        //public IActionResult EditarIntegrante(IntegrantesVM vm)
        //{
        //    bdvoleibolContext context = new bdvoleibolContext();
        //    if (vm.Archivo != null)
        //    {
        //        if (vm.Archivo.ContentType != "image/jpeg" || vm.Archivo.Length > 1024 * 1024 * 2)
        //        {
        //            ModelState.AddModelError("", "Debe seleccionar un archivo jpg de menos de 2MB.");
        //            DirectorTecnicoRepository categoriasRepository = new DirectorTecnicoRepository(context);
        //            vm.directortecnicos = categoriasRepository.ObtenerTodo();
        //            //return View(vm);
        //            return RedirectToAction("ListaDeIntegrantes");
        //        }
        //    }

        //    try
        //    {
        //        IntegrantesRepository repos = new IntegrantesRepository(context);
        //        var integrantes = repos.ObtenerPorId(vm.Integrantes.Id);
        //        if (integrantes != null)
        //        {
        //            integrantes.Edad = vm.Integrantes.Edad;
        //            integrantes.Estado = vm.Integrantes.Estado;
        //            integrantes.Posicion = vm.Integrantes.Posicion;
        //            integrantes.NumCamiseta = vm.Integrantes.NumCamiseta;
        //            integrantes.Fuerza = vm.Integrantes.Fuerza;
        //            integrantes.Bloqueo = vm.Integrantes.Bloqueo;
        //            integrantes.Recepcion = vm.Integrantes.Recepcion;
        //            integrantes.Remate = vm.Integrantes.Remate;
        //            integrantes.Salto = vm.Integrantes.Salto;
        //            integrantes.Saque = vm.Integrantes.Saque;

        //            repos.EditarI(integrantes);

        //            if (vm.Archivo != null)
        //            {
        //                FileStream fs = new FileStream(Environment.WebRootPath + "/images/" + vm.Integrantes.Id + ".jpg", FileMode.Create);
        //                vm.Archivo.CopyTo(fs);
        //                fs.Close();
        //            }

        //        }
        //        return RedirectToAction("ListaDeIntegrantes");
        //        //return View(vm);
        //    }

        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        DirectorTecnicoRepository categoriasRepository = new DirectorTecnicoRepository(context);
        //        vm.directortecnicos = categoriasRepository.ObtenerTodo();
        //        return View(vm);
        //    }
        //}
        [Authorize(Roles = "Administrador, DirectorTecnico")]
        public IActionResult AgregarIntegrante(int id)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository repository = new DirectorTecnicoRepository(context);
            IntegrantesVM intevm = new IntegrantesVM();
            intevm.Directortecnico = repository.ObtenerPorId(id);
            return View(intevm);
        }
        [Authorize(Roles = "Administrador, DirectorTecnico")]
        [HttpPost]
        public IActionResult AgregarIntegrante(IntegrantesVM vm)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            DirectorTecnicoRepository DTrepository = new DirectorTecnicoRepository(context);
            IntegrantesRepository Prepository = new IntegrantesRepository(context);
            if (vm.Archivo.ContentType != "image/jpeg" || vm.Archivo.Length > 1024 * 1024 * 2)
            {
                ModelState.AddModelError("", "Debe selecionar un archivo jpg de menos de 2mb");
                return View(vm);
            }
            try
            {

                var IdDt = DTrepository.ObtenerDtPorClave(vm.Directortecnico.Clave).Id;
              
                vm.Integrantes.IdDt = IdDt;
                Prepository.Insertar(vm.Integrantes);
                System.IO.FileStream fs = new FileStream(Environment.WebRootPath + "/images/" + vm.Integrantes.Id + "_0.jpg", FileMode.Create);
                vm.Archivo.CopyTo(fs);
                fs.Close();
                return RedirectToAction("ListaDeIntegrantes");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }



        [Authorize(Roles = "Administrador, DirectorTecnico")]
        public IActionResult EditarIntegrante(int id)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            IntegrantesVM vm = new IntegrantesVM();

            IntegrantesRepository pr = new IntegrantesRepository(context);
            vm.Integrantes = pr.ObtenerPorId(id);
            if (vm.Integrantes == null)
            {
                return RedirectToAction("ListaDeIntegrantes");
            }
            DirectorTecnicoRepository dtrepository = new DirectorTecnicoRepository(context);
            vm.directortecnicos = dtrepository.ObtenerTodo();
            if (System.IO.File.Exists(Environment.WebRootPath + $"/images/{vm.Integrantes.Id}_0.jpg"))
            {
                vm.Imagen = vm.Integrantes.Id + "_0.jpg";
            }
            else
            {
                vm.Imagen = "no-disponible.png";
            }

            return View(vm);

        }


        [Authorize(Roles = "Administrador, DirectorTecnico")]
        [HttpPost]
        public IActionResult EditarIntegrante(IntegrantesVM vm)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            if (vm.Archivo != null)
            {
                if (vm.Archivo.ContentType != "image/jpeg" || vm.Archivo.Length > 1024 * 1024 * 2)
                {
                    ModelState.AddModelError("", "Debe selecionar un archivo jpg de menos de 2mb");
                    DirectorTecnicoRepository marcarepository = new DirectorTecnicoRepository(context);
                    vm.directortecnicos = marcarepository.ObtenerTodo();

                    return View(vm);
                }
            }

            try
            {
                IntegrantesRepository repos = new IntegrantesRepository(context);

                var integrantes = repos.ObtenerPorId(vm.Integrantes.Id);
                if (integrantes != null)
                {
                    integrantes.Edad = vm.Integrantes.Edad;
                    integrantes.Estado = vm.Integrantes.Estado;
                    integrantes.Posicion = vm.Integrantes.Posicion;
                    integrantes.NumCamiseta = vm.Integrantes.NumCamiseta;
                    integrantes.Fuerza = vm.Integrantes.Fuerza;
                    integrantes.Bloqueo = vm.Integrantes.Bloqueo;
                    integrantes.Recepcion = vm.Integrantes.Recepcion;
                    integrantes.Remate = vm.Integrantes.Remate;
                    integrantes.Salto = vm.Integrantes.Salto;
                    integrantes.Saque = vm.Integrantes.Saque;
                    if (vm.Archivo != null)
                    {
                        FileStream fs = new FileStream(Environment.WebRootPath + "/images/" + vm.Integrantes.Id + "_0.jpg", FileMode.Create);
                        vm.Archivo.CopyTo(fs);
                        fs.Close();
                    }

                }


                return RedirectToAction("ListaDeIntegrantes");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                DirectorTecnicoRepository dtarcarepository = new DirectorTecnicoRepository(context);
                vm.directortecnicos = dtarcarepository.ObtenerTodo();

                return View(vm);
            }

        }

        [Authorize(Roles = "DirectorTecnico, Administrador")]
        [HttpPost]
        public IActionResult EliminarIntegrante(Integrantes integrantes)
        {
            bdvoleibolContext context = new bdvoleibolContext();
            IntegrantesRepository repository = new IntegrantesRepository(context);
            var integrante = repository.ObtenerPorId(integrantes.Id);
            if (integrante != null)
            {
                repository.Eliminar(integrante);
            }
            else
            {
                ModelState.AddModelError("", "El equipo a eliminar no existe.");
            }
            return RedirectToAction("ListaDeIntegrantes", new { id = integrante.IdDt });
        }

        [AllowAnonymous]
        public IActionResult Denegado()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult VentanaP()
        {
            bdvoleibolContext context = new bdvoleibolContext();
            var directortecnico = context.Directortecnico.Include(x => x.Integrantes).OrderBy(x => x.Nombre).Select(x => new DtVM
            {
                DirT = x.Nombre,
                Integrantes = x.Integrantes
            }
            );

            return View(directortecnico);

        }

        public IActionResult InfoEquipo(string Id)
        {
           
            bdvoleibolContext context = new bdvoleibolContext();

            IntegrantesRepository repos = new IntegrantesRepository(context);
            IntegrantesVM vm = new IntegrantesVM();
            vm.Integrantes = repos.GetIntegrantesPorNombre(Id);
            if(vm.Integrantes == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }

        }

        [Route("{id}")]
        public IActionResult integrantesXequipo(string Id)
        {
            using(bdvoleibolContext context = new bdvoleibolContext())

            {
                IntegrantesRepository repos = new IntegrantesRepository(context);
                DtVM vM = new DtVM();

                vM.DirT = Id;
                vM.Integrantes = repos.ObtenerIntegrantesxDt(Id).ToList();

                return View(vM);
            }
        }
    }
}
