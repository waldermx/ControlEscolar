﻿using ControlEscolar.Core.BusinessLogic;
using ControlEscolar.Core.Interfaces;
using ControlEscolar.Infrastructure;
using ControlEscolar.Data;
using Microsoft.EntityFrameworkCore;
using System;
class Program
{
    static void Main(string[] args)
    {
        IBusinessLogic businessLogic = new ApplicationOptions();
            IMenu menu = new ConsoleMenu(businessLogic);
            var mainLoop = new ConsoleMainLoop(menu);

        try
        {
            // Crear una instancia del contexto
            using (var context = new ControlEscolarContext())
            {
                // Validar la conexión a la base de datos
                bool canConnect = context.Database.CanConnect();
                if (canConnect)
                {
                    
                    Console.WriteLine("Conexión a la base de datos establecida correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo conectar a la base de datos.");
                }
            }
        }
        catch (Exception errorMSG)
        {
            Console.WriteLine("Error al conectar a la base de datos: " + errorMSG.Message);
        }

        mainLoop.Run();
    }
}