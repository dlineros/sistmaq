using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maqadmin.Models
{
    public class bingo
    {
        public string letraNumeroAleatorio(int idlocal)
        {
            var salida = string.Empty;
            Random r = new Random();

            int rInt = r.Next(1, 76); //for ints

            var listActual = numerosActuales(1);
            
            while ((listActual.Contains(rInt) == true) && (listActual.Count() < 75))
            {
                rInt = r.Next(1, 76);
                
            }

            //Significa que aqui obtuvo la bolita 75
            if ((listActual.Count() == 74))
            {
                using (var db = new bdloginEntities())
                {
                    //1:Juego Finalizado, ya se generaron todos los números
                    db.bingoParametro.Where(p=>p.idLocal==idlocal).Single().idEstadoJuego = 1;
                    db.SaveChanges();
                }
            }

            if ((listActual.Count() == 75))
            {
                using (var db = new bdloginEntities())
                {
                    //1:Juego Finalizado, ya se generaron todos los números
                    db.bingoParametro.Where(p => p.idLocal == idlocal).Single().idEstadoJuego = 1;
                    db.SaveChanges();
                    return "";
                }
            }

            if (rInt >= 1 && rInt <= 15) salida = "B-" + rInt;
            if (rInt >= 16 && rInt <= 30) salida = "I-" + rInt;
            if (rInt >= 31 && rInt <= 45) salida = "N-" + rInt;
            if (rInt >= 46 && rInt <= 60) salida = "G-" + rInt;
            if (rInt >= 61 && rInt <= 75) salida = "O-" + rInt;

            using (var db = new bdloginEntities())
            {

                var existeBingo = (from p in db.bingoJuego
                                   where p.idlocal==idlocal
                                   select p).Single();


                if (salida == "B-1") { existeBingo.B1 = true; }
                if (salida == "B-2") { existeBingo.B2 = true; }
                if (salida == "B-3") { existeBingo.B3 = true; }
                if (salida == "B-4") { existeBingo.B4 = true; }
                if (salida == "B-5") { existeBingo.B5 = true; }
                if (salida == "B-6") { existeBingo.B6 = true; }
                if (salida == "B-7") { existeBingo.B7 = true; }
                if (salida == "B-8") { existeBingo.B8 = true; }
                if (salida == "B-9") { existeBingo.B9 = true; }
                if (salida == "B-10") { existeBingo.B10 = true; }
                if (salida == "B-11") { existeBingo.B11 = true; }
                if (salida == "B-12") { existeBingo.B12 = true; }
                if (salida == "B-13") { existeBingo.B13 = true; }
                if (salida == "B-14") { existeBingo.B14 = true; }
                if (salida == "B-15") { existeBingo.B15 = true; }
                if (salida == "I-16") { existeBingo.I16 = true; }
                if (salida == "I-17") { existeBingo.I17 = true; }
                if (salida == "I-18") { existeBingo.I18 = true; }
                if (salida == "I-19") { existeBingo.I19 = true; }
                if (salida == "I-20") { existeBingo.I20 = true; }
                if (salida == "I-21") { existeBingo.I21 = true; }
                if (salida == "I-22") { existeBingo.I22 = true; }
                if (salida == "I-23") { existeBingo.I23 = true; }
                if (salida == "I-24") { existeBingo.I24 = true; }
                if (salida == "I-25") { existeBingo.I25 = true; }
                if (salida == "I-26") { existeBingo.I26 = true; }
                if (salida == "I-27") { existeBingo.I27 = true; }
                if (salida == "I-28") { existeBingo.I28 = true; }
                if (salida == "I-29") { existeBingo.I29 = true; }
                if (salida == "I-30") { existeBingo.I30 = true; }
                if (salida == "N-31") { existeBingo.N31 = true; }
                if (salida == "N-32") { existeBingo.N32 = true; }
                if (salida == "N-33") { existeBingo.N33 = true; }
                if (salida == "N-34") { existeBingo.N34 = true; }
                if (salida == "N-35") { existeBingo.N35 = true; }
                if (salida == "N-36") { existeBingo.N36 = true; }
                if (salida == "N-37") { existeBingo.N37 = true; }
                if (salida == "N-38") { existeBingo.N38 = true; }
                if (salida == "N-39") { existeBingo.N39 = true; }
                if (salida == "N-40") { existeBingo.N40 = true; }
                if (salida == "N-41") { existeBingo.N41 = true; }
                if (salida == "N-42") { existeBingo.N42 = true; }
                if (salida == "N-43") { existeBingo.N43 = true; }
                if (salida == "N-44") { existeBingo.N44 = true; }
                if (salida == "N-45") { existeBingo.N45 = true; }
                if (salida == "G-46") { existeBingo.G46 = true; }
                if (salida == "G-47") { existeBingo.G47 = true; }
                if (salida == "G-48") { existeBingo.G48 = true; }
                if (salida == "G-49") { existeBingo.G49 = true; }
                if (salida == "G-50") { existeBingo.G50 = true; }
                if (salida == "G-51") { existeBingo.G51 = true; }
                if (salida == "G-52") { existeBingo.G52 = true; }
                if (salida == "G-53") { existeBingo.G53 = true; }
                if (salida == "G-54") { existeBingo.G54 = true; }
                if (salida == "G-55") { existeBingo.G55 = true; }
                if (salida == "G-56") { existeBingo.G56 = true; }
                if (salida == "G-57") { existeBingo.G57 = true; }
                if (salida == "G-58") { existeBingo.G58 = true; }
                if (salida == "G-59") { existeBingo.G59 = true; }
                if (salida == "G-60") { existeBingo.G60 = true; }
                if (salida == "O-61") { existeBingo.O61 = true; }
                if (salida == "O-62") { existeBingo.O62 = true; }
                if (salida == "O-63") { existeBingo.O63 = true; }
                if (salida == "O-64") { existeBingo.O64 = true; }
                if (salida == "O-65") { existeBingo.O65 = true; }
                if (salida == "O-66") { existeBingo.O66 = true; }
                if (salida == "O-67") { existeBingo.O67 = true; }
                if (salida == "O-68") { existeBingo.O68 = true; }
                if (salida == "O-69") { existeBingo.O69 = true; }
                if (salida == "O-70") { existeBingo.O70 = true; }
                if (salida == "O-71") { existeBingo.O71 = true; }
                if (salida == "O-72") { existeBingo.O72 = true; }
                if (salida == "O-73") { existeBingo.O73 = true; }
                if (salida == "O-74") { existeBingo.O74 = true; }
                if (salida == "O-75") { existeBingo.O75 = true; }


                existeBingo.ultimonumero = salida;
                



                db.SaveChanges();






            }

            return salida;




        }

        public List<int> numerosActuales(int idbingo)
        {
            var lista = new List<int>();
            using (var db = new bdloginEntities())
            {
                var objBingo = (from p in db.bingoJuego
                                where p.idbingo == idbingo
                                select p).SingleOrDefault();

                if (objBingo != null)
                {

                    if (objBingo.B1 == true) lista.Add(1);
                    if (objBingo.B2 == true) lista.Add(2);
                    if (objBingo.B3 == true) lista.Add(3);
                    if (objBingo.B4 == true) lista.Add(4);
                    if (objBingo.B5 == true) lista.Add(5);
                    if (objBingo.B6 == true) lista.Add(6);
                    if (objBingo.B7 == true) lista.Add(7);
                    if (objBingo.B8 == true) lista.Add(8);
                    if (objBingo.B9 == true) lista.Add(9);
                    if (objBingo.B10 == true) lista.Add(10);
                    if (objBingo.B11 == true) lista.Add(11);
                    if (objBingo.B12 == true) lista.Add(12);
                    if (objBingo.B13 == true) lista.Add(13);
                    if (objBingo.B14 == true) lista.Add(14);
                    if (objBingo.B15 == true) lista.Add(15);
                    if (objBingo.I16 == true) lista.Add(16);
                    if (objBingo.I17 == true) lista.Add(17);
                    if (objBingo.I18 == true) lista.Add(18);
                    if (objBingo.I19 == true) lista.Add(19);
                    if (objBingo.I20 == true) lista.Add(20);
                    if (objBingo.I21 == true) lista.Add(21);
                    if (objBingo.I22 == true) lista.Add(22);
                    if (objBingo.I23 == true) lista.Add(23);
                    if (objBingo.I24 == true) lista.Add(24);
                    if (objBingo.I25 == true) lista.Add(25);
                    if (objBingo.I26 == true) lista.Add(26);
                    if (objBingo.I27 == true) lista.Add(27);
                    if (objBingo.I28 == true) lista.Add(28);
                    if (objBingo.I29 == true) lista.Add(29);
                    if (objBingo.I30 == true) lista.Add(30);
                    if (objBingo.N31 == true) lista.Add(31);
                    if (objBingo.N32 == true) lista.Add(32);
                    if (objBingo.N33 == true) lista.Add(33);
                    if (objBingo.N34 == true) lista.Add(34);
                    if (objBingo.N35 == true) lista.Add(35);
                    if (objBingo.N36 == true) lista.Add(36);
                    if (objBingo.N37 == true) lista.Add(37);
                    if (objBingo.N38 == true) lista.Add(38);
                    if (objBingo.N39 == true) lista.Add(39);
                    if (objBingo.N40 == true) lista.Add(40);
                    if (objBingo.N41 == true) lista.Add(41);
                    if (objBingo.N42 == true) lista.Add(42);
                    if (objBingo.N43 == true) lista.Add(43);
                    if (objBingo.N44 == true) lista.Add(44);
                    if (objBingo.N45 == true) lista.Add(45);
                    if (objBingo.G46 == true) lista.Add(46);
                    if (objBingo.G47 == true) lista.Add(47);
                    if (objBingo.G48 == true) lista.Add(48);
                    if (objBingo.G49 == true) lista.Add(49);
                    if (objBingo.G50 == true) lista.Add(50);
                    if (objBingo.G51 == true) lista.Add(51);
                    if (objBingo.G52 == true) lista.Add(52);
                    if (objBingo.G53 == true) lista.Add(53);
                    if (objBingo.G54 == true) lista.Add(54);
                    if (objBingo.G55 == true) lista.Add(55);
                    if (objBingo.G56 == true) lista.Add(56);
                    if (objBingo.G57 == true) lista.Add(57);
                    if (objBingo.G58 == true) lista.Add(58);
                    if (objBingo.G59 == true) lista.Add(59);
                    if (objBingo.G60 == true) lista.Add(60);
                    if (objBingo.O61 == true) lista.Add(61);
                    if (objBingo.O62 == true) lista.Add(62);
                    if (objBingo.O63 == true) lista.Add(63);
                    if (objBingo.O64 == true) lista.Add(64);
                    if (objBingo.O65 == true) lista.Add(65);
                    if (objBingo.O66 == true) lista.Add(66);
                    if (objBingo.O67 == true) lista.Add(67);
                    if (objBingo.O68 == true) lista.Add(68);
                    if (objBingo.O69 == true) lista.Add(69);
                    if (objBingo.O70 == true) lista.Add(70);
                    if (objBingo.O71 == true) lista.Add(71);
                    if (objBingo.O72 == true) lista.Add(72);
                    if (objBingo.O73 == true) lista.Add(73);
                    if (objBingo.O74 == true) lista.Add(74);
                    if (objBingo.O75 == true) lista.Add(75);


                }

                else
                {
                    var objNuevoBingo = new bingoJuego();
                    db.bingoJuego.AddObject(objNuevoBingo);


                }

                db.SaveChanges();


            }


            return lista;
        }



    }
}