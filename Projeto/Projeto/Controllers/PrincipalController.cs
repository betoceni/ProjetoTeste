using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class PrincipalController : Controller
    {
        public List<Ingredientes> CarregaIngredientes()
        {
            //Carregando a lista de ingredientes
            Ingredientes item;
            List<Ingredientes> lista = new List<Ingredientes>();

            //Alface
            item = new Ingredientes();
            item.Codigo_Ingrediente = 1;
            item.Ingrediente = "Alface";
            item.Valor_Ingrediente = string.Format("{0:C}", 0.4);
            item.Qtde_Ingrediente = 0;
            lista.Add(item);

            //Bacon
            item = new Ingredientes();
            item.Codigo_Ingrediente = 2;
            item.Ingrediente = "Bacon";
            item.Valor_Ingrediente = string.Format("{0:C}", 2);
            item.Qtde_Ingrediente = 0;
            lista.Add(item);

            //Hamburger de carne
            item = new Ingredientes();
            item.Codigo_Ingrediente = 3;
            item.Ingrediente = "Hambúrger de carne";
            item.Valor_Ingrediente = string.Format("{0:C}", 3);
            item.Qtde_Ingrediente = 0;
            lista.Add(item);

            //Ovo
            item = new Ingredientes();
            item.Codigo_Ingrediente = 4;
            item.Ingrediente = "Ovo";
            item.Valor_Ingrediente = string.Format("{0:C}", 0.8);
            item.Qtde_Ingrediente = 0;
            lista.Add(item);

            //Queijo
            item = new Ingredientes();
            item.Codigo_Ingrediente = 5;
            item.Ingrediente = "Queijo";
            item.Valor_Ingrediente = string.Format("{0:C}", 1.5);
            item.Qtde_Ingrediente = 0;
            lista.Add(item);

            //Guardando a lista de ingredientes em Session
            Session["Ingredientes"] = lista;

            return lista;
        }

        //Carregando a lista de lanches
        public List<Lanches> CarregaLanches()
        {
            //Recuperando a lista de ingredientes da Session
            List<Ingredientes> lista_lanche = new List<Ingredientes>();
            lista_lanche = CarregaIngredientes();

            //Lista de lanches
            Lanches item;
            List<Lanches> lista = new List<Lanches>();

            //Valores dos ingredientes
            var valor_item_alface = lista_lanche.Where(x => x.Codigo_Ingrediente == 1).FirstOrDefault();
            var valor_item_bacon = lista_lanche.Where(x => x.Codigo_Ingrediente == 2).FirstOrDefault();
            var valor_item_hamburger = lista_lanche.Where(x => x.Codigo_Ingrediente == 3).FirstOrDefault();
            var valor_item_ovo = lista_lanche.Where(x => x.Codigo_Ingrediente == 4).FirstOrDefault();
            var valor_item_queijo = lista_lanche.Where(x => x.Codigo_Ingrediente == 5).FirstOrDefault();

            //X-Bacon
            //Soma dos valores            
            var valor_soma_xbacon = (
                                        Convert.ToDecimal(valor_item_bacon.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_hamburger.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_queijo.Valor_Ingrediente.Replace("R$", ""))
                                    );

            item = new Lanches();
            item.Codigo_Lanche = 1;
            item.Lanche = "X-Bacon";
            item.Conteudo = "Bacon, hambúrger de carne e queijo";
            item.Valor_Lanche = string.Format("{0:C}", valor_soma_xbacon);
            lista.Add(item);

            //X-Burger
            //Soma dos valores
            var valor_soma_xburger = (
                                        Convert.ToDecimal(valor_item_hamburger.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_queijo.Valor_Ingrediente.Replace("R$", ""))
                                    );

            item = new Lanches();
            item.Codigo_Lanche = 2;
            item.Lanche = "X-Burger";
            item.Conteudo = "Hambúrger de carne e queijo";
            item.Valor_Lanche = string.Format("{0:C}", valor_soma_xburger);
            lista.Add(item);

            //X-Egg
            //Soma dos valores
            var valor_soma_xegg = (
                                        Convert.ToDecimal(valor_item_ovo.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_hamburger.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_queijo.Valor_Ingrediente.Replace("R$", ""))
                                    );
            item = new Lanches();
            item.Codigo_Lanche = 3;
            item.Lanche = "X-Egg";
            item.Conteudo = "Ovo, hambúrger de carne e queijo";
            item.Valor_Lanche = string.Format("{0:C}", valor_soma_xegg);
            lista.Add(item);

            //X-Egg Bacon
            //Soma dos valores
            var valor_soma_xeggbacon = (
                                        Convert.ToDecimal(valor_item_ovo.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_bacon.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_hamburger.Valor_Ingrediente.Replace("R$", "")) +
                                        Convert.ToDecimal(valor_item_queijo.Valor_Ingrediente.Replace("R$", ""))
                                    );

            item = new Lanches();
            item.Codigo_Lanche = 4;
            item.Lanche = "X-Egg Bacon";
            item.Conteudo = "Ovo, bacon, hambúrger de carne e queijo";
            item.Valor_Lanche = string.Format("{0:C}", valor_soma_xeggbacon);
            lista.Add(item);

            //Guardando a lista de lanches em Session
            Session["Lanches"] = lista;

            return lista;
        }

        // GET: Principal
        public ActionResult Index()
        {
            //Carregando a lista de ingredientes
            List<Ingredientes> lista = new List<Ingredientes>();
            List<Lanches> lista_lanches = new List<Lanches>();

            //Recuperando a lista de ingredientes da Session
            lista = CarregaIngredientes();

            //Recuperando a lista de lanches da Session
            lista_lanches = CarregaLanches();

            return View();
        }

        // GET: Principal
        public ActionResult Ingredientes()
        {
            //Lista de ingredientes
            List<Ingredientes> lista = new List<Ingredientes>();

            //Recuperando a lista de ingredientes da Session
            lista = CarregaIngredientes();

            return View(lista);
        }

        public ActionResult Lanches()
        {
            //Lista de lanches
            List<Lanches> lista = new List<Lanches>();

            //Recuperando a lista de ingredientes da Session
            lista = CarregaLanches();

            return View(lista);
        }

        //Personalizar Lanches
        public ActionResult PersonalizarLanches()
        {
            //Lista de ingredientes
            List<Ingredientes> lista = new List<Ingredientes>();

            //Recuperando a lista de ingredientes da Session
            lista = CarregaIngredientes();

            return View(lista);
        }


        [HttpGet]
        public ActionResult ListaLanchesPersonalizados()
        {
            //Lista de lanches
            List<Lanches> lista = new List<Lanches>();

            //Recuperando a lista de ingredientes da Session
            lista = CarregaLanches();

            return View(lista);
        }

        //Monta Lanches Personalizados    
        [HttpPost]
        public ActionResult ListaLanchesPersonalizados(FormCollection form)
        {
            string vetor = "";
            //Coletando os valores das quantidades dos 5 ingredientes disponíveis
            foreach (var key in form.AllKeys)
            {
                vetor = form[key];
            }

            string[] lista_qtde = vetor.Split(',');

            int Qtde1 = Convert.ToInt32(lista_qtde[0].ToString());
            int Qtde2 = Convert.ToInt32(lista_qtde[1].ToString());
            int Qtde3 = Convert.ToInt32(lista_qtde[2].ToString());
            int Qtde4 = Convert.ToInt32(lista_qtde[3].ToString());
            int Qtde5 = Convert.ToInt32(lista_qtde[4].ToString());

            //Carregando a lista de ingredientes
            List<Ingredientes> lista_ingredientes_aux = new List<Ingredientes>();
            Ingredientes item_ingredientes;
            int i;
            decimal total_parcial = 0;
            string conteudo_lanche = string.Empty;
            List<Ingredientes> lista_ingredientes = new List<Ingredientes>();

            //Recuperando a lista de ingredientes da Session
            lista_ingredientes_aux = CarregaIngredientes();

            for (i = 0; i < lista_ingredientes_aux.Count; i++)
            {
                item_ingredientes = new Ingredientes();
                item_ingredientes.Codigo_Ingrediente = lista_ingredientes_aux[i].Codigo_Ingrediente;
                item_ingredientes.Ingrediente = lista_ingredientes_aux[i].Ingrediente;

                if (i == 0)
                {
                    item_ingredientes.Qtde_Ingrediente = Qtde1;
                    if (Qtde1 > 0)
                        conteudo_lanche = conteudo_lanche + lista_ingredientes_aux[i].Ingrediente + ", ";
                }
                else if (i == 1)
                {
                    item_ingredientes.Qtde_Ingrediente = Qtde2;
                    if (Qtde2 > 0)
                        conteudo_lanche = conteudo_lanche + lista_ingredientes_aux[i].Ingrediente + ", ";
                }
                else if (i == 2)
                {
                    item_ingredientes.Qtde_Ingrediente = Qtde3;
                    if (Qtde3 > 0)
                        conteudo_lanche = conteudo_lanche + lista_ingredientes_aux[i].Ingrediente + ", ";
                }
                else if (i == 3)
                {
                    item_ingredientes.Qtde_Ingrediente = Qtde4;
                    if (Qtde4 > 0)
                        conteudo_lanche = conteudo_lanche + lista_ingredientes_aux[i].Ingrediente + ", ";
                }
                else if (i == 4)
                {
                    item_ingredientes.Qtde_Ingrediente = Qtde5;
                    if (Qtde5 > 0)
                        conteudo_lanche = conteudo_lanche + lista_ingredientes_aux[i].Ingrediente + ", ";
                }

                item_ingredientes.Valor_Ingrediente = (Convert.ToDecimal(lista_ingredientes_aux[i].Valor_Ingrediente.Replace("R$", "")) * item_ingredientes.Qtde_Ingrediente).ToString();
                lista_ingredientes.Add(item_ingredientes);

                //Calculando total parcial
                total_parcial = total_parcial + Convert.ToDecimal(item_ingredientes.Valor_Ingrediente);
            }

            //Removendo a última vírgula
            conteudo_lanche = conteudo_lanche.Substring(0, conteudo_lanche.Length - 2);


            //Promoções
            decimal desconto = Promocoes(Qtde1, Qtde2, Qtde3, Qtde4, Qtde5, total_parcial, lista_ingredientes_aux, lista_ingredientes);


            //Lista de ingredientes
            List<Lanches> lista = new List<Lanches>();
            Lanches item = new Lanches();

            //Gravando informações do lanche personalizado
            item.Codigo_Lanche = 5;
            item.Lanche = "Personalizado";
            item.Conteudo = conteudo_lanche;
            item.Valor_Lanche = string.Format("{0:C}", (total_parcial - desconto));
            lista.Add(item);


            return View(lista);
        }

        public decimal Promocoes(int Qtde1, int Qtde2, int Qtde3, int Qtde4, int Qtde5, decimal total_parcial, List<Ingredientes> lista_ingredientes_aux, List<Ingredientes> lista_ingredientes)
        {
            decimal retorno = 0;
            decimal desconto = 0;

            if (Qtde1 > 0 && Qtde2 == 0) //Light
                desconto = Convert.ToDecimal(Convert.ToDouble(total_parcial) * 0.1);

            if (Qtde3 > 2) //Muita carne
                desconto = lista_ingredientes.Where(x => x.Codigo_Ingrediente == 3).Select(x => Convert.ToDecimal(x.Valor_Ingrediente.Replace("R$", ""))).FirstOrDefault() -
                   (lista_ingredientes_aux.Where(x => x.Codigo_Ingrediente == 3).Select(x => Convert.ToDecimal(x.Valor_Ingrediente.Replace("R$", ""))).FirstOrDefault()) * (Qtde3 - Convert.ToInt32(Qtde3 / 3));

            if (Qtde5 > 2) //Muito queijo
                desconto = lista_ingredientes.Where(x => x.Codigo_Ingrediente == 5).Select(x => Convert.ToDecimal(x.Valor_Ingrediente.Replace("R$", ""))).FirstOrDefault() -
                   (lista_ingredientes_aux.Where(x => x.Codigo_Ingrediente == 5).Select(x => Convert.ToDecimal(x.Valor_Ingrediente.Replace("R$", ""))).FirstOrDefault()) * (Qtde5 - Convert.ToInt32(Qtde5 / 3));

            retorno = desconto;

            return retorno;
        }

        // GET: Principal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Principal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Principal/Edit/5
        public ActionResult Voltar()
        {
            //return View();
            return RedirectToAction("Index");
        }

        // GET: Principal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Principal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Principal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Principal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
