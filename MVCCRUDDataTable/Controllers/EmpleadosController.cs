using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDDataTable.Models;
using System.Data.Entity;

namespace MVCCRUDDataTable.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mostrar()
        {

            List<TblEmpleados> resultado = new List<TblEmpleados>();

            using (ConexionEntities db = new ConexionEntities())
            {
                resultado = db.TblEmpleado.ToList();
            }

            return Json(new { data = resultado }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AgregarOEditar(int id = 0)
        {

            TblEmpleados resultado = new TblEmpleados();

            try
            {
                if (id != 0)
                {

                    using (ConexionEntities db = new ConexionEntities())
                    {
                        resultado = db.TblEmpleado.Find(id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(resultado);
        }

        [HttpPost]
        public ActionResult AgregarOEditar(TblEmpleados _Empleado)
        {

            try
            {

                if (_Empleado.IdEmpleado == 0)
                {
                    using (ConexionEntities db = new ConexionEntities())
                    {
                        db.TblEmpleado.Add(_Empleado);
                        db.SaveChanges();
                    }

                    return Json(new { success = true, message = "Registro Exitoso" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    using (ConexionEntities db = new ConexionEntities())
                    {
                        var _modificar = db.TblEmpleado.Find(_Empleado.IdEmpleado);
                        if (_modificar != null)
                        {

                            _modificar.Nombres = _Empleado.Nombres;
                            _modificar.Apellidos = _Empleado.Apellidos;
                            _modificar.Edad = _Empleado.Edad;
                            _modificar.Oficio = _Empleado.Oficio;
                            _modificar.Salario = _Empleado.Salario;

                            db.SaveChanges();
                        }

                    }

                    return Json(new { success = true, message = "Registro Actualizado" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (ConexionEntities db = new ConexionEntities())
                {
                    var _Eliminar = db.TblEmpleado.Find(id);

                    if (_Eliminar!=null)
                    {
                        db.TblEmpleado.Remove(_Eliminar);
                        db.SaveChanges();
                    }
                    else                    
                        return Json(new { success = false, message = "El registro no existe" }, JsonRequestBehavior.AllowGet);
                    
                }

                return Json(new { success = true, message = "Registro Eliminado" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
